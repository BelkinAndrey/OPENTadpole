using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class InputEvent : MonoBehaviour {


    delegate void ModeLeftButton(RaycastHit2D _hit);
    ModeLeftButton modeButton;

    public UnityEvent MauseRightButtonEvent = new UnityEvent();
    public UnityEvent MauseRightUpEvent = new UnityEvent();

    public UnityEvent MouseLeftDown = new UnityEvent();
    public UnityEvent MouseLeftUp = new UnityEvent();

    private GameObject toolAction;

    void Awake() 
    {
        modeButton = ModeSelection;
    }
	void Update () {

        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 PointMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(PointMouse, Vector2.zero);
            modeButton(hit);
            MouseLeftDown.Invoke();
            if (modeButton != ModeSelectTargetNeuronTool) OffSelectTool();
        }

        if (Input.GetMouseButtonUp(0)) 
        {
            MouseLeftUp.Invoke();
        }

        if (Input.GetMouseButtonDown(1)) 
        {
            MauseRightButtonEvent.Invoke();
        }

        if (Input.GetMouseButtonUp(1)) 
        {
            MauseRightUpEvent.Invoke();
        }
	}

    public void SetSynapseEdit(bool value) 
    {
        if (value) modeButton = ModeNewSynaps;
        else modeButton = ModeSelection;
    }

    public void SetNoSelectMode(bool value) 
    {
        if (value) modeButton = ModeNoSelect;
        else modeButton = ModeSelection;
    }

    void ModeNewSynaps(RaycastHit2D _hit) 
    {
        if (_hit.collider != null)
        {
           if (_hit.collider.tag == "Neuron")
           {
                GetComponent<InsertSynapse>().SynapseInsert(GetComponent<SelectionNeuron>().SelectorNeuronOne, _hit.collider.gameObject);
           }
        }
    }

    void ModeSelection(RaycastHit2D _hit)
    {
        if (_hit.collider != null)
        {
            if (_hit.collider.tag == "Neuron")
            {
                GetComponent<SelectionNeuron>().RayOn(_hit.collider.gameObject);
            }
            else GetComponent<SelectionNeuron>().RayOn(null);

            if (_hit.collider.tag == "Tool") 
            {
                if (toolAction != null) toolAction.GetComponent<ToolSelect>().OffSelectTool();
                _hit.collider.GetComponent<ToolSelect>().OnSelectTool();
                toolAction = _hit.collider.gameObject;
                modeButton = ModeSelectTargetNeuronTool;
            }
        }
        else GetComponent<SelectionNeuron>().RayOn(null);
    }

    void ModeNoSelect(RaycastHit2D _hit) 
    {
        //
    }

    void ModeSelectTargetNeuronTool(RaycastHit2D hit) 
    {
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Neuron")
            {
                toolAction.GetComponent<ToolSelect>().SelectTool(hit.collider.gameObject);
                toolAction = null;
                modeButton = ModeSelection;
            }
        }
    }

    public void OffSelectTool() 
    {
        if (toolAction != null) toolAction.GetComponent<ToolSelect>().OffSelectTool();
        //Отмена события
    }
}
