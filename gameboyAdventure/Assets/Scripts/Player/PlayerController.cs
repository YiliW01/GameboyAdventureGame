using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float speed;

    private void Awake()
    {
        if (_characterController == null) _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        _characterController.Move(_direction * speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector2(_input.x, _input.y);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        Debug.Log("Inting");
    }

    public void Back(InputAction.CallbackContext context) 
    {
        if (!context.started) return;
        Debug.Log("Backing");
    }
}
