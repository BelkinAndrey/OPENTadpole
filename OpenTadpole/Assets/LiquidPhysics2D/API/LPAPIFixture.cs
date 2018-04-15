using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun fixtures</summary>
public static class LPAPIFixture {
	#region AddFixture
	/**
	* <summary>Creates a fixture, and returns an IntPtr containing its memory address.</summary>
	* <param name="bodyPointer">A pointer to the body that the fixture will be attached to.</param>
	* <param name="shapeType">The shape of the fixture. 0 for Polygon, 1 for Circle, 2 for Edge, 3 for Chain or Ellipse.</param>
	* <param name="shapePointer">Pointer to the shape.</param>
	* <param name="density">Density of the fixture.</param>
	* <param name="userData">User data for the fixture.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr AddFixture(IntPtr bodyPointer, int shapeType, IntPtr shapePointer, float density, float friction, float restitution, bool isSensor, int userData);
	#endregion AddFixture
	
	#region GetFixtureInfo
	/**
	* <summary>Returns an IntPtr to an array of floats containing basic information about a fixture, with its X Position at array[0], Y Position at array[1], and its Angle at array[2] </summary>
	* <param name="fixture">A pointer to the fixture who's information will be returned.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetFixtureInfo(IntPtr fixture);
    #endregion GetFixtureInfo
	
	#region GetFixtureUserData
    /**
    * <summary>Gets the user data of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture who's user data will be returned.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern int GetFixtureUserData(IntPtr fixture);
    #endregion GetFixtureUserData
	
	#region SetFixtureFilterData
    /**
    * <summary>Sets the filter data of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture who's user data will be returned.</param>
    * <param name="groupIndex">Specify an integral group index. You can have all fixtures with the same group index always collide (positive index) or never collide (negative index).  Note: Collisions between fixtures of different group indices are filtered according the category and mask bits.</param>
    * <param name="categoryBits">Specify which category this fixture belongs to. LiquidFun supports 16 categories (0-15).</param>
    * <param name="maskBits">Specify which category this fixture can collide with.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern void SetFixtureFilterData(IntPtr fixture, Int16 groupIndex, UInt16 categoryBits, UInt16 maskBits);
    #endregion SetFixtureFilterData
	
	#region GetFixtureGroupIndex
    /**
    * <summary>Gets the groupIndex filter data of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture who's index will be returned.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern UInt16 GetFixtureGroupIndex(IntPtr fixture);
    #endregion GetFixtureGroupIndex
	
	#region GetFixtureCategoryBits
    /**
    * <summary>Gets the categoryBits filter data of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture who's filter data will be returned.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern UInt16 GetFixtureCategoryBits(IntPtr fixture);
    #endregion GetFixtureCategoryBits
	
	#region GetFixtureMaskBits
    /**
    * <summary>Gets the maskBits filter data of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture who's filter data will be returned.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern UInt16 GetFixtureMaskBits(IntPtr fixture);
    #endregion GetFixtureMaskBits
	
	#region TestPoint
    /**
    * <summary>Tests whether a point is contained in a fixture.</summary>
    * <param name="fixture">A pointer to the fixture who's fixture.</param>
	* <param name="x">The point to test (x position).</param>
	* <param name="y">The point to test (y position).</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern bool TestPoint(IntPtr fixture, float x, float y);
    #endregion TestPoint
	
	#region SetFixtureIsSensor
    /**
    * <summary>Set whether this fixture is a sensor.</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    * <param name="flag">Is it a sensor?</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern void SetFixtureIsSensor(IntPtr fixture, bool flag);
    #endregion SetFixtureIsSensor
	
	#region GetFixtureIsSensor
    /**
    * <summary>Is this fixture is a sensor?</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern bool GetFixtureIsSensor(IntPtr fixture);
    #endregion GetFixtureIsSensor
	
	#region SetFixtureDensity
    /**
    * <summary>Set the density of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    * <param name="density">The density.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern void SetFixtureDensity(IntPtr fixture, float density);
    #endregion SetFixtureDensity
	
	#region GetFixtureDensity
    /**
    * <summary>Get the density of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern float GetFixtureDensity(IntPtr fixture);
    #endregion GetFixtureDensity
	
	#region SetFixtureFriction
    /**
    * <summary>Set the friction of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    * <param name="friction">The friction.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern void SetFixtureFriction(IntPtr fixture, float friction);
    #endregion SetFixtureFriction
	
	#region GetFixtureFriction
    /**
    * <summary>Get the friction of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern float GetFixtureFriction(IntPtr fixture);
    #endregion GetFixtureFriction
	
	#region SetFixtureRestitution
    /**
    * <summary>Set the restitution of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    * <param name="restitution">The restitution.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern void SetFixtureRestitution(IntPtr fixture, float restitution);
    #endregion SetFixtureRestitution
	
	#region GetFixtureRestitution
    /**
    * <summary>Get the restitution of a fixture.</summary>
    * <param name="fixture">A pointer to the fixture.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern float GetFixtureRestitution(IntPtr fixture);
    #endregion GetFixtureRestitution
	
	#region DeleteFixture
    /**
    * <summary>Deletes a fixture. This will automatically adjust the mass of the body if the body is dynamic and the fixture has positive density. This function is locked during callbacks.</summary>
    * <param name="bodyPointer">Pointer to the body that the fixture is associated with.</param>
	* <param name="fixturePointer">The fixture which will be deleted.</param>
    **/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
    public static extern void DeleteFixture(IntPtr bodyPointer, IntPtr fixturePointer);
    #endregion DeleteFixture
}