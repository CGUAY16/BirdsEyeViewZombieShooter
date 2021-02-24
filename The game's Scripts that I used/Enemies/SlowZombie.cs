using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZombie : ZombieDefault
{

    protected override void Start()
    {
        base.Start();
        zomValue = 100;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!IsZombieDead)
        {
            var player = FindObjectOfType<PlayerMovement>();
            // zombie find player
            if (navMeshAgent.enabled && !isAttacking)
            {
                ChangeAnimationState(WALK);
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

    protected override void ZombieDeath()
    {
        ScoreSystem.instance.UpdateScore(zomValue); // adds zombie death points to total score
        base.ZombieDeath();
    }
}
