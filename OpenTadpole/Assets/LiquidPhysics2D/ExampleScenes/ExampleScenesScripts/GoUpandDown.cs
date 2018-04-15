using UnityEngine;
using System.Collections;

public class GoUpandDown : MonoBehaviour {

	LPJointPrismatic joint;
	// Use this for initialization
	void Start ()
	{
		joint  = GetComponent<LPJointPrismatic>();
		StartCoroutine("UpandDown");
	}
	
	private IEnumerator UpandDown()
	{
		while (true)
		{
			if (Random.Range(0,2) == 1)
			{
				LPAPIJoint.SetPrismaticJointMotorSpeed(joint.GetPtr(),Random.Range(-3f,3f));
			}
			yield return new WaitForSeconds(2f);
		}
	}
}
