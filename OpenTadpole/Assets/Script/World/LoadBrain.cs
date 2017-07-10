using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using UnityEngine.UI;

public class LoadBrain : MonoBehaviour {

    public string PathFile;  //путь к файлу

    public string[] listTols;

    public int[] NeuronTools = new int[36];

    public Text errorText;

    void Start()
    {
        if (PlayerPrefs.HasKey("Path")) PathFile = PlayerPrefs.GetString("Path"); // PlayerPrefs для пути к файлу.
        if (PathFile != "")
        {
            if (File.Exists(Application.dataPath + "/Data/" + PathFile + ".tad"))
            {
                Load();
            }
            else 
            {
                errorText.enabled = true;
            }
        }
    }

    public void Open()
    {
        if (PathFile != "")
        {
            if (File.Exists(Application.dataPath + "/Data/" + PathFile + ".tad"))
            {
                PlayerPrefs.SetString("Path", PathFile);
                Application.LoadLevel(1);
            }
        }
    }

    void Load()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Application.dataPath + "/Data/" + PathFile + ".tad"); //открываем файл


        int maxId = 0;
        foreach (XmlNode node in xmlDoc.SelectNodes("NetSave/Neurons/Neuron"))
        {
            int type = int.Parse(node.Attributes.GetNamedItem("Type").Value);
            Vector2 pos = new Vector2(float.Parse(node.Attributes.GetNamedItem("X").Value), float.Parse(node.Attributes.GetNamedItem("Y").Value));
            int Layer = int.Parse(node.Attributes.GetNamedItem("Layer").Value);

            Neuron neuron = GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().CreateNeuron(pos, Layer, type);

            int id = int.Parse(node.Attributes.GetNamedItem("IDNeuron").Value);
            neuron.IDNeuron = id;
            if (id > maxId) maxId = id;

            if (node.Attributes["MaxSumm"] != null)
            {
                if (neuron.summator.GetType() == typeof(SummatorSimple))
                    (neuron.summator as SummatorSimple).MaxSumm = float.Parse(node.Attributes.GetNamedItem("MaxSumm").Value);
                if (neuron.summator.GetType() == typeof(SummatordIN))
                    (neuron.summator as SummatordIN).MaxSumm = float.Parse(node.Attributes.GetNamedItem("MaxSumm").Value);
            }

            if (node.Attributes["MinSumm"] != null)
            {
                if (neuron.summator.GetType() == typeof(SummatorSimple))
                    (neuron.summator as SummatorSimple).MinSumm = float.Parse(node.Attributes.GetNamedItem("MinSumm").Value);
                if (neuron.summator.GetType() == typeof(SummatordIN))
                    (neuron.summator as SummatordIN).MinSumm = float.Parse(node.Attributes.GetNamedItem("MinSumm").Value);
            }

            if (node.Attributes["threshold"] != null)
            {
                if (neuron.summator.GetType() == typeof(SummatorSimple))
                    (neuron.summator as SummatorSimple).threshold = float.Parse(node.Attributes.GetNamedItem("threshold").Value);
                if (neuron.summator.GetType() == typeof(SummatordIN))
                    (neuron.summator as SummatordIN).threshold = float.Parse(node.Attributes.GetNamedItem("threshold").Value);
            }

            if (node.Attributes["Dampfer"] != null)
            {
                if (neuron.summator.GetType() == typeof(SummatorSimple))
                    (neuron.summator as SummatorSimple).Dampfer = float.Parse(node.Attributes.GetNamedItem("Dampfer").Value);
                if (neuron.summator.GetType() == typeof(SummatordIN))
                    (neuron.summator as SummatordIN).Dampfer = float.Parse(node.Attributes.GetNamedItem("Dampfer").Value);
            }

            if (node.Attributes["AnswerTime"] != null)
            {
                if (neuron.summator.GetType() == typeof(SummatorSimple))
                    (neuron.summator as SummatorSimple).AnswerTime = int.Parse(node.Attributes.GetNamedItem("AnswerTime").Value);
                if (neuron.summator.GetType() == typeof(SummatordIN))
                    (neuron.summator as SummatordIN).AnswerTime = int.Parse(node.Attributes.GetNamedItem("AnswerTime").Value);
            }

            if (node.Attributes["ReposeTime"] != null)
            {
                if (neuron.summator.GetType() == typeof(SummatorSimple))
                    (neuron.summator as SummatorSimple).ReposeTime = int.Parse(node.Attributes.GetNamedItem("ReposeTime").Value);
                if (neuron.summator.GetType() == typeof(SummatordIN))
                    (neuron.summator as SummatordIN).ReposeTime = int.Parse(node.Attributes.GetNamedItem("ReposeTime").Value);
            }

            if (node.Attributes["MaxModul"] != null)
                (neuron.modulator as ModulatorMod).MaxModul = float.Parse(node.Attributes.GetNamedItem("MaxModul").Value);

            if (node.Attributes["DampferM"] != null)
                (neuron.modulator as ModulatorMod).DampferM = float.Parse(node.Attributes.GetNamedItem("DampferM").Value);

            if (node.Attributes["EvaluationTime"] != null)
                (neuron.modulator as ModulatorMod).EvaluationTime = int.Parse(node.Attributes.GetNamedItem("EvaluationTime").Value);

            if (node.Attributes["IterationLimit"] != null)
                (neuron.modulator as ModulatorMod).IterationLimit = int.Parse(node.Attributes.GetNamedItem("IterationLimit").Value);

            if (node.Attributes["thresholdUp"] != null)
                (neuron.modulator as ModulatorMod).thresholdUp = float.Parse(node.Attributes.GetNamedItem("thresholdUp").Value);

            if (node.Attributes["StartAdaptTime"] != null)
                (neuron.modulator as ModulatorMod).StartAdaptTime = int.Parse(node.Attributes.GetNamedItem("StartAdaptTime").Value);

            if (node.Attributes["SpeedAdapt"] != null)
                (neuron.modulator as ModulatorMod).SpeedAdapt = int.Parse(node.Attributes.GetNamedItem("SpeedAdapt").Value);

            if (node.Attributes["MinThreshold"] != null)
                (neuron.modulator as ModulatorMod).MinThreshold = float.Parse(node.Attributes.GetNamedItem("MinThreshold").Value);

            if (node.Attributes["thresholdDown"] != null)
                (neuron.summator as SummatordIN).thresholdDown = float.Parse(node.Attributes.GetNamedItem("thresholdDown").Value);

            if (node.Attributes["TimeReAction"] != null)
                (neuron.summator as SummatordIN).TimeReAction = int.Parse(node.Attributes.GetNamedItem("TimeReAction").Value);
        }
        GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().MaxIDNeuron = maxId;

        foreach (XmlNode node in xmlDoc.SelectNodes("NetSave/Synapses/Synapse"))
        {
            int parentN = int.Parse(node.Attributes.GetNamedItem("parentNeuron").Value);
            int targetN = int.Parse(node.Attributes.GetNamedItem("targetNeuron").Value);
            Synapse synapse = GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().CreateSynapse(
                GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[parentN],
                GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[targetN]);
            synapse.TypeSynapse = int.Parse(node.Attributes.GetNamedItem("TypeSynapse").Value);
            synapse.descriptor = int.Parse(node.Attributes.GetNamedItem("descriptor").Value);
            synapse.Force = float.Parse(node.Attributes.GetNamedItem("Force").Value);
            synapse.Delay = int.Parse(node.Attributes.GetNamedItem("Delay").Value);
            synapse.Freeze = bool.Parse(node.Attributes.GetNamedItem("Freeze").Value);
        }

        for (int i = 0; i < listTols.Length; i++) 
        {
            XmlNode node = xmlDoc.SelectSingleNode("NetSave/" + listTols[i]);
            NeuronTools[i] = int.Parse(node.Attributes.GetNamedItem("target").Value);
        }

        if (NeuronTools[11] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[11]].onAction 
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS1L;
        if (NeuronTools[12] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[12]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS2L;
        if (NeuronTools[13] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[13]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS3L;
        if (NeuronTools[14] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[14]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS4L;
        if (NeuronTools[15] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[15]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS5L;
        if (NeuronTools[16] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[16]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS6L;
        if (NeuronTools[17] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[17]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS7L;
        if (NeuronTools[18] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[18]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS8L;

        if (NeuronTools[19] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[19]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS1R;
        if (NeuronTools[20] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[20]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS2R;
        if (NeuronTools[21] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[21]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS3R;
        if (NeuronTools[22] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[22]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS4R;
        if (NeuronTools[23] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[23]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS5R;
        if (NeuronTools[24] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[24]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS6R;
        if (NeuronTools[25] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[25]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS7R;
        if (NeuronTools[26] != -1) GetComponent<ManagerWorld>().Tadpole1.GetComponent<SpaceNeuron>().NeuronList[NeuronTools[26]].onAction
            += GetComponent<ManagerWorld>().Tadpole1.GetComponent<JointTadLP>().EventS8R;
    }
}
