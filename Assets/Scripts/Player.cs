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
    private int m_iGunIndex;
    private int m_iConsecutiveJumps;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

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
    }

    private void Update()
    {
        // Point gun at mouse cursor's position.
        if (!m_bIsAimingWithStick)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 gunToMouse = m_cGuns[m_iGunIndex].transform.position - new Vector3(mousePos.x, mousePos.y, m_cGuns[m_iGunIndex].transform.position.z);
            m_cGuns[m_iGunIndex].transform.up = gunToMouse;
        }
        // Fire gun if player is currently firing automatic.
        if (m_bIsFiringAutomatic)
            FireGun();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsGrounded())
        {
            m_bIsJumping = false;
            m_iConsecutiveJumps = m_iMaxConsecutiveJumps;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AntiTarget>() != null)
        {
            Debug.Log("Level FAILED");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void SetAimType(bool _isAimingWithStick)
    {
        m_bIsAimingWithStick = _isAimingWithStick;
    }

    public void AimWithStick(Vector2 _aimDirection)
    {
        m_cGuns[m_iGunIndex].transform.up = -_aimDirection;
    }

    public void FireGun()
    {
        if (m_cGuns[m_iGunIndex].Fire(-m_cGuns[m_iGunIndex].transform.up))
        {
            m_bIsJumping = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(m_cGuns[m_iGunIndex].transform.up * m_cGuns[m_iGunIndex].m_fShootForce, ForceMode2D.Impulse);
        }
    }

    public void StartFiringAutomatic()
    {
        m_bIsFiringAutomatic = true;
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
        int layerMask = LayerMask.NameToLayer("Player");
        Bounds bounds = cc.bounds;
        Vector2 topLeft = new Vector2(bounds.center.x - bounds.extents.x, bounds.center.y);
        Vector2 bottomRight = new Vector2(bounds.center.x + bounds.extents.x, bounds.center.y - bounds.extents.y);

        foreach (var collider in Physics2D.OverlapAreaAll(topLeft, bottomRight, layerMask))
        {
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
            // Commenting this out in order to display all weapons (whether currently
            // equipped or not) in the HUD.
            //if (i != m_iGunIndex)
            //    gun.EnableHudInfo(false);
            //else
            //    gun.EnableHudInfo(true);
        }
    }

    public void ApplyForce(Vector3 _force)
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(_force, ForceMode2D.Impulse);
    }
}
