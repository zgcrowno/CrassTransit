using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletL : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
        StartCoroutine("destroy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("Level FAILED");
            EndCondition.Lose(this);
        }
        if (collision.tag == ("Wall"))
        {

            gameObject.SetActive(false);
        }

    }
    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(.75f);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
