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
        Debug.Log("J chilling");
        if (collision.gameObject.name == "Player" && !nextLevelEnabled && Globals.playerInteraction)
            {
                nextLevelSound.Play();
                nextLevelEnabled = true;
                SceneLoader.loadScene(nextLevelIndex);
                Debug.Log("You got here? How?! My lord, no one has traveled these lands in many years! By GOD, you look ravished, please please, sit and enjoy a nice warm meal");
                Globals.playerInteraction = false;
            }
       
    }
    // Dom is a bitch

}
