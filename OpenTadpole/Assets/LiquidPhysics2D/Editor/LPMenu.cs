using UnityEditor;
using UnityEngine;
using System.IO;

public class LPMenu : MonoBehaviour 
{	
	[MenuItem ("Component/Liquid Physics 2D/Body")] 
	static void AddaBody()
	{ 
		if (Selection.activeGameObject != null)
		{
			if (Selection.activeGameObject.GetComponent<LPBody>() == null) 
			{	
				Undo.AddComponent<LPBody>(Selection.activeGameObject);	
			}
			else
			{
				Debug.LogError("This gameobject already has a body component (only one is allowed per unity gameobject)");
			}
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	
	//Add fixtures
	[MenuItem  ("Component/Liquid Physics 2D/Collider/Circle")] 
	static void AddaCircle()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPFixtureCircle>(Selection.activeGameObject);	
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
		
	//box
	/*
	[MenuItem( "GameObject/Create Other/Liquid Physics 2D/Collider/Box" ) ]
	static void CreateaBox()
	{ 
		GameObject box = new GameObject("LPBox");
		box.AddComponent<LPFixtureBox>();
	}*/
		
	[MenuItem  ("Component/Liquid Physics 2D/Collider/Box")] 
	static void AddaBox()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPFixtureBox>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}	
	}
	
	[MenuItem  ("Component/Liquid Physics 2D/Collider/Polygon")] 
	static void AddaPoly()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPFixturePoly>(Selection.activeGameObject);	
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}	
	[MenuItem  ("Component/Liquid Physics 2D/Collider/Edge")] 
	static void AddaChainShape()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPFixtureChainShape>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}	
	}
	
	//Add particles
	[MenuItem  ("Component/Liquid Physics 2D/Particle Group/Circle")] 
	static void AddaParticleGroupCircle()
	{ 	
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPParticleGroupCircle>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Particle Group/Square")] 
	static void AddaParticleGroupBox()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPParticleGroupBox>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Particle Group/Polygon")] 
	static void AddaParticleGroupPoly()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPParticleGroupPoly>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
			
	//Add Joints
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Weld")] 
	static void AddajointWeld()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointWeld>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Revolute")] 
	static void AddajointRevolute()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointRevolute>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Prismatic")] 
	static void AddajointPrismatic()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointPrismatic>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Rope")] 
	static void AddajointRope()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointRope>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Distance")] 
	static void AddajointDistance()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointDistance>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Pulley")] 
	static void AddajointPulley()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointPulley>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Wheel")] 
	static void AddajointWheel()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointWheel>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Mouse")] 
	static void AddajointMouse()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointMouse>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Friction")] 
	static void AddajointFriction()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointFriction>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}		
	[MenuItem  ("Component/Liquid Physics 2D/Joint/Gear")] 
	static void AddajointGear()
	{ 
		if (Selection.activeGameObject != null)
		{
			Undo.AddComponent<LPJointGear>(Selection.activeGameObject);
		}
		else
		{
			Debug.LogError("No gameobject selected");
		}
	}	
	
	
	//Create Materials
	[MenuItem  ("Assets/Create/PLParticleMaterial")] 
	static void AddaPartMat()
	{ 		
		AddAnAsset("/PLParticleMaterial",".asset",typeof(LPParticleMaterial));
	}
	
	[MenuItem  ("Assets/Create/PLParticleGroupMaterial")] 
	static void AddaGroupMat()
	{ 		
		AddAnAsset("/PLParticleGroupMaterial",".asset",typeof(LPParticleGroupMaterial));
	}
	
	private static void AddAnAsset(string name,string ext,System.Type type)
	{
		int iter = 0;
		string path = GetCurrentPath()+name+iter.ToString()+ext;
		while(File.Exists(path))
		{
			iter++;
			path = GetCurrentPath()+name+iter.ToString()+ext;
		}
		AssetDatabase.CreateAsset(ScriptableObject.CreateInstance(type),path);
	}
	
	private static string GetCurrentPath()
	{
		string path = "Assets";
		foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
		{
			path = AssetDatabase.GetAssetPath(obj);
			if (File.Exists(path))
			{
				path = Path.GetDirectoryName(path);
			}
			return path;
		}
		return path;
	}
}
