using UnityEngine;
using UnityEngine.Events;

public class InputListener : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKeyCode = KeyCode.Space;
    [SerializeField] private KeyCode _shootKeyCode = KeyCode.Mouse0;
    
    public UnityAction JumpKeyCodePress;
    public UnityAction ShootKeyCodePress;
    public Vector2 PlayerInput { get; private set; }

    public int StepsSinceLastJumpKeyPressed { get; private set; }
    private void Update()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetKey(_jumpKeyCode))
        {
            StepsSinceLastJumpKeyPressed = 0;
            JumpKeyCodePress?.Invoke();
        }

        if (Input.GetKey(_shootKeyCode))
        {
            ShootKeyCodePress?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        StepsSinceLastJumpKeyPressed++;
    }
}