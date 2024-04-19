using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class TouchControls : MonoBehaviour
{
    // MOBILE INPUT
    [SerializeField] private Rect leftButton;
    [SerializeField] private Rect rightButton;
    [SerializeField] private Rect jumpButton;
    [SerializeField] private InputManager inputManager;
    private Finger movementFinger;
    private Finger jumpingFinger;
    private Vector2 movementAmount;
    private bool jumping;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += TouchOnFingerDown;
        ETouch.Touch.onFingerUp += TouchOnFingerUp;
        ETouch.Touch.onFingerMove += TouchOnFingerMove;
        jumpButton.x = Screen.width - 275;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= TouchOnFingerDown;
        ETouch.Touch.onFingerUp -= TouchOnFingerUp;
        ETouch.Touch.onFingerMove -= TouchOnFingerMove;
        EnhancedTouchSupport.Enable();
    }

    // empty function woop woop
    private void TouchOnFingerMove(Finger finger) { }

    private void TouchOnFingerUp(Finger finger)
    {
        if (finger == movementFinger)
        {
            movementFinger = null;
            movementAmount = Vector2.zero;
        }
        else if (finger == jumpingFinger)
        {
            jumpingFinger = null;
            jumping = false;
        }
    }

    private void TouchOnFingerDown(Finger finger)
    {
        //Debug.LogWarning(jumpButton + " " + finger.screenPosition);
        if (movementFinger == null && leftButton.Contains(finger.screenPosition))
        {
            //Debug.LogWarning("lefted");
            movementFinger = finger;
            movementAmount = -Vector2.one;
        }
        else if (movementFinger == null && rightButton.Contains(finger.screenPosition))
        {
            //Debug.LogWarning("righted");
            movementFinger = finger;
            movementAmount = Vector2.one;
        }
        else if (jumpingFinger == null && jumpButton.Contains(finger.screenPosition))
        {
            //Debug.LogWarning("jumped");
            jumpingFinger = finger;
            jumping = true;
        }
    }

    private void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            inputManager.movementInput = movementAmount.x;
            inputManager.isJumping = jumping;
        }
    }

    public void ResetMovement()
    {
        movementFinger = null;
        movementAmount = Vector2.zero;
        jumping = false;
        inputManager.movementInput = 0;
        inputManager.isJumping = false;
    }
}
// 64