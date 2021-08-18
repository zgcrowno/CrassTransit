using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IShootable
{
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GotShot(Vector2 _force, Vector2 _hitPoint)
    {
        rb.AddForceAtPosition(_force, _hitPoint);
    }
}
