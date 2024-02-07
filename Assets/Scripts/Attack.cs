
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    [SerializeField] int attackCount;
    [SerializeField] List<AttackType> attackTypes;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (attackCount == attackTypes.Count)
            {
                attackCount = 0;
            }
            animator.runtimeAnimatorController = attackTypes[attackCount].animatorOV;
            animator.SetTrigger("Attack");
            attackCount++;
        }
    }
}
