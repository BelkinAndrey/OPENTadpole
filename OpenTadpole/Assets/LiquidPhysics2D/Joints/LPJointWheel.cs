using UnityEngine;
using System.Collections;
using System;

/// <summary>Simulates a car wheel with suspension. It is like a revolute joint with a motor + a squishy prismatic joint to act as suspension</summary>
public class LPJointWheel : LPJoint
{
		[Tooltip("How much damping this joint has")]
		public float SpringDampingRatio = 0.6f;
	    [Tooltip("This joints natural frequency in hertz. Note: it is recommended to keep this slower than the simulation timestep")]
	    public float SpringFrequency = 4f;
		[Tooltip("vector2 representing the angle of the line of translation for the suspension element of this joint")]
		public Vector2 Axis = new Vector2(0f,1f);
		[Tooltip("Does this joint have a motor which causes the 'wheel' to rotate?")]		
		public bool HasMotor = false;
		[Tooltip("The maximum torque this joints motor can exert")]
		public float MaxMotorTorque = 500f;
		[Tooltip("The movement speed this motorised joint should try to achieve")]
		public float MotorSpeed = 1.5f;
		
		protected override void Initialise2(IntPtr world)	
		{
			Vector3 anchorA = transform.position - BodyA.transform.position;
			Vector3 anchorB = transform.position - BodyB.transform.position;
			ThingPtr = LPAPIJoint.CreateWheelJoint(world,BodyA.GetComponent<LPBody>().GetPtr(),BodyB.GetComponent<LPBody>().GetPtr()	 
			                                                  ,anchorA.x,anchorA.y,anchorB.x,anchorB.y,Axis.x,Axis.y,CollideConnected);	   
			                                                  
			LPAPIJoint.SetWheelJointSpringFrequency(ThingPtr,SpringFrequency);
			LPAPIJoint.SetWheelJointSpringDampingRatio(ThingPtr,SpringDampingRatio);                              
			if (HasMotor)
			{
				LPAPIJoint.EnableWheelJointMotor(ThingPtr,HasMotor);
				LPAPIJoint.SetWheelJointMaxMotorTorque(ThingPtr,MaxMotorTorque);
				LPAPIJoint.SetWheelJointMotorSpeed(ThingPtr,MotorSpeed);
			}
		}
		
		void OnDrawGizmos()
		{		
		Gizmos.DrawIcon(transform.position,@"LiquidPhysics2D/Icon_wheel",false);					
		}
}
