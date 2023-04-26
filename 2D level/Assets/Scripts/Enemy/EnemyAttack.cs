using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(EnemyAnimnation))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private UnityEvent _loseGame;
    private EnemyAnimnation _enemyAnimnation;

    private void Awake()
    {
        _enemyAnimnation = GetComponent<EnemyAnimnation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMovement>(out _))
        {
            _loseGame.Invoke();
            _enemyAnimnation.AttackEnemy();
        }
    }
}