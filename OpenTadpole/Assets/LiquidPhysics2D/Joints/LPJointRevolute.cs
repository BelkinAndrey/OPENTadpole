using UnityEngine;
using System.Collections;
using System;

/// <summary>Simulates a joint between 2 bodies that allows rotation but no translation bweteen the bodies</summary>
public class LPJointRevolute : LPJoint
{
	[Tooltip("Does this joint have a motor?")]
	public bool HasMotor = false;
	[Tooltip("The maximum torque this joints mtor can exert")]
	public float MaxMotorTorque = 500f;
	[Tooltip("The movement speed this motorised joint should try to achieve")]
	public float MotorSpeed = 1.5f;
	
	[Tooltip("Does this joint have limits?")]
	public bool HasLimits = false;
	[Tooltip("The lower limit in degrees that this joint can rotate if it has a limit")]
	public float LowerLimit = -30f;
	[Tooltip("The upper limit in degrees that this joint can rotate if it has a limit")]
	public float UpperLimit = 210f;
	
	protected override void Initialise2(IntPtr world)	
	{
		Vector3 anchorA = transform.position - BodyA.transform.position;
		Vector3 anchorB = transform.position - BodyB.transform.position;
		ThingPtr = LPAPIJoint.CreateRevoluteJoint(world,BodyA.GetComponent<LPBody>().GetPtr(),BodyB.GetComponent<LPBody>().GetPtr()
		                                  ,anchorA.x,anchorA.y,anchorB.x,anchorB.y,CollideConnected);	                                  
		if (HasMotor)
		{
			LPAPIJoint.EnableRevoluteJointMotor(ThingPtr,HasMotor);
			LPAPIJoint.SetRevoluteJointMaxMotorTorque(ThingPtr,MaxMotorTorque);
			LPAPIJoint.SetRevoluteJointMotorSpeed(ThingPtr,MotorSpeed);
		}
		
		if (HasLimits)
		{
			LPAPIJoint.EnableRevoluteJointLimits(ThingPtr,HasLimits);
			LPAPIJoint.SetRevoluteJointLimits(ThingPtr,LowerLimit*Mathf.Deg2Rad,UpperLimit*Mathf.Deg2Rad);
        }
    }

	void OnDrawGizmos()
	{
		Gizmos.DrawIcon(transform.position,@"LiquidPhysics2D/Icon_revolute",false);				
    }
}
