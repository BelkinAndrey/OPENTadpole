using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class SaveOpen : MonoBehaviour {

    public string PathFile;  //путь к файлу

    public GameObject[] listTols;
    void Start()
    {
        if (PlayerPrefs.HasKey("Path")) PathFile = PlayerPrefs.GetString("Path"); // PlayerPrefs для пути к файлу.
        if (PathFile != "")
        {
            if (File.Exists(Application.dataPath + "/Data/" + PathFile + ".tad"))
            {
               Load(); 
            }
        }
    }

    public void Save() 
    {
        if (PathFile != "") 
        {
            PlayerPrefs.SetString("Path", PathFile);  // Сохраняем в PlayerPrefs имя файла

            XmlDocument xmlDoc = new XmlDocument(); //создаем новый документ xml
            XmlNode rootNode = xmlDoc.CreateElement("NetSave"); // Главный раздел <NetSave>...
            xmlDoc.AppendChild(rootNode); // добавляем главный раздел 

            XmlNode userNode;
            XmlNode userNodeChild;
            XmlAttribute attribute;

            userNode = xmlDoc.CreateElement("Neurons"); //<Neurons>

            for (int i = 0; i < GetComponent<SpaceNeuron>().NeuronList.Count; i++) 
            {
                userNodeChild = xmlDoc.CreateElement("Neuron"); //<Neurons>

                attribute = xmlDoc.CreateAttribute("index"); //Атрибут index
                attribute.Value = i.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("IDNeuron"); 
                attribute.Value = GetComponent<SpaceNeuron>().NeuronList[i].IDNeuron.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("Type"); 
                attribute.Value = GetComponent<SpaceNeuron>().NeuronList[i].Type.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("X");
                attribute.Value = GetComponent<SpaceNeuron>().NeuronList[i].position.x.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("Y");
                attribute.Value = GetComponent<SpaceNeuron>().NeuronList[i].position.y.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("Layer");
                attribute.Value = GetComponent<SpaceNeuron>().NeuronList[i].Layer.ToString();
                userNodeChild.Attributes.Append(attribute);

                switch (GetComponent<SpaceNeuron>().NeuronList[i].Type) 
                {
                    case 0: 
                        attribute = xmlDoc.CreateAttribute("MaxSumm");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).MaxSumm.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("MinSumm");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).MinSumm.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("threshold");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).threshold.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("Dampfer");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).Dampfer.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("AnswerTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).AnswerTime.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("ReposeTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).ReposeTime.ToString();
                        userNodeChild.Attributes.Append(attribute);
                    break;

                    case 1:
                        attribute = xmlDoc.CreateAttribute("MaxSumm");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).MaxSumm.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("MinSumm");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).MinSumm.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("threshold");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).threshold.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("Dampfer");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).Dampfer.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("AnswerTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).AnswerTime.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("ReposeTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatorSimple).ReposeTime.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("MaxModul");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).MaxModul.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("DampferM");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).DampferM.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("EvaluationTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).EvaluationTime.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("IterationLimit");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).IterationLimit.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("thresholdUp");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).thresholdUp.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("StartAdaptTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).StartAdaptTime.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("SpeedAdapt");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).SpeedAdapt.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("MinThreshold");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].modulator as ModulatorMod).MinThreshold.ToString();
                        userNodeChild.Attributes.Append(attribute);
                    break;

                    case 2:
                        attribute = xmlDoc.CreateAttribute("MaxSumm");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).MaxSumm.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("MinSumm");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).MinSumm.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("threshold");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).threshold.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("Dampfer");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).Dampfer.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("AnswerTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).AnswerTime.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("ReposeTime");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).ReposeTime.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("thresholdDown");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).thresholdDown.ToString();
                        userNodeChild.Attributes.Append(attribute);

                        attribute = xmlDoc.CreateAttribute("TimeReAction");
                        attribute.Value = (GetComponent<SpaceNeuron>().NeuronList[i].summator as SummatordIN).TimeReAction.ToString();
                        userNodeChild.Attributes.Append(attribute);
                    break;
                }

                userNode.AppendChild(userNodeChild); //</Neuron>
            }

            rootNode.AppendChild(userNode); //<Neurons>

            userNode = xmlDoc.CreateElement("Synapses"); //<Synapses>

            for (int i = 0; i < GetComponent<SpaceNeuron>().SynapseList.Count; i++)
            {
                userNodeChild = xmlDoc.CreateElement("Synapse"); //<Synapse>

                attribute = xmlDoc.CreateAttribute("index"); //Атрибут index
                attribute.Value = i.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("parentNeuron");
                attribute.Value = GetComponent<SpaceNeuron>().NeuronList.IndexOf(GetComponent<SpaceNeuron>().SynapseList[i].parentNeuron).ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("targetNeuron");
                attribute.Value = GetComponent<SpaceNeuron>().NeuronList.IndexOf(GetComponent<SpaceNeuron>().SynapseList[i].targetNeuron).ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("TypeSynapse");
                attribute.Value = GetComponent<SpaceNeuron>().SynapseList[i].TypeSynapse.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("descriptor");
                attribute.Value = GetComponent<SpaceNeuron>().SynapseList[i].descriptor.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("Force");
                attribute.Value = GetComponent<SpaceNeuron>().SynapseList[i].Force.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("Delay");
                attribute.Value = GetComponent<SpaceNeuron>().SynapseList[i].Delay.ToString();
                userNodeChild.Attributes.Append(attribute);

                attribute = xmlDoc.CreateAttribute("Freeze");
                attribute.Value = GetComponent<SpaceNeuron>().SynapseList[i].Freeze.ToString();
                userNodeChild.Attributes.Append(attribute);

                userNode.AppendChild(userNodeChild); //</Synapse>
            }

            rootNode.AppendChild(userNode); //</Synapses>

            for (int i = 0; i < listTols.Length; i++) 
            {
                userNode = xmlDoc.CreateElement(listTols[i].name);

                attribute = xmlDoc.CreateAttribute("target");
                if (listTols[i].GetComponent<InputOne>()) attribute.Value = GetComponent<SpaceNeuron>().NeuronList.IndexOf(listTols[i].GetComponent<InputOne>().N).ToString();
                if (listTols[i].GetComponent<OutOne>()) attribute.Value = GetComponent<SpaceNeuron>().NeuronList.IndexOf(listTols[i].GetComponent<OutOne>().N).ToString();
                userNode.Attributes.Append(attribute);

                rootNode.AppendChild(userNode);
            }

            xmlDoc.Save(Application.dataPath + "/Data/" + PathFile + ".tad"); // Сохранение в файл
        }
    }

    public void Open() 
    {
        if (PathFile != "") 
        {
            if (File.Exists(Application.dataPath + "/Data/" + PathFile + ".tad"))
            {
                GameObject C = GameObject.Find("Camera");
                PlayerPrefs.SetFloat("StartZoom", C.GetComponent<Camera>().orthographicSize);
                PlayerPrefs.SetFloat("CamX", C.transform.position.x);
                PlayerPrefs.SetFloat("CamY", C.transform.position.y);
                PlayerPrefs.SetFloat("CamZ", C.transform.position.z);

                PlayerPrefs.SetString("Path", PathFile);
                Application.LoadLevel(0);
            }
        }
    }

    void Load() 
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(Application.dataPath + "/Data/" + PathFile + ".tad"); //открываем файл

        List<InspectorNeuron> ListInspector = new List<InspectorNeuron>();

        int maxId = 0;
        foreach (XmlNode node in xmlDoc.SelectNodes("NetSave/Neurons/Neuron")) 
        {
            int type = int.Parse(node.Attributes.GetNamedItem("Type").Value);
            Vector2 pos = new Vector2(float.Parse(node.Attributes.GetNamedItem("X").Value), float.Parse(node.Attributes.GetNamedItem("Y").Value));
            int Layer = int.Parse(node.Attributes.GetNamedItem("Layer").Value);
            InspectorNeuron Inspector = GetComponent<InsertOneNeuron>().LoadNeuron(pos, Layer, type);
            int id = int.Parse(node.Attributes.GetNamedItem("IDNeuron").Value);
            Inspector.isNeuron.IDNeuron = id;
            if (id > maxId) maxId = id;

            if (node.Attributes["MaxSumm"] != null) 
            {
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatorSimple))
                    (Inspector.isNeuron.summator as SummatorSimple).MaxSumm = float.Parse(node.Attributes.GetNamedItem("MaxSumm").Value);
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatordIN))
                    (Inspector.isNeuron.summator as SummatordIN).MaxSumm = float.Parse(node.Attributes.GetNamedItem("MaxSumm").Value);
            }

            if (node.Attributes["MinSumm"] != null)
            {
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatorSimple))
                    (Inspector.isNeuron.summator as SummatorSimple).MinSumm = float.Parse(node.Attributes.GetNamedItem("MinSumm").Value);
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatordIN))
                    (Inspector.isNeuron.summator as SummatordIN).MinSumm = float.Parse(node.Attributes.GetNamedItem("MinSumm").Value);
            }

            if (node.Attributes["threshold"] != null)
            {
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatorSimple))
                    (Inspector.isNeuron.summator as SummatorSimple).threshold = float.Parse(node.Attributes.GetNamedItem("threshold").Value);
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatordIN))
                    (Inspector.isNeuron.summator as SummatordIN).threshold = float.Parse(node.Attributes.GetNamedItem("threshold").Value);
            }

            if (node.Attributes["Dampfer"] != null)
            {
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatorSimple))
                    (Inspector.isNeuron.summator as SummatorSimple).Dampfer = float.Parse(node.Attributes.GetNamedItem("Dampfer").Value);
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatordIN))
                    (Inspector.isNeuron.summator as SummatordIN).Dampfer = float.Parse(node.Attributes.GetNamedItem("Dampfer").Value);
            }

            if (node.Attributes["AnswerTime"] != null)
            {
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatorSimple))
                    (Inspector.isNeuron.summator as SummatorSimple).AnswerTime = int.Parse(node.Attributes.GetNamedItem("AnswerTime").Value);
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatordIN))
                    (Inspector.isNeuron.summator as SummatordIN).AnswerTime = int.Parse(node.Attributes.GetNamedItem("AnswerTime").Value);
            }

            if (node.Attributes["ReposeTime"] != null)
            {
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatorSimple))
                    (Inspector.isNeuron.summator as SummatorSimple).ReposeTime = int.Parse(node.Attributes.GetNamedItem("ReposeTime").Value);
                if (Inspector.isNeuron.summator.GetType() == typeof(SummatordIN))
                    (Inspector.isNeuron.summator as SummatordIN).ReposeTime = int.Parse(node.Attributes.GetNamedItem("ReposeTime").Value);
            }

            if (node.Attributes["MaxModul"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).MaxModul = float.Parse(node.Attributes.GetNamedItem("MaxModul").Value);

            if (node.Attributes["DampferM"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).DampferM = float.Parse(node.Attributes.GetNamedItem("DampferM").Value);

            if (node.Attributes["EvaluationTime"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).EvaluationTime = int.Parse(node.Attributes.GetNamedItem("EvaluationTime").Value);

            if (node.Attributes["IterationLimit"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).IterationLimit = int.Parse(node.Attributes.GetNamedItem("IterationLimit").Value);

            if (node.Attributes["thresholdUp"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).thresholdUp = float.Parse(node.Attributes.GetNamedItem("thresholdUp").Value);

            if (node.Attributes["StartAdaptTime"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).StartAdaptTime = int.Parse(node.Attributes.GetNamedItem("StartAdaptTime").Value);

            if (node.Attributes["SpeedAdapt"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).SpeedAdapt = int.Parse(node.Attributes.GetNamedItem("SpeedAdapt").Value);

            if (node.Attributes["MinThreshold"] != null)
                (Inspector.isNeuron.modulator as ModulatorMod).MinThreshold = float.Parse(node.Attributes.GetNamedItem("MinThreshold").Value);

            if (node.Attributes["thresholdDown"] != null)
                (Inspector.isNeuron.summator as SummatordIN).thresholdDown = float.Parse(node.Attributes.GetNamedItem("thresholdDown").Value);

            if (node.Attributes["TimeReAction"] != null)
                (Inspector.isNeuron.summator as SummatordIN).TimeReAction = int.Parse(node.Attributes.GetNamedItem("TimeReAction").Value);

            ListInspector.Add(Inspector);
        }
        GetComponent<SpaceNeuron>().MaxIDNeuron = maxId;

        foreach (XmlNode node in xmlDoc.SelectNodes("NetSave/Synapses/Synapse")) 
        {
            int parentN = int.Parse(node.Attributes.GetNamedItem("parentNeuron").Value);
            int targetN = int.Parse(node.Attributes.GetNamedItem("targetNeuron").Value);
            GetComponent<InsertSynapse>().SynapseInsert(ListInspector[parentN].gameObject, ListInspector[targetN].gameObject);
            int indexS = int.Parse(node.Attributes.GetNamedItem("index").Value);
            GetComponent<SpaceNeuron>().SynapseList[indexS].TypeSynapse = int.Parse(node.Attributes.GetNamedItem("TypeSynapse").Value);
            GetComponent<SpaceNeuron>().SynapseList[indexS].descriptor = int.Parse(node.Attributes.GetNamedItem("descriptor").Value);
            GetComponent<SpaceNeuron>().SynapseList[indexS].Force = float.Parse(node.Attributes.GetNamedItem("Force").Value);
            GetComponent<SpaceNeuron>().SynapseList[indexS].Delay = int.Parse(node.Attributes.GetNamedItem("Delay").Value);
            GetComponent<SpaceNeuron>().SynapseList[indexS].Freeze = bool.Parse(node.Attributes.GetNamedItem("Freeze").Value);
        }

        foreach (GameObject value in listTols) 
        {
            XmlNode node = xmlDoc.SelectSingleNode("NetSave/" + value.name);
            if (node.Attributes.GetNamedItem("target").Value != "-1") 
            {
                value.GetComponentInChildren<ToolSelect>().LoodTool(ListInspector[int.Parse(node.Attributes.GetNamedItem("target").Value)].gameObject);
            }
        }
    }
}
