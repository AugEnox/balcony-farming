using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public int speed = 5;
    public int easeSpeed = 1;
    public BalconyMovement BalconyMovement;

    private Transform _transform;
    private BoxCollider _boxCollider;
    private Rigidbody _rigidbody;
    private Vector2 _movementDirection = Vector2.zero;

    private InputAction move;
    private InputAction interact;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        BalconyMovement = new BalconyMovement();
    }
    
    private void OnEnable()
    {
        move = BalconyMovement.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
    
    private void Update()
    {
        _movementDirection = move.ReadValue<Vector2>() * speed;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_movementDirection.x, 0, _movementDirection.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("plantTrigger"))
        {
            other.GetComponent<Plot>().PlantASeed();
        }
    }
}