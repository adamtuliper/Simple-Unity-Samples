using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollowWithDistanceChecks : MonoBehaviour
{
    //4 m/s
    public int Speed = 4;
    public float FollowDistance = 2f;

    private Transform player;


    // Use this for initialization
    void Start()
    {
        //Find the player's transform. This saves us a little bit
        //of work as opposed to finding a game object, then every frame
        //asking for its transform.position. Note that "Player" is case sensitive.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Look at someone tagged (case sensitive) 'Player'
        transform.LookAt(player);

        var distance = Vector3.Distance(transform.position, player.position);
        //Debug.Log("Distance:" + distance);

        if (distance > FollowDistance)
        {
            //Note - if your object is bigger than say 4 meters, the center point
            //to the destintion object may be longer than 2 meters and actually
            //push the object as its seeking towards it.

            //Move forward (however we are rotated)
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }


    }
}
