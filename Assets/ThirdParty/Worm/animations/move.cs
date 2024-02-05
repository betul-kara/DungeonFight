using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] float stoppingDistance;
    [SerializeField] Transform player;
    void Update()
    {
        transform.LookAt(player);
        Vector3 direction = (player.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            Vector3 newPos = transform.position + direction * 1 * Time.deltaTime;
            transform.position = newPos;
        }
    }
}
