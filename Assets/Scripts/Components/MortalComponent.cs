using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalComponent : MonoBehaviour
{
    public float health = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage(float damage)
    {
        health = health - damage;
        if (health<=0) Die();
        print("DAMAGED!");
    }

    public void Die()
    {
        if (GetComponent<SimpleEnemy>())
        {
            GetComponent<SimpleEnemy>().Die();
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }
}
