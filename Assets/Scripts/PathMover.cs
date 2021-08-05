using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is for moving game objects around on a set path
/// </summary>
public class PathMover : MonoBehaviour
{
    [Tooltip("How many units should this object move per second?")]
    public float moveSpeed = 1f;
    [Tooltip("These are the nodes on the path that this game object should follow. Must be at least 2.")]
    public Vector3[] pathNodes = new Vector3[2];

    private readonly float reachedNodeCutoff = 0.05f;

    private int curIDX = 0;
    private int nextIDX = 1;
    private Vector3 curDirection;

    void Awake()
    {
        transform.position = pathNodes[curIDX];
        curDirection = (pathNodes[nextIDX] - pathNodes[curIDX]).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if (Distance(transform.position, pathNodes[nextIDX]) <= reachedNodeCutoff)
        {
            incrementIDX();
            transform.position = pathNodes[curIDX];
            curDirection = (pathNodes[nextIDX] - pathNodes[curIDX]).normalized;
        }

        transform.position += curDirection * moveSpeed * Time.deltaTime;
    }

    private float Distance(Vector3 A, Vector3 B)
    {
        return (A - B).magnitude;
    }

    private void incrementIDX()
    {
        curIDX++;
        if (curIDX >= pathNodes.Length)
        {
            curIDX = 0;
        }

        nextIDX++;
        if (nextIDX >= pathNodes.Length)
        {
            nextIDX = 0;
        }
    }
}
