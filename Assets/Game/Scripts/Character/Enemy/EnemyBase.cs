using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : CharacterBase
{
    public Transform playerTransform;
    
    [SerializeField]
    public float attackRange;
    
    [SerializeField]
    public float damageToDeal;
    
    [SerializeField]
    public float damageMultiplier;

    [SerializeField]
    public float attackFrequency;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public virtual void Attack() { }

    //#TODO: Remove? Decide Later
    ////Common function for enemies to move (Velocity will be calculated and passed and this will move the enemy)
    //public virtual void Move(float speed, Quaternion rot)
    //{
    //    transform.position += (transform.forward * speed);
    //    transform.rotation = rot;
    //}

   
}
