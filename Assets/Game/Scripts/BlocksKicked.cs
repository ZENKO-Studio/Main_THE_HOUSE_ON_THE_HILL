using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksKicked : MonoBehaviour
{

    public Rigidbody blockRigidbody;
    public AudioSource audio;

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Block")) // Make sure your blocks have the tag "Block"
        {
             blockRigidbody = other.GetComponent<Rigidbody>();
            if (blockRigidbody != null)
            {
                // Apply force to simulate the kick
                blockRigidbody.AddForce(transform.forward * 500); // Adjust force as necessary




                 audio = other.GetComponent<AudioSource>();
                if (audio != null)
                {
                    audio.Play();

                    anim = other.GetComponent<Animator>();
                
                    
                        anim.SetTrigger("Kick");

                  

                }
            }
        }
    }





}
