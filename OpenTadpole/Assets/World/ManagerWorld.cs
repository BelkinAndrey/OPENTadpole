using UnityEngine;
using System.Collections;

public class ManagerWorld : MonoBehaviour {

    public GameObject Tadpole1;

    public BuldScript buld;
    public ViseScript vise;

    void Update()
    {
        if (Input.GetKey(KeyCode.F1)) SetSignal(27);


        if (Input.GetKey(KeyCode.F2)) SetSignal(28);


        if (Input.GetKey(KeyCode.F3)) SetSignal(29);


        if (Input.GetKey(KeyCode.F4)) SetSignal(30);


        if (buld.OnOff) SetSignal(31);


        if (vise.OnOff) 
        {
            SetSignal(3);
            SetSignal(8);
        }
    }

    public void SetSignal(int index) 
    {
        if (GetComponent<LoadBrain>().NeuronTools[index] != -1)
            Tadpole1.GetComponent<SpaceNeuron>().NeuronList[GetComponent<LoadBrain>().NeuronTools[index]].Signal(2, 0, 0);
    }
}
