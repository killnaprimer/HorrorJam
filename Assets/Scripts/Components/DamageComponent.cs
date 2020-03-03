using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    public bool isActive = true;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isActive)
        {
            other.gameObject.SendMessage("ApplyDamage",1f,SendMessageOptions.DontRequireReceiver);
        }
    }
}
