using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class EndLevelPortal : MonoBehaviour
{
    [SerializeField] private UnityEvent _winGame;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterAction>(out var action) && action.hasKey)
        {
            _winGame.Invoke(); 
        }
    }

    public void OpenPortal()
    {
        gameObject.SetActive(true);
    }
}
