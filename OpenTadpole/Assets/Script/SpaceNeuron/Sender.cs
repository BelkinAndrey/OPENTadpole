using UnityEngine;
using System.Collections;

public class Sender {

    public Neuron parent;
    public virtual void CallSender() 
    {
        Debug.Log("Call sender");
    } 
}
