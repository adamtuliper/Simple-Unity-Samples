using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// To use, add this to an object with a collider.
/// When it is hit, you'll see arrows in the Scene Window
/// and primitives in the Scene and Game window.
/// This is now a replacement for the Physics Debugger
/// but instead used as a simple visualization tool that
/// can show what happened after the fact.
/// </summary>
public class VisualizeCollisions : MonoBehaviour
{
    /// <summary>
    /// Can be a simple primitive prefab
    /// </summary>
    public GameObject PrefabForCollisionPoint;
    private struct ContactPointAndColor
    {
        public Color Color;
        public ContactPoint ContactPoint;
        public float Magnitude;
    }

    /// <summary>
    /// I opted to hard code the size rather than worry about dynamically
    /// scaling an array (or linked list) and dealing with allocations.
    /// </summary>
    private ContactPointAndColor[] contactPoints = new ContactPointAndColor[100];

    private int lastContactPoint = -1;

    /// <summary>
    /// Should we create a sphere at the contact point?
    /// </summary>
    public bool CreatePrimitiveAtPoint = true;

    /// <summary>
    /// Should we keep viewing the collision points with rays?
    /// If not you will only view it for ONE FRAME which means ideally
    /// you'll need to single step to debug your collisions (which is normally
    /// how we debug collisions, no?) :)
    /// </summary>
    public bool PersistContactVisuals = true;
    

    // Update is called once per frame
    void Update()
    {
        //Draw every contact point
        for (int i = 0; i < lastContactPoint + 1; i++)
        {
            var contact = contactPoints[i];
            Debug.DrawRay(contact.ContactPoint.point, contact.ContactPoint.normal * contact.Magnitude, contact.Color);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        //Choose a random color to color 
        //the arrows and primitives
        var color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);

        //If we haven't filled up the contact point history
        bool addPoint = lastContactPoint < contactPoints.Length - 1;
        
        //Create a parent game object for the collision group
        var parentGroup = new GameObject(string.Format("Collisions between {0} / {1}  FixedUpdate#{2} ", gameObject.name, collision.gameObject.name, FixedFrameCount()));

        for (int i = 0; i < collision.contacts.Length; i++)
        {
            var contact = collision.contacts[i];

            //***WARNING*** If you do this you'll add a draw call
            //for every color primitive you add to the scene.
            //This is obviously for debugging only. You can workaround by using vertex color in a shader
            //but that's outside the scope of this pure C# example.
            if (CreatePrimitiveAtPoint)
            {
                //Note don't use a sphere, its too many vertices to batch.
                var go = Instantiate(PrefabForCollisionPoint, contact.point, Quaternion.identity);
                go.name = string.Format("Collision Point Group {0}", i);
                go.transform.parent = parentGroup.transform;

                //var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Destroy(go.GetComponent<Collider>());
                var mesh = go.GetComponent<MeshFilter>().mesh;
                var vertices = mesh.vertices;
                var colors = new Color[vertices.Length];
                int q = 0;
                while (q < vertices.Length)
                {
                    colors[q] = color;
                    q++;
                }
                //We're using a simple vertex color shader.
                //If you aren't using this shader you can try this to change primitive color but with more draw calls
                //go.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
                mesh.colors = colors;

                //go.GetComponent<MeshRenderer>().material.SetColor("_Color", color);
                //go.transform.localScale = new Vector3(.1f, .1f, .1f);
                go.transform.position = contact.point;
            }

            Debug.Log(contact.thisCollider.name + " hit at " + contact.point + " to " + contact.otherCollider.name + " Normal " + contact.normal + " separation " + contact.separation);
            var magnitude = collision.relativeVelocity.magnitude;
            
            if (addPoint)
            {
                lastContactPoint++;
                contactPoints[lastContactPoint].Color = color;
                contactPoints[lastContactPoint].ContactPoint = contact;
                contactPoints[lastContactPoint].Magnitude = magnitude;
            }

            Debug.DrawRay(contact.point, contact.normal * magnitude, color);

        }

        Debug.Log(collision.gameObject.name + " hit " + gameObject.name);
    }

    /// <summary>
    /// Rough estimate of the physics frame this happened in 
    /// </summary>
    /// <returns></returns>
    public static int FixedFrameCount()
    {
        return Mathf.RoundToInt(Time.fixedTime / Time.fixedDeltaTime);
    }
}
