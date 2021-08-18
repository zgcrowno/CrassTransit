using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    public void GotShot(Vector2 _force, Vector2 _hitPoint);
}
