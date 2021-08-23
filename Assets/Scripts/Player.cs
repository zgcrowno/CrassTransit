using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool m_bRegularMovementAllowed;
    public int m_iMaxConsecutiveJumps;
    public float m_fMoveSpeed;
    public float m_fJumpForce;
    public List<Gun> m_cGuns;

    private bool m_bIsJumping;
    private bool m_bIsAimingWithStick;
    private bool m_bIsFiringAutomatic;
    private bool m_bIsFiringRicochets;
    private int m_iGunIndex;
    private int m_iConsecutiveJumps;
    private InputType m_eInputType;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

    private AudioManager m_cAudioManager;
    private string[] HeroLevelStartSayings = new string[2] {
        "BestWay",
        "GetThroughThis"
    };

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        m_iConsecutiveJumps = m_iMaxConsecutiveJumps;

        // Disable guns as appropriate.
        for (int i = 0; i < m_cGuns.Count; ++i)
        {
            if (i != m_iGunIndex)
                m_cGuns[i].gameObject.SetActive(false);
        }

        // Update the HUD.
        UpdateHUDInfo();

        //Say an encouraging line
        EnsureAudioManagerExists();
        m_cAudioManager.Play(HeroLevelStartSayings[Random.Range(0, HeroLevelStartSayings.Length)]);
    }

    private void Update()
    {
        if (m_eInputType == InputType.mkb)
            PointGun();
        // Fire gun if player is currently firing automatic.
        if (m_bIsFiringAutomatic)
        {
            FireGun(m_bIsFiringRicochets);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGrounded())
        {
            m_bIsJumping = false;
            m_iConsecutiveJumps = m_iMaxConsecutiveJumps;

            //Play landing noise
            EnsureAudioManagerExists();
            m_cAudioManager.Play("Landing", 0.2f);
        }
        if( collision.gameObject.tag == ("Platform"))
        {

            this.transform.parent = collision.transform;

        }
    }
     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Platform"))
        {

            this.transform.parent = null;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AntiTarget>() != null)
        {
            Debug.Log("Level FAILED");
            if (m_cAudioManager == null)
            {
                try
                {
                    m_cAudioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
                }
                catch (System.NullReferenceException)
                {
                    Debug.LogError("The Gun: " + this.name + " tried to find the AudioManager but couldn't find the AudioManager in the scene. Either start from the MainMenu or add the AudioManager prefab to this scene.");
                    throw;
                }
            }

            m_cAudioManager.Play("FrogRibbit", 0.5f);

            EndCondition.Lose(this);
        }
    }

    public void Move(float _horizontalMovementMultiplier)
    {
        rb.velocity = new Vector2(m_fMoveSpeed * _horizontalMovementMultiplier * Time.deltaTime, rb.velocity.y);
    }

    public void Jump()
    {
        if (m_iConsecutiveJumps > 0)
        {
            m_bIsJumping = true;
            --m_iConsecutiveJumps;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * m_fJumpForce, ForceMode2D.Impulse);
        }
    }

    public void SetInputType(InputType _inputType)
    {
        m_eInputType = _inputType;
    }

    public void AimWithStick(Vector2 _aimDirection)
    {
        // TODO: Hard coding this since the rocket launcher has a different point from which it fires.
        if (m_iGunIndex == 3)
            m_cGuns[m_iGunIndex].transform.up = -_aimDirection;
        else
            m_cGuns[m_iGunIndex].transform.right = -_aimDirection;
    }

    public void FireGun(bool _ricochet = false)
    {
        // TODO: Hard coding this since the rocket launcher has a different point from which it fires.
        Vector3 directionToFireFrom = m_iGunIndex == 3 ? -m_cGuns[m_iGunIndex].transform.up : m_cGuns[m_iGunIndex].transform.right;

        if (m_cGuns[m_iGunIndex].Fire(directionToFireFrom, _ricochet))
        {
            m_bIsJumping = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(-directionToFireFrom * m_cGuns[m_iGunIndex].m_fShootForce, ForceMode2D.Impulse);
        }
    }

    public void StartFiringAutomatic(bool _ricochet = false)
    {
        m_bIsFiringAutomatic = true;
        m_bIsFiringRicochets = _ricochet;
    }

    public void StopFiringAutomatic()
    {
        m_bIsFiringAutomatic = false;
    }

    public void ScrollThroughGuns(float _indexModifier)
    {
        int newGunIndex;

        if (_indexModifier > 0)
            newGunIndex = m_iGunIndex == m_cGuns.Count - 1 ? 0 : m_iGunIndex + 1;
        else
            newGunIndex = m_iGunIndex == 0 ? m_cGuns.Count - 1 : m_iGunIndex - 1;

        EquipGunAtIndex(newGunIndex);

        if (!IsWieldingAutomatic())
            m_bIsFiringAutomatic = false;
    }

    public void EquipGunAtIndex(int _index)
    {
        Gun gunFrom = m_cGuns[m_iGunIndex];
        gunFrom.SwapOut();

        m_iGunIndex = _index;

        m_cGuns[m_iGunIndex].gameObject.SetActive(true);
        UpdateHUDInfo();
    }

    public void Reload()
    {
        m_cGuns[m_iGunIndex].Reload();
    }

    public bool IsJumping()
    {
        return m_bIsJumping;
    }

    public bool IsWieldingAutomatic()
    {
        return m_cGuns[m_iGunIndex].m_bIsAutomatic;
    }

    public bool IsGrounded()
    {
        int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        Bounds bounds = cc.bounds;
        Vector2 topLeft = new Vector2(bounds.center.x - bounds.extents.x + 0.1f, bounds.center.y);
        Vector2 bottomRight = new Vector2(bounds.center.x + bounds.extents.x - 0.1f, bounds.center.y - bounds.extents.y);

        foreach (var collider in Physics2D.OverlapAreaAll(topLeft, bottomRight, layerMask))
        {
            Debug.Log("IsGrounded() detected: " + collider.name);
            if (!collider.isTrigger)
            {
                return true;
            }
        }
        return false;
    }

    public void UpdateHUDInfo()
    {
        for (int i = 0; i < m_cGuns.Count; ++i)
        {
            Gun gun = m_cGuns[i];
            gun.UpdateHUDInfo();
            gun.EnableBorder(i == m_iGunIndex);
        }
    }

    public void ApplyForce(Vector3 _force)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(_force, ForceMode2D.Impulse);
    }

    public void PointGun()
    {
        // Point gun at mouse cursor's position.
        Vector3 mousePos = Input.touchCount > 0 ? Camera.main.ScreenToWorldPoint(Input.touches[0].position) : Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 gunToMouse = m_cGuns[m_iGunIndex].transform.position - new Vector3(mousePos.x, mousePos.y, m_cGuns[m_iGunIndex].transform.position.z);
        // TODO: Hard coding this since the rocket launcher has a different point from which it fires.
        if (m_iGunIndex == 3)
        {
            m_cGuns[m_iGunIndex].FlipSpriteX(gunToMouse.x > 0);
            m_cGuns[m_iGunIndex].transform.up = gunToMouse;
        }
        else
        {
            m_cGuns[m_iGunIndex].FlipSpriteY(gunToMouse.x > 0);
            m_cGuns[m_iGunIndex].transform.right = -gunToMouse;
        }
    }

    private void EnsureAudioManagerExists()
    {
        if (m_cAudioManager == null)
        {
            try
            {
                m_cAudioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
            }
            catch (System.NullReferenceException)
            {
                Debug.LogError("The Gun: " + this.name + " tried to find the AudioManager but couldn't find the AudioManager in the scene. Either start from the MainMenu or add the AudioManager prefab to this scene.");
                throw;
            }
        }
    }
}
