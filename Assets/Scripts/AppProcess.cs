using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Класс управления приложением
/// </summary>
public class AppProcess : MonoBehaviour 
{
    [HideInInspector]
    /// <summary>
    /// Задвижка 1
    /// </summary>
    public Valve Valve1;

    [HideInInspector]
    /// <summary>
    /// Задвижка 2
    /// </summary>
    public Valve Valve2;

    /// <summary>
    /// Поток из 1 трубы
    /// </summary>
    FlowFluid Flow1;

    /// <summary>
    /// Значение потока 1
    /// </summary>
    public float Flow1Value
    {
        get { return Flow1.Flow; }
    }
    /// <summary>
    /// Поток из 2 трубы
    /// </summary>
    FlowFluid Flow2;

    /// <summary>
    /// Значение потока 2
    /// </summary>
    public float Flow2Value
    {
        get { return Flow2.Flow; }
    }

    [HideInInspector]
    /// <summary>
    /// Резервуар с житкостью
    /// </summary>    
    public Fluid FluidTank;

    

    void Start() 
    {
        Valve1 = GameObject.Find("Valve 1").GetComponentInChildren<Valve>();        

        Valve2 = GameObject.Find("Valve 2").GetComponentInChildren<Valve>();        

        Flow1 = GameObject.Find("Flow1").GetComponent<FlowFluid>();
        Flow1.Parameter = 1f;

        Flow2 = GameObject.Find("Flow2").GetComponent<FlowFluid>();

        FluidTank = GameObject.Find("Fluid").GetComponent<Fluid>();
        FluidTank.Parameter = 0;               
    }


    private void Update()
    {
        Flow1.Parameter = Valve1.Parameter;
        Flow2.Parameter = Valve2.Parameter;
        FluidTank.InputFlows(Flow1, Flow2);
    }

}
