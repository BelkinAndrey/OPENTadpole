using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun raycasts</summary>
public static class LPAPIRaycast {
    #region RaycastWorld
	/**
	* <summary>Ray-cast the world for all fixtures in the path of the ray. The ray-cast ignores shapes that contain the starting point. Returns an unmarshalled float array of length 2+(array[0]*7)+(array[1]*7).</summary>
	* <param name="world">The world.</param>
	* <param name="x1">The ray starting point (x position).</param>
	* <param name="y1">The ray starting point (y position).</param>
	* <param name="x2">The ray ending point (x position).</param>
	* <param name="y2">The ray ending point (y position).</param>
	* <param name="mode">Raycast mode. -1 to filter, 0 to terminate, fraction to clip the ray for closest hit, 1 to continue.</param>
	* <param name="shouldQueryParticleSystem">True if you want to include particleSystem in the RayCast, or false to cull particleSystem from the RayCast.</param>
	* <returns>Array[0] = Number of fixture hits. Array[1] = Number of particle hits. Each fixture hit returns: bodyIndex, fixtureIndex, posX, posY, normalX, normalY, fraction. Each particle hit returns: systemIndex, particleIndex, posX, posY, normalX, normalY, fraction.</returns>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr RaycastWorld(IntPtr world, float x1, float y1, float x2, float y2, int mode, bool shouldQueryParticleSystem);
	#endregion RaycastWorld
}