using UnityEngine;
using System.Collections;

public class MouseJointTarget : MonoBehaviour {

	public LPJointMouse mousejoint;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		mousejoint.SetTarget(transform.position);
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position,0.5f);
	}
}
