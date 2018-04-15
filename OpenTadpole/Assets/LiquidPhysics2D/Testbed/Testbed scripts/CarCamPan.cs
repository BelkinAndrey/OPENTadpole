using UnityEngine;
using System.Collections;

public class CarCamPan : MonoBehaviour {

	public GameObject subject;
	Vector3 diff;
	
	// Use this for initialization
	void Start ()
	{
		diff = transform.position - subject.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		transform.position = subject.transform.position + diff;
	}
}
