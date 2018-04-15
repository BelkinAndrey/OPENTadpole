using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun particle systems or every particle in the system</summary>
public static class LPAPIParticleSystems {
	#region CreateParticleSystem
	/**
	* <summary>Creates a particle system and returns an IntPtr with its memory address.</summary>
	* <param name="worldPointer">A pointer to Box2D World.</param>
	* <param name="radius">Particle radius.</param>
	* <param name="damping">Particle damping.</param>
	* <param name="gravityScale">Scale of gravity.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr CreateParticleSystem(IntPtr worldPointer, float radius, float damping, float gravityScale,int number);
	#endregion CreateParticleSystem
	
	#region CreateParticleSystem2
	/**
	* <summary>Creates a particle system and returns an IntPtr with its memory address.</summary>
	* <param name="worldPointer">A pointer to Box2D World.</param>
	* <param name="radius">Particle radius.</param>
	* <param name="damping">Particle damping.</param>
	* <param name="gravityScale">Scale of gravity.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr CreateParticleSystem2(IntPtr worldPointer, float radius, float damping, float gravityScale,int number, float tennorm,float tenpres, float viscstr);
	#endregion CreateParticleSystem2
	
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
    #endif
	public static extern void SetParticleSystemIndex(IntPtr partsysPointer, int userData);
	
	#region GetParticleIterations
	/**
	* <summary>Gets the recommended value for Particle Iterations.</summary>
	* <param name="gravity">Force of gravity in the world.</param>
	* <param name="particleRadius">Radius of the particles in the system.</param>
	* <param name="timeStep">The amount of time to simulate. This should not vary.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern Int32 GetParticleIterations(float gravity, float particleRadius, float timeStep);
	#endregion EndParticleIterations
	
	
	#region GetParticlePositions
	/**
	* <summary>Returns a pointer to a float array containing the positions of all particles in a particle group. The array is of length (2*numberOfParticles)+1. The number of particles in the system is returned at index position 0. The X and Y positions are alternated starting from index 1. The array must be Marshalled to managed memory before use.</summary>
	* <param name="particlePointer">A pointer to the particle system who's information will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetParticlePositions(IntPtr particlePointer);
	#endregion GetParticlePositions
	
	#region GetParticlePositionsAndColor
	/**
	* <summary>Returns a pointer to a float array containing the positions and RGBA colors of all particles in a particle group. The array is of length (6*numberOfParticles)+1. The number of particles in the system is returned at index position 0. The X, Y, R, G, B, and A values start from index 1. The array must be Marshalled to managed memory before use.</summary>
	* <param name="particlePointer">A pointer to the particle system who's information will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetParticlePositionsAndColors(IntPtr particlePointer);
	#endregion GetParticlePositionsAndColor
	
	#region GetParticlesDetails
	/**
	* <summary>Returns a pointer to a float array containing selected info about all the particlers in the system
	 The array must be Marshalled to managed memory before use.</summary>
	* <param name="particlePointer">A pointer to the particle system who's information will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetParticlesDetails(IntPtr particlePointer,bool position,bool color,bool age,bool weight,bool velocity,bool userdata);
	#endregion GetParticlesDetails

	#region GetNumberOfParticles
	/**
	* <summary>Gets the number of particles in a system.</summary>
	* <param name="particlePointer">The particle system who's information will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int GetNumberOfParticles(IntPtr particlePointer);
	#endregion GetNumberOfParticles
	
	#region DeleteParticleSystem
	/**
	* <summary>Deletes a particle system. This function is locked during callbacks.</summary>
	* <param name="worldPointer">Pointer to the world that the particle system will be deleted from.</param>
	* <param name="particlesPointer">The particle system which will be deleted.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void DeleteParticleSystem(IntPtr worldPointer, IntPtr particlesPointer);
	#endregion DeleteParticleSystem
	
	#region SetAllParticleFlags
	/**
	* <summary>Set the flags for all particles in a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="particleFlags">The particle flags (b2ParticleFlag).</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetAllParticleFlags(IntPtr particleSystemPointer, int particleFlags);
	#endregion SetAllParticleFlags
	
	#region SetParticleFlagsUpToLimit
	/**
	* <summary>Set the flags for a set number of particles in a particle system. Takes an upper limit as a parameter - all particles from from system[0] up to system[upperLimit] will be set.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="particleFlags">The particle flags (b2ParticleFlag).</param>
	* <param name="upperBound">The index of the last particle who's flags will be set. All particles from system[0] up to system[upperBound] will be set.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetParticleFlagsUpToLimit(IntPtr particleSystemPointer, int particleFlags, int upperBound);
	#endregion SetParticleFlagsUpToLimit

	
	
	#region GetStuckCandidateCount
	/**
	* <summary>Get the number of stuck particle candidates from the last step.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int GetStuckCandidateCount(IntPtr particleSystemPointer);
	#endregion GetStuckCandidateCount
	
	#region SetStuckThreshold
	/**
	* <summary>Set an optional threshold for the maximum number of consecutive particle iterations that a particle may contact multiple bodies before it is considered a candidate for being "stuck". Setting to zero or less disables.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="iterations">The number of consecutive particle iterations.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetStuckThreshold(IntPtr particleSystemPointer, int iterations);
	#endregion SetStuckThreshold
	
	#region DestroyParticlesInShape
	/**
	* <summary>Destroy particles inside a shape. Returns the number of particles destroyed. This function is locked during callbacks. This function immediately destroys particles in the shape, rather than on the next simulation step.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="shapePointer">Pointer to a shape which encloses particles that should be destroyed.</param>
	* <param name="shapeX">X position of the shape.</param>
	* <param name="shapeY">Y position of the shape.</param>
	* <param name="shapeRotation">Angle of the shape in radians.</param>
	* <param name="callDestructionListener">Should the world b2DestructionListener be called for each particle destroyed.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int DestroyParticlesInShape(IntPtr particleSystemPointer, IntPtr shapePointer, float shapeX, float shapeY, float shapeRotation, bool callDestructionListener);
	#endregion DestroyParticlesInShape
	
	#region GetParticlesInShape
	/**
	* <summary>Gets the indices of particles inside a shape. Returns an unmarshalled int array of length array[0]. This function is locked during callbacks.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="shapePointer">Pointer to a shape which encloses particles.</param>
	* <param name="shapeX">X position of the shape.</param>
	* <param name="shapeY">Y position of the shape.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern IntPtr GetParticlesInShape(IntPtr worldPtr, IntPtr particleSystemPtr, IntPtr shapePointer, float shapeX, float shapeY, float shapeRotation);
	#endregion GetParticlesInShape

    #region SetDesctructionByAge
    /**
	* <summary>Set whether particles in a system will be destroyed after a certain amount of time.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="isSet">Set to true if particles should have lifetimes/destruction.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetDestructionByAge(IntPtr particleSystemPointer, bool isSet);
    #endregion SetDesctructionByAge

    #region GetDesctructionByAge
    /**
	* <summary>Checks whether particle destruction by age is enabled in a particle system. Returns true if it is.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern bool GetDestructionByAge(IntPtr particleSystemPointer);
    #endregion GetDesctructionByAge
	
    #region SetAllParticleLifetimes
    /**
	* <summary>Set the lifetime of all particles in a particle system. Note: SetDestructionByAge must be called to enable destruction.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="lifetime">Time before the particles are destroyed.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern void SetAllParticleLifetimes(IntPtr particleSystemPointer, float lifetime);
    #endregion SetAllParticleLifetimes
		
	#region GetMaxParticleCount
	/**
	* <summary>Gets the max particle count of a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int GetMaxParticleCount(IntPtr particleSystemPointer);
	#endregion GetMaxParticleCount
	
	#region SetMaxParticleCount
	/**
	* <summary>Sets the max particle count of a particle system..</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="maxParticleCount">The new max count.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetMaxParticleCount(IntPtr particleSystemPointer, int maxParticleCount);
	#endregion SetMaxParticleCount
	
	#region GetParticleSystemContacts
	/**
	* <summary>Get the particle system contacts. Returns an unmarshalled array of ints, which is of length ((array[0] * 4) + 1). Contains: indexA, indexB, userdata A,userdataB.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetParticleSystemContacts(IntPtr particleSystemPointer);
	#endregion GetParticleSystemContacts
	
	#region GetParticleSystemBodyContacts
	/**
	* <summary>Get the particle system body contacts. Returns an unmarshalled array of floats, which is of length ((array[0] * 7) + 1). 
	* Contains: particle index, particle userdata, bodyUserData, fixtureUserData, normalX, notmalY, contact weight, for each contact.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetParticleSystemBodyContacts(IntPtr particleSystemPointer);
	#endregion GetParticleSystemBodyContacts

    #region GetParticleGroupCount
    /**
	* <summary>Gets the count of a particle groups in the system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern Int32 GetParticleGroupCount(IntPtr particleSystemPointer);
    #endregion GetParticleGroupCount

    #region GetParticleGroupPointers
    /**
	* <summary>Gets the list of pointers for each group.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr GetParticleGroupPointers(IntPtr particleSystemPointer);
    #endregion GetParticleGroupPointers


        #region GetParticleGroupPointerForLargestGroup
    /**
	* <summary>Gets the pointer for the largest group.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	**/
#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
#else
    [DllImport("liquidfundll")]
#endif
    public static extern IntPtr GetParticleGroupPointerForLargestGroup(IntPtr particleSystemPointer);
    #endregion GetParticleGroupPointers
}