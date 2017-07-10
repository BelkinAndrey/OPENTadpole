using UnityEngine;
using System.Threading;
using System.Timers;
using System.Collections;

public class SummatorSimple : Summator {

    /// <summary>
    /// Простой сумматор
    /// </summary>
   
    private float _Summ = 0; //Значение суммы
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

    private Object _addForceLock = new Object();
    private float _addForce = 0;

    public float threshold = 1; // Порог
    public float Dampfer = 1;  //Демпфер сумматора

    public int AnswerTime = 0; //Время активации, до выполнения передачи сигнала после активации 
    public int ReposeTime = 0;  // Время отдыха после передачи сигнала

    public float MaxSumm = 300f; // Максимум суммы
    public float MinSumm = -10000f; // Минимум суммы

    public delegate void ActionNeuronTask();
    ActionNeuronTask TA;
    System.IAsyncResult arTA;

    public delegate void MethodonThreshold();
    public event MethodonThreshold onThreshold;

    public delegate void MethodonDeActionNeuron();
    public event MethodonDeActionNeuron deActionNeuron;

    public override void CallDirect(float force) //Получение сигнала от синапса прямого действия
    {
        _addForce += force;
    }

    public override void CallContact() // Получение сигнала от контактного синспса
    {
        if (arTA != null) // Делегат запускался
        {
            if (arTA.IsCompleted) // Выполение делегата завершено
            {
                TA = ActionNeuron;
                arTA = TA.BeginInvoke(null, null); //Запуск задачи, запуск активации нейрона
            }
        }
        else 
        {
            // Делегат никогда не запускался
            TA = ActionNeuron;
            arTA = TA.BeginInvoke(null, null); //Запуск активации нейрона
        }
    }


    public void Drain(object sender, System.Timers.ElapsedEventArgs e) //Запускается с периодичностью 1мс
    {
        if (Summ > threshold) //Если порог превышен то запускаем нейроэлемент
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

        if (Mathf.Abs(Summ) <= Dampfer) Summ = 0f;
        if (Summ > Dampfer) Summ -= Dampfer;
        if (Summ < -Dampfer) Summ += Dampfer;

        lock (_addForceLock)
        {
            Summ += _addForce;
            _addForce = 0;
        }
    }

    void ActionNeuron() //Запуск нейрона, нейрон не запусается повторно пока не закончится выполнение данной задачи
    {
        base.parent.Action = true; //Индикатор активности нейрона, запускает необходимые события 
        Thread.Sleep(AnswerTime); //Задержка на AnswerTime
        base.parent.Action = false; //Изменяем индикатор активности и соотвествующие события
        base.parent.sender.CallSender(); //Пердача сигнала
        Thread.Sleep(ReposeTime); //Период отдыха
        if (deActionNeuron != null) deActionNeuron(); 
    }

}
