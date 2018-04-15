using UnityEngine;
using System.Collections;

public class DestroyWhenHit : MonoBehaviour {

	LPManager lpman;
	
	// Use this for initialization
	void Start()
	{
		lpman = FindObjectOfType<LPManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (lpman.ContactListener.ParticleFixtureContacts !=null && lpman.ContactListener.ParticleFixtureContacts.Length >0)
		{
			foreach (LPContactPartFix pf in lpman.ContactListener.ParticleFixtureContacts)
			{
				if (lpman.allBodies.ContainsKey(pf.BodyIndex) && lpman.allBodies[pf.BodyIndex].BodyType == LPBodyTypes.Dynamic)
				{
					lpman.allBodies[pf.BodyIndex].Delete();
				}	
			}
		}
	}
}
