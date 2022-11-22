using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowFluid : MonoBehaviour
{

    public ParticleSystem FlowPS;

    /// <summary>
    /// Максимальное значение, для визуализации частиц.
    /// </summary>
    public float MaxSize = 1;

    public Color FlowColor;

    /// <summary>
    /// Максимальный поток, л/с
    /// </summary>
    public float MaxFlow = 100;

    float flow;
    public float Flow
    {
        get { return flow; }
    }

    float parameter = 0;
    /// <summary>    
    /// 0 - Нет потока;
    /// 1 - Максимальный поток.        
    /// </summary>
    public float Parameter
    {
        get { return parameter; }
        set
        {
            // корректировка границ параметра
            float p = value;
            p = Mathf.Clamp01(p);

            //UpdateParameterOut(p);
            parameter = p;
            var emission = FlowPS.emission;
            emission.rateOverTime = parameter * MaxSize;
            flow = p * MaxFlow;
        }
    }

    
}
