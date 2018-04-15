using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Represents a box shaped fixture in the liquidfun simulation</summary>
public class LPFixtureBox : LPFixture
{
	[Tooltip("This boxes dimensions")]
	public Vector2 Size = new Vector2(0.5f,0.5f);
	[Tooltip("This boxes rotation relative to the body")]
	public float Rotation;
	
	[SerializeField][HideInInspector]
	private Vector2 LastOffset;
	[SerializeField][HideInInspector]
	private float LastRotation;
	
	[SerializeField][HideInInspector]
	private Vector2 LastSize;
	
	public override IntPtr GetShape()
	{
		Shapetype = LPShapeTypes.Polygon;	
		if (pointsList == null)
		{
			pointsList = LPShapeTools.MakeBoxPoints(Size);
		}
		PointsCopy = LPShapeTools.TransformPoints(transform,transform.position,pointsList);
		return LPShapeTools.Initialise(PointsCopy);
	}
	
	void OnDrawGizmos()
	{ 	
		if (Size != LastSize)
		{
			pointsList = LPShapeTools.MakeBoxPoints(Size);
			LastRotation = 0f;
			LastOffset = Vector2.zero;
			LastSize = Size;
		}
		
		if (Offset != LastOffset)
		{
			pointsList = LPShapeTools.OffsetPoints(Offset -LastOffset,pointsList); 
			LastOffset = Offset;
		}
		
		if (Rotation != LastRotation)
		{
			pointsList = LPShapeTools.RotatePoints(pointsList,Rotation - LastRotation, new Vector3(Offset.x,Offset.y)); 
			LastRotation = Rotation;
		}		

		
		if(!Application.isPlaying)
		{
			if (pointsList == null)
			{
				pointsList = LPShapeTools.MakeBoxPoints(Size);
			}
			LPShapeTools.DrawGizmos(GetColor(),LPShapeTools.TransformPoints(transform,Vector3.zero,pointsList),true);
		}
		else
		{
			LPShapeTools.DrawGizmosPlaying(transform,true,GetComponent<LPBody>().GetDiff(),GetColor(),PointsCopy,true);
		} 
	}	
}
