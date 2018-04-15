using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun bodies</summary>
public static class LPAPIBody {
	#region CreateBody
	/**
	* <summary>Creates a new Box2D Body (b2Body) in the world, and returns an IntPtr containing its memory address.</summary>
	* <param name="IntPtr world">A pointer to the world that the body will be created in.</param>
	* <param name="bodyType">The type of body to be created (static, dynamic, or kinematic).</param>
	* <param name="xPosition">The body's X Position.</param>
	* <param name="yPosition">The body's Y Position.</param>
	* <param name="angleInRadians">The world angle of the body (in radians).</param>
	* <param name="linearDamping">Linear damping is use to reduce the linear velocity. The damping parameter can be larger than 1.0f but the damping effect becomes sensitive to the time step when the damping parameter is large.</param>
	* <param name="angularDamping"> Angular damping is use to reduce the angular velocity. The damping parameter can be larger than 1.0f but the damping effect becomes sensitive to the time step when the damping parameter is large.</param>
	* <param name="allowSleep">Set this flag to false if this body should never fall asleep. Note that this increases CPU usage.</param>
	* <param name="fixedRotation">Prevents the body from rotating.</param>
	* <param name="bullet">Is this a fast moving body that should be prevented from tunneling through other bodies?</param>
	* <param name="gravityScale">Scale the gravity applied to the body.</param>
	* <param name="userData">User data for the body.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR 
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	/*For bodyType, pass 0 for Static, 1 for Dymanic, 2 for Kinematic*/
	public static extern IntPtr CreateBody(IntPtr world, int bodyType, float xPosition, float yPosition, float angleInRadians,
	                                       float linearDamping, float angularDamping, bool allowSleep, bool fixedRotation,
	                                        bool bullet, float gravityScale, int userData);
	#endregion CreateBody

	#region ApplyForceToCentreOfBody
	/**
	* <summary>Apply a force to the center of mass. This wakes up the body.</summary>
	* <param name="bodyPointer">A pointer to the body that the force will be applied to.</param>
	* <param name="impulseX">The X component of the force.</param>
	* <param name="impulseY">The Y component of the force.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyForceToCentreOfBody(IntPtr bodyPointer, float impulseX, float impulseY);
	#endregion ApplyForceToCentreOfBody
	
	#region GetBodyInfo
	/**
	* <summary>Returns an IntPtr to an array of floats containing basic information about a body, with its X Position at array[0], Y Position at array[1], and its Angle at array[2]</summary>
	* <param name="body">A pointer to the body who's information will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetBodyInfo(IntPtr body);
	#endregion GetBodyInfo
		
	#region GetAllBodyInfo
	/**
	* <summary>gets position and rotation for an array of bodies</summary>
	* <param name="body">An array of pointers to the bodies who's information will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetAllBodyInfo([In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] bodyArray, int numbodies);
	#endregion GetAllBodyInfo
	
	#region SetBodyAwake
	/**
	* <summary>Set the sleep state of the body. A sleeping body has very low CPU cost.</summary>
	* <param name="body">A pointer to the body who's sleep state will be set.</param>
	* <param name="isAwake">Set to true to wake the body, false to put it to sleep.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetBodyAwake(IntPtr body, bool isAwake);
	#endregion SetBodyAwake
	
	#region GetBodyAwake
	/**
	* <summary>Gets the sleep state of the body.</summary>
	* <param name="body">A pointer to the body who's sleep state will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern bool GetBodyAwake(IntPtr body);
	#endregion GetBodyAwake
	
	#region SetBodyActive
	/**
	* <summary>Set the active state of the body. An inactive body is not simulated and cannot be collided with or woken up.</summary>
	* <param name="body">A pointer to the body who's active state will be set.</param>
	* <param name="isActive">Set to true to activate the body, false to deactivate it.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetBodyActive(IntPtr body, bool isActive);
	#endregion SetBodyActive
	
	#region GetBodyActive
	/**
	* <summary>Gets the active state of the body.</summary>
	* <param name="body">A pointer to the body who's active state will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern bool GetBodyActive(IntPtr body);
	#endregion GetBodyActive
	
	#region GetBodyFixtures
	/**
	* <summary>WARNING: This is a utility method which returns an unusable array - GetBodyFixturesList should be used instead. Returns pointers to all of the fixtures attached to a body.</summary>
	* <param name="body">A pointer to the body who's fixtures will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	private static extern IntPtr GetBodyFixtures(IntPtr body);
	#endregion GetBodyFixtures
	
	#region GetBodyFixturesCount
	/**
	* <summary>Gets the number of fixtures attached to a body.</summary>
	* <param name="body">A pointer to the body who's number of fixtures will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int GetBodyFixturesCount(IntPtr body);
	#endregion GetBodyFixturesCount

    #region GetBodyFixturesList
    /**
    * <summary>Returns an array of pointers to all the fixtures attached to a body.</summary>
    * <param name="body">A pointer to the body who's number of fixtures will be returned.</param>
    **/
    public static IntPtr[] GetBodyFixturesList(IntPtr body) {
        int count = GetBodyFixturesCount(body);
        IntPtr fixturesListPointer = GetBodyFixtures(body);
        IntPtr[] fixturesList = new IntPtr[count];
        Marshal.Copy(fixturesListPointer,fixturesList,0,count);
        return fixturesList;
    }
    #endregion GetBodyFixturesList

