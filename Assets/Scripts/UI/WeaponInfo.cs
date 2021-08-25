using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponInfo : MonoBehaviour, IPointerClickHandler
{
    public int m_iWeaponIndex;

    private Player m_pPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_pPlayer = GameObject.Find("Player").GetComponent<Player>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_iWeaponIndex == m_pPlayer.GetGunIndex())
            m_pPlayer.Reload();
        else
            m_pPlayer.EquipGunAtIndex(m_iWeaponIndex);
    }
}
