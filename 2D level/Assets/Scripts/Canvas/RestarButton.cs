using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestarButton : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
