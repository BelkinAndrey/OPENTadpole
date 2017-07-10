using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeleteNeuron : MonoBehaviour {

    public void DeleteN() 
    {
        gameObject.GetComponent<SelectionNeuron>().SelectOff.Invoke();
        if (GetComponent<SelectionNeuron>().SelectorNeuronOne != null)
        {
            DeleteFull(gameObject.GetComponent<SelectionNeuron>().SelectorNeuronOne);
            GetComponent<SpaceNeuron>().NeuronList.Remove(GetComponent<SelectionNeuron>().SelectorNeuronOne.GetComponent<InspectorNeuron>().isNeuron);
            Destroy(gameObject.GetComponent<SelectionNeuron>().SelectorNeuronOne);
        }

        if (gameObject.GetComponent<SelectionNeuron>().SelectionList.Count > 0) 
        {
            for (int i = 0; i < gameObject.GetComponent<SelectionNeuron>().SelectionList.Count; i++)
            {
                DeleteFull(GetComponent<SelectionNeuron>().SelectionList[i]);
                GetComponent<SpaceNeuron>().NeuronList.Remove(GetComponent<SelectionNeuron>().SelectionList[i].GetComponent<InspectorNeuron>().isNeuron);
                Destroy(GetComponent<SelectionNeuron>().SelectionList[i]);
            }
        }

        gameObject.GetComponent<SelectionNeuron>().SelectionList.Clear();
    }

    void DeleteFull(GameObject DeleteNeuron) 
    {
        if (DeleteNeuron != null) 
        {
            for (int i = 0; i < DeleteNeuron.GetComponent<InspectorNeuron>().isNeuron.PostSynapses.Count; i++)
            {
                Synapse DeleteSynapse = DeleteNeuron.GetComponent<InspectorNeuron>().isNeuron.PostSynapses[i];
                DeleteSynapse.parentNeuron.PreSynapses.Remove(DeleteSynapse);
                GetComponent<SpaceNeuron>().SynapseList.Remove(DeleteSynapse);
                DeleteSynapse.DeleteSynapse();
            }

            for (int i = 0; i < DeleteNeuron.GetComponent<InspectorNeuron>().isNeuron.PreSynapses.Count; i++)
            {
                Synapse DeleteSynapse = DeleteNeuron.GetComponent<InspectorNeuron>().isNeuron.PreSynapses[i];
                DeleteSynapse.targetNeuron.PostSynapses.Remove(DeleteSynapse);
                GetComponent<SpaceNeuron>().SynapseList.Remove(DeleteSynapse);
            }
        }
    }
}
