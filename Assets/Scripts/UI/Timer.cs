using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float m_fTimeAtStart;
    public float m_fTimeSoFar { get; private set; }
    private TextMeshProUGUI m_pTimerText;

    // Start is called before the first frame update
    void Start()
    {
        m_fTimeAtStart = Time.time;
        m_pTimerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        m_fTimeSoFar = Time.time - m_fTimeAtStart;
        m_pTimerText.text = string.Format("{0:#0.000}", m_fTimeSoFar);
    }
}
