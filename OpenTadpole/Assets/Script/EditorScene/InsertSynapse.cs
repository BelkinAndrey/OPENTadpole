using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InsertSynapse : MonoBehaviour {
    public GameObject prefabSynapse;

    public void SynapseInsert(GameObject parentNeuron, GameObject targetNeuron) 
    { 
        if ((prefabSynapse != null) && (targetNeuron != null) && (parentNeuron != null) && (targetNeuron != parentNeuron))
        {
            GameObject clone = Instantiate(prefabSynapse, transform.position, transform.rotation) as GameObject;
            clone.name = "Synapse";
            clone.GetComponent<InspectorSynapse>().synapse = GetComponent<SpaceNeuron>().CreateSynapse(parentNeuron.GetComponent<InspectorNeuron>().isNeuron, targetNeuron.GetComponent<InspectorNeuron>().isNeuron);
            clone.transform.parent = parentNeuron.transform;
            clone.GetComponent<InspectorSynapse>().ReLocation(parentNeuron, targetNeuron);
            //parentNeuron.GetComponent<InspectorNeuron>().isNeuron.PreSynapses.Add(clone.GetComponent<InspectorSynapse>().synapse);
            //targetNeuron.GetComponent<InspectorNeuron>().isNeuron.PostSynapses.Add(clone.GetComponent<InspectorSynapse>().synapse);
            clone.GetComponent<InspectorSynapse>().synapse.onDelete += clone.GetComponent<InspectorSynapse>().Delete;
            clone.GetComponent<InspectorSynapse>().synapse.startSignal += clone.GetComponent<InspectorSynapse>().StartSignal;
            clone.GetComponent<InspectorSynapse>().synapse.endSignal += clone.GetComponent<InspectorSynapse>().EndSignal;
        }
    }
     
}