	#region SetBodyType
	/**
    * <summary>Set the body's type</summary>
    * <param name="body">A pointer to the body who's rotation will be set.</param>
	* <param name="angle">An int representing the type to be set. Use the </param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport("liquidfundll")]
	#endif
	public static extern void SetBodyType(IntPtr body, int type);
	#endregion SetBodyType

    #region SetBodyPosition
    /**
    * <summary>Set the position of the body's origin. Manipulating a body's transform may cause non-physical behavior.</summary>
    * <param name="body">A pointer to the body who's position will be set.</param>
	* <param name="x">X position of the new origin.</param>
	* <param name="y">Y position of the new origin.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyPosition(IntPtr body, float x, float y);
    #endregion SetBodyPosition

    #region SetBodyRotation
    /**
    * <summary>Set the body's rotation. Manipulating a body's transform may cause non-physical behavior.</summary>
    * <param name="body">A pointer to the body who's rotation will be set.</param>
	* <param name="angle">The angle in radians.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyRotation(IntPtr body, float angle);
    #endregion SetBodyRotation

    #region SetBodyLinearVelocity
    /**
    * <summary>Set the linear velocity of the body's center of mass.</summary>
    * <param name="body">A pointer to the body who's rotation will be set.</param>
	* <param name="x">The linear velocity (x component).</param>
	* <param name="y">The linear velocity (y component).</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyLinearVelocity(IntPtr body, float x, float y);
    #endregion SetBodyLinearVelocity
	
	#region GetBodyLinearVelocity
	/**
	* <summary>Returns the linear velocity of a body. This is an unmarshalled float array of length 2, containing the x component at array[0] and the y component at array[1].</summary>
	* <param name="body">A pointer to the body.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetBodyLinearVelocity(IntPtr world);
	#endregion GetBodyLinearVelocity

    #region SetBodyAngularVelocity
    /**
    * <summary>Set the body's angular velocity.</summary>
    * <param name="body">A pointer to the body who's rotation will be set.</param>
	* <param name="omega">The new angular velocity in radians/second.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyAngularVelocity(IntPtr body, float omega);
    #endregion SetBodyAngularVelocity
	
    #region GetBodyAngularVelocity
    /**
    * <summary>Get the angular velocity of a body in radians/second.</summary>
    * <param name="body">A pointer to the body.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetBodyAngularVelocity(IntPtr body);
    #endregion GetBodyAngularVelocity

    #region GetBodyUserData
    /**
    * <summary>Gets the user data of a body.</summary>
    * <param name="body">A pointer to the body who's user data will be returned.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern int GetBodyUserData(IntPtr body);
    #endregion GetBodyUserData

    #region GetBodyContactsCount
    /**
    * <summary>Gets the number of contacts involving a particluar body</summary>
    * <param name="body">A pointer to the body</param>
    **/
    #if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
    #else
    [DllImport ("liquidfundll")]
	#endif      
	public static extern int GetBodyContactsCount(IntPtr bodyPointer) ;
    #endregion GetBodyContactsCount

