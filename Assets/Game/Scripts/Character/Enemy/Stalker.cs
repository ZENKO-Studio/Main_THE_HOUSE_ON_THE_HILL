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

    [SerializeField]
    public List<Transform> patrolPoints = new List<Transform>();

    int currIndex = 0;

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

    public Transform GetNextWaypoint()
    {
        if(currIndex == patrolPoints.Count)
        {
            currIndex = 0;
            RandomizePatrolPoints();
        }

        return patrolPoints[currIndex++];
    }

    void RandomizePatrolPoints()
    {
        for (int i = 0; i < patrolPoints.Count-1; i++)
        {
            Transform temp = patrolPoints[i];
            int randomIndex = Random.Range(i + 1, patrolPoints.Count - 1);
            patrolPoints[i] = patrolPoints[randomIndex];
            patrolPoints[randomIndex] = temp;
        }
    }
}
