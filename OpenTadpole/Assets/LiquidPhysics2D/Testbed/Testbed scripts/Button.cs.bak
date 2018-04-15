using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour 
{	
	protected bool On = false;
	
	public virtual Button BeOnClicked()
	{
		GetComponent<SpriteRenderer>().color = Color.red;
		On = true;
		return this;
	}
	
	public virtual void BeOffClicked()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
		On = false;
	}

}
