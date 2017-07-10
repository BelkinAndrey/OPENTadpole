using UnityEngine;
using System.Collections;

public class ToolSelect : MonoBehaviour {

    private bool GoMouse = false;

    public void OnSelectTool() 
    {
        Vector3 startPos = transform.position;
        GetComponent<LineRenderer>().SetPosition(0, startPos);
        GoMouse = true;
    }

    public void OffSelectTool() 
    {
        GoMouse = false;
        GetComponent<LineRenderer>().enabled = false;
        transform.parent.gameObject.SendMessage("OffSelectTarget");
    }

    public void SelectTool(GameObject Neuron) 
    {
        GoMouse = false;
        Vector3 Pos = Neuron.transform.position;
        GetComponent<LineRenderer>().SetPosition(1, Pos);
        transform.parent.gameObject.SendMessage("OnSelectTarget", Neuron);
    }

    void Update()
    {
        if (GoMouse)
        {
            Vector3 endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 1f;
            gameObject.GetComponent<LineRenderer>().SetPosition(1, endPos);
            if (!GetComponent<LineRenderer>().enabled) GetComponent<LineRenderer>().enabled = true;
        }
    }

    public void LoodTool(GameObject Neuron) 
    {
        Vector3 startPos = transform.position;
        GetComponent<LineRenderer>().SetPosition(0, startPos);
        Vector3 Pos = Neuron.transform.position;
        GetComponent<LineRenderer>().SetPosition(1, Pos);
        GetComponent<LineRenderer>().enabled = true;
        transform.parent.gameObject.SendMessage("OnSelectTarget", Neuron);
    }
}
