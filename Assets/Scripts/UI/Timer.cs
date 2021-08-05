using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float m_fTimeAtStart;
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
        m_pTimerText.text = string.Format("{0:#0.000}", (Time.time - m_fTimeAtStart));
    }
}
