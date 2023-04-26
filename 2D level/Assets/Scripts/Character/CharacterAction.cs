using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAction : MonoBehaviour
{
    public bool hasKey { get; private set; }

    private void Awake()
    {
        hasKey = false;
    }

    public void PickKey()
    {
        hasKey = true;
    }
}