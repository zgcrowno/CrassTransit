using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool m_bUpdateTime;
    private float m_fTimeAtStart;
    public float m_fTimeSoFar { get; private set; }
    private TextMeshProUGUI m_pTimerText;

    // Start is called before the first frame update
    void Start()
    {
        m_bUpdateTime = true;
        m_fTimeAtStart = Time.time;
        m_pTimerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bUpdateTime)
        {
            m_fTimeSoFar = Time.time - m_fTimeAtStart;

            if (m_fTimeSoFar > 999.999f)
            {
                m_bUpdateTime = false;
                m_fTimeSoFar = 999.999f;
                m_pTimerText.text = ">999.9";
            }
            else
                m_pTimerText.text = string.Format("{0:#0.0}", m_fTimeSoFar);
        }
    }
}
