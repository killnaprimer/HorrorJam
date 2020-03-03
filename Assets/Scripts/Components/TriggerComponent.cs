using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    [Header("Old Stuff")]
    public AudioSource sound;
    
    [Header("Regularity")]
    public float cooldown;
    public bool isReusable = false;
    float nextUseTime = 0f;
    
    [Header("Dependencies")]
    public GameObject[] listeners;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && nextUseTime < Time.time)
        {
            for (int i = 0; i < listeners.Length; i++)
            {
                listeners[i].SendMessage("Interact", this.gameObject, SendMessageOptions.DontRequireReceiver);
            }
            if (!isReusable) this.GetComponent<Collider>().enabled = false;
            nextUseTime = Time.time + cooldown;
        }
    }
    
    void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1f, 0.7f, 0f, 0.5f);
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void OnDrawGizmosSelected()
    {
        if (listeners == null) return;
        for (int i = 0; i < listeners.Length; i++)
        {
            Gizmos.color = new Color(1f, 0.7f, 0f, 0.5f);
            Gizmos.DrawLine(transform.position, listeners[i].transform.position);
        }
    }
}
