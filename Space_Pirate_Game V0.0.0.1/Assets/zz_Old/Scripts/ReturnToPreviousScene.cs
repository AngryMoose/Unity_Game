using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnToPreviousScene : MonoBehaviour
{
    [SerializeField] Button ExitButton;

    void Start()
    {
        ExitButton.onClick.AddListener(() => ExitClicked());
    }

    private void ExitClicked()
    {
        SceneManager.LoadScene(SceneLoader.previousScene());
    }
}
