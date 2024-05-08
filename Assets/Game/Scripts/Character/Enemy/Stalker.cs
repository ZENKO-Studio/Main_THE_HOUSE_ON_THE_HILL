using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(StalkerFSM))]
public class Stalker : EnemyBase
{

    Transform playerTransform;
    
    StalkerFSM fsm;
    SteeringAgent steeringAgent;

    public bool bPlayerInsight = false;

    protected override void Start()
    {
        
    }

    //Checks continuosly
    void CheckForPlayer()
    {
        if (!bPlayerInsight) return;

        if (fsm.currentState == StalkerFSM.PatrolState || fsm.currentState == StalkerFSM.InvestigateState)
            fsm.ChangeState(StalkerFSM.ChasePlayerState);
    }
}
