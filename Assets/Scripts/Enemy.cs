using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject projectile;
    [SerializeField] float speed = 1f;
    [SerializeField] float stoppingDistance;
    Animator animator;
    NavMeshAgent agent;
    bool isDamaged = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        InvokeRepeating(nameof(Attack), 0, 2);
    }

    private void Update()
    {
        transform.LookAt(player);

        agent.SetDestination(player.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            isDamaged = true;
            animator.SetBool("Attack", true);
            StartCoroutine(ResetAttack());
        }
    }
    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length / 2);
        animator.SetBool("Attack", false);
    }
    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}
