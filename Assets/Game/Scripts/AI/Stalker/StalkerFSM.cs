using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerFSM : FSM
{
    static public readonly int PatrolState = Animator.StringToHash("Patrol");
    static public readonly int ChasePlayerState = Animator.StringToHash("ChasePlayer");
    static public readonly int AttackState = Animator.StringToHash("Attack");
    static public readonly int InvestigateState = Animator.StringToHash("Investigate");


}
