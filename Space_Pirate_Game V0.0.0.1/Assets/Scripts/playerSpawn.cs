using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSpawn : MonoBehaviour
{
    [SerializeField] Vector2 spawnPosition;
    [SerializeField] GameObject spawnPlayer;

    // Start is called before the first frame update
    private void Awake()
    {
        spawnPlayer.transform.position = spawnPosition;
    }
}
