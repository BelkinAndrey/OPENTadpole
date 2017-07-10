using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GUIEditNeuron : MonoBehaviour {

    private Rect WindowsRect = new Rect(10, 10, 180, 450);

    public UnityEvent MouseWindowsOn = new UnityEvent();
    public UnityEvent MouseWindowsExit = new UnityEvent();

    private bool EnableWindows = false;

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

    private Vector2 inventoryScroll = new Vector2();

    private Neuron _EditNeuron;
    private Neuron EditNeuron 
    {
        get { return _EditNeuron; }
        set 
        {
            if (_EditNeuron != value) 
            {
                _EditNeuron = value;
                if (value != null)
                {
                    switch (value.Type)
                    {
                        case 0:
                            SimpleSummerLoad(value);
                            break;
                        case 1:
                            SimpleSummerLoad(value);
                            ModulModLoad(value);
                            break;
                        case 2:
                            SummerdINLoad(value);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    //// SimpleSummer
    private string sMaxSumm = "";
    private string sMinSumm = "";
    private string sthreshold = "";
    private string sDampfer = "";
    private string sAnswerTime = "";
    private string sReposeTime = "";

    //// ModulatorMod
    private string sMaxModul = "";
    private string sDampferM = "";
    private string sEvaluationTime = "";
    private string sIterationLimit = "";
    private string sthresholdUp = "";
    private string sStartAdaptTime = "";
    private string sSpeedAdapt = "";
    private string sMinThreshold = "";

    /// SummatordIN
    private string sthresholdDown = "";
    private string sTimeReAction = "";

    public void WindowsExist(bool value)
    {
        if (EnableWindows && value) EnableWindows = false;
        else EnableWindows = value;
    }

    void OnGUI()
    {
        if (EnableWindows)
        {
            OnRect = WindowsRect.Contains(Event.current.mousePosition);
            WindowsRect = GUI.Window(0, WindowsRect, DoMyWindow, "Edit Neuron");
        }
    }

    void DoMyWindow(int windowID) 
    {
        if (GUI.Button(new Rect(160, 2, 18, 18), "x"))
        {
            EnableWindows = false;
            MouseWindowsExit.Invoke();
        }

        if (GetComponent<SelectionNeuron>().SelectorNeuronOne != null)
        {
            GUILayout.BeginArea(new Rect(2, 20, 174, 408));
            inventoryScroll = GUILayout.BeginScrollView(inventoryScroll, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));
            EditNeuron = GetComponent<SelectionNeuron>().SelectorNeuronOne.GetComponent<InspectorNeuron>().isNeuron;
            GUILayout.Label("ID Neuron:   " + EditNeuron.IDNeuron.ToString("000000000"));
            GUILayout.Label("Type index: " + EditNeuron.Type);
            switch (EditNeuron.Type)
            {
                case 0:
                    SimpleSummer(EditNeuron);
                    break;
                case 1:
                    SimpleSummer(EditNeuron);
                    ModulMod(EditNeuron);
                    break;
                case 2:
                    SummerdIN(EditNeuron);
                    break;
                default:
                    break;
            }
            GUILayout.EndScrollView();
            GUILayout.EndArea();
            if (GUI.Button(new Rect(2, 428, 88, 20), "Cancel"))
            {
                EnableWindows = false;
                MouseWindowsExit.Invoke();
            }
            if (GUI.Button(new Rect(91, 428, 88, 20), "Ok"))
            {
                switch (EditNeuron.Type)
                {
                    case 0:
                        SimpleSummerOk(EditNeuron);
                        break;
                    case 1:
                        SimpleSummerOk(EditNeuron);
                        ModulModOk(EditNeuron);
                        break;
                    case 2:
                        SummerdINOk(EditNeuron);
                        break;
                    default:
                        break;
                }
            }
        }
        else EditNeuron = null;
        GUI.DragWindow(); 
    }

    private void SimpleSummer(Neuron N) 
    {
        GUILayout.Label("Simple summator");
        GUILayout.Label("Summ: " + (N.summator as SummatorSimple).Summ);
        GUILayout.Label("Max Summ:");
        sMaxSumm = GUILayout.TextField(sMaxSumm);
        GUILayout.Label("Min Summ:");
        sMinSumm = GUILayout.TextField(sMinSumm);
        GUILayout.Label("Threshold(" + (N.summator as SummatorSimple).threshold + "):");
        sthreshold = GUILayout.TextField(sthreshold);
        GUILayout.Label("Dampfer:");
        sDampfer = GUILayout.TextField(sDampfer);
        GUILayout.Label("AnswerTime:");
        sAnswerTime = GUILayout.TextField(sAnswerTime);
        GUILayout.Label("ReposeTime:");
        sReposeTime = GUILayout.TextField(sReposeTime);
    }

    private void ModulMod(Neuron N) 
    {
        GUILayout.Label("");
        GUILayout.Label("-- ModulatorMod --");
        GUILayout.Label("MaxModul:");
        sMaxModul = GUILayout.TextField(sMaxModul);
        GUILayout.Label("DampferM:");
        sDampferM = GUILayout.TextField(sDampferM);
        GUILayout.Label("EvaluationTime:");
        sEvaluationTime = GUILayout.TextField(sEvaluationTime);
        GUILayout.Label("IterationLimit(" + (N.modulator as ModulatorMod).iteration + "):");
        sIterationLimit = GUILayout.TextField(sIterationLimit);
        GUILayout.Label("thresholdUp:");
        sthresholdUp = GUILayout.TextField(sthresholdUp);
        GUILayout.Label("StartAdaptTime:");
        sStartAdaptTime = GUILayout.TextField(sStartAdaptTime);
        GUILayout.Label("SpeedAdapt");
        sSpeedAdapt = GUILayout.TextField(sSpeedAdapt);
        GUILayout.Label("MinThreshold");
        sMinThreshold = GUILayout.TextField(sMinThreshold);
    }

    private void SummerdIN(Neuron N) 
    {
        GUILayout.Label("Simple summator");
        GUILayout.Label("Summ: " + (N.summator as SummatordIN).Summ);
        GUILayout.Label("Max Summ:");
        sMaxSumm = GUILayout.TextField(sMaxSumm);
        GUILayout.Label("Min Summ:");
        sMinSumm = GUILayout.TextField(sMinSumm);
        GUILayout.Label("Threshold(" + (N.summator as SummatordIN).threshold + "):");
        sthreshold = GUILayout.TextField(sthreshold);
        GUILayout.Label("Dampfer:");
        sDampfer = GUILayout.TextField(sDampfer);
        GUILayout.Label("AnswerTime:");
        sAnswerTime = GUILayout.TextField(sAnswerTime);
        GUILayout.Label("ReposeTime:");
        sReposeTime = GUILayout.TextField(sReposeTime);

        GUILayout.Label("thresholdDown:");
        sthresholdDown = GUILayout.TextField(sthresholdDown);
        GUILayout.Label("TimeReAction");
        sTimeReAction = GUILayout.TextField(sTimeReAction);
    }

    private void SimpleSummerOk(Neuron N) 
    {
        float tryFloat;
        if (float.TryParse(sMaxSumm, out tryFloat)) (N.summator as SummatorSimple).MaxSumm = tryFloat;
        if (float.TryParse(sMinSumm, out tryFloat)) (N.summator as SummatorSimple).MinSumm = tryFloat;
        if (float.TryParse(sthreshold, out tryFloat)) (N.summator as SummatorSimple).threshold = tryFloat;
        if (float.TryParse(sDampfer, out tryFloat)) (N.summator as SummatorSimple).Dampfer = tryFloat;
        int tryInt;
        if (int.TryParse(sAnswerTime, out tryInt)) (N.summator as SummatorSimple).AnswerTime = tryInt;
        if (int.TryParse(sReposeTime, out tryInt)) (N.summator as SummatorSimple).ReposeTime = tryInt;
    }

    private void ModulModOk(Neuron N) 
    {
        float tryFloat;
        if (float.TryParse(sMaxModul, out tryFloat)) (N.modulator as ModulatorMod).MaxModul = tryFloat;
        if (float.TryParse(sDampferM, out tryFloat)) (N.modulator as ModulatorMod).DampferM = tryFloat;
        if (float.TryParse(sthresholdUp, out tryFloat)) (N.modulator as ModulatorMod).thresholdUp = tryFloat;
        if (float.TryParse(sMinThreshold, out tryFloat)) (N.modulator as ModulatorMod).MinThreshold = tryFloat;
        int tryInt;
        if (int.TryParse(sEvaluationTime, out tryInt)) (N.modulator as ModulatorMod).EvaluationTime = tryInt;
        if (int.TryParse(sIterationLimit, out tryInt)) (N.modulator as ModulatorMod).IterationLimit = tryInt;
        if (int.TryParse(sStartAdaptTime, out tryInt)) (N.modulator as ModulatorMod).StartAdaptTime = tryInt;
        if (int.TryParse(sSpeedAdapt, out tryInt)) (N.modulator as ModulatorMod).SpeedAdapt = tryInt;
    }

    private void SummerdINOk(Neuron N) 
    {
        float tryFloat;
        if (float.TryParse(sMaxSumm, out tryFloat)) (N.summator as SummatordIN).MaxSumm = tryFloat;
        if (float.TryParse(sMinSumm, out tryFloat)) (N.summator as SummatordIN).MinSumm = tryFloat;
        if (float.TryParse(sthreshold, out tryFloat)) (N.summator as SummatordIN).threshold = tryFloat;
        if (float.TryParse(sDampfer, out tryFloat)) (N.summator as SummatordIN).Dampfer = tryFloat;
        if (float.TryParse(sthresholdDown, out tryFloat)) (N.summator as SummatordIN).thresholdDown = tryFloat;
        int tryInt;
        if (int.TryParse(sAnswerTime, out tryInt)) (N.summator as SummatordIN).AnswerTime = tryInt;
        if (int.TryParse(sReposeTime, out tryInt)) (N.summator as SummatordIN).ReposeTime = tryInt;
        if (int.TryParse(sTimeReAction, out tryInt)) (N.summator as SummatordIN).TimeReAction = tryInt;
    } 

    private void SimpleSummerLoad(Neuron N)
    {
        sMaxSumm = "" + (N.summator as SummatorSimple).MaxSumm;
        sMinSumm = "" + (N.summator as SummatorSimple).MinSumm;
        sthreshold = "" + (N.summator as SummatorSimple).threshold;
        sDampfer = "" + (N.summator as SummatorSimple).Dampfer;
        sAnswerTime = "" + (N.summator as SummatorSimple).AnswerTime;
        sReposeTime = "" + (N.summator as SummatorSimple).ReposeTime;
    }

    private void ModulModLoad(Neuron N) 
    {
        sMaxModul = "" + (N.modulator as ModulatorMod).MaxModul;
        sDampferM = "" + (N.modulator as ModulatorMod).DampferM;
        sEvaluationTime = "" + (N.modulator as ModulatorMod).EvaluationTime;
        sIterationLimit = "" + (N.modulator as ModulatorMod).IterationLimit;
        sthresholdUp = "" + (N.modulator as ModulatorMod).thresholdUp;
        sStartAdaptTime = "" + (N.modulator as ModulatorMod).StartAdaptTime;
        sSpeedAdapt = "" + (N.modulator as ModulatorMod).SpeedAdapt;
        sMinThreshold = "" + (N.modulator as ModulatorMod).MinThreshold;
    }

    private void SummerdINLoad(Neuron N) 
    {
        sMaxSumm = "" + (N.summator as SummatordIN).MaxSumm;
        sMinSumm = "" + (N.summator as SummatordIN).MinSumm;
        sthreshold = "" + (N.summator as SummatordIN).threshold;
        sDampfer = "" + (N.summator as SummatordIN).Dampfer;
        sAnswerTime = "" + (N.summator as SummatordIN).AnswerTime;
        sReposeTime = "" + (N.summator as SummatordIN).ReposeTime;
        sthresholdDown = "" + (N.summator as SummatordIN).thresholdDown;
        sTimeReAction = "" + (N.summator as SummatordIN).TimeReAction;
    } 
}
