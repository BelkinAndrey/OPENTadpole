using UnityEngine;
using System.Collections;

public class LPPrefabSpawner : LPSpawner
{
	
	public GameObject Prefab;
	
	protected override void Start2()
	{
	}
		
	protected override void DoSpawn()
	{
		GameObject ob = Instantiate(Prefab,transform.position,Quaternion.AngleAxis(Random.Range(0f,360f),Vector3.back)) as GameObject;
		LPBody bod = ob.GetComponent<LPBody>();
		bod.Initialise(lpman);
		Vector3 diff = getdiff();
		LPAPIBody.ApplyLinearImpulseToBody(bod.GetPtr(),diff.x,diff.y,ob.transform.position.x,ob.transform.position.y,true);
	}
	
	void OnDrawGizmos()
	{
		drawGiz();
	}
}
