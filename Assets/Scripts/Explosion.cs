using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public static float M_FLifetime = 0.25f;

    public float m_fForce;
    public float m_fEndOpacity;
    public float m_fEndScale;

    private float m_fRemainingLife;
    private float m_fStartOpacity;
    private float m_fStartScale;
    private SpriteRenderer sr;

    void Start()
    {
        m_fRemainingLife = M_FLifetime;
        sr = GetComponent<SpriteRenderer>();
        m_fStartOpacity = sr.color.a;
        m_fStartScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        m_fRemainingLife -= Time.deltaTime;

        float step = m_fRemainingLife / M_FLifetime;
        Color color = sr.color;
        sr.color = new Color(color.r, color.g, color.b, Mathf.Lerp(m_fEndOpacity, m_fStartOpacity, step));
        transform.localScale = Vector3.Lerp(
            new Vector3(m_fEndScale, m_fEndScale, transform.localScale.z), 
            new Vector3(m_fStartScale, m_fStartScale, transform.localScale.z), 
            step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AntiTarget antiTarget = collision.gameObject.GetComponent<AntiTarget>();
        if (antiTarget != null)
        {
            antiTarget.GotShot();
        }

        Block block = collision.gameObject.GetComponent<Block>();
        if (block != null)
        {
            block.LoseHealth();
        }

        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            gameObject.layer = LayerMask.NameToLayer("IgnorePlayer");
            player.ApplyForce(-collision.contacts[0].normal * m_fForce);
        }
    }
}
