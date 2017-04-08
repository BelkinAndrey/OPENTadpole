using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;

public class SummatordIN : Summator {

    /// <summary>
    /// Нецрон генератора движения головастика dIN
    /// имеет особенность: после реполяризации генерирует спайк 
    /// </summary>

    private float _Summ = 0;
    public float Summ
    {
        get { return _Summ; }
        set
        {
            if (value > MaxSumm)
            {
                _Summ = MaxSumm;
            }

            else if (value < MinSumm)
            {
                _Summ = MinSumm;
            }

            else
            {
                _Summ = value;
            }
        }
    }

    private float _addForce = 0;

    public float threshold = 1;
    public float Dampfer = 1;

    public int AnswerTime = 0;
    public int ReposeTime = 0;

    public float MaxSumm = 300f;
    public float MinSumm = -10000f;

    public float thresholdDown = -50;
    public int TimeReAction = 2000;

    public delegate void ActionNeuronTask();
    ActionNeuronTask TA;
    System.IAsyncResult arTA;

    public delegate void MethodonThreshold();
    public event MethodonThreshold onThreshold;

    public delegate void MethodonDeActionNeuron();
    public event MethodonDeActionNeuron deActionNeuron;

    public delegate void MethodonDeReActionNeuron();
    public event MethodonDeReActionNeuron DeReActionNeuron;

    public override void CallDirect(float force)
    {
        _addForce += force;
    }

    public override void CallContact()
    {
        if (arTA != null)
        {
            if (arTA.IsCompleted)
            {
                TA = ActionNeuron;
                arTA = TA.BeginInvoke(null, null);
            }
        }
        else
        {
            TA = ActionNeuron;
            arTA = TA.BeginInvoke(null, null);
        }
    }


    public void Drain(object sender, System.Timers.ElapsedEventArgs e)
    {

        if (Summ > threshold)
        {
            if (arTA != null)
            {
                if (arTA.IsCompleted)
                {

                    if (onThreshold != null) onThreshold();
                    TA = ActionNeuron;
                    arTA = TA.BeginInvoke(null, null);
                }
            }
            else
            {
                if (onThreshold != null) onThreshold();
                TA = ActionNeuron;
                arTA = TA.BeginInvoke(null, null);
            }
        }

        if (Summ < thresholdDown)
        {
            if (arTA != null)
            {
                if (arTA.IsCompleted)
                {

                    if (DeReActionNeuron != null) DeReActionNeuron();
                    TA = DeReAction;
                    arTA = TA.BeginInvoke(null, null);
                }
            }
            else
            {
                if (DeReActionNeuron != null) DeReActionNeuron();
                TA = DeReAction;
                arTA = TA.BeginInvoke(null, null);
            }
        }
      

        if (Mathf.Abs(Summ) <= Dampfer) Summ = 0f;
        if (Summ > Dampfer) Summ -= Dampfer;
        if (Summ < -Dampfer) Summ += Dampfer;

        Summ += _addForce;
        _addForce = 0;
    }

    void ActionNeuron()
    {
        base.parent.Action = true;
        Thread.Sleep(AnswerTime);
        base.parent.Action = false;
        base.parent.sender.CallSender();
        Thread.Sleep(ReposeTime);
        if (deActionNeuron != null) deActionNeuron();
    }

    void DeReAction() 
    {
        Thread.Sleep(TimeReAction);
        ActionNeuron();
    }

}
