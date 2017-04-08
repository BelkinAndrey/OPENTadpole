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

    public delegate void ActionTask();
    ActionTask TA;

    public delegate void MethodonDelete();
    public event MethodonDelete onDelete;

    public delegate void MethodonStartSignal();
    public event MethodonStartSignal startSignal;

    public delegate void MethodonEndSignal();
    public event MethodonEndSignal endSignal;

    public Synapse(Neuron parent, Neuron target) 
    {
        parentNeuron = parent;
        targetNeuron = target;
    }

    public void CallAction() //Передача сигнала
    {
        TA = TCallAction;
        TA.BeginInvoke(null, null); //Запуск передачи
        if (startSignal != null) startSignal(); //Событие для индикации в редакторе
    }

    void TCallAction()
    {
        Thread.Sleep(Delay); //Синаптическая задержка
        targetNeuron.Signal(TypeSynapse, descriptor, Force);
        if (endSignal != null) endSignal(); // Событие для индикации в редакторе
    }

    public void DeleteSynapse() 
    {
        if(onDelete != null) onDelete();
    }
}
