using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class EndGameText : MonoBehaviour
{
    [SerializeField] private UnityEvent _stopPlayer;
    [SerializeField] private UnityEvent _animateDeath;
    private Text _text;

    private void Awake()
    {
        gameObject.SetActive(false);
        _text = GetComponent<Text>();
    }

    public void Lose()
    {
        gameObject.SetActive(true);
        _text.text = "You Lose!";
        _text.color = Color.red;

        _stopPlayer.Invoke();
        _animateDeath.Invoke();
    }

    public void Win()
    {
        gameObject.SetActive(true);
        _text.text = "You Win!";
        _text.color = Color.yellow;

        _stopPlayer.Invoke();
    }
}
