using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterDoor : MonoBehaviour
{
    [SerializeField] private AudioSource nextLevelSound;
    [SerializeField] private int nextLevelIndex;

    private bool nextLevelEnabled = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.name == "Player" && !nextLevelEnabled)
        {
            nextLevelSound.Play();
            nextLevelEnabled = true;
            nextLevel();
            
        }
    }

    private void nextLevel()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }

}
