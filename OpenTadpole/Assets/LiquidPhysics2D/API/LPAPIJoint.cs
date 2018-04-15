using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun joints</summary>
public static class LPAPIJoint
{

    #region RevoluteJoints
    #region CreateRevoluteJoint
    /**
	* <summary>Creates a new Revolute Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="anchorAX">The local anchor point relative to bodyA's origin. X position.</param>
	* <param name="anchorAY">The local anchor point relative to bodyA's origin. Y position.</param>
	* <param name="anchorBX">The local anchor point relative to bodyB's origin. X position.</param>
	* <param name="anchorBY">The local anchor point relative to bodyB's origin. Y position.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateRevoluteJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float anchorAX, float anchorAY, float anchorBX, float anchorBY, bool collideConnected);
    #endregion CreateRevoluteJoint
    #region SetRevoluteJointLimits
    /**
	* <summary>Set the joint limits in radians.</summary>
	* <param name="joint">The joint who's limits will be set.</param>
	* <param name="lowerLimit">The lower limit.</param>
	* <param name="lowerLimit">The upper limit.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetRevoluteJointLimits(IntPtr joint, float lowerLimit, float upperLimit);
    #endregion SetRevoluteJointLimits
    #region SetRevoluteJointMotorSpeed
    /**
	* <summary>Set the joint motor speed in radians per second.</summary>
	* <param name="joint">The joint who's speed will be set.</param>
	* <param name="speed">The motor speed.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetRevoluteJointMotorSpeed(IntPtr joint, float speed);
    #endregion SetRevoluteJointMotorSpeed
    #region SetRevoluteJointMaxMotorTorque
    /**
	* <summary>Set the joint max motor torque.</summary>
	* <param name="joint">The joint who's motor torque will be set.</param>
	* <param name="torque">The max motor torque.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetRevoluteJointMaxMotorTorque(IntPtr joint, float torque);
    #endregion SetRevoluteJointMaxMotorTorque
    #region EnableRevoluteJointMotor
    /**
	* <summary>Enable/disable the joint motor.</summary>
	* <param name="joint">The joint who's motor will be set.</param>
	* <param name="isEnabled">Is the motor enabled?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void EnableRevoluteJointMotor(IntPtr joint, bool isEnabled);
    #endregion EnableRevoluteJointMotor
    #region EnableRevoluteJointLimits
    /**
	* <summary>Enable/disable the joint limit.</summary>
	* <param name="joint">The joint who's limits will be set.</param>
	* <param name="isLimited">Is the joint limited?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void EnableRevoluteJointLimits(IntPtr joint, bool isLimited);
    #endregion EnableRevoluteJointLimits
    #region GetRevoluteJointUpperLimit
    /**
	* <summary>Returns the upper limit of a revolute joint.</summary>
	* <param name="joint">The joint who's limit will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetRevoluteJointUpperLimit(IntPtr joint);
    #endregion GetRevoluteJointUpperLimit
    #region GetRevoluteJointLowerLimit
    /**
	* <summary>Returns the lower limit of a revolute joint.</summary>
	* <param name="joint">The joint who's limit will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetRevoluteJointLowerLimit(IntPtr joint);
    #endregion GetRevoluteJointLowerLimit
    #region IsRevoluteJointMotorEnabled
    /**
	* <summary>Returns true if the motor is enabled, and false if it isn't.</summary>
	* <param name="joint">The joint who's motor status will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern bool IsRevoluteJointMotorEnabled(IntPtr joint);
    #endregion IsRevoluteJointMotorEnabled
    #region GetRevoluteJointMotorSpeed
    /**
	* <summary>Returns the motor speed of a revolute joint.</summary>
	* <param name="joint">The joint who's motor speed will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetRevoluteJointMotorSpeed(IntPtr joint);
    #endregion GetRevoluteJointMotorSpeed
    #region GetRevoluteJointMotorTorque
    /**
	* <summary>Get the current motor torque given the inverse time step. Unit is N*m.</summary>
	* <param name="joint">The joint who's torque will be returned.</param>
	* <param name="inverseDeltaTime">The inverse time step.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetRevoluteJointMotorTorque(IntPtr joint, float inverseDeltaTime);
    #endregion GetRevoluteJointMotorTorque
    #region GetRevoluteJointMaxMotorTorque
    /**
	* <summary>Returns the max motor torque of a revolute joint.</summary>
	* <param name="joint">The joint who's max motor torque will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetRevoluteJointMaxMotorTorque(IntPtr joint);
    #endregion GetRevoluteJointMaxMotorTorque
    #endregion RevoluteJoints

    #region DistanceJoints
    #region CreateDistanceJoint
    /**
	* <summary>Creates a new Distance Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="anchorAX">The local anchor point relative to bodyA's origin. X position.</param>
	* <param name="anchorAY">The local anchor point relative to bodyA's origin. Y position.</param>
	* <param name="anchorBX">The local anchor point relative to bodyB's origin. X position.</param>
	* <param name="anchorBY">The local anchor point relative to bodyB's origin. Y position.</param>
	* <param name="length">The joint length.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateDistanceJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float anchorAX, float anchorAY, float anchorBX, float anchorBY, float length, bool collideConnected);
    #endregion CreateDistanceJoint
    #region SetDistanceJointFrequency
    /**
	* <summary>Set the joint frequency in hertz.</summary>
	* <param name="joint">The joint who's frequency will be set.</param>
	* <param name="frequency">The frequency in hertz.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetDistanceJointFrequency(IntPtr joint, float frequency);
    #endregion SetDistanceJointFrequency
    #region GetDistanceJointFrequency
    /**
	* <summary>Get the joint frequency in hertz.</summary>
	* <param name="joint">The joint who's frequency will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetDistanceJointFrequency(IntPtr joint);
    #endregion GetDistanceJointFrequency
    #region SetDistanceJointDampingRatio
    /**
	* <summary>Set the joint damping ratio.</summary>
	* <param name="joint">The joint who's damping ratio will be set.</param>
	* <param name="dampingRatio">The damping ratio.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetDistanceJointDampingRatio(IntPtr joint, float dampingRatio);
    #endregion SetDistanceJointDampingRatio
    #region GetDistanceJointDampingRatio
    /**
	* <summary>Get the joint damping ratio.</summary>
    * <param name="joint">The joint who's damping ratio will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetDistanceJointDampingRatio(IntPtr joint);
    #endregion GetDistanceJointDampingRatio
    #region SetDistanceJointLength
    /**
	* <summary>Set the joint length.</summary>
	* <param name="joint">The joint who's length will be set.</param>
	* <param name="length">The length.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetDistanceJointLength(IntPtr joint, float length);
    #endregion SetDistanceJointLength
    #region GetDistanceJointLength
    /**
	* <summary>Get the joint length.</summary>
	* <param name="joint">The joint who's length will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetDistanceJointLength(IntPtr joint);
    #endregion GetDistanceJointLength
    #endregion DistanceJoints

    #region PrismaticJoints
    #region CreatePrismaticJoint
    /**
	* <summary>Creates a new Revolute Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="anchorAX">The local anchor point relative to bodyA's origin. X position.</param>
	* <param name="anchorAY">The local anchor point relative to bodyA's origin. Y position.</param>
	* <param name="anchorBX">The local anchor point relative to bodyB's origin. X position.</param>
	* <param name="anchorBY">The local anchor point relative to bodyB's origin. Y position.</param>
	* <param name="axisX">The local joint axis relative to bodyA. X component.</param>
	* <param name="axisY">The local joint axis relative to bodyA. Y component.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreatePrismaticJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float anchorAX, float anchorAY, float anchorBX, float anchorBY, float axisX, float axisY, bool collideConnected);
    #endregion CreatePrismaticJoint
    #region SetPrismaticJointLimits
    /**
	* <summary>Set the joint limits in radians.</summary>
	* <param name="joint">The joint who's limits will be set.</param>
	* <param name="lowerLimit">The lower limit.</param>
	* <param name="lowerLimit">The upper limit.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetPrismaticJointLimits(IntPtr joint, float lowerLimit, float upperLimit);
    #endregion SetPrismaticJointLimits
    #region SetPrismaticJointMotorSpeed
    /**
	* <summary>Set the joint motor speed in radians per second.</summary>
	* <param name="joint">The joint who's speed will be set.</param>
	* <param name="speed">The motor speed.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetPrismaticJointMotorSpeed(IntPtr joint, float speed);
    #endregion SetPrismaticJointMotorSpeed
    #region SetPrismaticJointMaxMotorForce
    /**
	* <summary>Set the joint max motor force.</summary>
	* <param name="joint">The joint who's motor force will be set.</param>
	* <param name="force">The max motor force.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetPrismaticJointMaxMotorForce(IntPtr joint, float force);
    #endregion SetPrismaticJointMaxMotorForce
    #region EnablePrismaticJointMotor
    /**
	* <summary>Enable/disable the joint motor.</summary>
	* <param name="joint">The joint who's motor will be set.</param>
	* <param name="isEnabled">Is the motor enabled?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void EnablePrismaticJointMotor(IntPtr joint, bool isEnabled);
    #endregion EnablePrismaticJointMotor
    #region EnablePrismaticJointLimits
    /**
	* <summary>Enable/disable the joint limit.</summary>
	* <param name="joint">The joint who's limits will be set.</param>
	* <param name="isLimited">Is the joint limited?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void EnablePrismaticJointLimits(IntPtr joint, bool isLimited);
    #endregion EnablePrismaticJointLimits
    #region GetPrismaticJointUpperLimit
    /**
	* <summary>Returns the upper limit of a Prismatic joint.</summary>
	* <param name="joint">The joint who's limit will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPrismaticJointUpperLimit(IntPtr joint);
    #endregion GetPrismaticJointUpperLimit
    #region GetPrismaticJointLowerLimit
    /**
	* <summary>Returns the lower limit of a Prismatic joint.</summary>
	* <param name="joint">The joint who's limit will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPrismaticJointLowerLimit(IntPtr joint);
    #endregion GetPrismaticJointLowerLimit
    #region IsPrismaticJointMotorEnabled
    /**
	* <summary>Returns true if the motor is enabled, and false if it isn't.</summary>
	* <param name="joint">The joint who's motor status will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern bool IsPrismaticJointMotorEnabled(IntPtr joint);
    #endregion IsPrismaticJointMotorEnabled
    #region GetPrismaticJointMotorSpeed
    /**
	* <summary>Returns the motor speed of a Prismatic joint.</summary>
	* <param name="joint">The joint who's motor speed will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPrismaticJointMotorSpeed(IntPtr joint);
    #endregion GetPrismaticJointMotorSpeed
    
    #region GetPrismaticJointMotorForce
    /**
	* <summary>Get the current motor force given the inverse time step.</summary>
	* <param name="joint">The joint who's force will be returned.</param>
	* <param name="inverseDeltaTime">The inverse time step.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPrismaticJointMotorForce(IntPtr joint, float inverseDeltaTime);
    #endregion GetPrismaticJointMotorforce
    #region GetPrismaticJointMaxMotorForce
    /**
	* <summary>Returns the max motor force of a Prismatic joint.</summary>
	* <param name="joint">The joint who's max motor force will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPrismaticJointMaxMotorForce(IntPtr joint);
    #endregion GetPrismaticJointMaxMotorForce
    #region GetPrismaticJointSpeed
    /**
	* <summary>Returns the speed of a Prismatic joint.</summary>
	* <param name="joint">The joint who's speed will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPrismaticJointSpeed(IntPtr joint);
    #endregion GetPrismaticJointSpeed
    #endregion PrismaticJoints

    #region PulleyJoints
    #region CreatePulleyJoint
    /**
	* <summary>Creates a new Pulley Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="groundAnchorAX">The first ground anchor. X position.</param>
	* <param name="groundAnchorAY">The first ground anchor. Y position.</param>
	* <param name="groundAnchorBX">The second ground anchor. X position.</param>
	* <param name="groundAnchorBY">The second ground anchor. Y position.</param>
	* <param name="anchorAX">The local anchor point on bodyA. X position.</param>
	* <param name="anchorAY">The local anchor point on bodyA. Y position.</param>
	* <param name="anchorBX">The local anchor point on bodyB. X position.</param>
	* <param name="anchorBY">The local anchor point on bodyB. Y position.</param>
	* <param name="ratio">The pulley ratio.</param>
	* <param name="lengthA">Length A.</param>
	* <param name="lengthB">Length B.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreatePulleyJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float groundAnchorAX, float groundAanchorAY, float groundAnchorBX, float groundAanchorBY, float anchorAX, float anchorAY, float anchorBX, float anchorBY, float ratio, float lengthA, float lengthB, bool collideConnect);
    #endregion CreatePulleyJoint
    #region GetPulleyJointLengthA
    /**
	* <summary>Current A length of the joint.</summary>
	* <param name="joint">The joint who's length will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPulleyJointLengthA(IntPtr joint);
    #endregion GetPulleyJointLengthA
    #region GetPulleyJointLengthB
    /**
	* <summary>Current B length of the joint.</summary>
	* <param name="joint">The joint who's length will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetPulleyJointLengthB(IntPtr joint);
    #endregion GetPulleyJointLengthB
    #endregion PulleyJoints

    #region GearJoints
    #region CreateGearJoint
    /**
	* <summary>Creates a new Gear Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="jointA">First joint connected to the gear. Can be revolute or prismatic.</param>
	* <param name="isJointARevolute">Set to true if jointA is a revolute joint. False if it is prismatic.</param>
	* <param name="jointB">Second joint connected to the gear. Can be revolute or prismatic.</param>
	* <param name="isJointBRevolute">Set to true if jointA is a revolute joint. False if it is prismatic.</param>
	* <param name="ratio">A gear ratio to bind the motions together. Can be negative or positive.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateGearJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, IntPtr jointA, bool isJointARevolute, IntPtr jointB, bool isJointBRevolute, float ratio, bool collideConnected);
    #endregion CreateGearJoint
    #region SetGearJointRatio
    /**
	* <summary>Set the ratio of a Gear joint.</summary>
	* <param name="joint">The joint who's ratio will be set.</param>
	* <param name="ratio">The joint ratio.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetGearJointRatio(IntPtr joint, float ratio);
    #endregion SetGearJointRatio
    #region GetGearJointRatio
    /**
	* <summary>Get the ratio of a Gear joint.</summary>
	* <param name="joint">The joint who's ratio will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetGearJointRatio(IntPtr joint);
    #endregion GetGearJointRatio
    #endregion GearJoints

    #region WheelJoints
    #region CreateWheelJoint
    /**
	* <summary>Creates a new Wheel Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="anchorAX">The local anchor point on bodyA. X position.</param>
	* <param name="anchorAY">The local anchor point on bodyA. Y position.</param>
	* <param name="anchorBX">The local anchor point on bodyB. X position.</param>
	* <param name="anchorBY">The local anchor point on bodyB. Y position.</param>
	* <param name="axisX">Axis of freedom. X component.</param>
	* <param name="axisY">Axis of freedom. Y component.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateWheelJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float anchorAX, float anchorAY, float anchorBX, float anchorBY, float axisA, float axisB, bool collideConnect);
    #endregion CreateWheelJoint
    #region SetWheelJointMotorSpeed
    /**
	* <summary>Set the joint motor speed in radians per second.</summary>
	* <param name="joint">The joint who's speed will be set.</param>
	* <param name="speed">The motor speed.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetWheelJointMotorSpeed(IntPtr joint, float speed);
    #endregion SetWheelJointMotorSpeed
    #region SetWheelJointMaxMotorTorque
    /**
	* <summary>Set the joint max motor torque.</summary>
	* <param name="joint">The joint who's motor torque will be set.</param>
	* <param name="torque">The max motor torque.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetWheelJointMaxMotorTorque(IntPtr joint, float torque);
    #endregion SetWheelJointMaxMotorTorque
    #region EnableWheelJointMotor
    /**
	* <summary>Enable/disable the joint motor.</summary>
	* <param name="joint">The joint who's motor will be set.</param>
	* <param name="isEnabled">Is the motor enabled?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void EnableWheelJointMotor(IntPtr joint, bool isEnabled);
    #endregion EnableWheelJointMotor
    #region IsWheelJointMotorEnabled
    /**
	* <summary>Returns true if the motor is enabled, and false if it isn't.</summary>
	* <param name="joint">The joint who's motor status will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern bool IsWheelJointMotorEnabled(IntPtr joint);
    #endregion IsWheelJointMotorEnabled
    #region GetWheelJointMotorSpeed
    /**
	* <summary>Returns the motor speed of a wheel joint.</summary>
	* <param name="joint">The joint who's motor speed will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetWheelJointMotorSpeed(IntPtr joint);
    #endregion GetWheelJointMotorSpeed
    #region GetWheelJointMotorTorque
    /**
	* <summary>Get the current motor torque given the inverse time step. Unit is N*m.</summary>
	* <param name="joint">The joint who's torque will be returned.</param>
	* <param name="inverseDeltaTime">The inverse time step.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetWheelJointMotorTorque(IntPtr joint, float inverseDeltaTime);
    #endregion GetWheelJointMotorTorque
    #region GetWheelJointMaxMotorTorque
    /**
	* <summary>Returns the max motor torque of a wheel joint.</summary>
	* <param name="joint">The joint who's max motor torque will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetWheelJointMaxMotorTorque(IntPtr joint);
    #endregion GetWheelJointMaxMotorTorque
    #region SetWheelJointSpringDampingRatio
    /**
	* <summary>Sets the spring damping ratio of a wheel joint.</summary>
	* <param name="joint">The joint who's damping ratio will be set.</param>
	* <param name="ratio">The damping ratio.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetWheelJointSpringDampingRatio(IntPtr joint, float ratio);
    #endregion SetWheelJointSpringDampingRatio
    #region GetWheelJointSpringDampingRatio
    /**
	* <summary>Returns the spring damping ratio of a wheel joint.</summary>
	* <param name="joint">The joint who's damping ratio will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetWheelJointSpringDampingRatio(IntPtr joint);
    #endregion GetWheelJointSpringDampingRatio
    #region SetWheelJointSpringFrequency
    /**
	* <summary>Sets the frequency (hertz) of a wheel joint.</summary>
	* <param name="joint">The joint who's frequency will be set.</param>
	* <param name="frequency">The frequency (hertz).</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetWheelJointSpringFrequency(IntPtr joint, float frequency);
    #endregion SetWheelJointSpringFrequency
    #region GetWheelJointSpringFrequency
    /**
	* <summary>Returns the frequency (hertz) of a wheel joint.</summary>
	* <param name="joint">The joint who's frequency will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetWheelJointSpringFrequency(IntPtr joint);
    #endregion GetWheelJointSpringFrequency
    #endregion WheelJoints

    #region WeldJoints
    #region CreateWeldJoint
    /**
	* <summary>Creates a new Weld Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="anchorAX">The local anchor point relative to bodyA's origin. X position.</param>
	* <param name="anchorAY">The local anchor point relative to bodyA's origin. Y position.</param>
	* <param name="anchorBX">The local anchor point relative to bodyB's origin. X position.</param>
	* <param name="anchorBY">The local anchor point relative to bodyB's origin. Y position.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateWeldJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float anchorAX, float anchorAY, float anchorBX, float anchorBY, bool collideConnected);
    #endregion CreateWeldJoint
    #region SetWeldJointDampingRatio
    /**
	* <summary>Sets the damping ratio of a weld joint.</summary>
	* <param name="joint">The joint who's damping ratio will be set.</param>
	* <param name="ratio">The damping ratio.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetWeldJointDampingRatio(IntPtr joint, float ratio);
    #endregion SetWeldJointDampingRatio
    #region GetWeldJointDampingRatio
    /**
	* <summary>Returns the damping ratio of a weld joint.</summary>
	* <param name="joint">The joint who's damping ratio will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetWeldJointDampingRatio(IntPtr joint);
    #endregion GetWeldJointDampingRatio
    #region SetWeldJointFrequency
    /**
	* <summary>Sets the frequency (hertz) of a weld joint.</summary>
	* <param name="joint">The joint who's frequency will be set.</param>
	* <param name="frequency">The frequency (hertz).</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetWeldJointFrequency(IntPtr joint, float frequency);
    #endregion SetWeldJointFrequency
    #region GetWeldJointFrequency
    /**
	* <summary>Returns the frequency (hertz) of a weld joint.</summary>
	* <param name="joint">The joint who's frequency will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetWeldJointFrequency(IntPtr joint);
    #endregion GetWeldJointFrequency
    #endregion WeldJoints

    #region FrictionJoint
    #region CreateFrictionJoint
    /**
	* <summary>Creates a new Friction Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="anchorAX">The local anchor point relative to bodyA's origin. X position.</param>
	* <param name="anchorAY">The local anchor point relative to bodyA's origin. Y position.</param>
	* <param name="anchorBX">The local anchor point relative to bodyB's origin. X position.</param>
	* <param name="anchorBY">The local anchor point relative to bodyB's origin. Y position.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateFrictionJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float anchorAX, float anchorAY, float anchorBX, float anchorBY, bool collideConnected);
    #endregion CreateFrictionJoint
    #region GetFrictionJointMaxTorque
    /**
	* <summary>Get the maximum torque.</summary>
	* <param name="joint">The joint who's max torque will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetFrictionJointMaxTorque(IntPtr joint);
    #endregion GetFrictionJointMaxTorque
    #region SetFrictionJointMaxTorque
    /**
	* <summary>Set the maximum torque.</summary>
	* <param name="joint">The joint who's max torque will be set.</param>
	* <param name="torque">The max torque.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetFrictionJointMaxTorque(IntPtr joint, float torque);
    #endregion SetFrictionJointMaxTorque
    #region GetFrictionJointMaxForce
    /**
	* <summary>Get the maximum force.</summary>
	* <param name="joint">The joint who's max force will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetFrictionJointMaxForce(IntPtr joint);
    #endregion GetFrictionJointMaxForce
    #region SetFrictionJointMaxForce
    /**
	* <summary>Set the maximum force.</summary>
	* <param name="joint">The joint who's max force will be set.</param>
	* <param name="force">The max force.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetFrictionJointMaxForce(IntPtr joint, float force);
    #endregion SetFrictionJointMaxForce
    #endregion FrictionJoint

    #region RopeJoints
    #region CreateRopeJoint
    /**
	* <summary>Creates a new Rope Joint and returns an IntPtr containing its memory address.</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body.</param>
	* <param name="bodyB">Second body.</param>
	* <param name="anchorAX">The local anchor point on bodyA. X position.</param>
	* <param name="anchorAY">The local anchor point on bodyA. Y position.</param>
	* <param name="anchorBX">The local anchor point on bodyB. X position.</param>
	* <param name="anchorBY">The local anchor point on bodyB. Y position.</param>
	* <param name="maxLength">Maximum length between the two points.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateRopeJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float anchorAX, float anchorAY, float anchorBX, float anchorBY, float maxLength, bool collideConnect);
    #endregion CreateRopeJoint
    #region GetRopeJointMaxLength
    /**
	* <summary>Get the maximum length.</summary>
	* <param name="joint">The joint who's max length will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetRopeJointMaxLength(IntPtr joint);
    #endregion GetRopeJointMaxLength
    #region SetRopeJointMaxLength
    /**
	* <summary>Set the maximum length.</summary>
	* <param name="joint">The joint who's max length will be set.</param>
	* <param name="length">The max length.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetRopeJointMaxLength(IntPtr joint, float length);
    #endregion SetRopeJointMaxLength
    #endregion RopeJoints

    #region MouseJoints
    #region CreateMouseJoint
    /**
	* <summary>Creates a new Mouse Joint and returns an IntPtr containing its memory address. A mouse joint is used to make a point on a body track a specified world point (target).</summary>
	* <param name="world">A pointer to the world that the joint will be created in.</param>
	* <param name="bodyA">First body. This doesnt actually do anything but it needs to be set. Just set this as a static ground body for instance</param>
	* <param name="bodyB">Second body. This is the body that will have forces applied to it by the mouse joint</param>
	* <param name="targetX">The target point. X position.</param>
	* <param name="targetY">The target point. Y position.</param>
	* <param name="collideConnected">Can connected bodies collide?</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr CreateMouseJoint(IntPtr world, IntPtr bodyA, IntPtr bodyB, float targetX, float targetY, bool collideConnected);
    #endregion CreateMouseJoint
    #region SetMouseJointDampingRatio
    /**
	* <summary>Sets the damping ratio of a mouse joint.</summary>
	* <param name="joint">The joint who's damping ratio will be set.</param>
	* <param name="ratio">The damping ratio.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetMouseJointDampingRatio(IntPtr joint, float ratio);
    #endregion SetMouseJointDampingRatio
    #region GetMouseJointDampingRatio
    /**
	* <summary>Returns the damping ratio of a mouse joint.</summary>
	* <param name="joint">The joint who's damping ratio will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetMouseJointDampingRatio(IntPtr joint);
    #endregion GetMouseJointDampingRatio
    #region SetMouseJointFrequency
    /**
	* <summary>Sets the frequency (hertz) of a mouse joint.</summary>
	* <param name="joint">The joint who's frequency will be set.</param>
	* <param name="frequency">The frequency (hertz).</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetMouseJointFrequency(IntPtr joint, float frequency);
    #endregion SetMouseJointFrequency
    #region GetMouseJointFrequency
    /**
	* <summary>Returns the frequency (hertz) of a mouse joint.</summary>
	* <param name="joint">The joint who's frequency will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetMouseJointFrequency(IntPtr joint);
    #endregion GetMouseJointFrequency
    #region SetMouseJointMaxForce
    /**
	* <summary>Sets the max force of a mouse joint.</summary>
	* <param name="joint">The joint who's max force will be set.</param>
	* <param name="maxForce">The max force.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetMouseJointMaxForce(IntPtr joint, float maxForce);
    #endregion SetMouseJointMaxForce
    #region GetMouseJointMaxForce
    /**
	* <summary>Returns the max force of a mouse joint.</summary>
	* <param name="joint">The joint who's max force will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetMouseJointMaxForce(IntPtr joint);
    #endregion GetMouseJointMaxForce
    
	#region SetMouseJointTarget
	/**
	* <summary>Set the target for a mouse joint.</summary>
	* <param name="targetX">The x coordinate of the target posistion to be set.</param>
	* <param name="targetY">The y coordinate of the target posistion to be set.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport("liquidfundll")]
	#endif
	public static extern void SetMouseJointTarget(IntPtr joint,float targetX,float targetY);
	#endregion SetMouseJointTarget   
    #endregion MouseJoints

    #region GenericFunctions
    #region DeleteJoint
    /**
	* <summary>Deletes a joint from the world.</summary>
	* <param name="world">A pointer to the world.</param>
	* <param name="joint">The joint that will be deleted.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float DeleteJoint(IntPtr world, IntPtr joint);
    #endregion DeleteJoint
    #region GetJointCollideConnected
    /**
	* <summary>Get collide connected.</summary>
	* <param name="joint">The joint who's info will be returned.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern bool GetJointCollideConnected(IntPtr joint);
    #endregion GetJointCollideConnected
    #region ShiftJointOrigin
    /**
	* <summary>Shifts the origin of the joint.</summary>
	* <param name="originX">New origin of the joint. X position.</param>
    * <param name="originY">New origin of the joint. Y position.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float ShiftJointOrigin(IntPtr joint, float originX, float originY);
    #endregion ShiftJointOrigin
    #endregion GenericFunctions
}