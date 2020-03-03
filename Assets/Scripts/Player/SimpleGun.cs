using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : MonoBehaviour
{
    public GameObject blood;

    public GameObject dust;
    //Shooting
    public float damage = 10f;
    public float range = 100f;
    private bool shotDelay = false;
    
    //Reloading
    public int maxAmmo = 16;
    private int currAmmo = 16;
    private bool isReloading = false;
    public int ammo = 40;
    
    //Dependencies
    public Camera fpsCam;
    public ParticleSystem muzzle;
    public AudioSource audio;
    private Animator _animator;

    public PlayerUi _ui;

    public PlayerManager manager;
    // Update is called once per frame
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isReloading)
        {
            TryShooot();
        }

        if (Input.GetKeyDown(KeyCode.R) && currAmmo < maxAmmo)
        {
            Reload();
        }
    }

    //Shooting Methods
    void TryShooot()
    {
        if (currAmmo > 0)
        {
            Shoot();
        }
        else
        {
            Reload();
        }
    }

    void Shoot()
        {
            if (shotDelay) return;
            shotDelay = true;
            audio.Play();
            muzzle.Play();
            _animator.SetTrigger("onFire");
            
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
               hit.transform.gameObject.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
               if (hit.transform.CompareTag("Enemy"))
               {
                   GameObject.Instantiate(blood, hit.point, Quaternion.identity);
               }
               else
               {
                   GameObject.Instantiate(dust, hit.point, Quaternion.identity);
               }
            }
        }
    
    public void EndShot()
        {
            shotDelay = false;
            currAmmo--;
            UpdateAmmo();
        }
    
    //Rekiading Methods
    void Reload()
    {
        if (isReloading) return;
        isReloading = true;
        shotDelay = false;
        _animator.SetTrigger("onReload");
    }
    
    public void EndReload()
         {
             isReloading = false;
             //currAmmo = maxAmmo;

             if (manager.ammo >= maxAmmo-currAmmo)
             {
                 manager.ammo = manager.ammo - maxAmmo+currAmmo;
                 currAmmo = maxAmmo;
                 
             }
             else
             {
                 currAmmo = manager.ammo;
                 manager.ammo = 0;
             }
             
             UpdateAmmo();
             
             
         }

    public void UpdateAmmo()
    {
        _ui.SetAmmoText(currAmmo,manager.ammo);
    }
    

    
}
