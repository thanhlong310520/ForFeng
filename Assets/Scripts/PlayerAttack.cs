using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public bool attacking;

    public bool GetAttacking()
    {
        return attacking;
    }

    [SerializeField] float timeAttack = 0.5333333f;
    [SerializeField] float currentTimeAttack;
    [SerializeField] float attackSpeed = 1;

    [SerializeField] float timeResetAttack = 0.5f; 
    [SerializeField] float currentTimeResetAttack;
    [SerializeField] int numberAttack = 0;
    [SerializeField] int numberAttackMax = 3;
    bool countingResetAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attacking = false;
        countingResetAttack = false;
        currentTimeResetAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            currentTimeAttack += Time.deltaTime;
            if (currentTimeAttack >= timeAttack / attackSpeed)
            {
                DoneAnimAttack();
            }
        }
        if(countingResetAttack)
        {
            currentTimeResetAttack += Time.deltaTime;
            if (currentTimeResetAttack >= timeResetAttack)
            {
                numberAttack = 1;
                countingResetAttack = false;
            }
        }
    }
    public void DoneAnimAttack()
    {
        //ActionDoneAttack?.Invoke();
        attacking = false;
        currentTimeResetAttack = 0;
        countingResetAttack = true;
    }
    public float GetAnimationLengthByName(string clipName)
    {
        RuntimeAnimatorController controller = animator.runtimeAnimatorController;

        foreach (AnimationClip clip in controller.animationClips)
        {
            if (clip.name == clipName)
                return clip.length;
        }

        Debug.LogWarning($"Không tìm thấy animation: {clipName}");
        return 0f;
    }

    public void PlayerAnimAttack()
    {
        
        if (attacking) return;
        currentTimeAttack = 0;
        countingResetAttack = false;
        currentTimeResetAttack = 0;
        //animator.Play("Attack", 1, 0);
        animator.SetTrigger("Attack");
        animator.SetInteger("NumberAttack", numberAttack);
        numberAttack++;
        if(numberAttack > numberAttackMax)
        {
            numberAttack = 1;
        }
        //timeAttack = GetAnimationLengthByName("attack");    
        attackSpeed = 1;
        attacking = true;
    }

}
