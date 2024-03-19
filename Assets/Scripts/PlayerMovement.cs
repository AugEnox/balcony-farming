using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 5;
    public int easeSpeed = 1;
    public BalconyMovement BalconyMovement;
    public Plot selectedPlot;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private Vector2 _movementDirection = Vector2.zero;

    private InputAction _moveAction;
    private Vector2 _moveValue;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        BalconyMovement = new BalconyMovement();
    }
    
    private void OnEnable()
    {
        _moveAction = BalconyMovement.Player.Move;
        _moveAction.Enable();
        BalconyMovement.Player.Interact.performed += PlayerInteract;
        BalconyMovement.Player.Fire.performed += PlayerFire;
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        BalconyMovement.Player.Interact.performed -= PlayerInteract;
    }

    public void PlayerInteract(InputAction.CallbackContext context)
    {
        if(!selectedPlot) return;
        
        selectedPlot.PlantASeed();
    }
    
    public void PlayerFire(InputAction.CallbackContext context)
    {
        // this doesn't trigger for some reason after planting
        if(!selectedPlot) return;
        
        Debug.Log("harvesting");
        selectedPlot.HarvestPlant();
    }

    private void Update()
    {
        _movementDirection = _moveAction.ReadValue<Vector2>() * speed;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_movementDirection.x, _rigidbody.velocity.y, _movementDirection.y);
    }
}