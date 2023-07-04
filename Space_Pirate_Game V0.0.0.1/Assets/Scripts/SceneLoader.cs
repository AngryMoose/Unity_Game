using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static int previousSceneIndex;

    public static void loadScene(int sceneIndex)
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"previousSceneIndex = {previousSceneIndex}");
        SceneManager.LoadScene(sceneIndex);
    }

    public static int previousScene()
    {
        return previousSceneIndex;
    }

}
