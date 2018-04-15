using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {
	
	Button activebutton;
	bool buttonactive;
	public MoveLadle ladle;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0)
		{			
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x,Input.touches[0].position.y)),Vector2.zero);
				
				if(hit.collider != null)
				{
					activebutton = hit.collider.gameObject.GetComponent<Button>().BeOnClicked();
					buttonactive =  true;
				}
			}
			else if	((Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) && buttonactive)
			{
				activebutton.BeOffClicked();
				buttonactive = false;
			}
			
			if (!buttonactive && Input.touches[0].phase != TouchPhase.Ended && Input.touches[0].phase != TouchPhase.Canceled)
			{
				ladle.MoveIt( Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x,Input.touches[0].position.y)));
			}
		} 
		
		#if UNITY_EDITOR || UNITY_STANDALONE
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
			if(hit.collider != null)
			{
				activebutton = hit.collider.gameObject.GetComponent<Button>().BeOnClicked();
				buttonactive =  true;
			}
		}
		else if (buttonactive && Input.GetMouseButtonUp(0))
		{
			activebutton.BeOffClicked();
			buttonactive = false;
		}
		if (!buttonactive && Input.GetMouseButton(0))
		{
			ladle.MoveIt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}		
		#endif
	}
}

