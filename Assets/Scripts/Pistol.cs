using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : Gun
{
    protected override void Awake()
    {
        base.Awake();

        m_pHudInfo = GameObject.Find("PistolInfo");
        m_pReloadingImage = GameObject.Find("HUD").transform.Find("ReloadingImage").gameObject;
        m_pShotsInClipText = m_pHudInfo.transform.Find("ShotsInClip").GetComponent<TextMeshProUGUI>();
        m_pClipSizeText = m_pHudInfo.transform.Find("ClipSize").GetComponent<TextMeshProUGUI>();
        m_pNumClipsText = m_pHudInfo.transform.Find("NumClips").GetComponent<TextMeshProUGUI>();
    }

    public override void GunSpecificFire(Vector2 _fireDirection)
    {
        int layerMask = LayerMask.NameToLayer("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _fireDirection, m_fShotDistance, layerMask);
        if (hit)
        {
            Debug.DrawRay(transform.position, hit.point - new Vector2(transform.position.x, transform.position.y), Color.red, 0.25f);
            AntiTarget antiTarget = hit.collider.gameObject.GetComponent<AntiTarget>();
            if (antiTarget != null)
            {
                antiTarget.GotShot();
            }
            Block block = hit.collider.gameObject.GetComponent<Block>();
            if(block != null)
            {

                block.LoseHealth();

            }
        }
        else
        {
            Debug.DrawRay(transform.position, new Vector2(transform.position.x, transform.position.y) + (_fireDirection * 10000), Color.red, 0.25f);
        }
    }
}
