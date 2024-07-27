using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour, Controls.IBallActions
{
    [SerializeField] private new Rigidbody2D rigidbody;
    [SerializeField] private float throwForce;

    private Controls _controls;
    private Vector2 _touchPosition;
    private bool _isTouched;

    private void Awake()
    {
        _controls = new Controls();
        _controls.Ball.SetCallbacks(this);
    }

    private void OnEnable()
    {
        _controls.Ball.Enable();
    }

    private void OnDisable()
    {
        _controls.Ball.Disable();
    }

    private void Update()
    {
        if (_isTouched)
        {
            transform.position = _touchPosition;
        }
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isTouched = true;
        }
        else if (context.canceled)
        {
            _isTouched = false;
            rigidbody.AddForce(new Vector2(throwForce, 0.0f), ForceMode2D.Impulse);
        }
    }

    public void OnPosition(InputAction.CallbackContext context)
    {
        _touchPosition = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
