using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class GUIWindowEditSynapse : MonoBehaviour {

    public GUISkin skin;

    public GameObject GizmaSynapse;

    public UnityEvent MouseWindowsOn = new UnityEvent();
    public UnityEvent MouseWindowsExit = new UnityEvent();

    private Synapse EditSynanse;

    private bool EnableWindows = false;
    private Rect WindowsRect = new Rect(15, 15, 430, 250);

    private bool _OnRect = false;
    private bool OnRect
    {
        get { return _OnRect; }
        set
        {
            if (_OnRect != value)
            {
                if (value) { MouseWindowsOn.Invoke(); }
                else { MouseWindowsExit.Invoke(); }
            }
            _OnRect = value;
        }
    }

    private string[] ButtonSPrePost = new string[] {"PreSynapses", "PostSynapses" };
    private int intButtonPrePost = 0;

    private Vector2 ScrollBlok;

    private string[] ButtonTypeS = new string[] { "I", "M", "E" };

    private string forceS = "";
    private string delayS = "";
    private string descriptorS = "";

    private float distanse;

    void OnGUI() 
    {
        GUI.skin = skin;

        if (EnableWindows)
        {
            OnRect = WindowsRect.Contains(Event.current.mousePosition);
            WindowsRect = GUI.Window(0, WindowsRect, DoMyWindow, "Edit Synapses");
        }
    }


    void DoMyWindow(int windowID) 
    {
        if (GUI.Button(new Rect(408, 2, 18, 18), "x")) 
        {
            EnableWindows = false;
            if (GizmaSynapse != null) GizmaSynapse.SetActive(false);
            MouseWindowsExit.Invoke();
        }

        if (GetComponent<SelectionNeuron>().SelectorNeuronOne != null)
        {
            intButtonPrePost = GUI.SelectionGrid(new Rect(5, 20, 200, 20), intButtonPrePost, ButtonSPrePost, ButtonSPrePost.Length);

            GUILayout.BeginArea(new Rect(5, 42, 200, 203), GUI.skin.box);
            ScrollBlok = GUILayout.BeginScrollView(ScrollBlok, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

            if (intButtonPrePost == 0)
            {
                List<Synapse> hit = GetComponent<SelectionNeuron>().SelectorNeuronOne.GetComponent<InspectorNeuron>().isNeuron.PreSynapses;
                for (int i = 0; i < hit.Count; i++) 
                {
                    string ButtonName = "" + (i + 1) + ". #" + hit[i].parentNeuron.IDNeuron.ToString("000000") + " >>  #" + hit[i].targetNeuron.IDNeuron.ToString("000000");
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button(ButtonName)) 
                    {
                        ButtonOn(hit[i]);
                    }
                    GUILayout.EndHorizontal();
                }
            }

            if (intButtonPrePost == 1)
            {
                List<Synapse> hit = GetComponent<SelectionNeuron>().SelectorNeuronOne.GetComponent<InspectorNeuron>().isNeuron.PostSynapses;
                for (int i = 0; i < hit.Count; i++)
                {
                    string ButtonName = "" + (i + 1) + ". #" + hit[i].parentNeuron.IDNeuron.ToString("000000") + " >>  #" + hit[i].targetNeuron.IDNeuron.ToString("000000");
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button(ButtonName))
                    {
                       ButtonOn(hit[i]);
                    }
                    GUILayout.EndHorizontal();
                }
            }

            GUILayout.EndScrollView();
            GUILayout.EndArea();

            if (EditSynanse != null)
            {
                GUI.Label(new Rect(210, 40, 100, 20), "Type");
                EditSynanse.TypeSynapse = GUI.SelectionGrid(new Rect(310, 40, 100, 20), EditSynanse.TypeSynapse, ButtonTypeS, ButtonTypeS.Length);
                GUI.Label(new Rect(210, 65, 100, 20), "Force");
                forceS = GUI.TextField(new Rect(310, 65, 100, 20), forceS);
                GUI.Label(new Rect(210, 90, 100, 20), "Delay");
                delayS = GUI.TextField(new Rect(310, 90, 100, 20), delayS);
               // GUI.Label(new Rect(210, 115, 100, 20), "descriptor");
               // descriptorS = GUI.TextField(new Rect(310, 115, 100, 20), descriptorS);
               // GUI.Label(new Rect(210, 140, 100, 20), "Freeze");
               // EditSynanse.Freeze = GUI.Toggle(new Rect(310, 140, 100, 20), EditSynanse.Freeze, "");
                GUI.Label(new Rect(210, 165, 200, 20), "Distanse = " + distanse.ToString("0.00"));
                if (GUI.Button(new Rect(260, 190, 110, 20), "Delete Synapse")) DeleteSynapse();
                if (GUI.Button(new Rect(210, 220, 100, 20), "Close"))
                {
                    EnableWindows = false;
                    if (GizmaSynapse != null) GizmaSynapse.SetActive(false);
                    MouseWindowsExit.Invoke();
                }
                if (GUI.Button(new Rect(315, 220, 100, 20), "OK")) 
                {
                    float tryFloat;
                    if (float.TryParse(forceS, out tryFloat)) EditSynanse.Force = tryFloat;
                    int tryInt;
                    if (int.TryParse(delayS, out tryInt)) EditSynanse.Delay = tryInt;
                    if (int.TryParse(descriptorS, out tryInt)) EditSynanse.descriptor = tryInt;
                }
            }
            else GUI.Label(new Rect(210, 20, 200, 20), "Not select synapse");
        }

        GUI.DragWindow(); 
    }

    public void WindowsExist(bool value) 
    {
        if (EnableWindows && value) EnableWindows = false; 
        else EnableWindows = value;
    }

    private void ButtonOn(Synapse value) 
    { 
        if (GizmaSynapse != null)
        {
            GizmaSynapse.SetActive(true);
            GizmaSynapse.GetComponent<LineRenderer>().SetPosition(0, value.parentNeuron.position);
            GizmaSynapse.GetComponent<LineRenderer>().SetPosition(1, value.targetNeuron.position);
        }
        EditSynanse = value;
        forceS = "" + value.Force;
        delayS = "" + value.Delay;
        descriptorS = "" + value.descriptor;
        distanse = Vector2.Distance(value.parentNeuron.position, value.targetNeuron.position);
    }

    private void DeleteSynapse() 
    {
        EditSynanse.parentNeuron.PreSynapses.Remove(EditSynanse);
        EditSynanse.targetNeuron.PostSynapses.Remove(EditSynanse);
        GetComponent<SpaceNeuron>().SynapseList.Remove(EditSynanse);
        EditSynanse.DeleteSynapse();
        if (GizmaSynapse != null) GizmaSynapse.SetActive(false);
        EditSynanse = null;
    }
}
