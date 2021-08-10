using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RocketLauncher : Gun
{
    public GameObject rocketPrefab;

    protected override void Awake()
    {
        base.Awake();

        m_pHudInfo = GameObject.Find("RocketLauncherInfo");
        m_pReloadingImage = m_pHudInfo.transform.Find("ReloadingImage").gameObject;
        m_pShotsInClipText = m_pHudInfo.transform.Find("ShotsInClip").GetComponent<TextMeshProUGUI>();
        m_pClipSizeText = m_pHudInfo.transform.Find("ClipSize").GetComponent<TextMeshProUGUI>();
        m_pNumClipsText = m_pHudInfo.transform.Find("NumClips").GetComponent<TextMeshProUGUI>();
    }

    public override void GunSpecificFire(Vector2 _fireDirection)
    {
        Rocket rocket = Instantiate<GameObject>(rocketPrefab).GetComponent<Rocket>();
        rocket.transform.position = transform.position;
        rocket.FireInDirection(_fireDirection);
    }
}
