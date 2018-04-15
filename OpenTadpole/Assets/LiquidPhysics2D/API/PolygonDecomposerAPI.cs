/*
* Farseer Physics Engine:
* Copyright (c) 2012 Ian Qvist
* 
* Original source Box2D:
* Copyright (c) 2006-2011 Erin Catto http://www.box2d.org 
* 
* This software is provided 'as-is', without any express or implied 
* warranty.  In no event will the authors be held liable for any damages 
* arising from the use of this software. 
* Permission is granted to anyone to use this software for any purpose, 
* including commercial applications, and to alter it and redistribute it 
* freely, subject to the following restrictions: 
* 1. The origin of this software must not be misrepresented; you must not 
* claim that you wrote the original software. If you use this software 
* in a product, an acknowledgment in the product documentation would be 
* appreciated but is not required. 
* 2. Altered source versions must be plainly marked as such, and must not be 
* misrepresented as being the original software. 
* 3. This notice may not be removed or altered from any source distribution. 
*/

using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Convex decomposition algorithm created by Mark Bayazit (http://mnbayazit.com/)
/// 
/// Properties:
/// - Tries to decompose using polygons instead of triangles.
/// - Tends to produce optimal results with low processing time.
/// - Running time is O(nr), n = number of vertices, r = reflex vertices.
/// - Does not support holes.
/// 
/// For more information about this algorithm, see http://mnbayazit.com/406/bayazit
/// </summary>
public static class PolygonDecomposerAPI {
	/**
	* <summary>Decomposes a concave polygon into several convex ones. Returns a list containing lists of vertices of the convex polygons.</summary>
	* <param name="vertices">The list of vertices representing the polygon to be decomposed.</param>
	**/
	public static List<List<Vector2>> DecomposePolygon(List<Vector2> vertices) {
		List<List<Vector2>> list = new List<List<Vector2>>();
		Vector2 lowerInt = new Vector2();
		Vector2 upperInt = new Vector2(); // intersection points
		int lowerIndex = 0, upperIndex = 0;
		List<Vector2> lowerPoly, upperPoly;
		
		for (int i = 0; i < vertices.Count; ++i) {
			if (Reflex(i, vertices)) {
				float upperDist;
				float lowerDist = upperDist = float.MaxValue;
				for (int j = 0; j < vertices.Count; ++j) {
					// if line intersects with an edge
					float d;
					Vector2 p;
					if (Left(At(i - 1, vertices), At(i, vertices), At(j, vertices)) && RightOn(At(i - 1, vertices), At(i, vertices), At(j - 1, vertices))) {
						// find the point of intersection
						p = LineIntersect(At(i - 1, vertices), At(i, vertices), At(j, vertices), At(j - 1, vertices));
						
						if (Right(At(i + 1, vertices), At(i, vertices), p)) {
							// make sure it's inside the poly
							d = SquareDist(At(i, vertices), p);
							if (d < lowerDist) {
								// keep only the closest intersection
								lowerDist = d;
								lowerInt = p;
								lowerIndex = j;
							}
						}
					}
					
					if (Left(At(i + 1, vertices), At(i, vertices), At(j + 1, vertices)) && RightOn(At(i + 1, vertices), At(i, vertices), At(j, vertices))) {
						p = LineIntersect(At(i + 1, vertices), At(i, vertices), At(j, vertices), At(j + 1, vertices));
						
						if (Left(At(i - 1, vertices), At(i, vertices), p)) {
							d = SquareDist(At(i, vertices), p);
							if (d < upperDist) {
								upperDist = d;
								upperIndex = j;
								upperInt = p;
							}
						}
					}
				}
				
				// if there are no vertices to connect to, choose a point in the middle
				if (lowerIndex == (upperIndex + 1) % vertices.Count) {
					Vector2 p = ((lowerInt + upperInt) / 2);
					
					lowerPoly = Copy(i, upperIndex, vertices);
					lowerPoly.Add(p);
					upperPoly = Copy(lowerIndex, i, vertices);
					upperPoly.Add(p);
				}
				else {
					double highestScore = 0, bestIndex = lowerIndex;
					while (upperIndex < lowerIndex)
						upperIndex += vertices.Count;
					
					for (int j = lowerIndex; j <= upperIndex; ++j) {
						if (CanSee(i, j, vertices)) {
							double score = 1 / (SquareDist(At(i, vertices), At(j, vertices)) + 1);
							if (Reflex(j, vertices)) {
								if (RightOn(At(j - 1, vertices), At(j, vertices), At(i, vertices)) && LeftOn(At(j + 1, vertices), At(j, vertices), At(i, vertices)))
									score += 3;
								else
									score += 2;
							}
							else {
								score += 1;
							}
							if (score > highestScore) {
								bestIndex = j;
								highestScore = score;
							}
						}
					}
					lowerPoly = Copy(i, (int)bestIndex, vertices);
					upperPoly = Copy((int)bestIndex, i, vertices);
				}
				list.AddRange(DecomposePolygon(lowerPoly));
				list.AddRange(DecomposePolygon(upperPoly));
				return list;
			}
		}
		
		// polygon is already convex
		if (vertices.Count > 8) { //MaxPolygonVertices
			lowerPoly = Copy(0, vertices.Count / 2, vertices);
			upperPoly = Copy(vertices.Count / 2, 0, vertices);
			list.AddRange(DecomposePolygon(lowerPoly));
			list.AddRange(DecomposePolygon(upperPoly));
		}
		else
			list.Add(vertices);
		
		return list;
	}
	
	private static Vector2 At(int i, List<Vector2> vertices) {
		int s = vertices.Count;
		return vertices[i < 0 ? s - 1 - ((-i - 1) % s) : i % s];
	}
	
	private static List<Vector2> Copy(int i, int j, List<Vector2> vertices) {
		while (j < i)
			j += vertices.Count;
		
		List<Vector2> p = new List<Vector2>(j);
		
		for (; i <= j; ++i) {
			p.Add(At(i, vertices));
		}
		return p;
	}
	
	private static bool CanSee(int i, int j, List<Vector2> vertices) {
		if (Reflex(i, vertices)) {
			if (LeftOn(At(i, vertices), At(i - 1, vertices), At(j, vertices)) && RightOn(At(i, vertices), At(i + 1, vertices), At(j, vertices)))
				return false;
		}
		else {
			if (RightOn(At(i, vertices), At(i + 1, vertices), At(j, vertices)) || LeftOn(At(i, vertices), At(i - 1, vertices), At(j, vertices)))
				return false;
		}
		if (Reflex(j, vertices)) {
			if (LeftOn(At(j, vertices), At(j - 1, vertices), At(i, vertices)) && RightOn(At(j, vertices), At(j + 1, vertices), At(i, vertices)))
				return false;
		}
		else {
			if (RightOn(At(j, vertices), At(j + 1, vertices), At(i, vertices)) || LeftOn(At(j, vertices), At(j - 1, vertices), At(i, vertices)))
				return false;
		}
		for (int k = 0; k < vertices.Count; ++k) {
			if ((k + 1) % vertices.Count == i || k == i || (k + 1) % vertices.Count == j || k == j)
				continue; // ignore incident edges
			
			Vector2 intersectionPoint;
			
			if (LineIntersect(At(i, vertices), At(j, vertices), At(k, vertices), At(k + 1, vertices), out intersectionPoint))
				return false;
		}
		return true;
	}
	
	private static bool Reflex(int i, List<Vector2> vertices) {
		return Right(i, vertices);
	}
	
    private static bool Right(int i, List<Vector2> vertices) {
        return Right(At(i - 1, vertices), At(i, vertices), At(i + 1, vertices));
    }
    
    private static bool Left(Vector2 a, Vector2 b, Vector2 c) {
        return Area(ref a, ref b, ref c) > 0;
    }
    
    private static bool LeftOn(Vector2 a, Vector2 b, Vector2 c) {
        return Area(ref a, ref b, ref c) >= 0;
    }
    
    private static bool Right(Vector2 a, Vector2 b, Vector2 c) {
        return Area(ref a, ref b, ref c) < 0;
    }
    
    private static bool RightOn(Vector2 a, Vector2 b, Vector2 c) {
        return Area(ref a, ref b, ref c) <= 0;
    }
    
    private static float SquareDist(Vector2 a, Vector2 b) {
        float dx = b.x - a.x;
        float dy = b.y - a.y;
        return dx * dx + dy * dy;
    }
    
    public static float Area(Vector2 a, Vector2 b, Vector2 c) {
        return Area(ref a, ref b, ref c);
    }
    
    public static float Area(ref Vector2 a, ref Vector2 b, ref Vector2 c) {
        return a.x * (b.y - c.y) + b.x * (c.y - a.y) + c.x * (a.y - b.y);
    }
    
    public static bool FloatEquals(float value1, float value2) {
        return Math.Abs(value1 - value2) <= 1.192092896e-07f;
    }
    
    public static bool FloatEquals(float value1, float value2, float delta) {
        return FloatInRange(value1, value2 - delta, value2 + delta);
    }
    
    public static bool FloatInRange(float value, float min, float max) {
        return (value >= min && value <= max);
    }
    
    //From Mark Bayazit's convex decomposition algorithm
    public static Vector2 LineIntersect(Vector2 p1, Vector2 p2, Vector2 q1, Vector2 q2) {
        Vector2 i = Vector2.zero;
        float a1 = p2.y - p1.y;
        float b1 = p1.x - p2.x;
        float c1 = a1 * p1.x + b1 * p1.y;
        float a2 = q2.y - q1.y;
        float b2 = q1.x - q2.x;
        float c2 = a2 * q1.x + b2 * q1.y;
        float det = a1 * b2 - a2 * b1;
        
        if (!FloatEquals(det, 0)) {
            // lines are not parallel
            i.x = (b2 * c1 - b1 * c2) / det;
			i.y = (a1 * c2 - a2 * c1) / det;
		}
		return i;
	}

	public static bool LineIntersect(ref Vector2 point1, ref Vector2 point2, ref Vector2 point3, ref Vector2 point4, bool firstIsSegment, bool secondIsSegment, out Vector2 point) {
		point = new Vector2();
		
		// these are reused later.
		// each lettered sub-calculation is used twice, except
		// for b and d, which are used 3 times
		float a = point4.y - point3.y;
		float b = point2.x - point1.x;
		float c = point4.x - point3.x;
		float d = point2.y - point1.y;
		
		// denominator to solution of linear system
		float denom = (a * b) - (c * d);
		
		// if denominator is 0, then lines are parallel
		if (!(denom >= -1.192092896e-07f && denom <= 1.192092896e-07f))
		{
			float e = point1.y - point3.y;
			float f = point1.x - point3.x;
			float oneOverDenom = 1.0f / denom;
			
			// numerator of first equation
			float ua = (c * e) - (a * f);
			ua *= oneOverDenom;
			
			// check if intersection point of the two lines is on line segment 1
			if (!firstIsSegment || ua >= 0.0f && ua <= 1.0f)
			{
				// numerator of second equation
				float ub = (b * e) - (d * f);
				ub *= oneOverDenom;
				
				// check if intersection point of the two lines is on line segment 2
				// means the line segments intersect, since we know it is on
				// segment 1 as well.
				if (!secondIsSegment || ub >= 0.0f && ub <= 1.0f)
				{
					// check if they are coincident (no collision in this case)
					if (ua != 0f || ub != 0f)
					{
						//There is an intersection
						point.x = point1.x + ua * b;
						point.y = point1.y + ua * d;
						return true;
					}
				}
			}
		}
		return false;
    }

	public static bool LineIntersect(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4, bool firstIsSegment, bool secondIsSegment, out Vector2 intersectionPoint) {
		return LineIntersect(ref point1, ref point2, ref point3, ref point4, firstIsSegment, secondIsSegment, out intersectionPoint);
	}

	public static bool LineIntersect(ref Vector2 point1, ref Vector2 point2, ref Vector2 point3, ref Vector2 point4, out Vector2 intersectionPoint) {
		return LineIntersect(ref point1, ref point2, ref point3, ref point4, true, true, out intersectionPoint);
	}

	public static bool LineIntersect(Vector2 point1, Vector2 point2, Vector2 point3, Vector2 point4, out Vector2 intersectionPoint) {
		return LineIntersect(ref point1, ref point2, ref point3, ref point4, true, true, out intersectionPoint);
    }
}