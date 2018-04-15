using UnityEngine;
using System.Collections;

public class SetPoly : MonoBehaviour {

	public GameObject PolyFix;
	public GameObject PolyPart;
	public GameObject ChainFix;
	
	Vector3[] Points = new Vector3[]
	{
		 new Vector3(-1f,0.5f)
		,new Vector3(0.2f,-0.8f)
		,new Vector3(1.5f,0.5f)
	};
		
	// Use this for initialization
	void Start ()
	{
		MakePolyFix();
		MakePolyPart();
		MakeChainFix();
	}
	
	void MakePolyFix()
	{
		//Add an LPFixturePoly to the gameobject (LPBody is required so is added automatically)
		LPFixturePoly fix = PolyFix.AddComponent<LPFixturePoly>();
		
		//Call DefinePoints to set the polys points programmatically
		fix.DefinePoints(Points);
		
		//Set up the body how we want
		LPBody bod = PolyFix.GetComponent<LPBody>();
		bod.BodyType = LPBodyTypes.Dynamic;
		
		//Call initialise on the LPBody component passing in the LPManager component		
		bod.Initialise(FindObjectOfType<LPManager>());
	}
	
	void MakePolyPart()
	{
		//Add an LPParticleGroupPoly to the gameobject 
		LPParticleGroupPoly group = PolyPart.AddComponent<LPParticleGroupPoly>();
		
		//Call DefinePoints to set the polys points programmatically
		group.DefinePoints(Points);
		
		//Call initialise on the LPParticleGroupPoly component passing in the chosen LPParticleSystem component	
		//In this case it must be particlesystem 0, as there is only one particlesystem in this scene	
		group.Initialise(FindObjectOfType<LPManager>().ParticleSystems[0]);
	}
	
	void MakeChainFix()
	{
		//Add an LPFixtureChainShape to the gameobject (LPBody is required so is added automatically)
		LPFixtureChainShape fix = ChainFix.AddComponent<LPFixtureChainShape>();
		
		//Call DefinePoints to set the polys points programmatically
		fix.DefinePoints(Points);
		
		//Set up the body how we want
		LPBody bod = ChainFix.GetComponent<LPBody>();
		bod.BodyType = LPBodyTypes.Dynamic;
		
		//Call initialise on the LPBody component passing in the LPManager component		
		bod.Initialise(FindObjectOfType<LPManager>());
	}
	
}
