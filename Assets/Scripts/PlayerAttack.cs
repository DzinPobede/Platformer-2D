using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float AttackCooldown;
    [SerializeField] private float timerAttackColdown;

    public Transform attackPosition;
    public LayerMask whatIsEnemies;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AttackCooldown <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                Collider2D[] emeniesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemies);
                for(int i = 0; i < emeniesToDamage.Length; i++)
                {

                }
            }
            AttackCooldown = timerAttackColdown;
        }
        else
        {
            AttackCooldown -= Time.deltaTime;
        }
    }
}
