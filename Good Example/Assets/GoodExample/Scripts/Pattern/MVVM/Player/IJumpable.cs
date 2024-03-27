using System;
using UnityEngine;

public interface IJumpable
{
    public event Action Jumped;
    public void Jump();
    public bool CheckGround(Transform transform);
}
