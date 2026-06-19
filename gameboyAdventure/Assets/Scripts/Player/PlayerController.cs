using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _direction;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private InteractionDetector _interactor;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (PauseManager.Instance.IsGamePaused)
        {
            _rb.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }

        ApplyMovement();
    }

    private void ApplyMovement()
    {
        _rb.linearVelocity = (_input * speed);  //* Time.deltaTime;
        animator.SetBool("isWalking", _rb.linearVelocity.magnitude > 0);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", _input.x);
            animator.SetFloat("LastInputY", _input.y);
        }

        _input = context.ReadValue<Vector2>();
        //_direction = new Vector2(_input.x, _input.y);

        animator.SetFloat("InputX", _input.x);
        animator.SetFloat("InputY", _input.y);
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactor.OnInteract();
            //Debug.Log("Player Inting");
        }
        
    }

    public void Back(InputAction.CallbackContext context) 
    {
        if (context.performed)
        {
            //Debug.Log("Player Backing");
            if (PauseManager.Instance.IsGamePaused) { PauseManager.Instance.SetPause(false); }
            else { PauseManager.Instance.SetPause(true); }
        }
    }
}
