using UnityEngine;
using System.Threading;
using System.Collections;

public class Synapse {

    /// <summary>
    /// Класс симнапса
    /// </summary>

    public Neuron parentNeuron; //Ссылка на родитель нейрон
    public Neuron targetNeuron; //Ссфлка на целевой нейрон

    public int TypeSynapse = 0; //Тип синапса
    public int descriptor = 0; //пока не используется
    public float Force = 0f; //Сила синапса
    public int Delay = 0; //Синаатическая задержка
    public bool Freeze = false; //пока не используется

    public delegate void MethodonDelete();
    public event MethodonDelete onDelete;

    public delegate void MethodonStartSignal();
    public event MethodonStartSignal startSignal;

    public delegate void MethodonEndSignal();
    public event MethodonEndSignal endSignal;

    System.Timers.Timer Act; 


    public Synapse(Neuron parent, Neuron target) 
    {
        parentNeuron = parent;
        targetNeuron = target;
    }

    public void CallAction() //Передача сигнала
    {
        if (Delay == 0) 
        {
            if (startSignal != null) startSignal();
            targetNeuron.Signal(TypeSynapse, descriptor, Force);
            if (endSignal != null) endSignal();
        }
        else 
        { 
            Act = new System.Timers.Timer();
            Act.AutoReset = false;
            Act.Interval = Delay;
            Act.Elapsed += actTime;
            Act.Start(); 
            if (startSignal != null) startSignal(); //Событие для индикации в редакторе
        }
    }

    private void actTime(object sender, System.Timers.ElapsedEventArgs e) //по завершению времени оценки 
    {
        targetNeuron.Signal(TypeSynapse, descriptor, Force);
        if (endSignal != null) endSignal(); // Событие для индикации в редакторе
        Act.Dispose();
    }

    public void DeleteSynapse() 
    {
        if(onDelete != null) onDelete();
    }
}
