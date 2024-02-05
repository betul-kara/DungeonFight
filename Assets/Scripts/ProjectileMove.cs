using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    void Update()
    {
        transform.Translate(projectileSpeed * Time.deltaTime * Vector3.forward);

        Destroy(gameObject, 2);
    }
}
