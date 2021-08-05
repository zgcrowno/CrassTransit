using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static Vector2 RotateVectorByDegrees(Vector2 _vec, float _angleInDegrees)
    {
        float rad = _angleInDegrees * Mathf.Deg2Rad;
        float s = Mathf.Sin(rad);
        float c = Mathf.Cos(rad);
        return new Vector2(_vec.x * c - _vec.y * s, _vec.y * c + _vec.x * s);
    }
}
