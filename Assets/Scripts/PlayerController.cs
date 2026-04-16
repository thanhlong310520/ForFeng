using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    public PlayerMovement movement;
    private InputAction moveAction;
    private InputAction attackAction;

    private void Awake()
    {
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];

    }

    private void Update()
    {
        float move = moveAction.ReadValue<float>();
        movement.Move(move);
        if (attackAction.triggered)
        {
            movement.Jump();    
        }
    }
}