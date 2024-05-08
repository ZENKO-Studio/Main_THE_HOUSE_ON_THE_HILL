using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{
    public Transform playerTransform;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    //#TODO: Remove? Decide Later
    ////Common function for enemies to move (Velocity will be calculated and passed and this will move the enemy)
    //public virtual void Move(float speed, Quaternion rot)
    //{
    //    transform.position += (transform.forward * speed);
    //    transform.rotation = rot;
    //}

   
}
