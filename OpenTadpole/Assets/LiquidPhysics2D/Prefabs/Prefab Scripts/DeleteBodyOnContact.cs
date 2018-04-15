using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeleteBodyOnContact : MonoBehaviour
{
	private LPManager lpman;
	private LPBody bod;
		
	void Start()
	{
		bod = GetComponent<LPBody>();
		lpman = FindObjectOfType<LPManager>();
		if (lpman.UseContactListener == false)
		{
			Debug.LogError("This body destroyer needs 'Use Contact Listener' in the LPManager component in this scene to be set to reue in order to work");
		}
	}
	
	void FixedUpdate ()
	{
		if (lpman.ContactListener.FixtureFixtureContacts != null)
		{
			foreach (LPContactFixFix con in lpman.ContactListener.FixtureFixtureContacts )
			{
				if (con.BodyAIndex == bod.myIndex)
				{
					if (lpman.allBodies.ContainsKey(con.BodyBIndex))
					{
						lpman.allBodies[con.BodyBIndex].Delete();
					}
				}
				if (con.BodyBIndex == bod.myIndex)
				{
					if (lpman.allBodies.ContainsKey(con.BodyAIndex))
					{
						lpman.allBodies[con.BodyAIndex].Delete();
					}
				}
			}
		}		
	}
}