    #region GetBodyContacts
    /**
    * <summary>Gets the indices of the other bodies currently in contact with this one
    This is an unmarshalled int array of length 1+number of contacts,
    The 1st entry in the array is the number of contacts, the sunsequent entries are the indices of the contacting bodies</summary>
    * <param name="body">A pointer to the body who's contacts will be returned.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetBodyContacts(IntPtr body);
	#endregion GetBodyContacts
	
	#region DeleteBody
    /**
    * <summary>Deletes a body. This automatically deletes all associated shapes and joints. This function is locked during callbacks.</summary>
    * <param name="worldPointer">Pointer to the world that the body will be deleted from.</param>
	* <param name="bodyPointer">The body which will be deleted.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern void DeleteBody(IntPtr worldPointer, IntPtr bodyPointer);
    #endregion DeleteBody
	
	#region ApplyAngularImpulseToBody
	/**
	* <summary>Apply an angular impulse to a body.</summary>
	* <param name="bodyPointer">A pointer to the body that the force will be applied to.</param>
	* <param name="impulse">The angular impulse in units of kg*m*m/s.</param>
	* <param name="wake">Should this wake up the body?</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyAngularImpulseToBody(IntPtr bodyPointer, float impulse, bool wake);
	#endregion ApplyAngularImpulseToBody
	
	#region ApplyForceToBody
	/**
	* <summary>Apply a force to a body.</summary>
	* <param name="bodyPointer">A pointer to the body that the force will be applied to.</param>
	* <param name="forceX">X component of the force.</param>
	* <param name="forceY">Y component of the force.</param>
	* <param name="pointX">Point at which the force will be applied (X position).</param>
	* <param name="pointY">Point at which the force will be applied (Y position).</param>
	* <param name="wake">Should this wake up the body?</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyForceToBody(IntPtr bodyPointer, float forceX, float forceY, float pointX, float pointY, bool wake);
	#endregion ApplyForceToBody
	
	#region ApplyLinearImpulseToBody
	/**
	* <summary>Apply a linear impulse to a body.</summary>
	* <param name="bodyPointer">A pointer to the body that the impulse will be applied to.</param>
	* <param name="impulseX">X component of the impulse.</param>
	* <param name="impulseY">Y component of the impulse.</param>
	* <param name="pointX">Point at which the impulse will be applied (X position).</param>
	* <param name="pointY">Point at which the impulse will be applied (Y position).</param>
	* <param name="wake">Should this wake up the body?</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyLinearImpulseToBody(IntPtr bodyPointer, float impulseX, float impulseY, float pointX, float pointY, bool wake);
	#endregion ApplyLinearImpulseToBody
	
	#region ApplyTorqueToBody
	/**
	* <summary>Apply a torque to a body.</summary>
	* <param name="bodyPointer">A pointer to the body that the torque will be applied to.</param>
	* <param name="torque">The torque about the Z axis, in N-m.</param>
	* <param name="wake">Should this wake up the body?</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyTorqueToBody(IntPtr bodyPointer, float torque, bool wake);
	#endregion ApplyTorqueToBody
	
	#region GetBodyMass
	/**
	* <summary>Returns the mass of a body.</summary>
	* <param name="bodyPointer">A pointer to the body.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern float GetBodyMass(IntPtr bodyPointer);
	#endregion GetBodyMass
	
	#region GetBodyInertia
	/**
	* <summary>Returns the inertia of a body.</summary>
	* <param name="bodyPointer">A pointer to the body.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern float GetBodyInertia(IntPtr bodyPointer);
	#endregion GetBodyInertia
	
	#region SetBodyTransform
	/**
	* <summary>Set the position of the body's origin and rotation. Manipulating a body's transform may cause non-physical behavior.</summary>
	* <param name="bodyPointer">A pointer to the body.</param>
	* <param name="xPos">The world position of the body's local origin (x position).</param>
	* <param name="yPos">The world position of the body's local origin (y position).</param>
	* <param name="angle">The world rotation (in radians).</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetBodyTransform(IntPtr bodyPointer, float xPos, float yPos, float angle);
	#endregion SetBodyTransform
	
	#region SetBodyLinearDamping
    /**
    * <summary>Set the body's linear damping.</summary>
    * <param name="body">A pointer to the body who's linear damping will be set.</param>
	* <param name="linearDamping">The new linear damping.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyLinearDamping(IntPtr body, float linearDamping);
    #endregion SetBodyLinearDamping
	
    #region GetBodyLinearDamping
    /**
    * <summary>Get the linear damping of a body.</summary>
    * <param name="body">A pointer to the body.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetBodyLinearDamping(IntPtr body);
    #endregion GetBodyLinearDamping
	
	#region SetBodyAngularDamping
    /**
    * <summary>Set the body's angular damping.</summary>
    * <param name="body">A pointer to the body who's angular damping will be set.</param>
	* <param name="angularDamping">The new angular damping.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyAngularDamping(IntPtr body, float angularDamping);
    #endregion SetBodyAngularDamping
	
    #region GetBodyAngularDamping
    /**
    * <summary>Get the angular damping of a body.</summary>
    * <param name="body">A pointer to the body.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetBodyAngularDamping(IntPtr body);
    #endregion GetBodyAngularDamping
	
	#region SetBodyGravityScale
    /**
    * <summary>Set the body's gravity scale.</summary>
    * <param name="body">A pointer to the body who's gravity scale will be set.</param>
	* <param name="gravityScale">The new gravity scale.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyGravityScale(IntPtr body, float gravityScale);
    #endregion SetBodyGravityScale
	
    #region GetBodyGravityScale
    /**
    * <summary>Get the gravity scale of a body.</summary>
    * <param name="body">A pointer to the body.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern float GetBodyGravityScale(IntPtr body);
    #endregion GetBodyGravityScale

	#region SetBodyIsBullet
    /**
    * <summary>Should this body be treated like a bullet for continuous collision detection?</summary>
    * <param name="body">A pointer to the body.</param>
	* <param name="isBullet">Bullet flag.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyIsBullet(IntPtr body, bool isFlag);
    #endregion SetBodyIsBullet
	
    #region GetBodyIsBullet
    /**
    * <summary>Is this body treated like a bullet for continuous collision detection?</summary>
    * <param name="body">A pointer to the body.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern bool GetBodyIsBullet(IntPtr body);
    #endregion GetBodyIsBullet

	#region SetBodyFixedRotation
    /**
    * <summary>Set fixed rotation for the body.</summary>
    * <param name="body">A pointer to the body.</param>
	* <param name="flag">Fixed rotation flag.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetBodyFixedRotation(IntPtr body, bool flag);
    #endregion SetBodyFixedRotation
	
    #region GetBodyFixedRotation
    /**
    * <summary>Does this body have fixed rotation?</summary>
    * <param name="body">A pointer to the body.</param>
    **/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern bool GetBodyFixedRotation(IntPtr body);
    #endregion GetBodyFixedRotation
}