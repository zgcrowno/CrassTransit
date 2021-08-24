using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class RicochetToggle : MonoBehaviour, IPointerClickHandler
{
    private Player m_pPlayer;
    private TextMeshProUGUI m_tOnOffText;

    // Start is called before the first frame update
    void Start()
    {
        m_pPlayer = GameObject.Find("Player").GetComponent<Player>();
        m_tOnOffText = transform.Find("OnOffText").GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_pPlayer.IsFiringRicochets())
        {
            m_pPlayer.SetIsFiringRicochets(false);
            m_tOnOffText.text = "Off";
        }
        else
        {
            m_pPlayer.SetIsFiringRicochets(true);
            m_tOnOffText.text = "On";
        }
    }
}
