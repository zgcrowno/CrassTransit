using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right* speed;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    public IEnumerator destroy()
    {

        yield return new WaitForSeconds(4);

        gameObject.SetActive (false);
    }
}
