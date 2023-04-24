using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimnation))]
public class EnemyAttack : MonoBehaviour
{    
    [SerializeField] private GameObject _gameEndCanvas;

    private EnemyAnimnation _enemyAnimnation;
    private Text _gameEndText;

    private void Awake()
    {
        _gameEndText = _gameEndCanvas.GetComponent<Text>();
        _enemyAnimnation = GetComponent<EnemyAnimnation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMovement>(out var movement))
        {
            _gameEndText.text = "You lose!";
            _gameEndText.color = Color.red;
            _gameEndCanvas.SetActive(true);

            _enemyAnimnation.AttackEnemy();
            collision.GetComponent<CharacterAnimationController>().Death();
            movement.enabled = false;
        }
    }
}
