using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerInteractor interactor;
    public PlayerHealth health;
    public PlayerUi ui;
    public SimpleGun gun;

    public int ammo = 16;

    public int medkit = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(int amm, int kit)
    {
        ammo = ammo + amm;
        medkit = medkit + kit;
        gun.UpdateAmmo();
        ui.SetMedText(medkit);
    }

    public void SetHealth(float health, float maxHealth)
    {
        ui.UpdateHealth(health, maxHealth);
        GetComponent<FirstPersonAIO>().headbobSideMovement = 0.5f +3*(1 - health / maxHealth);
        ui.SetMedText(medkit);
    }
}
