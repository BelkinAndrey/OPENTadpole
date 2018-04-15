using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun fixtures</summary>
public static class LPAPIUtility
{
	#region ReleaseFloatArray
	/**
	* <summary>
	* Release the memory for a float array recieved from liquidfun</summary>
	*<param name="floatArray">Pointer to the array</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int ReleaseFloatArray(IntPtr floatArray);
	#endregion ReleaseFloatArray
	
	#region ReleaseIntArray
	/**
	* <summary>
	* Release the memory for a float array recieved from liquidfun</summary>
	*<param name="intArray">Pointer to the array</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int ReleaseIntArray(IntPtr intArray);
	#endregion ReleaseIntArray
	
	#region ReleaseShape
	/**
	* <summary>
	* Release the memory for a liquidfun shape object</summary>
	*<param name="intArray">Pointer to the shape</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern int ReleaseShape(IntPtr shape);
	#endregion ReleaseShape
}