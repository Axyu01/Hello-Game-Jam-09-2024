using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntityBase : EntityBase
{
    public Rigidbody2D Rigidbody;
    protected new void Start()
    {
        base.Start();
    }
}
