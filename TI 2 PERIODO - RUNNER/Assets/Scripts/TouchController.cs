using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchController : MonoBehaviour
{
    public PlayerController playerController;

    public GameManager gameManager;

    //public GameObject playerCharacter;

    private PlayerInput playerInput;

    private InputAction touchPositionAction;

    private InputAction touchPressAction;

    private Vector2 startTouchPosition;

    private Vector2 endTouchPosition;

    //private bool isSwiping;

    //private float speed = 2;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        touchPressAction = playerInput.actions["TouchPress"];

        touchPositionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchStarted;
        touchPressAction.canceled += TouchEnded;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
        touchPressAction.canceled -= TouchEnded;
    }

    private void TouchStarted(InputAction.CallbackContext context)
    {
        startTouchPosition = touchPositionAction.ReadValue<Vector2>();
        //isSwiping = true;
    }

    private void TouchEnded(InputAction.CallbackContext context)
    {
        endTouchPosition = touchPositionAction.ReadValue<Vector2>();
        //isSwiping = false;
        DetectSwipe();
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 position = touchPositionAction.ReadValue<Vector2>();
        Debug.Log(position);
    }

    private void DetectSwipe()
    {
        Debug.Log("DEDOU");
        Vector2 swipeDirection = endTouchPosition - startTouchPosition;
        int minimalDistance = 50;

        if (swipeDirection.magnitude > minimalDistance)
        {
            // Debug
            Debug.Log("Swipe Detected: " + swipeDirection.normalized);
            Vector3 startWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(startTouchPosition.x, startTouchPosition.y, 10));
            Vector3 endWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(endTouchPosition.x, endTouchPosition.y, 10));
            Debug.DrawLine(startWorldPosition, endWorldPosition, Color.red, 2.0f);
            // EndDebug

            if(gameManager.isPaused == false)
            {
                playerController.Move(swipeDirection.normalized);
                //playerCharacter.transform.Translate(swipeDirection * speed * Time.deltaTime);
            }
        }
    }

}