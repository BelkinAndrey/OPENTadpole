using UnityEngine;
using System.Collections;

public class TestUserData : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Debug.Log(LPAPIBody.GetBodyUserData(GetComponent<LPBody>().GetPtr()));
		
		Debug.Log(LPAPIFixture.GetFixtureUserData(GetComponent<LPFixture>().GetPtr()));
	}

}
