using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions.FindAction("TouchPress");
        touchPositionAction = playerInput.actions.FindAction("TouchPosition");
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
        touchPressAction.canceled += TouchUnpressed;

    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        touchPressAction.canceled -= TouchUnpressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
    }

    private void TouchUnpressed(InputAction.CallbackContext context)
    {

    }
}
