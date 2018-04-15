using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to the liquidfun contact listener</summary>
public static class LPAPIContacts {
    #region SetContactListener
	/**
	* <summary>Creates and sets a contact listener for the world, and returns a pointer to the listener.</summary>
	* <param name="world">The world.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr SetContactListener(IntPtr world);
	#endregion SetContactListener
	
    #region UpdateContactListener
	/**
	* <summary>Returns the contact info from a contact listener.</summary>
	* <param name="contactListener">The listener.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr UpdateContactListener(IntPtr contactListener);
	#endregion UpdateContactListener
}