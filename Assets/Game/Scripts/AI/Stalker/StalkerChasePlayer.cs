using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerChasePlayer : StalkerBaseState
{
    public float AngularDampeningTime = 5.0f;
    public float DeadZone = 10.0f;

    Vector3 lastPlayerPos;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(stalkerRef.playerTransform.position);
        lastPlayerPos = stalkerRef.playerTransform.position;   
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!stalkerRef.bPlayerInsight)
        {
            //Change State to Investigate
            return;
        }

        //Recalculate Navmesh Path if player moved by certain distance
        if(Vector3.Distance(lastPlayerPos, agent.transform.position) > 2f)
        {
            agent.SetDestination(stalkerRef.playerTransform.position);
            lastPlayerPos = stalkerRef.playerTransform.position;
        }

        //#TODO: Maybe move this movement thing into Enemy Controller and Just Handle Destination Changes from here?
        //Actually Move the player
        if (agent.desiredVelocity != Vector3.zero)
        {

            float speed = Vector3.Project(agent.desiredVelocity, stalkerTransform.forward).magnitude * agent.speed;

            Vector3 nextPos = stalkerTransform.position + (stalkerTransform.forward * speed * Time.deltaTime);

            //stalkerTransform.position = nextPos;

            agent.velocity = (nextPos - agent.transform.position) / Time.deltaTime;

            float angle = Vector3.Angle(stalkerTransform.forward, agent.desiredVelocity);

            if (Mathf.Abs(angle) <= DeadZone)
            {
                stalkerTransform.LookAt(stalkerTransform.position + agent.desiredVelocity);
            }
            else
            {
                stalkerTransform.rotation = Quaternion.Lerp(stalkerTransform.rotation,
                                                     Quaternion.LookRotation(agent.desiredVelocity),
                                                     Time.deltaTime * AngularDampeningTime);
            }
        }
        
        if(Vector3.Distance(stalkerTransform.position, agent.destination) < 2f) //#TODO: Change it to attack Range of Stalker
        {
            //Change State to Attack
            fsm.ChangeState(StalkerFSM.AttackState);
        }
    }

}
