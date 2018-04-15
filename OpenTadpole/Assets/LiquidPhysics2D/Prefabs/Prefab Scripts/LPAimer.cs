using UnityEngine;
using System.Collections;

public abstract class LPAimer : MonoBehaviour
{
	[Tooltip("Spawner: should this begin spawning when the game starts? Acclerator: should this accelerate operate?")]
	public bool Active = true;
	public LPTarget target;
	[HideInInspector]
	public Color _Color = Color.white;
	
	protected Vector3 getdiff()
	{
		return target.transform.position - transform.position;
	}
	
	protected void drawGiz()
	{
        Gizmos.DrawLine(transform.position, target.transform.position);
	}
}
