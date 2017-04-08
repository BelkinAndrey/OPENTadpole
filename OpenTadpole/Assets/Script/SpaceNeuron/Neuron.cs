using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Neuron {

    /// <summary>
    /// Клас нейроэлемента
    /// </summary>

    public int IDNeuron = 0; //Идекс нейрона
    public Vector2 position = new Vector2(0f, 0f); //Позиция в прострастве 
    public int Layer = 0; //Уровень (кооридната по Z)
    public int Type = 0; //Тип нейрона

    public List<Synapse> PreSynapses = new List<Synapse>(); //Ссылка на исходящие синапсы
    public List<Synapse> PostSynapses = new List<Synapse>(); //Ссылки на входящие синапсы

    /// <summary>
    /// Логика нейроэлемнта разделена на три части, каждому типу нейроэлементов будет соотсвествовть своя комбинация модулей.
    /// summator - модуль отвественный за получение сигналов от синапсов прямого действия, а также суммацию и активацию нейроэлемента.
    /// modulator - модуль отвественный за получение сигналов от модулирующих синапсов, а также за механизмы метаболизма, привыкание, адаптацию и сенсибилизацию
    /// sender - модуль отвечающий за передачу сигналов по синапсам и изменение синапсов перд отправкой сигнала
    /// </summary>

    public Summator summator; 
    public Modulator modulator;
    public Sender sender;

    private bool _Action = false; //Индиктор состояния активности
    public bool Action 
    {
        get { return _Action; }
        set 
        {
            _Action = value;

            if (value) { if (onAction != null) onAction(); } 
            else { if (deAction != null) deAction(); }
            
        }
    }

    public delegate void MethodonAction();
    public event MethodonAction onAction;

    public delegate void MethodonDeAction();
    public event MethodonDeAction deAction;

    public Neuron ()
    {
        position = new Vector2(0f, 0f);
        Layer = 0;
    }
    public Neuron(Vector2 pos, int layer) 
    {
        position = pos;
        Layer = layer;
    }

    public void Signal(int type, int desdescriptor, float force)
    {
        switch (type)
        {
            case 0: if (summator != null) summator.CallDirect(force); break; // Получение сигнала от синапса прямого действия
            case 1: if (modulator != null) modulator.CallModular(force); break; // Получение сигнала от модулирующего синапса, если экземпляра нет, то сигнал игнорируется
            case 2: if (summator != null) summator.CallContact(); break; // Получение сигнала от контактного синапса
        }
    }
}
