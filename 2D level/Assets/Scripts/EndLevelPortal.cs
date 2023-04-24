using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelPortal : MonoBehaviour
{
    [SerializeField] private GameObject _gameEndCanvas;
    private Text _gameEndText;

    private void Awake()
    {
        _gameEndText = _gameEndCanvas.GetComponent<Text>();
        _gameEndCanvas.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMovement>(out var movement))
        {
            _gameEndText.text = "You win!";
            _gameEndText.color = Color.red;
            _gameEndCanvas.SetActive(true);
 
            movement.enabled = false;
        }
    }
}
