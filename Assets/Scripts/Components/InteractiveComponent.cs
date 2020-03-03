using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveComponent : MonoBehaviour
{
    public AudioSource audio;
    // Start is called before the first frame update

    public void PlaySound()
    {
        if (audio != null)
        {
            audio.Play();
        }
    }
    
    public void Interact(GameObject instigator)
    {
        GetComponent<Animator>().SetTrigger("onOpen");
    }
}
