using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveComponent : MonoBehaviour
{
    public AudioSource audio;
    public Animator _animator;
    public GameObject listener;
    // Start is called before the first frame update
    
    public void Interact(GameObject instigator)
    {
        _animator.SetTrigger("onOpen");
        if (listener == null) return;
        listener.SendMessage("Interact", this.gameObject, SendMessageOptions.DontRequireReceiver);
    }

    private void OnDrawGizmosSelected()
    {
        if (listener == null) return;
        Gizmos.color = new Color(1f, 0.7f, 0f, 0.5f);
        Gizmos.DrawLine(transform.position, listener.transform.position);
    }
}
