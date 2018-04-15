using UnityEngine;
using System.Collections;
using System;

public static class LPShapeCircle 
{	
	public static  IntPtr Initialise(Vector3 pos,float Radius)
	{
		return LPAPIShape.GetCircleShapeDef(Radius,pos.x,pos.y);
	}
	
	public static void DrawGizmos (Transform transform,bool tran,float diff, Color colour,float Radius,Vector2 Offset)
	{
		Gizmos.color = colour;
		Vector3 pos =  transform.TransformPoint(new Vector3(Offset.x,Offset.y));
        Gizmos.DrawWireSphere(pos,Radius);
	}
	
	public static void DrawGizmosPlaying (float radius,Transform transform,bool tran,float diff, Color colour,Vector3 Point,bool loop)
	{	
		Vector3 pos;
		Quaternion ang;
		if (tran)pos = transform.position;
		else pos = Vector3.zero;
		if (diff !=0f) ang = Quaternion.AngleAxis(diff,Vector3.forward);
		else ang = Quaternion.identity;
		
		Gizmos.matrix = Matrix4x4.TRS(pos,ang,Vector3.one); 
		Gizmos.color = colour;
		Gizmos.DrawWireSphere(Point,radius);
	}
}
