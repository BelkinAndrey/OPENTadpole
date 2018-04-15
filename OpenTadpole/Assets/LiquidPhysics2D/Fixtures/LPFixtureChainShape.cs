using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Represents a chain shaped fixture in the liquidfun simulation</summary>
public class LPFixtureChainShape : LPFixture
{
	[Tooltip("This chainshapes rotation relative to the body")]
	public float Rotation;
	[Tooltip("Should this shape form a closed loop?")]
	public bool IsLoop = false;
	
	[SerializeField][HideInInspector]
	private Vector2 LastOffset;
	[SerializeField][HideInInspector]
	private float LastRotation;	
	
	public override IntPtr GetShape()
	{
		if (pointsList == null)
		{
			pointsList = LPShapeTools.MakeEdgePoints();
		}
		PointsCopy = LPShapeTools.TransformPoints(transform,transform.position,pointsList);
		
		if (pointsList.Count > 2)
		{
			Shapetype = LPShapeTypes.ChainShape;
			return LPAPIShape.GetChainShapeDef(LPShapeTools.GetfloatArray(PointsCopy),IsLoop);
		}
		else
		{
			Shapetype = LPShapeTypes.Edge;
			return LPAPIShape.GetEdgeShapeDef(PointsCopy[0].x,PointsCopy[0].y,PointsCopy[1].x,PointsCopy[1].y);
		}

	}
	
	void OnDrawGizmos()
	{ 	
		if (Rotation != LastRotation)
		{
			pointsList = LPShapeTools.RotatePoints(pointsList,Rotation - LastRotation,new Vector3(Offset.x,Offset.y)); 
			LastRotation = Rotation;
		}		
		if (Offset != LastOffset)
		{
			pointsList = LPShapeTools.OffsetPoints(Offset -LastOffset,pointsList); 
			LastOffset = Offset;
		}
		
		if(!Application.isPlaying)
		{
			if (pointsList == null)
			{
				pointsList = LPShapeTools.MakeEdgePoints();
			}
			LPShapeTools.DrawGizmos(GetColor(),LPShapeTools.TransformPoints(transform,Vector3.zero,pointsList),IsLoop);
		}
		else
		{
			if (PointsCopy != null)
			{
				LPShapeTools.DrawGizmosPlaying(transform,true,GetComponent<LPBody>().GetDiff(),GetColor(),PointsCopy,IsLoop);
			}               
		} 
	}	
}
