using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject projectile;
    Animator animator;
    NavMeshAgent agent;
    public float health;
    [SerializeField] HealthBar enemyHealthBar;
    public float enemyCount;
    private void Awake()
    {
        enemyHealthBar.SetHealth(health);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        InvokeRepeating(nameof(Attack), 0, 2);
    }

    private void Update()
    {
        transform.LookAt(player.transform);

        agent.SetDestination(player.transform.position);

        if (health <= 0)
        {
            Destroy(gameObject,0.5f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            TakeDamage(25);
        }
    }
    void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= agent.stoppingDistance)
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        enemyHealthBar.SetHealth(health);
    }
}