using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AntiTarget : MonoBehaviour, IShootable
{
    public void GotShot(Vector2 _force, Vector2 _hitPoint)
    {
        Debug.Log("Level FAILED");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
