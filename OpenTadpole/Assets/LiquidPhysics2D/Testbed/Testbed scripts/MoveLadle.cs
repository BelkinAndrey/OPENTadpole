using UnityEngine;
using System.Collections;

public class MoveLadle : MonoBehaviour
{

	public LPJointMouse mj;
		
	// Use this for initialization
	void Start ()
	{
	
	}
	
	public void MoveIt(Vector3 pos)
	{
		mj.SetTarget(pos);	
	}
}
