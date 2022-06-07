using UnityEngine;
using UnityEngine.Events;

public class InputListener : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKeyCode = KeyCode.Space;
    [SerializeField] private KeyCode _useItemKeyCode = KeyCode.Mouse0;
    [SerializeField] private KeyCode _takeItemKeyCode = KeyCode.E;
    [SerializeField] private KeyCode _dropItemKeyCode = KeyCode.G;
    
    public UnityEvent JumpKeyCodePress;
    public UnityEvent UseItemKeyCodePress;
    public UnityEvent TakeItemKeyCodePress;
    public UnityEvent DropItemKeyCodePress;
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

        if (Input.GetKey(_useItemKeyCode))
        {
            UseItemKeyCodePress?.Invoke();
        }

        if (Input.GetKeyDown(_takeItemKeyCode))
        {
            TakeItemKeyCodePress?.Invoke();
        }  
        
        if (Input.GetKeyDown(_dropItemKeyCode))
        {
            DropItemKeyCodePress?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        StepsSinceLastJumpKeyPressed++;
    }
}
