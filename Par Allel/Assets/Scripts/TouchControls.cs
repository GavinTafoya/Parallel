using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class TouchControls : MonoBehaviour
{
    // MOBILE INPUT
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private Rect leftButton;
    [SerializeField] private Rect rightButton;
    [SerializeField] private Rect jumpButton;
    [SerializeField] private Rect joystickLocation;
    [SerializeField] private InputManager inputManager;
    private Finger movementFinger;
    private Finger jumpingFinger;
    private Vector2 movementAmount;
    private bool jumping;
    // rect transfrom is so broken
    //private Rect offset = new Rect(50, 50, 0, 0);

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += TouchOnFingerDown;
        ETouch.Touch.onFingerUp += TouchOnFingerUp;
        ETouch.Touch.onFingerMove += TouchOnFingerMove;
        jumpButton.x = Screen.width - 275;
    }

    // so dumb that I need this
    // 
    public void FindJoystick()
    {
        Debug.Log("found buttons");
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= TouchOnFingerDown;
        ETouch.Touch.onFingerUp -= TouchOnFingerUp;
        ETouch.Touch.onFingerMove -= TouchOnFingerMove;
        EnhancedTouchSupport.Enable();
    }

    // empty function woop woop
    private void TouchOnFingerMove(Finger finger)
    {
        /*if (finger == movementFinger)
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
        }*/
    }

    private void TouchOnFingerUp(Finger finger)
    {
        if (finger == movementFinger)
        {
            movementFinger = null;
            //joystick.knob.anchoredPosition = Vector2.zero;
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
        FindJoystick();

        /*if (movementFinger == null && joystickLocation.Contains(finger.screenPosition))
        {
            movementFinger = finger;
            movementAmount = Vector2.zero;
        } */
        //Debug.LogWarning(leftButton.rect + " " + finger.screenPosition + " " + leftButton.rect.Contains(finger.screenPosition));
        // bs to fix unity bs
        /*Rect leftArea = new Rect(offset.x + leftButton.rect.x, offset.y + leftButton.rect.y, leftButton.rect.width, leftButton.rect.height);
        Rect rightArea = new Rect(offset.x + rightButton.rect.x, offset.y + rightButton.rect.y, rightButton.rect.width, rightButton.rect.height);
        Rect jumpArea = new Rect(offset.x + jumpButton.rect.x, offset.y + jumpButton.rect.y, jumpButton.rect.width, jumpButton.rect.height);*/

        Debug.LogWarning(jumpButton + " " + finger.screenPosition);
        if (movementFinger == null && leftButton.Contains(finger.screenPosition))
        {
            Debug.LogWarning("lefted");
            movementFinger = finger;
            movementAmount = -Vector2.one;
        }
        else if (movementFinger == null && rightButton.Contains(finger.screenPosition))
        {
            Debug.LogWarning("righted");
            movementFinger = finger;
            movementAmount = Vector2.one;
        }
        else if (jumpingFinger == null && jumpButton.Contains(finger.screenPosition))
        {
            Debug.LogWarning("jumped");
            jumpingFinger = finger;
            jumping = true;
        }
    }

    private void Update()
    {
        // TODO: player movement updating
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            inputManager.movementInput = movementAmount.x;
            inputManager.isJumping = jumping;
        }
    }

    public void ResetMovement()
    {
        movementFinger = null;
        //joystick.knob.anchoredPosition = Vector2.zero;
        movementAmount = Vector2.zero;
        jumping = false;
        inputManager.movementInput = 0;
        inputManager.isJumping = false;
    }
}
// 64