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
    private bool playerInteraction;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !nextLevelEnabled && Globals.playerInteraction)
            {
                Debug.Log(nextLevelIndex);
                nextLevelSound.Play();
                nextLevelEnabled = true;
                SceneLoader.loadScene(nextLevelIndex);
                Globals.playerInteraction = false;
            }
       
    }
    // Dom is a bitch

}
