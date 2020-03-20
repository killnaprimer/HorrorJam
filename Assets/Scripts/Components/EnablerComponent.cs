using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablerComponent : MonoBehaviour
{
    [Header("Preferences")] 
    public bool StartState;
    public GameObject listener;
    
    private void OnDrawGizmosSelected()
    {
        if (listener == null) return;
        Gizmos.color = new Color(1f, 0.7f, 0f, 0.5f);
        Gizmos.DrawLine(transform.position, listener.transform.position);
    }

    private void Start()
    {
        listener.SetActive(StartState);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "switch-on",true);
    }

    public void Interact(GameObject instigator)
    {
        listener.SetActive(!listener.activeSelf);
    }
}
