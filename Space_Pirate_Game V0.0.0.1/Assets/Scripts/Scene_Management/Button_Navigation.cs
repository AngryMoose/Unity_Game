using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Navigation : MonoBehaviour
{

    public void ButtonSceneNavigate(int sceneIndex)
    {
        Debug.Log(sceneIndex);
        SceneManager.LoadScene(sceneIndex);
    }

}
