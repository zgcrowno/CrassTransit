using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AntiTarget : MonoBehaviour
{
    public void GotShot()
    {
        //Play croaking noise
        FindObjectOfType<AudioManager>().Play("FrogRibbit", 0.5f);

        Debug.Log("Level FAILED");
        EndCondition.Lose(this);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
