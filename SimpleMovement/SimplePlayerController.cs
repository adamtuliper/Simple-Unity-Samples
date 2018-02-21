using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float Health = 100f;
    public float MoveSpeed = 5f;
    public float SprintSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        //These return a value of -1 to 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float sprint = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = SprintSpeed;
        }

        //transform.Translate(0, 0, vertical * Time.deltaTime * MoveSpeed * sprint);
        transform.Translate(Vector3.forward * 
                            vertical * 
                            Time.deltaTime * 
                            MoveSpeed * 
                            sprint);

        transform.Rotate(0, horizontal * 30 * Time.deltaTime, 0);

        //This is a public 'member variable' that belong
        //to the class, not the function - ie it is not a local variable.
        Health = Health - 1 * Time.deltaTime;
        Debug.Log("Player Health:" + Health);

        //Debug.Log("horizontal:" + horizontal + " vertical:" + vertical);
        //Or if you have '.NET 4.6 support' turned on in player settings you can use this syntax called String Interpolation
        //Debug.Log($"horizontal:{horizontal} vertical:{vertical}");


    }

}
