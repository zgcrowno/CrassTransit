using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject part;
    public int Health;
    Animator anim;
    public AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            anim.SetBool("Go", true);
        }
    }
    public void LoseHealth()
    {

        Health--;

    }
    public void DestroyBlock()
    {
        gameObject.SetActive(false);
    }
    public void Sound()
    {
        sound.Play();
    }
    public void Particle()
    {
        part.SetActive(true);
    }

}
