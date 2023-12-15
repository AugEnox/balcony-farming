using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public int speed = 5;
    public int easeSpeed = 1;
    public BalconyMovement BalconyMovement;
    public GameObject selectedGameObject;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private GameObject _collidedGameObject;
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
        if(!selectedGameObject)
            return;
        if (selectedGameObject.GetComponent<Plot>())
        {
            selectedGameObject.GetComponent<Plot>().PlantASeed();
        }
    }
    
    public void PlayerFire(InputAction.CallbackContext context)
    {
        // this doesn't trigger for some reason after planting
        if(!selectedGameObject)
            return;
        if (selectedGameObject.GetComponent<Plot>())
        {
            selectedGameObject.GetComponent<Plot>().HarvestPlant();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        _collidedGameObject = collision.gameObject;
    }

    private void Update()
    {
        _movementDirection = _moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_movementDirection.x, _rigidbody.velocity.y, _movementDirection.y);
    }
}