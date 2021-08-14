using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AntiTarget : MonoBehaviour
{
    public void GotShot()
    {
        Debug.Log("Level FAILED");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
