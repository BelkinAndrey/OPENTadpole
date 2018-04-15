using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

public class RoundedCornerShapes : MonoBehaviour
{
    public bool editModeOn = false;

    LPManager lpManager;
    LPBody body;
    LPFixturePoly polyFixture = null;
    public bool waitAfterClick = false;

	// Use this for initialization
	void Awake () 
    {
        lpManager = FindObjectOfType<LPManager>();
        if (SceneView.currentDrawingSceneView != null)
        {
            SceneView.currentDrawingSceneView.wantsMouseMove = true;
        }

        SetupBody();
	}

    public void SetupBody()
    {
        body = GetComponent<LPBody>();
        if (body == null)
        {
            body = gameObject.AddComponent<LPBody>();
            //body.Initialise(lpManager);
        }
    }

    public void GenerateCollider()
    {
        Undo.SetCurrentGroupName("Undo generate filled shape.");
        int undoGroup = Undo.GetCurrentGroup();

        foreach (LPFixturePoly fix in GetComponents<LPFixturePoly>())
        {
            Undo.DestroyObjectImmediate(fix);
        }
        LPFixtureCircle[] circles = GetComponents<LPFixtureCircle>();
        
        if (circles.Length < 2)
        {
            return;
        }

        int currentPoint = 0;
        Vector3[] points = new Vector3[circles.Length*2];
        for (int i = 0; i < circles.Length; i++)
        {
            //Vector3 diff = circles[i].Offset - circles[(i + 1) % circles.Length].Offset;
            //diff.Normalize();

            //Vector3 rightAngleVector = new Vector3(diff.y, -diff.x, 0f);
            //Vector3 tangentPoint1 = new Vector3(circles[i].Offset.x, circles[i].Offset.y) + (rightAngleVector * circles[i].Radius);
            //Vector3 tangentPoint2 = new Vector3(circles[(i + 1) % circles.Length].Offset.x, circles[(i + 1) % circles.Length].Offset.y) 
            //                                        + (rightAngleVector * circles[(i + 1) % circles.Length].Radius);
            Vector2 outerPoint1 = new Vector2();
            Vector2 outerPoint2 = new Vector2();
            Vector2 outerPoint3 = new Vector2();
            Vector2 outerPoint4 = new Vector2();
            
            Vector2 innerDummy = new Vector2();

            CircleTangents.FindCircleCircleTangents(circles[i].Offset, circles[i].Radius, circles[(i + 1) % circles.Length].Offset, circles[(i + 1) % circles.Length].Radius,
                                                    out outerPoint1, out outerPoint2, out outerPoint3, out outerPoint4, out innerDummy, out innerDummy, out innerDummy, out innerDummy);

            points[currentPoint] = outerPoint1;
            points[currentPoint + 1] = outerPoint2;
            currentPoint += 2;
        }



        // add the actual collider
        if (polyFixture == null)
        {
            polyFixture = Undo.AddComponent<LPFixturePoly>(gameObject);
        }

        //Call DefinePoints to set the polys points programmatically
        polyFixture.DefinePoints(points);

    #if UNITY_EDITOR
        gameObject.layer = 8;
        EditorUtility.SetDirty(gameObject);
    #endif
    }

    public void GenerateOutlineCollider()
    {
        Undo.SetCurrentGroupName("Undo generate outline.");
        int undoGroup = Undo.GetCurrentGroup();

        foreach (LPFixturePoly fix in GetComponents<LPFixturePoly>())
        {
            Undo.DestroyObjectImmediate(fix);
        }
        LPFixtureCircle[] circles = GetComponents<LPFixtureCircle>();

        if (circles.Length < 2)
        {
            return;
        }

        int numberOfPolys = circles.Length - 1; // Must use seperate polygons because otherwise the edges will intersect creating a complex shape
                                                // Each shape has 4 points

        Vector3[][] shapes = new Vector3[numberOfPolys][];
        for (int i = 0; i < numberOfPolys; i++)
        {
            shapes[i] = new Vector3[4];
        }

        for (int i = 0; i < circles.Length-1; i++)
        {
            Vector2 outerPoint1 = new Vector2();
            Vector2 outerPoint2 = new Vector2();
            Vector2 outerPoint3 = new Vector2();
            Vector2 outerPoint4 = new Vector2();

            Vector2 innerDummy = new Vector2();

            CircleTangents.FindCircleCircleTangents(circles[i].Offset, circles[i].Radius, circles[(i + 1)].Offset, circles[(i + 1)].Radius,
                                                    out outerPoint1, out outerPoint2, out outerPoint3, out outerPoint4, out innerDummy, out innerDummy, out innerDummy, out innerDummy);

            shapes[i][0] = outerPoint1;
            shapes[i][1] = outerPoint2;
        }

        for (int i = circles.Length-1; i > 0; i--)
        {
            Vector2 outerPoint1 = new Vector2();
            Vector2 outerPoint2 = new Vector2();
            Vector2 outerPoint3 = new Vector2();
            Vector2 outerPoint4 = new Vector2();

            Vector2 innerDummy = new Vector2();

            CircleTangents.FindCircleCircleTangents(circles[i].Offset, circles[i].Radius, circles[(i - 1)].Offset, circles[(i - 1)].Radius,
                                                    out outerPoint1, out outerPoint2, out outerPoint3, out outerPoint4, out innerDummy, out innerDummy, out innerDummy, out innerDummy);


            shapes[i-1][2] = outerPoint1;
            shapes[i-1][3] = outerPoint2;
        }

        foreach (Vector3[] shape in shapes)
        {
            // add the actual collider
            polyFixture = Undo.AddComponent<LPFixturePoly>(gameObject);

            //Call DefinePoints to set the polys points programmatically
            polyFixture.DefinePoints(shape);
        }

        gameObject.layer = 8;
        EditorUtility.SetDirty(gameObject);

        Undo.CollapseUndoOperations(undoGroup);
    }

    internal void Clear()
    {
        Undo.SetCurrentGroupName("Clear rounded shape.");
        int undoGroup = Undo.GetCurrentGroup();

        LPFixture[] fixtures = gameObject.GetComponents<LPFixture>();
        foreach (LPFixture fix in fixtures)
        {
            Undo.DestroyObjectImmediate(fix);
        }

        Undo.CollapseUndoOperations(undoGroup);
    }
}

#endif