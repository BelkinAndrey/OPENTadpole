using UnityEngine;
using System.Collections;

public class Movemanipulator : MonoBehaviour {

	public LPJointMouse mj;
	
	public void MoveIt(Vector3 pos)
	{
		mj.SetTarget(Camera.main.ScreenToWorldPoint(pos));	
	}
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0)
		{			
			MoveIt(Input.touches[0].position);
		}
		#if UNITY_EDITOR || UNITY_STANDALONE  
		if (Input.GetMouseButton(0))
		{
			MoveIt(Input.mousePosition);
		}
		#endif
	}
}
