using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Represents a circle shaped particle group in the liquidfun simulation</summary>
public class LPParticleGroupCircle : LPParticleGroup
{	
	[Tooltip("Radius of this circle")]
	public float Radius = 0.25f;	
		
	protected override IntPtr GetShape()
	{	
		Vector3 pos =  transform.TransformPoint(Vector3.zero);
		return LPShapeCircle.Initialise(pos,Radius);
	}
	
	void OnDrawGizmos()
	{
		if(!Application.isPlaying)
		{
			LPShapeCircle.DrawGizmos(transform,true,0f,GetColors(),Radius,Vector2.zero);
        }
    }
}

