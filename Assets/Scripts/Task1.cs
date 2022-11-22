using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{

    string taskText = "Необходимо смешать жидкости из первой и второй трубы в резервуаре в пропорции 70 " +
            "частей зеленой жидкости к 30 частям синей жидкости с погрешностью не более 5 %; ";

    /// <summary>
    /// Персонаж
    /// </summary>
    FPC player;

    /// <summary>
    /// Мэнеджер
    /// </summary>
    UIManager manager;

    /// <summary>
    /// Процесс моделирования
    /// </summary>
    AppProcess process;
    /// <summary>
    /// Потоки 
    /// </summary>
    FlowFluid flow1, flow2;

    /// <summary>
    /// Планшет 
    /// </summary>
    Tablet tablet;

    /// <summary>
    /// Старт выполения задания
    /// </summary>
    bool isStartTask;

    /// <summary>
    /// Погрешность
    /// </summary>
    float inaccuracy = 0.05f;

    /// <summary>
    /// Пропорция потока 1 
    /// </summary>
    float ratioFlow1 = 0.7f;

    /// <summary>
    /// Пропорция потока 2 
    /// </summary>
    float ratioFlow2 = 0.3f;

    /// <summary>
    /// Максимальный объем 
    /// </summary>
    float maxVolume = 0.8f;

    /// <summary>
    /// Признак правильности выполнения задания
    /// </summary>
    bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<FPC>();
        player.enabled = false;
        manager = FindObjectOfType<UIManager>();
        manager.TaskPageGo.SetActive(true);
        manager.TaskTxt.text = taskText;
           
        manager.StartTaskBtn.onClick.AddListener(() => StartTask());
        manager.StopTaskBtn.interactable = false;
        manager.StopTaskBtn.onClick.AddListener(() => StopTask());

        process = FindObjectOfType<AppProcess>();
        tablet = FindObjectOfType<Tablet>();
    }

    public void StartTask()
    {
        player.enabled = true;
        manager.TaskPageGo.SetActive(false);
        manager.ModelingPageGo.SetActive(true);
        isStartTask = true;
    }

    public void StopTask()
    {
        player.enabled = true;
        
        manager.ModelingPageGo.SetActive(false);
        manager.ResultPageGo.SetActive(true);
        isStartTask = false;
        isRight = 
            (process.FluidTank.CurrentVolumeFlow1 / process.FluidTank.CurrentVolume - ratioFlow1 < inaccuracy) 
            &&  (process.FluidTank.CurrentVolumeFlow2 / process.FluidTank.CurrentVolume - ratioFlow2) < inaccuracy;

        string s = isRight ? "Задание выполнено верно" : "Задание выполнено не верно";
        s += string.Format("Соотношение жидкостей {0}/{1}. Количество действий с вентилями {2}. Общее время выполнения задания {3} cек.", 
            process.FluidTank.CurrentVolumeFlow1.ToString("0"), process.FluidTank.CurrentVolumeFlow2.ToString("0"),
            (process.Valve1.ControlCounter + process.Valve2.ControlCounter),Time.realtimeSinceStartup.ToString("0"));
       

        manager.ResultTxt.text = s;
        tablet.HomeClick(true);
    }

    private void Update()
    {
        if(isStartTask)
        {
            manager.Flow1Txt.text = string.Format("{0} {1}", process.FluidTank.CurrentVolumeFlow1.ToString("0"), "л");
            manager.Flow2Txt.text = string.Format("{0} {1}", process.FluidTank.CurrentVolumeFlow2.ToString("0"), "л");

            if(process.FluidTank.CurrentVolume / process.FluidTank.MaxVolume > maxVolume &&
                process.Valve1.Parameter == 0 && process.Valve2.Parameter == 0)
            {
                manager.StopTaskBtn.interactable = true;
            }
            else
                manager.StopTaskBtn.interactable = false;
        }
    }
}
