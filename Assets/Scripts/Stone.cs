using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }



    void OnTriggerStay2D(Collider2D attackerCollider)
    {
        Attacker attacker = attackerCollider.gameObject.GetComponent<Attacker>();
        if (attacker)
        {
            animator.SetTrigger("underAttackTrigger");
        }
    }
}
