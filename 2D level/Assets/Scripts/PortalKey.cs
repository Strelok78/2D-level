using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalKey : MonoBehaviour
{
    [SerializeField] private GameObject portal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<CharacterMovement>(out _))
        {
            portal.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
