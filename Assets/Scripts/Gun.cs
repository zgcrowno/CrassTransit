using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public bool m_bIsAutomatic;
    public int m_iClipSize;
    public float m_fMaxTimeBetweenShots;
    public float m_fMaxReloadTime;
    public float m_fShotDistance;
    public float m_fShootForce;

    private int m_iShotsInClip;
    private float m_fTimeBetweenShots;
    private float m_fReloadTime;

    private void Start()
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
            }
        }
    }

    public void Reload()
    {
        if (m_iShotsInClip < m_iClipSize)
            m_fReloadTime = m_fMaxReloadTime;
    }

    public void SwapOut()
    {
        m_fReloadTime = m_fReloadTime > 0 ? m_fMaxReloadTime : 0;
        gameObject.SetActive(false);
    }

    // Returns whether or not the gun was successfully able to fire.
    public bool Fire(Vector2 _fireDirection)
    {
        if (m_iShotsInClip > 0 && m_fTimeBetweenShots == 0 && m_fReloadTime == 0)
        {
            GunSpecificFire(_fireDirection);

            --m_iShotsInClip;

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

    public abstract void GunSpecificFire(Vector2 _fireDirection);
}
