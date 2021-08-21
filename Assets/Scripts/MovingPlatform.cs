using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    public float dirx;
    public float startspot;
    [SerializeField]
    public float movespeed = 3f;
    [SerializeField]
    public float moved;
   public bool mover = true;

    // Start is called before the first frame update
    void Start()
    {

        startspot = this.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (dirx >= moved + startspot)
            mover = false;
        if (dirx <= -moved+startspot)
            mover = true;
        dirx = this.transform.position.x;
        if (mover==true)
            this.transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
        else if (mover == false)
            this.transform.position = new Vector2(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
    }
}
