using UnityEngine;
using System.Collections;
using System;

/// <summary>This joint creates friction between the two bodies. Can be used to approximate a 'top down' view</summary>
public class LPJointFriction : LPJoint
{	
	[Tooltip("maximum force for this joint")]
	public float MaximumForce = 10f;
	[Tooltip("maximum torque for this joint")]
	public float MaximumTorque = 10f;
	
	protected override void Initialise2(IntPtr world)	
	{		
		Vector3 anchorA = Vector3.zero;
		Vector3 anchorB = Vector3.zero;
		
		ThingPtr = LPAPIJoint.CreateFrictionJoint(world,BodyA.GetComponent<LPBody>().GetPtr(),BodyB.GetComponent<LPBody>().GetPtr()	 
		                                             ,anchorA.x,anchorA.y,anchorB.x,anchorB.y,CollideConnected);
		                                             
		LPAPIJoint.SetFrictionJointMaxForce(ThingPtr,MaximumForce);
		LPAPIJoint.SetFrictionJointMaxTorque(ThingPtr,MaximumTorque);
		
	}
	
	void OnDrawGizmos()
	{		
		Gizmos.DrawIcon(transform.position,@"LiquidPhysics2D/Icon_friction",false);							
    }
}
