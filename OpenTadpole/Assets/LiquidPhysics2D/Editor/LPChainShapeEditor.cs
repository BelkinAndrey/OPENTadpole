using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(LPFixtureChainShape))]
public class LPChainShapeEditor : LPShapeEditor
{
	public override void OnInspectorGUI()
	{
		DrawPointsUI();
	}
}



