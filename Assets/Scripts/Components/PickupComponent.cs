using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupComponent : MonoBehaviour
{
    public int ammo = 16;
    public int kit = 0; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject player)
    {
       player.GetComponent<PlayerManager>().AddItem(ammo, kit);
       Destroy(this.gameObject);
    }
}
