using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// This is the base class for bodies, fixtures, particle groups and joints</summary>
public abstract class LPThing : MonoBehaviour
{
	/// <summary>
	/// This IntPtr structure stores the pointer to the relevant C++ object in the liquidfun library.</summary> 
	protected IntPtr ThingPtr;
	
	/// <summary>
	/// Get the pointer to the C++ object represented by this object</summary>
	public IntPtr GetPtr()
	{
		return ThingPtr;
	}
	/// <summary>
	//Remove the thing from the simulation and delete the associated unity component.</summary>
	public abstract void Delete();

}
