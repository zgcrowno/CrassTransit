using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shotgun : Gun
{
    public int m_iNumShotsFired;
    public float m_fShotAngleIncrement;

    protected override void Awake()
    {
        base.Awake();

        m_pHudInfo = GameObject.Find("ShotgunInfo");
        m_pReloadingImage = m_pHudInfo.transform.Find("ReloadingImage").gameObject;
        m_pBorderImage = m_pHudInfo.transform.Find("Border").gameObject;
        m_pShotsInClipText = m_pHudInfo.transform.Find("ShotsInClip").GetComponent<TextMeshProUGUI>();
        m_pClipSizeText = m_pHudInfo.transform.Find("ClipSize").GetComponent<TextMeshProUGUI>();
        m_pNumClipsText = m_pHudInfo.transform.Find("NumClips").GetComponent<TextMeshProUGUI>();
    }

    public override void GunSpecificFire(Vector2 _fireDirection, bool _ricochet = false)
    {
        Vector2 startingDirection = Util.RotateVectorByDegrees(_fireDirection, -((m_iNumShotsFired / 2) * m_fShotAngleIncrement));

        for (int i = 0; i < m_iNumShotsFired; ++i)
        {
            GunshotRaycast(Util.RotateVectorByDegrees(startingDirection, i * m_fShotAngleIncrement), _ricochet);
        }

        PlayShotNoise("ShotgunShot");
    }
}
