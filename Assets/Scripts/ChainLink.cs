using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLink : MonoBehaviour, IShootable
{
    public HingeJoint2D m_pPriorHinge;

    private Rigidbody2D rb;
    private List<HingeJoint2D> m_cHingeJoints = new List<HingeJoint2D>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        foreach (HingeJoint2D hj in GetComponents<HingeJoint2D>())
        {
            m_cHingeJoints.Add(hj);
        }
    }

    public void GotShot(Vector2 _force, Vector2 _hitPoint)
    {
        // Disconnect the hinge joints.
        foreach (HingeJoint2D hj in m_cHingeJoints)
        {
            hj.enabled = false;
        }
        if (m_pPriorHinge != null)
            m_pPriorHinge.enabled = false;
        // Disable the parent's distance joint (so the crate can fall).
        GetComponentInParent<DistanceJoint2D>().enabled = false;
        // Add appropriate force.
        rb.AddForceAtPosition(_force, _hitPoint);
    }
}
