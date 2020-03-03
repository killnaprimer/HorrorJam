using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalComponent : MonoBehaviour
{
    public AudioSource audioSource;
    public bool makeKinematicFirst;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (makeKinematicFirst) this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void OnCollisionEnter(Collision collision){
       if (collision.relativeVelocity.magnitude > 1.5) audioSource.Play();
       if (collision.other.CompareTag("Enemy"))audioSource.Play();
    }
    
    public void Interact(GameObject instigator)
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
