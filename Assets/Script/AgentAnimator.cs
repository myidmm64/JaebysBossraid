using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentAnimator : MonoBehaviour
{
    private Animator _animator = null;
    [SerializeField]
    private RuntimeAnimatorController _whiteAnimator = null;
    [SerializeField]
    private RuntimeAnimatorController _redAnimator = null;
    [SerializeField]
    private GameObject _effect = null;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(float amount)
    {
        if(Mathf.Abs(amount) > 0f)
        {
            _animator.SetBool("Move", true);
        }
        else
        {
            _animator.SetBool("Move",false);
        }
    }

    public void JumpAnimation(float amount)
    {
        _animator.SetFloat("MoveY", amount);
    }
    public void IsGrounded(bool value)
    {
        _animator.SetBool("IsGround", value);
    }

    public void AttackAnimation(int cnt)
    {
        switch(cnt)
        {
            case 0:
                _animator.SetTrigger("Attack");
                break;
            case 1:
                _animator.SetTrigger("Attack1");
                break;
            case 2:
                _animator.SetTrigger("Attack2");
                break;
            default:
                break;
        }
    }

    public void DashAnimation()
    {
        _animator.SetTrigger("Dash");
    }

    public void AnimationReset()
    {
        _animator.SetBool("Dash", false);
        _animator.SetBool("Move", false);
        _animator.SetBool("IsGround", true);
    }

    public void GeneAnimation()
    {
        _animator.SetTrigger("Gene");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GeneAnimation();
        }
    }

    public void AnimatorRedToWhite()
    {
        _animator.runtimeAnimatorController = _whiteAnimator;
    }
    public void AnimatorWhiteToRed()
    {
        _animator.runtimeAnimatorController = _redAnimator;
    }
    public void EffectSummon()
    {
        WiatEndDestory w = PoolManager.Instance.Pop("GenerateAnimation") as WiatEndDestory;
        w.transform.position = transform.position;
    }
}
