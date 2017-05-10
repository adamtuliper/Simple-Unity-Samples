using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindObject : MonoBehaviour
{
	/*
		This is some simple code to show how to 
		1. Find a game object by name or tag (the player)
		2. Get a reference to the PlayerController on that game object
	*/

    private PlayerController _playerController;

	// Use this for initialization
	void Start ()
	{
        //Method 1 - technically a bit slower. Requries a game object named (name, not tag) "Player"
	    var player = GameObject.Find("Player");
	    _playerController = player.GetComponent<PlayerController>();

        //Method 2 - use the tag
	    var thePlayer = GameObject.FindWithTag("Player");
	    _playerController = thePlayer.GetComponent<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
	    //Don't do it in update. Its typically bad as you tend to call it every frame.	
	}

}
