using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float m_fMoveSpeed;
    public GameObject explosionPrefab;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AntiTarget antiTarget = collision.gameObject.GetComponent<AntiTarget>();
        if (antiTarget != null)
        {
            antiTarget.GotShot();
        }
        else
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if (block != null)
            {
                block.LoseHealth();
            }
        }

        GameObject explosion = Instantiate<GameObject>(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(explosion, Explosion.M_FLifetime);
        Destroy(gameObject);
    }

    public void FireInDirection(Vector2 _direction)
    {
        transform.up = -_direction;
        rb.velocity = _direction * m_fMoveSpeed;
    }
}
