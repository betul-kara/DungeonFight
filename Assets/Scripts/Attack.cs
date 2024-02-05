using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("LEFT");
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("RIGHT");

        }

    }
}
