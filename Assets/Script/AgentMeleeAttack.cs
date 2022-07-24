using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMeleeAttack : MonoBehaviour
{
    [field: SerializeField]
    private UnityEvent<int> OnAttack = null;
    protected int _attackCnt = 0;


    public void Attack()
    {
        OnAttack?.Invoke(_attackCnt);
    }
}
