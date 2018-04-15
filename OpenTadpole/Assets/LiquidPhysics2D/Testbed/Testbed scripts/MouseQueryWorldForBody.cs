using UnityEngine;
using System.Collections;

public class MouseQueryWorldForBody : MonoBehaviour
{
    LPManager lpMan;
    public LPBody ClickedBody = null;

	// Use this for initialization
	void Start () {
        lpMan = FindObjectOfType<LPManager>();
	}
	
	// Update is called once per frame
	void Update () {
        bool aTouch = false;
        Vector3 touchPos = new Vector3();
        InputUtilities.GetMouseInput(out aTouch, out touchPos);

        if (aTouch)
        {
            if (ClickedBody == null) // If we have not clicked on a body yet
            {
                Vector3 mousePos = touchPos;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                ClickedBody = lpMan.TestPointForBody(mousePos.x, mousePos.y);
            }
        }
        else
        {
            ClickedBody = null;
        }
	}
}
