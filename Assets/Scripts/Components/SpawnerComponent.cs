using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public GameObject gameObject;
    
    public void Interact(GameObject instigator)
    {
        GameObject.Instantiate(gameObject, transform.position, transform.rotation);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0f, 0.7f, 1f, 0.5f);
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
