using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemylayer;
    public UnityEngine.Experimental.Rendering.Universal.Light2D FOV;
    public float attackRate = 1f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitenemy = Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemylayer);
        foreach(Collider2D enemy in hitenemy)
        {
            Destroy(enemy.gameObject);
            FOV.pointLightOuterRadius += 0.5f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
