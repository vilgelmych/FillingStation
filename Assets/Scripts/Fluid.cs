using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluid : MonoBehaviour
{
    /// <summary>
    /// Максимальный объем.
    /// </summary>
    public float MaxVolume;

    /// <summary>
    /// Материал жидкости в резервуаре
    /// </summary>
    public Material FluidMat;


    /// <summary>
    /// Teкущий общий объем.
    /// </summary>
    public float CurrentVolume
    {
        get { return Mathf.Min( CurrentVolumeFlow1 + CurrentVolumeFlow2, MaxVolume); }
    }

    float currentVolumeFlow1;
    /// <summary>
    /// Teкущий объем 1 жидкости .
    /// </summary>
    public float CurrentVolumeFlow1
    {
        get { return Mathf.Min(currentVolumeFlow1, MaxVolume); }
    }

    float currentVolumeFlow2;
    /// <summary>
    /// Teкущий объем 2 жидкости.
    /// </summary>
    public float CurrentVolumeFlow2
    {
        get { return Mathf.Min(currentVolumeFlow2, MaxVolume); }
    }

    float parameter = 0;
    /// <summary>    
    /// 0 - Пустой резервуар;
    /// 1 - Максимальный объем.        
    /// </summary>
    public float Parameter
    {
        get { return parameter; }
        set
        {
            // корректировка границ параметра
            float p = value;
            p = Mathf.Clamp01(p);           
            parameter = p;           
        }
    }

    public Color colorMixer(Color c1, Color c2)
    {
        float r = Mathf.Min(c1.r + c2.r, 255);
        float g = Mathf.Min((c1.g + c2.g), 255);
        float b = Mathf.Min((c1.b + c2.b), 255);
        float a = (c1.a + c2.a) / 2f;
        if (c1.a == 0)
            a = c2.a;
        if (c2.a == 0)
            a = c1.a;
        return new Color(r,g,b, a );
    }

    /// <summary>
    /// Входящие потоки
    /// </summary>
    /// <param name="flows"></param>
    public void InputFlows(FlowFluid flow1, FlowFluid flow2)
    {
        if (MaxVolume > CurrentVolume)
        {
            currentVolumeFlow1 += flow1.Flow * Time.deltaTime;
            currentVolumeFlow2 += flow2.Flow * Time.deltaTime;
            transform.localScale = new Vector3(1, CurrentVolume / MaxVolume, 1);
            FluidMat.color = colorMixer(currentVolumeFlow1 * flow1.FlowColor / CurrentVolume, 
                currentVolumeFlow2 * flow2.FlowColor / CurrentVolume);
        }
    }


   
}
