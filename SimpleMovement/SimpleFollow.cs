using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    //4 m/s
    public int Speed = 4;
    private Transform player;


    // Use this for initialization
    void Start()
    {
        //Find the player's transform. This saves us a little bit
        //of work as opposed to finding a game object, then every frame
        //asking for its transform.position
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Look at someone tagged 'player'
        transform.LookAt(player);

        //and then move forward (however we are rotated)
        //the problem is once we get to the game object, we'll
        //constantly flip about it. We need a distance check (see SimpleFollowWithDistanceCheck.cs)
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }
}
