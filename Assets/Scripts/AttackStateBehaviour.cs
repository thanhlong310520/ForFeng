using UnityEngine;

public class AttackStateBehaviour : StateMachineBehaviour
{
    // Gọi khi bắt đầu state (attack bắt đầu)
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAnim player = animator.GetComponent<PlayerAnim>();
        if (player != null)
        {
            player.OnAttack();
        }
    }

    // Gọi khi thoát state (attack kết thúc)
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("Attack", false);  
    }
}