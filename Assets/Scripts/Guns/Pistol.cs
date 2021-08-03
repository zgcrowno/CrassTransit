using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
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
        }
        else
        {
            Debug.DrawRay(transform.position, new Vector2(transform.position.x, transform.position.y) + (_fireDirection * 10000), Color.red, 0.25f);
        }
    }
}
