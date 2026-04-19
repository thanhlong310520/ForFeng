using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    public PlayerMovement movement;
    public PlayerAttack playAttack;
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
        if(playAttack.GetAttacking()) move = 0;
        movement.Move(move);
        if (attackAction.triggered)
        {
            playAttack.PlayerAnimAttack();    
        }
    }
}