using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour
{
    [SerializeField] int sceneIndex;

    public void startGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
