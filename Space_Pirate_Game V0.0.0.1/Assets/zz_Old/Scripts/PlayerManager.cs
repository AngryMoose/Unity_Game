using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public int currency;


    private void Update()
    {
        if (Input.GetButtonDown("Submit"))
        {
            Globals.playerInteraction = true;
        }
        if (Input.GetButtonUp("Submit"))
        {
            Globals.playerInteraction = false;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }


}

static class Globals
{
    // global int
    public static bool playerInteraction;

    // global function
    public static string HelloWorld()
    {
        return "Hello World";
    }

    // global int using get/set
    static int _getsetcounter;
    public static int getsetcounter
    {
        set { _getsetcounter = value; }
        get { return _getsetcounter; }
    }
}

