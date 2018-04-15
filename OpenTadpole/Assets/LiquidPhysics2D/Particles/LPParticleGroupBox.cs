using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Represents a box shaped particle group in the liquidfun simulation</summary>
public class LPParticleGroupBox : LPParticleGroup
{	
	[Tooltip("This boxes dimensions")]
	public Vector2 Size = new Vector2(0.5f,0.5f);
	[Tooltip("This boxes rotation relative to the body")]
	public float Rotation;
	
	[SerializeField][HideInInspector]
	private float LastRotation;
	
	[SerializeField][HideInInspector]
	private Vector2 LastSize;
	
	protected override IntPtr GetShape()
	{
		if (pointsList == null)
		{
			pointsList = LPShapeTools.MakeBoxPoints(Size);
		}
		PointsCopy = LPShapeTools.TransformPoints(transform,Vector3.zero,pointsList);
		
		return LPShapeTools.Initialise(PointsCopy);
	}
	
	void OnDrawGizmos()
	{ 	
		if (Size != LastSize)
		{
			pointsList = LPShapeTools.MakeBoxPoints(Size);
			LastRotation = 0f;
			LastSize = Size;
		}
		
		if (Rotation != LastRotation)
		{
			pointsList = LPShapeTools.RotatePoints(pointsList,Rotation - LastRotation,Vector3.zero); 
			LastRotation = Rotation;
		}		
		
		if(!Application.isPlaying)
		{
			if (pointsList == null)
			{
				pointsList = LPShapeTools.MakeBoxPoints(Size);
			}
			LPShapeTools.DrawGizmos(GetColors(),LPShapeTools.TransformPoints(transform,Vector3.zero,pointsList),true);
		}
	}	
}