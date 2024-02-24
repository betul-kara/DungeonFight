using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] HealthBar playerHealthBar;
    [SerializeField] GameObject startingPoint;
    [SerializeField] GameObject gameOverPanel;

    public static Player Instance;
    public float health;
    public float damage;
    public bool isSpawned = false;


    float _speed = 4f;
    float _Xspeed = 6f;
    float _gravity = -9.8f;
    float _jump = 1f;
    float groundDistance = 0.3f;
    Vector3 _velocity;
    bool isGrounded;

    private void Awake()
    {
        playerHealthBar.SetHealth(health);
        Instance = this;
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * _speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * _Xspeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jump * -2f * _gravity);
        }
        _velocity.y += _gravity * Time.deltaTime;

        characterController.Move(_velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(damage);
        }
        if (other.gameObject.CompareTag("StartingPoint"))
        {
            isSpawned = true;
            startingPoint.SetActive(false);
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        playerHealthBar.SetHealth(health);

        if (health <= 0 && gameOverPanel.active == false)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
