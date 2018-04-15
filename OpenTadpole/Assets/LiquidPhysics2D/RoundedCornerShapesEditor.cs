using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(RoundedCornerShapes))]
class RoundedCornerShapesEditor : Editor
{
    public float snapGridSize = 0.5f;
    public bool gridSnapOn = true;

    public float currentRadius = 0.75f;

    public override void OnInspectorGUI()
    {
        RoundedCornerShapes shape = (RoundedCornerShapes)target;

        GUILayout.Label("Filled shapes must be defined in clockwise order\nfor the collider to be generated correctly.\nDo not define concave shapes.\nIf the line intersect then the collider will not work.\nOutline shapes have no restrictions.\n\nIt is recommend to lock the inspector when drawing. \nDont forget to hit finish edit when you're done.");

        GUILayout.Space(20);
        GUILayout.Space(20);

        if (GUILayout.Button("Enable Edit"))
        {
            LockInspectorWindow();
            EnableEditMode(shape);
        }

        if (GUILayout.Button("Finish edit mode"))
        {
            CancelEditMode(shape);
        }

        if (GUILayout.Button("Generate Filled Shape"))
        {
            DoGenerateShape(shape);
        } 
        
        if (GUILayout.Button("Generate Outline Shape"))
        {
            DoGenerateOutlineShape(shape);
        }

        if (GUILayout.Button("Clear Shape"))
        {
            ClearShape(shape);
        }

        GUILayout.Space(20);

        currentRadius = EditorGUILayout.FloatField("Current Radius : ", currentRadius);
        GUILayout.Space(20);

        gridSnapOn = GUILayout.Toggle(gridSnapOn, "Enable Grid Snap");
        if (gridSnapOn)
        {
            snapGridSize = EditorGUILayout.FloatField("Snap Grid Size : ", snapGridSize);
        }
    }

    private static float GetSceneCameraZoom()
    {
        float zoom = 0;
        float x1 = HandleUtility.GUIPointToWorldRay(new Vector3(0f, 0f, 0f)).origin.x;
        //Debug.Log(x1);
        float x2 = HandleUtility.GUIPointToWorldRay(new Vector3(1f, 0f, 0f)).origin.x;
        // Debug.Log(x2);
        zoom = Mathf.Abs(x1 - x2);
        //Debug.Log(zoom);
        return 1f - zoom;
    }

    void OnSceneGUI()
    {
        RoundedCornerShapes shape = (RoundedCornerShapes)target;
        shape.SetupBody();

        if (shape.editModeOn)
        {
            if (Event.current.type == EventType.layout)
            {
                HandleUtility.AddDefaultControl(GUIUtility.GetControlID(GetHashCode(), FocusType.Passive));
            }


            Gizmos.color = Color.white;

            float zoom = GetSceneCameraZoom();


            //Ray rayo = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            //Vector3 pos = new Vector3(rayo.origin.x, rayo.origin.y, 0f);

            //Update mouse position
            Vector3 pos;
            Vector3 screenMousePos = new Vector3(Event.current.mousePosition.x, Camera.current.pixelHeight - Event.current.mousePosition.y);
            var plane = new Plane(Vector3.forward, shape.transform.position);
            var ray = Camera.current.ScreenPointToRay(screenMousePos);
            float hit;
            if (plane.Raycast(ray, out hit))
                pos = ray.GetPoint(hit);
            else
                return;


            if (gridSnapOn)
            {
                float xMultiplier = (int)((pos.x / snapGridSize) + 0.5f);
                pos.x = xMultiplier * snapGridSize;
                float yMultiplier = (int)((pos.y / snapGridSize) + 0.5f);
                pos.y = yMultiplier * snapGridSize;
            }

            //Gizmos.DrawWireSphere(pos, currentRadius * zoom);
            Handles.DrawWireDisc(pos, Vector3.forward, currentRadius * zoom);

            if (Event.current.type == EventType.MouseUp && Event.current.isMouse && Event.current.button == 0)
            {
                Vector3 colliderOffset = pos - shape.transform.position;
                // Add a collider at this position
                LPFixtureCircle collider = Undo.AddComponent<LPFixtureCircle>(shape.gameObject);
                collider.Radius = currentRadius;
                collider.Offset = colliderOffset;
            }


            HandleUtility.Repaint();
        }
    }

    private void LockInspectorWindow()
    {
    }

    private void ClearShape(RoundedCornerShapes shape)
    {
        shape.Clear();
    }

    private void CancelEditMode(RoundedCornerShapes shape)
    {
        shape.editModeOn = false;
    }

    private void EnableEditMode(RoundedCornerShapes shape)
    {
        shape.editModeOn = true;
    }

    private void DoGenerateShape(RoundedCornerShapes target)
    {
        Debug.Log("Begin generating colliders for " + target.name);
        target.GenerateCollider();
    }

    private void DoGenerateOutlineShape(RoundedCornerShapes target)
    {
        Debug.Log("Begin generating colliders for " + target.name);
        target.GenerateOutlineCollider();
    }
}


#endif