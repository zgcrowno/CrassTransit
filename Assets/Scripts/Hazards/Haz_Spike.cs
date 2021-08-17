using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haz_Spike : Hazard_Base
{
    protected override void KillPlayer()
    {
        base.KillPlayer();
        Object.FindObjectOfType<AudioManager>().Play("Waaaa", 0.25f);
    }
}
