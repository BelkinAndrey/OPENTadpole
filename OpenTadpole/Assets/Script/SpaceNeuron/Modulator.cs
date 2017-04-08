using UnityEngine;
using System.Collections;

public class Modulator {

    /// <summary>
    /// Базовый класс логической части нейроэлемента управляющей логикой изменения "метаболизма" и модуляцией
    /// </summary>

    public Neuron parent; //ссылка на экземляр нейроэлемента 

    public virtual void CallModular(float force) //получение сигнала от модулирующего синапса
    {
        Debug.Log("Call modular");
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
