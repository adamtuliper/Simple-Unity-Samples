using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Snap to surface"))
        {
            var go = ((Waypoint)target).gameObject;
            Debug.Log(go.transform.position);
            //add everthing the button would do.

            RaycastHit hitInfo;

            if (Physics.Raycast(go.transform.position, Vector3.down, out hitInfo, 2000))
            {
                go.transform.position = hitInfo.point;
            }
            else if (Physics.Raycast(go.transform.position, Vector3.up, out hitInfo, 2000))
            {
                go.transform.position = hitInfo.point;
            }
        }
    }

    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
    static void DrawGizmoForWaypoint(Waypoint waypoint, GizmoType gizmoType)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(waypoint.transform.position, 1);
    }
}
