using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(StalkerFSM))]
public class Stalker : EnemyBase
{

    StalkerFSM fsm;
    NavMeshAgent stalkerAgent;

    public bool bPlayerInsight = false;

    protected override void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
        stalkerAgent.stoppingDistance = attackRange;
    }

    //Checks continuosly
    void CheckForPlayer()
    {
        if (!bPlayerInsight) return;

        if (fsm.currentState == StalkerFSM.PatrolState || fsm.currentState == StalkerFSM.InvestigateState)
            fsm.ChangeState(StalkerFSM.ChasePlayerState);
    }

    public override void Attack()
    {
        if(playerTransform != null) 
        {
            //#TODO: Check if stalker is in FOV of player and adjust the damage multiplier

            PlayerCharacter playerRef = playerTransform.GetComponent<PlayerCharacter>();
            if (playerRef != null)
            {
                playerRef.TakeDamage(damageToDeal * damageMultiplier);
            }
        }


        //Do all the visuals 
    }
}
