using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float m_fMoveSpeed;
    public float m_fShotForce;
    public GameObject explosionPrefab;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IShootable shootable = collision.gameObject.GetComponent<IShootable>();
        if (shootable != null)
            shootable.GotShot(rb.velocity.normalized * m_fShotForce, collision.contacts[0].point);

        GameObject explosion = Instantiate<GameObject>(explosionPrefab);
        explosion.transform.position = transform.position;
        Destroy(explosion, Explosion.M_FLifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AntiTarget antiTarget = collision.gameObject.GetComponent<AntiTarget>();
        if (antiTarget != null)
        {
            antiTarget.GotShot(Vector2.zero, Vector2.zero);
        }
    }

    public void FireInDirection(Vector2 _direction)
    {
        transform.up = -_direction;
        rb.velocity = _direction * m_fMoveSpeed;
    }
}
