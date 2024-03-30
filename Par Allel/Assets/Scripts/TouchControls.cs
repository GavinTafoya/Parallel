using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class TouchControls : MonoBehaviour
{
    // MOBILE INPUT
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Rect joystickLocation;
    [SerializeField] private InputManager inputManager;
    private Finger movementFinger;
    private Vector2 movementAmount;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += TouchOnFingerDown;
        ETouch.Touch.onFingerUp += TouchOnFingerUp;
        ETouch.Touch.onFingerMove += TouchOnFingerMove;
    }

    // so dumb that I need this
    public void FindJoystick()
    {
        joystick = GameObject.Find("Joystick").GetComponent<FloatingJoystick>();
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= TouchOnFingerDown;
        ETouch.Touch.onFingerUp -= TouchOnFingerUp;
        ETouch.Touch.onFingerMove -= TouchOnFingerMove;
        EnhancedTouchSupport.Enable();
    }

    private void TouchOnFingerMove(Finger finger)
    {
        if (finger == movementFinger)
        {
            Vector2 knobPosition;
            float maxMovement = joystickLocation.width / 2;
            ETouch.Touch currentTouch = finger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, joystick.rect.anchoredPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - joystick.rect.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - joystick.rect.anchoredPosition;
            }

            joystick.knob.anchoredPosition = knobPosition;
            movementAmount = knobPosition / maxMovement;
        }
    }

    private void TouchOnFingerUp(Finger finger)
    {
        if (finger == movementFinger)
        {
            movementFinger = null;
            joystick.knob.anchoredPosition = Vector2.zero;
            movementAmount = Vector2.zero;
        }
    }

    private void TouchOnFingerDown(Finger finger)
    {
        FindJoystick();

        if (movementFinger == null && joystickLocation.Contains(finger.screenPosition))
        {
            movementFinger = finger;
            movementAmount = Vector2.zero;
        } 
    }

    private void Update()
    {
        // TODO: player movement updating
        if (SystemInfo.deviceType == DeviceType.Handheld) {
            inputManager.movementInput = movementAmount.x;
            inputManager.isJumping = movementAmount.y > 0.75f;
        }
    }

    public void ResetMovement()
    {
        movementFinger = null;
        joystick.knob.anchoredPosition = Vector2.zero;
        movementAmount = Vector2.zero;
        inputManager.movementInput = 0;
        inputManager.isJumping = false;
    }
}
// 64