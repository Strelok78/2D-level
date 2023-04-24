using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimnation : MonoBehaviour
{
    private const string EnemyDetected = "EnemyDetected";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackEnemy()
    {
        _animator.SetTrigger(EnemyDetected);
    }
}
