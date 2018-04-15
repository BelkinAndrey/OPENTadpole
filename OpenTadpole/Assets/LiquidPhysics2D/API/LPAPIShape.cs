using System;
using UnityEngine;
using System.Runtime.InteropServices;

/// <summary>Functions relating to liquidfun shapes</summary>
public static class LPAPIShape {
	#region GetBoxShapeDef
	/**
	* <summary>Creates a box shape, and returns an IntPtr containing its memory address.</summary>
	* <param name="width">The width of the box.</param>
	* <param name="height">The height of the box.</param>
	* <param name="centreX">The X Position of the box's centre.</param>
	* <param name="centreY">The Y Position of the box's centre.</param>
	* <param name="angle">The angle of the box.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetBoxShapeDef(float width, float height, float centreX, float centreY, float angle);
	#endregion GetBoxShapeDef
	
	#region GetCircleShapeDef
	/**
	* <summary>Creates a circle shape, and returns an IntPtr containing its memory address.</summary>
	* <param name="radius">The radius of the circle.</param>
	* <param name="centreX">X Position of the circle's centre, relative to the position of the body it will be attached to.</param>
	* <param name="centreY">Y Position of the circle's centre, relative to the position of the body it will be attached to.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetCircleShapeDef(float radius, float centreX, float centreY);
	#endregion GetCircleShapeDef
	
	#region GetPolygonShapeDef
	/**
	* <summary>Creates a polygon shape, and returns an IntPtr containing its memory address.</summary>
	* <param name="vertexArray">A float array containing all vertices. Index 0 MUST contain the length of the array. X and Y positions alternate from index 1 onwards, in a CCW winding order.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetPolygonShapeDef([In, MarshalAs(UnmanagedType.LPArray)] float[] vertexArray);
	#endregion GetPolygonShapeDef
	
	#region GetChainShapeDef
	/**
	* <summary>Creates a chain shape, and returns an IntPtr containing its memory address.</summary>
	* <param name="vertexArray">A float array containing all vertices. Index 0 MUST contain the length of the array. X and Y positions alternate from index 1 onwards, in a CCW winding order.</param>
	* <param name="loop">Set to true if the shape should be looped - The final vertex will be connected to the first vertex automatically.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetChainShapeDef([In, MarshalAs(UnmanagedType.LPArray)] float[] vertexArray, bool loop);
	#endregion GetChainShapeDef
	
	#region GetEdgeShapeDef
	/**
	* <summary>Creates a edge shape, and returns an IntPtr containing its memory address.</summary>
	* <param name="x1">X position of the edge's first vertex.</param>
	* <param name="y1">Y position of the edge's first vertex.</param>
	* <param name="x2">X position of the edge's second vertex.</param>
	* <param name="y2">Y position of the edge's second vertex.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetEdgeShapeDef(float x1, float y1, float x2, float y2);
	#endregion GetEdgeShapeDef
	
	#region GetEllipseShapeDef
	/**
	* <summary>Creates a polygon shape representing an ellipse, and returns an IntPtr containing its memory address.</summary>
	* <param name="outerRadius">Outer radius of the ellipse (length of the semi-major axis).</param>
	* <param name="divisions">Number of divisions/vertices to use. Use more for higher shape accuracy, at a cost of reduced performance.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	public static extern IntPtr GetEllipseShapeDef(float outerRadius, float divisions);
	#endregion GetEllipseShapeDef
	
	#region GetPolyShapeCentroid
	/**
	* <summary>Returns a 2 element float array containing the x and y positions of a polygon shape's centroid. The array must be marshalled before use.</summary>
	* <param name="shape">Pointer to the shape.</param>
	**/
	#if UNITY_IPHONE && !UNITY_EDITOR
	[DllImport ("__Internal")]   
	#else
	[DllImport ("liquidfundll")]
	#endif
	private static extern IntPtr GetPolyShapeCentroid(IntPtr shape);
	#endregion GetPolyShapeCentroid
	
	#region GetPolygonShapeCentroid
	/**
	* <summary>Returns the centroid of a polygon shape as a Vector2.</summary>
	* <param name="shape">Pointer to the shape.</param>
	**/
	public static Vector2 GetPolygonShapeCentroid(IntPtr shape) {
		IntPtr centroidArrayPointer = GetPolyShapeCentroid(shape);
        float[] centroidArray = new float[2];
        Marshal.Copy(centroidArrayPointer,centroidArray,0,2);
		Vector2 centroid = new Vector2(centroidArray[0], centroidArray[1]);
        return centroid;
	}
	#endregion GetPolygonShapeCentroid
}