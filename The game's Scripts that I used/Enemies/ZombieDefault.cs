using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieDefault : MonoBehaviour
{
    protected NavMeshAgent navMeshAgent;
    protected Animator animator;
    

    [Header("PowerUp Links")]
    [SerializeField] protected PowerUp twinShot;
    [SerializeField] protected PowerUp triShot;
    [SerializeField] protected float chanceToSpawnPowerUp = 0.1f;
    protected List<PowerUp> powerUpList = new List<PowerUp>();

    // ZOMBIE STATS
    [Header("ZOMBIE STATS")]
    [SerializeField] protected float Health = 3f;
    [SerializeField] protected float attackValue = 1f;
    [SerializeField] protected float zombieAttackRange = 1f;
    [SerializeField] protected float zombieDespawnTime = 5f;
    protected int zomValue;
    protected float currentHP;

    // ANIMATION STATES
    protected const string WALK = "Z_Walk";
    protected const string RUN = "Z_Run";
    protected const string ATTACK = "Z_Attack";
    protected const string DEATH = "Z_FallingBack";

    protected string currentState;
    protected bool isAttacking;

    protected bool IsZombieDead => currentHP <= 0;

    //EVENTS
    public static event Action zombieDied;

    void Awake()
    {
        currentHP = Health;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {
        isAttacking = false;
        powerUpList.Add(twinShot);
        powerUpList.Add(triShot);
    }

    // THIS FUNCTION NEEDS REFACTORING AGAIN
    protected virtual void Update()
    {
        if (!IsZombieDead) { 
            var player = FindObjectOfType<PlayerMovement>();
            // zombie find player
            if (navMeshAgent.enabled && !isAttacking)
            {
                navMeshAgent.SetDestination(player.transform.position);
            }

            // tells zombie whether to attack or not if in range of player
            if ((Vector3.Distance(transform.position, player.transform.position) < zombieAttackRange) && !isAttacking)
            {
                isAttacking = true;
                ChangeAnimationState(ATTACK);
                Attack();
            }
        }
    }

    //============================================================================
    // ANIMATIONS
    //============================================================================

    protected void ChangeAnimationState(string newState)
    {
        // Stop the same animation from interrupting itself
        if (currentState == newState) return;

        // Play Anim
        animator.Play(newState);

        // reassign the current state
        currentState = newState;
    }

    //============================================================================
    // ZOMBIE ATTACK
    //============================================================================
    protected void Attack()
    {
        // makes zombie stop moving while attacking.
        navMeshAgent.enabled = false;

        ZombieDoesDmg();
        Invoke("AttackComplete", animator.GetCurrentAnimatorStateInfo(0).length / 2);

    }

    protected void AttackComplete()
    {
        navMeshAgent.enabled = true;
        isAttacking = false;
    }

    protected virtual void ZombieDoesDmg()
    {
        Debug.Log("PLAYER TAKES DMG");
    }

    //============================================================================
    // zombie death area 
    //============================================================================
    protected void OnCollisionEnter(Collision collision)
    {
        var zombieTakesBullet = collision.collider.GetComponent<BlasterShot>();
        if (zombieTakesBullet)
        {
            currentHP--;
            if (currentHP <= 0)
                ZombieDeath();
        }
    }

    protected virtual void ZombieDeath()
    {
        // Update Kill Count
        zombieDied?.Invoke(); // for zombie kill count

        // turn off movement and collision
        GetComponent<Collider>().enabled = false;
        navMeshAgent.enabled = false;

        // death anim
        ChangeAnimationState(DEATH);

        // zombie drops powerups
        zombieDropsPowerup();

        // destroy the zombie, removing it from the scene
        Destroy(gameObject, zombieDespawnTime);
    }

    //============================================================================
    // Spawn power up from zombie
    //============================================================================

    protected void zombieDropsPowerup()
    {
        if ((UnityEngine.Random.Range(0f, 1f)) < 0.05f)
        {
            if ((UnityEngine.Random.Range(0f, 1f)) < 0.5) // spawn twinshot
            {
                Instantiate(powerUpList[0], transform.position, Quaternion.identity);
            }
            else // spawn tripleshot
            {
                Instantiate(powerUpList[1], transform.position, Quaternion.identity);
            }
        }
    }

}
