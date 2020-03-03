using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    public AudioSource audio;
    public AudioClip atk_sound;
    public Animator animator;
    public DamageComponent damage;
    private bool isDead = false;
    public bool mute = false;
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<PlayerManager>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) < 2f && !isDead)
            {
                animator.SetTrigger("onAttack");
                if (!mute)
                {
                    if (!audio.isPlaying && !mute)
                    {
                        audio.Play();
                        audio.clip = atk_sound;
                    }
                    //mute = true;
                }
            }
            agent.SetDestination(target.position);
        }
        else
        {
            //target = FindObjectOfType<PlayerManager>().gameObject.transform;
        }

        
    }

    public void Die()
    {
        agent.isStopped = true;
        if (animator != null)
        {
            animator.SetTrigger("isDead");
            isDead = true;
            damage.isActive = false;
            GameObject.Destroy(this.gameObject,5f);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }
    
}
