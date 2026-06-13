using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Rigidbody2D _rb;
    private Vector3 _direction;

    [SerializeField] private float speed;

    [SerializeField] private InteractionDetector _interactor;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        _rb.linearVelocity = _direction * speed; // * Time.deltaTime;
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector2(_input.x, _input.y);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactor.OnInteract();
            Debug.Log("Player Inting");
        }
        
    }

    public void Back(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            Debug.Log("Player Backing");
        }
    }
}
