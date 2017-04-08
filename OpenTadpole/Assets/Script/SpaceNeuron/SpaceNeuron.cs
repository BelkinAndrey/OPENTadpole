using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceNeuron : MonoBehaviour {

    /// <summary>
    /// Виртуальное простраство нейроэлементов
    /// </summary>

    public List<Neuron> NeuronList = new List<Neuron>(); //Список всех нейронов простраства
    public List<Synapse> SynapseList = new List<Synapse>(); // Список всех синапсов 

    public int MaxIDNeuron = 0; //Максимальный индекс нейронов

    System.Timers.Timer timeDrain = new System.Timers.Timer(); //Таймер с периодичностью 1мс (вналог FixedUpdate)

    void Start() 
    {
        timeDrain.AutoReset = true;
        timeDrain.Interval = 1;

        timeDrain.Start(); //запуск таймера
    }

    public Neuron CreateNeuron(Vector2 position, int layer, int type) //Создание нейронов
    {
        Neuron newNeuron = new Neuron(position, layer);
        InitializationNeuron(newNeuron, type);
        newNeuron.Layer = layer;
        newNeuron.Type = type;
        MaxIDNeuron++;
        newNeuron.IDNeuron = MaxIDNeuron;
        NeuronList.Add(newNeuron);

        return newNeuron;
    }

    public Synapse CreateSynapse(Neuron ParentNeuron, Neuron TargetNeuron) //Создание синапса
    {
        Synapse newSynapse = new Synapse(ParentNeuron, TargetNeuron);
        SynapseList.Add(newSynapse);
        ParentNeuron.PreSynapses.Add(newSynapse);
        TargetNeuron.PostSynapses.Add(newSynapse);
        return newSynapse;
    }

    void InitializationNeuron(Neuron neuron, int type) //Инициализация нейрона
    {
        switch (type) 
        {
            case 0:    //Простой сумматор                                                       
                neuron.summator = new SummatorSimple();
                timeDrain.Elapsed += (neuron.summator as SummatorSimple).Drain;
                neuron.summator.parent = neuron;
                neuron.sender = new SenderSimple();
                neuron.sender.parent = neuron;
                break;
            case 1:    //Модулируемый нейроэлемент
                neuron.summator = new SummatorSimple();
                timeDrain.Elapsed += (neuron.summator as SummatorSimple).Drain;
                neuron.summator.parent = neuron;
                neuron.modulator = new ModulatorMod();
                (neuron.summator as SummatorSimple).onThreshold += (neuron.modulator as ModulatorMod).onActionNeuron;
                (neuron.summator as SummatorSimple).deActionNeuron += (neuron.modulator as ModulatorMod).deActionNeuron;
                neuron.modulator.OnEnable();
                neuron.modulator.parent = neuron;
                neuron.sender = new SenderSimple();
                neuron.sender.parent = neuron;
                break;
            case 2:   //Нейрон генератора движенения головастика
                neuron.summator = new SummatordIN();
                timeDrain.Elapsed += (neuron.summator as SummatordIN).Drain;
                neuron.summator.parent = neuron;
                neuron.sender = new SenderSimple();
                neuron.sender.parent = neuron;
                break;
            default: 
                neuron.summator = new SummatorSimple();
                timeDrain.Elapsed += (neuron.summator as SummatorSimple).Drain;
                neuron.summator.parent = neuron;
                neuron.sender = new SenderSimple();
                neuron.sender.parent = neuron;
                break;
        }
    }

}
