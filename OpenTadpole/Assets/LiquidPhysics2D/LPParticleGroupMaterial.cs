using UnityEngine;
using System.Collections;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// Set various flags on this scriptableobject to add various properties to the particle group associated with it</summary>
public class LPParticleGroupMaterial : ScriptableObject
{
	[Tooltip("Prevents overlapping or leaking")]
	public bool	solid;
	[Tooltip("Keeps its shape")]
	public bool rigid;
	
	public Int32 GetInt()
	{
		Int32 num = 0;
		if (solid)
		{
			num |= (Int32)b2ParticleGroupFlag.b2_solidParticleGroup;
		}
		if (rigid)
		{
			num |= (Int32)b2ParticleGroupFlag.b2_rigidParticleGroup;
		}		
		return num;
	}
}