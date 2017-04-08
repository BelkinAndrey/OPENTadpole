using UnityEngine;
using System.Collections;

public class Summator {

    public Neuron parent;

    public virtual void CallDirect(float force) 
    {
        Debug.Log("Call direct");
    }

    public virtual void CallContact() 
    {
        Debug.Log("Call contact");
    }

    public virtual void OnEnable()
    {
        //
    }

    public virtual void OnDisable() 
    {
        //
    } 

}
