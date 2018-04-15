using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LPFixturePoly))]
public class LPFixturePolyEditor : LPShapeEditor
{
	public override void OnInspectorGUI()
	{
		DrawPointsUI();
	}
}
