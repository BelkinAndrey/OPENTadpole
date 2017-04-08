using UnityEngine;
using System.Collections;
using System.Threading;
using System.Timers;

public class ModulatorMod : Modulator {

    /// Клас выполняющий логику модуляции и управляющий "метаболизмом"


    public float MaxModul = 300f;  //Максимальный модулирующий фактор
    public float DampferM = 0.01f; //Демпфер модулирующего фактора
    public int EvaluationTime = 2000; //Время оценки, время за которое защитывается повторное срабатывание 
    public int IterationLimit = 5;   //Лимит повторов после которого будет увеличиваться порог
    public float thresholdUp = 1;    //Шаг с которым будет повышаться порог
    public int StartAdaptTime = 5000; //Время простоя после которого запускается адаптация (снижение порога)
    public int SpeedAdapt = 2000;  //Скорость адаптации, интервал времени в который будет уменаться порог на 1
    public float MinThreshold = 1f; //Минимальный порог при адаптации

    private int iteration = 0; //Счётчик повторов
    private float thresholdSumm = 0; //Значение порога до начала модулирующий действий

    private float _thresholdMod = 0; 
    private float thresholdMod // Модулирующее действие 
    {
        get { return _thresholdMod; }
        set 
        {
            if ((_thresholdMod == 0) && (value != 0))             
            {
                thresholdSumm = (base.parent.summator as SummatorSimple).threshold; //Если модулирующее воздействие изменилось с 0, то сохраняем текущий порог
                timeDrain.AutoReset = true; 
                timeDrain.Interval = 1;
                timeDrain.Elapsed += Drain;
                timeDrain.Start(); //Запускаем таймер с интервалом в 1мс, каждый вызов выполняется Drain
            } 

            _thresholdMod = value; 

            if (_thresholdMod == 0) 
            {
                timeDrain.Elapsed -= Drain; 
                timeDrain.Stop();
            }
        }
    }

    System.Timers.Timer timeDrain = new System.Timers.Timer();
    System.Timers.Timer timeEvaluation = new System.Timers.Timer();

    private bool Evaluat = false; //индикатор периода времени оценки

    TimerCallback tm;
    System.Threading.Timer timer;

    public override void CallModular(float force) //Получение сигнала от модулирующего синапса
    {
        thresholdMod += force;
        float s = thresholdMod + thresholdSumm; //модулирующий фактор + значение порога
        if (s > MaxModul) thresholdMod = MaxModul - thresholdSumm; //если их сумма будет больше максимума, то снижаем модулирующее воздествии ровно на значеине необходимую сумму, чтобы выводил максисмум 
        if (s < 0) thresholdMod = -thresholdSumm; //модулирующее действие не должно снижать порог ниже нуля
    }

    public override void OnEnable() //Событие при инициализации нейрона
    {
        if (StartAdaptTime > 0) //Если в настройках время простоя до начала адаптации будет указанно 0, то это значит отклечение механизма
        {
            tm = new TimerCallback(TickAdapt);
            timer = new System.Threading.Timer(tm, null, StartAdaptTime, SpeedAdapt); //Через StartAdaptTime запустится таймер с интервалом SpeedAdapt в который будет выполняться TickAdapt
        }
    }

    public override void OnDisable()
    {
        timeDrain.Stop();
    }

    public void onActionNeuron() //По событию активации нейрона
    {
        if (thresholdMod == 0) //Если нет модулирующего воздействия
        {
            if (Evaluat) //Сейча время оценки
            {
                Evaluat = false;
                timeEvaluation.Elapsed -= evaluationTime; //Останавливаем время оценки
                timeEvaluation.Dispose();
                iteration++; //Считаем повторы
            }
            else iteration = 0; //Время оценки вышло, обнуляем счётчик повторов

            if (iteration > IterationLimit) //Если лимит повторов превышен
            {
                (base.parent.summator as SummatorSimple).threshold += thresholdUp; //Увеличиваем порог на заданный шаг
            }

            if (timer != null) timer.Dispose(); //Останавливаем механизм адаптации, нейрон сработал, это не простой
        }
    }

    public void deActionNeuron()  //Срабатывает при деактивации нейрона
    {
        if (thresholdMod == 0) //Если нет модулирующего воздействия
        {
            Evaluat = true;
            timeEvaluation.AutoReset = false;
            timeEvaluation.Interval = EvaluationTime;
            timeEvaluation.Elapsed += evaluationTime;
            timeEvaluation.Start(); //Запускаем время оценки

            if (StartAdaptTime > 0)
            {
                if (timer != null) timer.Dispose();
                timer = new System.Threading.Timer(tm, null, StartAdaptTime, SpeedAdapt); //Запуск адаптации
            }
        }
    }

    private void evaluationTime(object sender, System.Timers.ElapsedEventArgs e) //по завершению времени оценки 
    {
        Evaluat = false; 
    }


    public void TickAdapt(object obj) //При адаптации
    {
        float t = (base.parent.summator as SummatorSimple).threshold - 1; //Уменьшение порога на 1 
        if (t >= MinThreshold) (base.parent.summator as SummatorSimple).threshold = t;
    }

    void Drain(object sender, System.Timers.ElapsedEventArgs e) //Срабатывает каждую миллисекунду
    {
        if (thresholdMod != 0)
        {
            if (Mathf.Abs(thresholdMod) <= DampferM) thresholdMod = 0f;
            if (thresholdMod > DampferM) thresholdMod -= DampferM;
            if (thresholdMod < -DampferM) thresholdMod += DampferM;

            (base.parent.summator as SummatorSimple).threshold = thresholdSumm + thresholdMod;
        }
        else thresholdMod = 0; //При присвоении 0, происходит остановка таймера
    }
}
