using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a basic asdw/arrow key driven input with simple mouse look.
/// It moves the object l/r/u/d in whatever direction it is facing
/// </summary>
public class SimplePlayerMovementWithMouseRotation : MonoBehaviour
{
    public float Speed = 10f;
    public float LookSpeed = 2f;
    // Update is called once per frame
    void Update()
    {
        //this returns a value between -1 and +1 (and then * Time.deltaTime)
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        //same: -1 <-> +1  * Time.deltaTime, so usually around .02 a frame
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        Debug.Log(horizontal);

        //IE we can only move a max of (assuming Time.deltaTime has a value around .02)
        //transform.Translate(new Vector3(1 *.02, 0, 1 * .02));
        //or
        //transform.Translate(new Vector3(-1 * .02, 0, -1 * .02));

        transform.Translate(new Vector3(horizontal * Speed,
                                        0,
                                        vertical * Speed));

        //Warning if you have a rigidbody (rb), you should be doing this with rb.MovePosition or rb.velocity
        //and rotating with rb.rotation. See the physics folder for examples
        var euler = transform.localEulerAngles;
        euler.y += Input.GetAxis("Mouse X") * LookSpeed;
        transform.localEulerAngles = euler;
    }
}
