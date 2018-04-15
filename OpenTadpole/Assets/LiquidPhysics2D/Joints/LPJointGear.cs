using UnityEngine;
using System.Collections;
using System;

/// <summary>Simulates round or stright mechanical gears between two bodies</summary>
public class LPJointGear : LPJoint
{
	[Tooltip("The 1st joint component attached to this gear (Must be either revolute or prismatic)")]
	public LPJoint JointA;
	[Tooltip("The 2nd joint component attached to this gear (Must be either revolute or prismatic)")]
	public LPJoint JointB;
	[Tooltip("The mechanical gear ratio")]
	public float Ratio = 1;
	
	protected override void Initialise2(IntPtr world)	
	{		
		bool isArev = false;
		bool isBrev = false;
		
		if (JointA !=null && JointB !=null 
		    &&(JointA.GetType() == typeof(LPJointRevolute )||JointA.GetType() == typeof(LPJointPrismatic))
		    &&(JointB.GetType() == typeof(LPJointRevolute )||JointB.GetType() == typeof(LPJointPrismatic)))
		{
			if (JointA.GetType() == typeof(LPJointRevolute)) isArev = true;
			if (JointB.GetType() == typeof(LPJointRevolute)) isBrev = true;
		
			ThingPtr = LPAPIJoint.CreateGearJoint(world,BodyA.GetComponent<LPBody>().GetPtr(),BodyB.GetComponent<LPBody>().GetPtr()	 
			                                             ,JointA.GetPtr(),isArev,JointB.GetPtr(),isBrev,Ratio,CollideConnected);
        }
        else
        {
			Debug.LogError("This Gear Joint must be assigned 2 Other Joints in order to be created"
			               +", also both joints need to be a type of either LPJointRevolute or LPJointPrismatic");
        }        
	}
	
	void OnDrawGizmos()
	{		
		Gizmos.DrawIcon(transform.position,@"LiquidPhysics2D/Icon_gear",false);							
	}
}
