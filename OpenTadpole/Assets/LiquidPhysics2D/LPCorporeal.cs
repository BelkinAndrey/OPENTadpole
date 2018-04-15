using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// The base class for any classes that use polygon shapes (fixtures and particle groups)
/// Contains code for dealing with polygon editing in the unity editor</summary>
public abstract class LPCorporeal : LPThing
{
	[HideInInspector]
	public bool Drawing;
	[HideInInspector]
	public bool drawingfirstpoint;	
	[HideInInspector]
	public bool DontDrawLoop;

	[HideInInspector]
	public float ClosestDist;
	[HideInInspector]
	public bool EditMe = true;
    
	[SerializeField][HideInInspector]
	protected List<Vector3> pointsList;
	protected Vector3[] PointsCopy;
	
	protected List<IntPtr> SubPtrs;
	
	/// <summary>
	/// Get the list of points representing this polygonal shape</summary>
	public virtual List<Vector3> GetPoints()
	{
		return pointsList;
	}
	
	/// <summary>
	/// Define the points of a polygonal particle group or fixture, or a chainchape programmatically</summary>
	public virtual void DefinePoints(Vector3[] points)
	{
		if (this.GetType() == typeof(LPFixturePoly) || this.GetType() == typeof(LPParticleGroupPoly)
		    || this.GetType() == typeof(LPFixtureChainShape))
		{
			pointsList = new List<Vector3>();
			foreach(Vector3 point in points)
			{
				pointsList.Add(point);
			}
		}
	}
	
	/// <summary>
	/// Change the position of a particular point</summary>
	public virtual void EditPoint(int index,Vector3 pos)
	{
		pointsList[index] = transform.InverseTransformPoint(pos + transform.position);
	}
	
	/// <summary>
	/// Clear all the points from this polygonal shape</summary>
	public virtual void EmptyPoints()
	{
		pointsList.Clear();
	}
	
	/// <summary>
	/// Remove a particular point from this polygonal shape</summary>
	public virtual void RemovePoint(int index)
	{
		pointsList.RemoveAt(index);
	}
	
	/// <summary>
	/// Add a point to this polygonal shape, at the end of the list</summary>
	public virtual void AddPoint(Vector3 pos)
	{
		pointsList.Add(transform.InverseTransformPoint(pos + transform.position));
	}
	
	/// <summary>
	/// Insert a new point to this polygonal shape, at a particular index</summary>
	public virtual void InsertPoint(int index,Vector3 pos)
	{
		pointsList.Insert(index,transform.InverseTransformPoint(pos + transform.position));
	}		
	
	/// <summary>
	/// Initialse a subshape of this fixture or particle group (for convex shapes)</summary>
	protected abstract void InitialiseWithShape(IntPtr shape);
	
	/// <summary>
	/// Logs an error if there is an attempt to create a complex (self intersecting) shape
	/// A default diamond shape is created instead </summary>
	protected virtual void LogComplex()
	{
	}
	
	/// <summary>
	/// Gets a pointer to a Box2D poly shape object. First checks that: shape is complex or not,
	/// points are in counter-clockwise order and shape is convex or not </summary>
	protected IntPtr GetPolyShape(int NumberOfSides,float radius,Vector3 tran)
	{
		if (pointsList == null)
		{
			pointsList = LPShapeTools.makePolyPoints(NumberOfSides,radius);
		}
		PointsCopy = LPShapeTools.TransformPoints(transform,tran,pointsList);
		
		//check complex			
		if (LPShapeTools.CheckComplex(PointsCopy))
		{
			LogComplex();
			PointsCopy = LPShapeTools.TransformPoints(transform,tran,LPShapeTools.makePolyPoints(4,1f));
		}	
		
		//check anticlockwise			
		if (!LPShapeTools.CheckAntiClockwise(PointsCopy))
		{
			Array.Reverse(PointsCopy); 
		}
		
		//check convex. If convex use decomposer and create multiple fixtures
		if(PointsCopy.Length > 8 || !LPShapeTools.CheckConvex(PointsCopy))
		{					
			List<Vector2>verts = new List<Vector2>();
			
			foreach (Vector3 point in PointsCopy)
			{
				verts.Add(new Vector2(point.x,point.y));
			}
			List<List<Vector2>> bits = PolygonDecomposerAPI.DecomposePolygon(verts);
						
			if (bits.Count > 1)
			{
				SubPtrs = new List<IntPtr>();
				for (int i = 1; i < bits.Count; i++)
				{
					InitialiseWithShape(LPShapeTools.Initialise(LPShapeTools.Vec2listToVec3Array(bits[i])));
				}
			}
			
			return LPShapeTools.Initialise(LPShapeTools.Vec2listToVec3Array(bits[0]));
		}
		
		return LPShapeTools.Initialise(PointsCopy);
	}	

}
