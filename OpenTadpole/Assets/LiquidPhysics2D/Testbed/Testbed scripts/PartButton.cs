using UnityEngine;
using System.Collections;

public class PartButton : Button2
{
	public LPSpawner Spawner;
	
	public override Button2 BeOnClicked()
	{
		GetComponent<SpriteRenderer>().color = Color.gray;
		On = true;
		Spawner.StartSpawning();
		return this;
	}
	
	public override void BeOffClicked()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
		On = false;
		Spawner.StopSpawning();
	}
}
