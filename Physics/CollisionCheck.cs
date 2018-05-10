using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {

    /*
     * This is a piece of simple code to show an example of
     * 1. Checking if we hit the player
     * 2. Getting the player controller and calling GotHit(pointsToDeduct) on it.
     * 
     */
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var playerController = collision.gameObject.GetComponent<PlayerController>();
            //10 points off for player. Assuming theres a PlayerController script on the player
            //and that the player is actually tagged as player
            playerController.GotHit(10);
        }
    }

    /// <summary>
    /// Reqires at least one of the game objects in the collision to have a trigger on it.
    /// This code will be called (ie OnTriggerEnter code) on any of the objects involved in the trigger event
    /// regardless if they have a trigger setup on them or not. This also requires (just like OnCollisionX) that one of the
    /// game objects has a rigidbody on it as well.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var playerController = other.gameObject.GetComponent<PlayerController>();
            //10 points off for player. Assuming theres a PlayerController script on the player
            //and that the player is actually tagged as player
            playerController.GotHit(10);
        }
    }

}
f