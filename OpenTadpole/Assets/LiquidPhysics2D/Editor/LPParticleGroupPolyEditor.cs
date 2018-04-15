using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LPParticleGroupPoly))]
public class LPParticleGroupPolyEditor : LPShapeEditor
{
	public override void OnInspectorGUI()
	{
		DrawPointsUI();
	}
}