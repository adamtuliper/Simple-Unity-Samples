using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnEscape : MonoBehaviour
{
	//Add this to a gameobject like GameManager
    //Ideally you want a UI to do this, also don't do this (usually)
    //on mobile. Allow the OS to suspend or kill you (usually)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
