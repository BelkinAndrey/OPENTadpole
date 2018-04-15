using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Represents a circle shaped fixture in the liquidfun simulation</summary>
public class LPFixtureCircle : LPFixture
{
	[Tooltip("Radius of this circle")]
	public float Radius = 0.25f;
	
	private Vector3 PointCopy;
    private float AdjustedRadius;
	
	public override IntPtr GetShape()
	{
		Shapetype = LPShapeTypes.Circle;
        AdjustedRadius = Radius*GetScale();
		PointCopy =  transform.TransformPoint(new Vector3(Offset.x,Offset.y))-transform.position;
		return  LPShapeCircle.Initialise(PointCopy,AdjustedRadius);
	}

    float GetScale()
    {
        float xscale = transform.lossyScale.x;
        float yscale = transform.lossyScale.y;

        if (xscale <= yscale) return xscale;

        return yscale;
    }
	
	void OnDrawGizmos()
	{ 
		if(!Application.isPlaying)
		{
            LPShapeCircle.DrawGizmos(transform, true, 0f, GetColor(), Radius * GetScale(), Offset);
		}
		else
		{
            LPShapeCircle.DrawGizmosPlaying(AdjustedRadius, transform, true, GetComponent<LPBody>().GetDiff(), GetColor(), PointCopy, true);
        }
        
    }	
}
