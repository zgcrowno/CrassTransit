using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Gun : MonoBehaviour
{
    private static float M_FRicochetOffsetMultiplier = 0.01f;

    public bool m_bIsAutomatic;
    public int m_iClipSize;
    public int m_iNumClips;
    public float m_fMaxTimeBetweenShots;
    public float m_fMaxReloadTime;
    public float m_fShotDistance;
    public float m_fShootForce;
    public float m_fShotForce;
    public GameObject rayBulletPrefab;

    private int m_iShotsInClip;
    private float m_fTimeBetweenShots;
    private float m_fReloadTime;
    protected GameObject m_pHudInfo;
    protected GameObject m_pReloadingImage;
    protected GameObject m_pBorderImage;
    protected TextMeshProUGUI m_pShotsInClipText;
    protected TextMeshProUGUI m_pClipSizeText;
    protected TextMeshProUGUI m_pNumClipsText;

    protected AudioManager m_cAudioManager = null;

    protected virtual void Awake()
    {
        m_iShotsInClip = m_iClipSize;
    }

    private void Update()
    {
        if (m_fTimeBetweenShots > 0)
        {
            m_fTimeBetweenShots = Mathf.Clamp(m_fTimeBetweenShots - Time.deltaTime, 0, m_fMaxTimeBetweenShots);
        }
        else if (m_fReloadTime > 0)
        {
            m_fReloadTime = Mathf.Clamp(m_fReloadTime - Time.deltaTime, 0, m_fMaxReloadTime);

            if (m_fReloadTime == 0)
            {
                m_iShotsInClip = m_iClipSize;
                m_iNumClips = m_iNumClips > 0 ? m_iNumClips - 1 : m_iNumClips;
            }
            UpdateHUDInfo();
        }
    }

    public void Reload()
    {
        if (m_iShotsInClip < m_iClipSize && m_iNumClips != 0)
            m_fReloadTime = m_fMaxReloadTime;
    }

    public void SwapOut()
    {
        m_fReloadTime = m_fReloadTime > 0 && m_iShotsInClip == 0 ? m_fMaxReloadTime : 0;
        gameObject.SetActive(false);
    }

    // Returns whether or not the gun was successfully able to fire.
    public bool Fire(Vector2 _fireDirection, bool _ricochet = false)
    {
        if (m_iShotsInClip > 0 && m_fTimeBetweenShots == 0 && m_fReloadTime == 0)
        {
            GunSpecificFire(_fireDirection, _ricochet);

            --m_iShotsInClip;

            UpdateHUDInfo();

            if (m_iShotsInClip > 0)
            {
                m_fTimeBetweenShots = m_fMaxTimeBetweenShots;
            }
            else
            {
                Reload();
            }

            return true;
        }

        return false;
    }

    public void GunshotRaycast(Vector2 _fireDirection, bool _ricochet = false)
    {
        // Ensure that we ignore the player layer (since we're firing from roughly the center thereof).
        int layerMask = ~(1 << LayerMask.NameToLayer("Player"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _fireDirection, m_fShotDistance, layerMask);
        if (hit)
        {
            SpawnRayBullet(transform.position, hit.point);
            CheckForHitObjects(hit, _fireDirection, m_fShotForce);

            if (_ricochet)
            {
                // We have to subtract transformToHitNormalized from hit.point in the raycast below
                // or else the raycast will likely hit the tilemap at the point from which it's firing.
                Vector2 reflectionVec = (_fireDirection - 2 * Vector2.Dot(_fireDirection, hit.normal) * hit.normal).normalized;
                RaycastHit2D ricochetHit = Physics2D.Raycast(hit.point + (reflectionVec * M_FRicochetOffsetMultiplier), reflectionVec, m_fShotDistance, layerMask);
                if (ricochetHit)
                {
                    SpawnRayBullet(hit.point, ricochetHit.point);
                    CheckForHitObjects(ricochetHit, reflectionVec, m_fShotForce);
                }
                else
                {
                    SpawnRayBullet(hit.point, new Vector2(hit.point.x, hit.point.y) + (reflectionVec * 10000));
                }
            }
        }
        else
        {
            SpawnRayBullet(transform.position, new Vector2(transform.position.x, transform.position.y) + (_fireDirection * 10000));
        }
    }

    public void SpawnRayBullet(Vector3 _startPos, Vector3 _endPos)
    {
        RayBullet rb = Instantiate<GameObject>(rayBulletPrefab).GetComponent<RayBullet>();
        rb.SetUp(_startPos, _endPos);
        Destroy(rb.gameObject, RayBullet.M_FLifetime);
    }

    public void EnableHudInfo(bool _enabled)
    {
        m_pHudInfo.SetActive(_enabled);
    }

    public void EnableBorder(bool _enabled)
    {
        m_pBorderImage.SetActive(_enabled);
    }

    public void UpdateHUDInfo()
    {
        if (m_fReloadTime > 0)
            m_pReloadingImage.transform.localScale = new Vector3(m_pReloadingImage.transform.localScale.x, Mathf.Lerp(1, 0, m_fReloadTime / m_fMaxReloadTime), m_pReloadingImage.transform.localScale.z);
        else
            m_pReloadingImage.transform.localScale = new Vector3(m_pReloadingImage.transform.localScale.x, 0, m_pReloadingImage.transform.localScale.z);

        m_pShotsInClipText.text = m_iShotsInClip.ToString();
        m_pClipSizeText.text = m_iClipSize.ToString();
        m_pNumClipsText.text = m_iNumClips < 0 ? m_pNumClipsText.text : m_iNumClips.ToString();
    }

    public void CheckForHitObjects(RaycastHit2D _hit, Vector2 _shotDirection, float _shotForce)
    {
        IShootable shootable = _hit.collider.gameObject.GetComponent<IShootable>();
        if (shootable != null)
            shootable.GotShot(_shotForce * _shotDirection, _hit.point);
    }

    public abstract void GunSpecificFire(Vector2 _fireDirection, bool _ricochet = false);

    protected virtual void PlayShotNoise(string clipName, float startPos = 0f)
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
            
        m_cAudioManager.Play(clipName, startPos);
    }
}
