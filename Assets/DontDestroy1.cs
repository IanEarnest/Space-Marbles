using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy1 : MonoBehaviour
{
    public static DontDestroy1 Instance
    {
        get; private set;
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //Debug.Log("Warning: multiple " + this + " in scene!");
            Destroy(gameObject); //this.enabled = false;
        }
        DontDestroyOnLoad(this);
    }
}
