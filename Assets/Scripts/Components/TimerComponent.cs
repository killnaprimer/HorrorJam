using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerComponent : MonoBehaviour
{
    public GameObject listener;
    public float delay;
    
    public void Interact(GameObject instigator)
    {
        StartCoroutine(InteractOnDelay());
    }
    
    IEnumerator InteractOnDelay()
    {
        yield return new WaitForSeconds(delay);
        listener.SendMessage("Interact", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }
    
    private void OnDrawGizmosSelected()
    {
        if (listener == null) return;
        Gizmos.color = new Color(1f, 0.7f, 0f, 0.5f);
        Gizmos.DrawLine(transform.position, listener.transform.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "timer",true);
    }
}
