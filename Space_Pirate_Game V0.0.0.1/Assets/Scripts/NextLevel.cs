using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private AudioSource nextLevelSound;
    [SerializeField] private int nextLevelIndex;

    private bool nextLevelEnabled = false; 

    // Start is called before the first frame update
    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hello 1");
        if (collision.gameObject.name == "Player" && !nextLevelEnabled)
        {
            Debug.Log(nextLevelIndex);
            nextLevelSound.Play();
            nextLevelEnabled = true;
            Invoke("nextLevel", 0.5f); //wait 2 seconds
            
        }
    }

    private void nextLevel()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }

}
