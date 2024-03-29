using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * Konner Unity Input Code Demo.txt
 * Displaying Konner Unity Input Code Demo.txt.
 */
public class InputManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset playerControls;  // The input action asset that contains all the actions
    [SerializeField] private InputActionReference interact;    // The reference to the Interact action
    [SerializeField] private InputActionReference jump;        // The reference to the Jump action
    [SerializeField] private InputActionReference move;        // The reference to the Move action
    [SerializeField] private InputActionReference click;        // The reference to the Click action

    public float movementInput;
    public bool isInteracting = false;
    public bool isJumping = false;
    public bool isClicking = false;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("EventSystem"));

        move.action.performed += ctx => MoveHandler(ctx);
        move.action.canceled += ctx => MoveCanceledHandler(ctx);

        interact.action.performed += ctx => InteractHandler(ctx);
        interact.action.canceled += ctx => InteractCanceledHandler(ctx);

        jump.action.performed += ctx => JumpHandler(ctx);
        jump.action.canceled += ctx => JumpCanceledHandler(ctx);

        click.action.performed += ctx => ClickHandler(ctx);
        click.action.canceled += ctx => ClickCanceledHandler(ctx);

        PlayerControlsEnable(); // Enable the player controls by default
    }

    #region Input Handelers
    private void MoveHandler(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<float>();
    }

    private void MoveCanceledHandler(InputAction.CallbackContext ctx)
    {
        movementInput = 0;
    }

    private void InteractHandler(InputAction.CallbackContext ctx)
    {
        isInteracting = true;   // Can pass this variable to another script that handels interaction that needs to know if the interact key is currently being passed
    }

    private void InteractCanceledHandler(InputAction.CallbackContext ctx)
    {
        isInteracting = false;
    }

    private void JumpHandler(InputAction.CallbackContext ctx)
    {
        isJumping = true;
    }

    private void JumpCanceledHandler(InputAction.CallbackContext ctx)
    {
        isJumping = false;
    }

    private void ClickHandler(InputAction.CallbackContext ctx)
    {
        Debug.Log("Bingo");
        isClicking = true;
    }

    private void ClickCanceledHandler(InputAction.CallbackContext ctx)
    {
        Debug.Log("Aww");
        isClicking = false;
    }
    #endregion


    #region Enable & Disable Actions
    public void PlayerControlsEnable()
    {
        playerControls.Enable(); // Enable the player controls
    }

    public void PlayerControlsDisable()
    {
        playerControls.Disable(); // Disable the player controls
    }

    public void MoveEnable()
    {
        move.action.Enable(); // Enable the Move action
    }

    public void MoveDisable()
    {
        move.action.Disable(); // Disable the Move action
    }

    public void InteractEnable()
    {
        interact.action.Enable(); // Enable the Interact action
    }

    public void InteractDisable()
    {
        interact.action.Disable(); // Disable the Interact action
    }
    #endregion

}

