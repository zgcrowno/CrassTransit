using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public Vector2 followOffset;
    public float speed = 3;
    private Vector2 threshold;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        threshold = calculat();
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 follow = player.transform.position;
        float xDiff = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDiff = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);
        Vector3 newposition = transform.position;
        if (Mathf.Abs(xDiff) >= threshold.x)
        {

            newposition.x = follow.x;

        }
        if (Mathf.Abs(yDiff) >= threshold.y)
        {

            newposition.y = follow.y;

        }
        //float movespeed = rb.velocity.magnitude > speed ? rb.velocity.magnitude : speed;
        float movespeed = rb.velocity.magnitude;
        //transform.position = Vector3.MoveTowards(transform.position, newposition, movespeed * Time.deltaTime);
        transform.position += (newposition - transform.position).normalized * movespeed * Time.deltaTime;
    }
    
    private Vector3 calculat()
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculat();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }
}
