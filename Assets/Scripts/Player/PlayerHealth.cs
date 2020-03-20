using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerManager manager;
    public float health = 100;
    public float maxHealth = 100;

    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        //health = Random.Range(1, 100);
        manager = GetComponent<PlayerManager>();
        manager.SetHealth(health, maxHealth);
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) RestoreHealth();
        
    }

    public void ApplyDamage(float damage)
    {
        health = health - damage;
        manager.SetHealth(health, maxHealth);
        if (health <= 0) levelManager.LoadMenu();
    }

    public void RestoreHealth()
    {
        if (manager.medkit > 0)
        {
            manager.medkit--;
            health = health + 0.5f*maxHealth;
            if (health > maxHealth) health = maxHealth;
            manager.SetHealth(health, maxHealth);
        }
    }
    
    
}
