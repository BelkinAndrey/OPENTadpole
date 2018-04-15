using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxSpawner : MonoBehaviour
{
	public LPManager lpman;
	public float spawninterval = 1.5f;
	public int amount = 3;
	public Vector2 SpawnVelocity;
	private	List<LPBody> bodylist = new List<LPBody>();
	void Start()
	{
		lpman = FindObjectOfType<LPManager>();
		StartCoroutine("Spawn");
	}
	private IEnumerator Spawn()
	{
		while(true)
		{
			if (bodylist.Count > amount)
			{
				bodylist[0].Delete();
				bodylist.RemoveAt(0);
			}
			GameObject go = new GameObject("body");
			go.transform.parent = transform;
			go.transform.position = transform.position;
			LPBody body = go.AddComponent<LPBody>();
			bodylist.Add(body);
			LPFixtureCircle circle = go.AddComponent<LPFixtureCircle>();
			circle.Density = 0.2f;
			circle.Radius = 0.1f;
			body.BodyType = LPBodyTypes.Dynamic;
			body.Initialise(lpman);
			LPAPIBody.ApplyForceToCentreOfBody(body.GetPtr(),SpawnVelocity.x,SpawnVelocity.y);
			yield return new WaitForSeconds(spawninterval);
		}	
	}
}