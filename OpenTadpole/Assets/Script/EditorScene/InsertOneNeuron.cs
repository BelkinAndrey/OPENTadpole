using UnityEngine;
using System.Collections;

public class InsertOneNeuron : MonoBehaviour {

    public int InsertLayer;
    public int InsertType;

    public GameObject _panel;
    public GameObject _neurons;
    public GameObject _layer;
    public GameObject prefabNeuron;


    public void InsertNeuron() 
    {
        if ((_panel != null) && (_neurons != null) && (prefabNeuron != null)) 
        {
            Vector3 PositionPanel = Camera.main.ScreenToWorldPoint(_panel.transform.position);
            PositionPanel.z = 0f;
            GameObject clone = Instantiate(prefabNeuron, PositionPanel, transform.rotation) as GameObject;
            clone.name = "Neuron";
            if (_neurons.transform.childCount < InsertLayer) NewLauers();
            clone.transform.parent = _neurons.transform.GetChild(InsertLayer);
            clone.GetComponent<InspectorNeuron>().isNeuron = GetComponent<SpaceNeuron>().CreateNeuron(new Vector2(clone.transform.position.x, clone.transform.position.y), InsertLayer, InsertType);
            clone.GetComponent<InspectorNeuron>().reColor();
            clone.GetComponent<InspectorNeuron>().isNeuron.onAction += clone.GetComponent<InspectorNeuron>().OnActionNeuron;
            clone.GetComponent<InspectorNeuron>().isNeuron.deAction += clone.GetComponent<InspectorNeuron>().deActionNeuron;
            if (InsertType == 2) (clone.GetComponent<InspectorNeuron>().isNeuron.summator as SummatordIN).DeReActionNeuron += clone.GetComponent<InspectorNeuron>().DeReActionNeuron; 
        }
    }

    void NewLauers() 
    {
        while (_neurons.transform.childCount <= InsertLayer) 
        {
            GameObject cloneL = Instantiate(_layer, Vector3.zero, _layer.transform.rotation) as GameObject;
            cloneL.transform.parent = _neurons.transform;
            cloneL.name = "Layer" + (_neurons.transform.childCount - 1);
        }
    }

    public void SetTypeNeuron(int type) 
    {
        InsertType = type;
    }

    public InspectorNeuron LoadNeuron(Vector2 position, int layer, int type) 
    {
        InspectorNeuron Inspector = null;
        if ((_panel != null) && (_neurons != null) && (prefabNeuron != null))
        {
            GameObject clone = Instantiate(prefabNeuron, position, transform.rotation) as GameObject;
            clone.name = "Neuron";
            if (_neurons.transform.childCount < InsertLayer) NewLauers();
            clone.transform.parent = _neurons.transform.GetChild(InsertLayer);
            clone.GetComponent<InspectorNeuron>().isNeuron = GetComponent<SpaceNeuron>().CreateNeuron(new Vector2(position.x, position.y), layer, type);
            clone.GetComponent<InspectorNeuron>().reColor();
            clone.GetComponent<InspectorNeuron>().isNeuron.onAction += clone.GetComponent<InspectorNeuron>().OnActionNeuron;
            clone.GetComponent<InspectorNeuron>().isNeuron.deAction += clone.GetComponent<InspectorNeuron>().deActionNeuron;
            if (type == 2) (clone.GetComponent<InspectorNeuron>().isNeuron.summator as SummatordIN).DeReActionNeuron += clone.GetComponent<InspectorNeuron>().DeReActionNeuron;
            Inspector = clone.GetComponent<InspectorNeuron>();
        }
        return Inspector;
    }

}
