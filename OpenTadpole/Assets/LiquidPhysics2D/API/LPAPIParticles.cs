using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to one or more liquidfun particles</summary>
public static class LPAPIParticles 
{
	#region CreateParticleInSystem
	/**
	* <summary>Adds a particle to a particle system.</summary>
	* <param name="systemPointer">A pointer to the particle system that the particle will be added to.</param>
	* <param name="flags">Int containing the particle flags (b2ParticleFlags).</param>
	* <param name="positionX">X position of the particle.</param>
	* <param name="positionY">Y position of the particle.</param>
	* <param name="velocityX">X velocity of the particle.</param>
	* <param name="velocityY">Y velocity of the particle.</param>
	* <param name="r">Red color value of the particle.</param>
	* <param name="g">Green color value of the particle.</param>
	* <param name="b">Blue color value of the particle.</param>
	* <param name="a">Alpha value of the particle.</param>
	* <param name="lifetime">Lifetime of the particle.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void CreateParticleInSystem(IntPtr systemPointer, int flags, float positionX, float positionY, float velocityX, float velocityY, int r, int g, int b, int a, float lifetime);
	#endregion CreateParticleInSystem
		
	#region SetSelectedParticleColor
	/**
	* <summary>Set the colours of selected particles in a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="indexArray">Array containing the indexes of the particles to be set.</param>
	* <param name="r">The red value for the color to be set. Between 0 and 255 inclusive</param>
	* <param name="g">The green value for the color to be set. Between 0 and 255 inclusive</param>
	* <param name="b">The blue value for the color to be set. Between 0 and 255 inclusive</param>
	* <param name="a">The alpha value for the color to be set. Between 0 and 255 inclusive</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetSelectedParticleColor(IntPtr particlesPointer,[In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray, int r, int g, int b, int a);
	#endregion SetSelectedParticleColor
		
	#region SetSelectedParticleUserData
	/**
	* <summary>Set the userdata of selected particles in a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="indexArray">Array containing the indexes of the particles to be set.</param>
	* <param name="userdata">The value to set the userdata to</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetSelectedParticleUserData(IntPtr particlesPointer,[In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray, int userdata);
	#endregion SetSelectedParticleUserData
	
	#region SetSelectedParticleFlags
	/**
	* <summary>Set the flags for selected particles in a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="indexArray">Array containing the indexes of the particles to be set. array member 0 must be the number of particles flags to be set</param>
	* <param name="particleFlags">The particle flags (b2ParticleFlag).</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void SetSelectedParticleFlags(IntPtr particleSystemPointer, [In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray, int particleFlags);
	#endregion SetSelectedParticleFlags
	
	#region DestroySelectedParticles
	/**
	* <summary>Destroy selected particles in a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="indexArray">Array containing the indexes of the particles to be destroyed.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void DestroySelectedParticles(IntPtr particleSystemPointer, [In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray);
	#endregion DestroySelectedParticles
	
	
	#region ExplodeSelectedParticles
	/**
	* <summary>Subjects selected particles to an explosive force. ie. Applies a force to all selected particles in the direction of that particle from the centre of the explosion</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="indexArray">Array containing the indices of the particles to be exploded. array member 0 indicates the number of indices</param>
	* <param name="CentreX">The x coordinate for the centre of the explosion</param>
	* <param name="CentreY">The Y coordinate for the centre of the explosion</param>
	* <param name="Strenght">The Strenght of the explosion</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ExplodeSelectedParticles(IntPtr particleSystemPointer, [In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray,float CentreX,float CentreY,float Strenght);
	#endregion ExplodeSelectedParticles
	
	
	#region ApplyForceToSelectedParticles
	/**
	* <summary>Apply a force to selected particles in a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="indexArray">Array containing the indexes of the particles to be set.</param>
	* <param name="forceX">~The force (x component).</param>
	* <param name="forceY">~The force (y component).</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyForceToSelectedParticles(IntPtr particleSystemPointer, [In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray, float forceX, float forceY);
	#endregion ApplyForceToSelectedParticles
	
	#region ApplyLinearImpulseToSelectedParticles
	/**
	* <summary>Apply a force to selected particles in a particle system.</summary>
	* <param name="particleSystemPointer">Pointer to the particle system.</param>
	* <param name="indexArray">Array containing the indexes of the particles to be set.</param>
	* <param name="impulseX">~The impulse (x component).</param>
	* <param name="impulseY">~The impulse (y component).</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern void ApplyLinearImpulseToSelectedParticles(IntPtr particleSystemPointer, [In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray, float impulseX, float impulseY);
	#endregion ApplyLinearImpulseToSelectedParticles  
	
	#region GetSelectedParticlesDetails
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
	public static extern IntPtr GetSelectedParticlesDetails(IntPtr particlePointer, [In, MarshalAs(UnmanagedType.LPArray)] int[] indexArray,bool position,bool color,bool age,bool weight,bool velocity,bool userdata);
	#endregion GetSelectedParticlesDetails
	   
}