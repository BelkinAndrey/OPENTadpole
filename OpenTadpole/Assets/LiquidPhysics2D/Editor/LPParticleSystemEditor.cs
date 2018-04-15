using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(LPParticleSystem))]
public class LPParticleSystemEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		LPParticleSystem sys = (LPParticleSystem)target;
		if(GUILayout.Button("Save"))
		{
			sys.Save();
		}
	}
}