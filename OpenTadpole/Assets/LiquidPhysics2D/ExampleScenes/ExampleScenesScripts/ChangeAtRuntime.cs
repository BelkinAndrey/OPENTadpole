using UnityEngine;
using System.Collections;

public class ChangeAtRuntime : MonoBehaviour {
	
	public AnimationCurve Curve;
	
	public float ChangeTime = 2f;
	float nowtime = 0f;
	float mult = 1f;
	LPFixturePoly fix;
	LPBody bod;
	
	Vector3[] Points = new Vector3[]
	{
		new Vector3(0f,2f)
		,new Vector3(-2f,0f)
		,new Vector3(0f,-2f)
		,new Vector3(2f,0f)
	};
	
	// Use this for initialization
	void Start ()
	{
		fix = gameObject.AddComponent<LPFixturePoly>();
		fix.DefinePoints(Points);
		bod = GetComponent<LPBody>();
		bod.Initialise(FindObjectOfType<LPManager>());
	}
	
	void FixedUpdate ()
	{
		nowtime += Time.deltaTime*mult;		
		if (nowtime >= ChangeTime)
		{
			mult = -1f;
		}
		else if(nowtime <= 0f)
		{
			mult = 1f;
		}		
		float ratio = Curve.Evaluate(nowtime / ChangeTime);
		
		Points[0] = Vector3.Lerp(new Vector3(0f,2f),new Vector3(0f,5f),ratio);
		
		//Step 1: Remove old fixture
		fix.Delete();
		
		//Step 2: Add new fixture component
		fix = gameObject.AddComponent<LPFixturePoly>();
		
		//Call DefinePoints to set the polys points programmatically
		fix.DefinePoints(Points);
		
		//Step 3: Initialise the new fixture (passing in the LPBody)		
		fix.Initialise(bod);
	}
}
