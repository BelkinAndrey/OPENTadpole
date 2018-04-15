using UnityEngine;
using System.Collections;

public class spawnafterwait : MonoBehaviour {

	public float spawntime = 3f;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine("SpawnNow");
	}
	
	IEnumerator SpawnNow()
	{
		yield return new WaitForSeconds(spawntime);
		
		GetComponent<LPBody>().Initialise(FindObjectOfType<LPManager>());
	}
}
