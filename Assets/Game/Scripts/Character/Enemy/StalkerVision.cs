using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerVision : MonoBehaviour
{
    Stalker stalker;

    private void Start()
    {
        stalker = GetComponentInParent<Stalker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            stalker.bPlayerInsight = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            stalker.bPlayerInsight = false;
    }
}
