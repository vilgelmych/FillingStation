using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Страница задания
    /// </summary>
    public GameObject TaskPageGo;

    /// <summary>
    /// Текст задания.
    /// </summary>
    public Text TaskTxt;

    /// <summary>
    /// Кнопка начала выполнения задания.
    /// </summary>
    public Button StartTaskBtn;

    /// <summary>
    /// Страница текущего процесса
    /// </summary>
    public GameObject ModelingPageGo;

    /// <summary>
    /// Значение тekущий поток 1
    /// </summary>
    public Text Flow1Txt;

    /// <summary>
    /// Значение тekущий поток 2
    /// </summary>
    public Text Flow2Txt;

    /// <summary>
    /// Кнопка завершения задания.
    /// </summary>
    public Button StopTaskBtn;

    /// <summary>
    /// Страница результата
    /// </summary>
    public GameObject ResultPageGo;

    /// <summary>
    /// Результат
    /// </summary>
    public Text ResultTxt;
}
