using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Hazard_Base : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KillPlayer();
        }
    }

    protected virtual void KillPlayer()
    {
        Debug.Log("Don't touch the spikes!");
        EndCondition.Lose(this);
    }
}
