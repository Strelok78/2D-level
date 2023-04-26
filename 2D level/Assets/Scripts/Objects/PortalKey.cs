using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalKey : MonoBehaviour
{    
    [SerializeField] private UnityEvent _openPortal;
    [SerializeField] private UnityEvent _pickKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMovement>(out _))
        {
            _openPortal.Invoke();
            _pickKey.Invoke();
            gameObject.SetActive(false);
        }
    }
}
