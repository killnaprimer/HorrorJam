using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInteractor interactor;
    public PlayerHealth health;
    public PlayerUi ui;
    public SimpleGun gun;

    public int ammo = 12;
    public int quest = 0;
    public int medkit = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(int amm, int kit, int filter)
    {
        ammo = ammo + amm;
        medkit = medkit + kit;
        gun.UpdateAmmo();
        ui.SetMedText(medkit);
        quest = quest + filter;
        ui.UpdateQuest(quest);
    }

    public void SetHealth(float health, float maxHealth)
    {
        ui.UpdateHealth(health, maxHealth);
        GetComponent<FirstPersonAIO>().headbobSideMovement = 0.5f +3*(1 - health / maxHealth);
        ui.SetMedText(medkit);
    }
}
