using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to the liquidfun world</summary>
public static class LPAPIWorld {
    #region CreateWorld
	/**
	* <summary>Creates a new Box2D World (b2World) and returns an IntPtr containing its memory address.</summary>
	* <param name="gravityX">The force of gravity in the world (X component).</param>
	* <param name="gravityY">The force of gravity in the world (Y component).</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr CreateWorld(float gravityX, float gravityY);
	#endregion CreateWorld

    #region End

    /**
	* <summary>Delete the world and all its contents. Prevents memory leaking</summary>
	* <param name="worldPointer">Pointer to the world. Get it via LPManager.GetPtr()</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport ("liquidfundll")]
	#endif
	public static extern int End(IntPtr worldPointer) ;
   
    #endregion End
	
	#region StepWithParticleIterations
	/**
	* <summary>Time steps the world.</summary>
	* <param name="world">A pointer to the world that the body will be created in.</param>
	* <param name="timeStep">The amount of time to simulate. This should not vary.</param>
	* <param name="velocityIterations">For the velocity constraint solver.</param>
	* <param name="positionIterations">For the position constraint solver.</param>
	* <param name="particleIterations">For the particle constraint solver.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern float StepWithParticleIterations(IntPtr world, float timeStep, int velocityIterations, int positionIterations, int particleIterations);
	#endregion StepWithParticleIterations
	
	#region GetAllowSleeping
	/**
	* <summary>Is sleep enabled?</summary>
	* <param name="world">A pointer to the world.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern bool GetAllowSleeping(IntPtr world);
	#endregion GetAllowSleeping
	
	#region SetAllowSleeping
	/**
	* <summary>Enable/disable sleep.</summary>
	* <param name="world">A pointer to the world.</param>
	* <param name="flag">Enable/disable.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetAllowSleeping(IntPtr world, bool flag);
	#endregion SetAllowSleeping
	
	#region GetWorldGravity
	/**
	* <summary>Returns the force of gravity in the world. This is an unmarshalled float array of length 2, containing the x component at array[0] and the y component at array[1].</summary>
	* <param name="world">A pointer to the world.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetWorldGravity(IntPtr world);
	#endregion GetWorldGravity
	
	#region SetWorldGravity
	/**
	* <summary>Set the force of gravity in the world.</summary>
	* <param name="world">A pointer to the world.</param>
	* <param name="gravityX">Gravity (x component).</param>
	* <param name="gravityY">Gravity (y component).</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetWorldGravity(IntPtr world, float gravityX, float gravityY);
	#endregion SetWorldGravity

    #region WorldTestPointForBody
    /**
	* <summary>Test a world point to see if it is contained within a body</summary>
	* <param name="world">A pointer to the world.</param>
	* <param name="x">The x position</param>
	* <param name="y">The y position(y component).</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern int WorldTestPointForBody(IntPtr world, float x, float y);
    #endregion WorldTestPointForBody
}