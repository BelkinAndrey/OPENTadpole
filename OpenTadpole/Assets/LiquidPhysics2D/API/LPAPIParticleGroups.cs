using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun particle groups</summary>
public static class LPAPIParticleGroups
{
	#region CreateParticleGroup
	/**
	* <summary>Creates a particle group within a particle system and returns an IntPtr with its memory address.</summary>
	* <param name="particlePointer">A pointer to the particle system that the group will be created in.</param>
	* <param name="types">Int containing the types of the particles (b2ParticleFlags).</param>
	* <param name="groupTypes">Int containing the types of the groups (b2ParticleGroupFlags).</param>
	* <param name="angle">The world angle of the group in radians. Rotates the shape by an angle equal to the value of angle.</param>
	* <param name="strength">The strength of cohesion among the particles in a group with flag b2_elasticParticle or b2_springParticle.</param>
	* <param name="angularVelocity">The angular velocity.</param>
	* <param name="linearVelocityX">The linear velocity - x component.</param>
	* <param name="linearVelocityY">The linear velocity - y component.</param>
	* <param name="shape">Pointer to the shape of the particle system.</param>
	* <param name="r">Red color value of the particle group.</param>
	* <param name="g">Green color value of the particle group.</param>
	* <param name="b">Blue color value of the particle group.</param>
	* <param name="a">Alpha value of the particle group.</param>
	* <param name="stride">The interval of particles in the shape. If it is 0, b2_particleStride * particleDiameter is used instead.</param>
	* <param name="lifetime">Lifetime of the particle group in seconds. A value <= 0.0f indicates a particle group with infinite lifetime.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr CreateParticleGroup(IntPtr particlePointer, Int32 types, Int32 groupTypes, float angle, float strength, float angularVelocity, float linearVelocityX, float linearVelocityY, IntPtr shape, int r, int g, int b, int a, float stride, float lifetime, int userdata);
	#endregion CreateParticleGroup
	
	#region DeleteParticlesInGroup
	/**
	* <summary>Deletes all particles in a particle group. This function is locked during callbacks.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void DeleteParticlesInGroup(IntPtr particleGroupPointer);
	#endregion DeleteParticlesInGroup

    #region GetParticlesInGroupCount
    /**
	* <summary>Get the number of particles in a group.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern int GetParticlesInGroupCount(IntPtr particleGroupPointer);
    #endregion GetParticlesInGroupCount

    #region SetParticleFlagsInGroup
    /**
	* <summary>Set the flags of all particles in a group.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
	* <param name="particleSystemPointer">Pointer to the particle system that contains the group.</param>
	* <param name="particleFlags">The particle flags.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetParticleFlagsInGroup(IntPtr particleGroupPointer, IntPtr particleSystemPointer, int particleFlags);
	#endregion SetParticleFlagsInGroup
	
	#region SetParticleLifetimesInGroup
	/**
	* <summary>Set the lifetimes of all particles in a group. Lifetimes must be enabled for the parent particle system for the particles to be destroyed.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
	* <param name="particleSystemPointer">Pointer to the particle system that contains the group.</param>
	* <param name="lifetime">The particle lifetime.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetParticleLifetimesInGroup(IntPtr particleGroupPointer, IntPtr particleSystemPointer, int lifetime);
	#endregion SetParticleLifetimesInGroup
	
	#region ApplyForceToParticleGroup
	/**
	* <summary>Apply a force to a particle group.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
	* <param name="forceX">X component of the force.</param>
	* <param name="forceY">Y component of the force.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyForceToParticleGroup(IntPtr particleGroupPointer, float forceX, float forceY);
	#endregion ApplyForceToParticleGroup
	
	#region ApplyLinearImpulseToParticleGroup
	/**
	* <summary>Apply a linear impulse to a particle group.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
	* <param name="impulseX">X component of the impulse.</param>
	* <param name="impulseY">Y component of the impulse.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyLinearImpulseToParticleGroup(IntPtr particleGroupPointer, float impulseX, float impulseY);
	#endregion ApplyLinearImpulseToParticleGroup

    #region SplitParticleGroups
    /**
	* <summary>Split a particle group. Warning: Locked during callbacks.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="groupPointer">The first particle group. Expands to encompass the second group.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SplitParticleGroup(IntPtr particleSystemPointer, IntPtr groupPointer);
    #endregion SplitParticleGroups
	
	#region JoinParticleGroups
	/**
	* <summary>Join two particle groups. Warning: Locked during callbacks.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="groupAPointer">The first particle group. Expands to encompass the second group.</param>
	* <param name="groupBPointer">The second particle group. This will be destroyed.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void JoinParticleGroups(IntPtr particleSystemPointer, IntPtr groupAPointer, IntPtr groupBPointer);
	#endregion JoinParticleGroups
	
	#region AreParticlesInGroup
	/**
	* <summary>Checks if a set of particles are within a particle group. Returns an unmarahslled array of ints which represent boolean values (0 = false, else true). The array length is the amount of particles you pass in.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
	* <param name="indices">Indices of the particles to be checked. 
	* note that the 1st member of this array must be the number of indices you are checking (ie. the array lenght -1)</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr AreParticlesInGroup(IntPtr particleGroupPointer, [In, MarshalAs(UnmanagedType.LPArray)] int[] indices);
	#endregion AreParticlesInGroup

    #region GetParticleGroupPosition
    /**
	* <summary>Get the centre of gravity of a particle group. Note: Only works for Rigid groups</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
    * <returns>Returns a pointer to an array containing 2 floats. This represents a 2d vector, array[0] is x. array[1] is y</returns>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
#else
    [DllImport("liquidfundll")]
    #endif
    public static extern IntPtr GetParticleGroupPosition(IntPtr particleGroupPointer);
    #endregion GetParticleGroupPosition
        
    #region GetParticleGroupCentroid
    /**
	* <summary>Get the centre of gravity of a particle group.</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
    * <returns>Returns a pointer to an array containing 2 floats. This represents a 2d vector, array[0] is x. array[1] is y</returns>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr GetParticleGroupCentroid(IntPtr particleGroupPointer);
    #endregion GetParticleGroupCentroid
    
    #region GetParticleGroupVelocity
    /**
	* <summary>Get the average velocity of a particle group</summary>
	* <param name="particleGroupPointer">Pointer to the particle group.</param>
    * <returns>Returns a pointer to an array containing 2 floats. This represents a 2d vector, array[0] is x. array[1] is y</returns>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
#else
    [DllImport("liquidfundll")]
    #endif
    public static extern IntPtr GetParticleGroupVelocity(IntPtr particleGroupPointer);
    #endregion GetParticleGroupVelocity
}