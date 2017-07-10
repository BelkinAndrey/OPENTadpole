using UnityEngine;
using System.Collections;

public class GUIRectSelect : MonoBehaviour {

    public GUISkin skin;

    private bool draw = false;
    private bool onSelect = false;
    private Rect rect;
    private Vector2 StartPos;
    private Vector2 EndPos;

    private bool NoSelect = false;


    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!NoSelect)
            {
                StartPos = Input.mousePosition;
                if (StartPos.y < (Screen.height - 30)) onSelect = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (draw) gameObject.GetComponent<SelectionNeuron>().SelectionRect(rect);
            draw = false;
            onSelect = false;
        }

        Vector2 OnPos = Input.mousePosition;
        if(Vector2.SqrMagnitude(OnPos - StartPos) > 500)
        {
            if (onSelect)
            {
                draw = true;
                gameObject.GetComponent<SelectionNeuron>().SelOff();
            }
        }
    }
    void OnGUI() 
    {
        GUI.skin = skin;

        if (draw) 
        {
            EndPos = Input.mousePosition;
            rect = new Rect(Mathf.Min(EndPos.x, StartPos.x),
                            Screen.height - Mathf.Max(EndPos.y, StartPos.y),
                            Mathf.Max(EndPos.x, StartPos.x) - Mathf.Min(EndPos.x, StartPos.x),
                            Mathf.Max(EndPos.y, StartPos.y) - Mathf.Min(EndPos.y, StartPos.y)
                            );
            GUI.Box(rect, "");
        }
    }

    public void EnableSelect(bool value) 
    {
        NoSelect = value;
    } 

}
