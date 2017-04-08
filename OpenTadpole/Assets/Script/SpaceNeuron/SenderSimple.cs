using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

public class SenderSimple : Sender {

    public delegate void ActionSender();
    ActionSender TA;

    public override void CallSender()
    {
        TA = TSender;
        TA.BeginInvoke(null, null); 
    }

    void TSender()
    {
        for (int i = 0; i < base.parent.PreSynapses.Count; i++)
        {
            base.parent.PreSynapses[i].CallAction();
        } 
    }
    
}
