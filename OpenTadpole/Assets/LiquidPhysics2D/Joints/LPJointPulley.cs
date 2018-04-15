using UnityEngine;
using System.Collections;
using System;

/// <summary>Simulates a joint connecting two bodies with a pulley system</summary>
public class LPJointPulley : LPJoint
{
	[Tooltip("The mechanical ratio of the pulley")]
	public float ratio = 1f;
	[Tooltip("Offset of BodyA's connection point to the pulley from the joint position")]
	public Vector2 BodyAGroundOffset = new Vector2(-1f,0f);
	[Tooltip("Offset of BodyB's connection point to the pulley from the joint position")]
	public Vector2 BodyBGroundOffset = new Vector2(1f,0f);
	[Tooltip("Offset of the anchor point of this joint on bodyA relative to the body position")]
	public Vector2 BodyAAnchorOffset = Vector2.zero;
	[Tooltip("Offset of the anchor point of this joint on bodyB relative to the body position")]
	public Vector2 BodyBAnchorOffset = Vector2.zero;
	
	protected override void Initialise2(IntPtr world)	
	{		
		Vector3 groundA = (transform.position + new Vector3(BodyAGroundOffset.x,BodyAGroundOffset.y));
		Vector3 groundB = (transform.position + new Vector3(BodyBGroundOffset.x,BodyBGroundOffset.y));
		float lenghtA = (BodyA.transform.position - groundA).magnitude; 
		float lenghtB = (BodyB.transform.position - groundB).magnitude;
		
		ThingPtr = LPAPIJoint.CreatePulleyJoint(world,BodyA.GetComponent<LPBody>().GetPtr(),BodyB.GetComponent<LPBody>().GetPtr()	 
		                                                 ,groundA.x,groundA.y,groundB.x,groundB.y
		                                        		,BodyAAnchorOffset.x,BodyAAnchorOffset.y
		                                        		,BodyBAnchorOffset.x,BodyBAnchorOffset.y,ratio,lenghtA,lenghtB,CollideConnected);	            
	}
	
	
	void OnDrawGizmos()
	{			
		Gizmos.color = LPColors.Joint;	
		Gizmos.DrawLine(transform.position+(Vector3)BodyAGroundOffset ,transform.position+(Vector3)BodyBGroundOffset);		
		Gizmos.DrawWireSphere(transform.position+(Vector3)BodyAGroundOffset,0.15f);
		
		Gizmos.DrawLine(transform.position+(Vector3)BodyAGroundOffset,BodyA.transform.position+
		 LPShapeTools.RotatePoint((Vector3)BodyAAnchorOffset,BodyA.transform.rotation.eulerAngles.z,Vector3.zero));
		 			
		Gizmos.DrawWireSphere(transform.position+(Vector3)BodyBGroundOffset,0.15f);
		
		Gizmos.DrawLine(transform.position+(Vector3)BodyBGroundOffset ,BodyB.transform.position
		+ LPShapeTools.RotatePoint((Vector3)BodyBAnchorOffset,BodyB.transform.rotation.eulerAngles.z,Vector3.zero));
		
		Gizmos.DrawIcon(transform.position,@"LiquidPhysics2D/Icon_pulley",false);							
	}
}
