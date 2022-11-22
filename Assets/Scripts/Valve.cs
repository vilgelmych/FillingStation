using UnityEngine;
using System;

  
[RequireComponent(typeof(Collider))]
public class Valve : MonoBehaviour
{
    /// <summary>
    /// Вращаемый объект.
    /// </summary>
    public GameObject RotatedGo;

    /// <summary>
    /// Ось вращения объекта.
    /// </summary>
    public Vector3 RotationAxis = new Vector3(0, 0, 1);
    
        
    float parameter = 0;
    /// <summary>    
    /// 0 - закрыто;
    /// 1 - открыто.        
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

    /// <summary>
    /// Чувствительность передвижения мыши.
    /// </summary>
    public float MoveSensitivity = 1;

    int controlCounter;
    /// <summary>
    /// Счетчик управления.
    /// </summary>
    public int ControlCounter
    {
        get { return controlCounter; }
    }

    /// <summary>
    /// Флаг, который указывает, что в данный момент происходит поворот мышью.
    /// </summary>
    bool isMouseRotating;
   
    /// <summary>
    /// Максимальный угол поворота.
    /// </summary>
    public float MaxAngle = 720;

    float newAngle;

    void Awake()
    {                
        Parameter = 0;
    }

    void OnMouseDown()
    {
        isMouseRotating = true;
        controlCounter++;
    }

    void OnMouseUp()
    {
        isMouseRotating = false;
    }
    
    void MouseRotation()
    {
       
        Vector3 rotationCenterPoint = Camera.main.WorldToScreenPoint(RotatedGo.transform.position);

        float directionX = 0f;
        float directionY = 0f;

        if (Input.mousePosition.x > rotationCenterPoint.x &&
            Input.mousePosition.y > rotationCenterPoint.y)
        {
            directionX = 1f; directionY = -1f;
        }
        else
            if (Input.mousePosition.x < rotationCenterPoint.x &&
                Input.mousePosition.y < rotationCenterPoint.y)
            {
                directionX = -1f; directionY = 1f;
            }
            else
                if (Input.mousePosition.x < rotationCenterPoint.x &&
                    Input.mousePosition.y > rotationCenterPoint.y)
                {
                    directionX = 1f; directionY = 1f;
                }
                else
                    if (Input.mousePosition.x > rotationCenterPoint.x &&
                        Input.mousePosition.y < rotationCenterPoint.y)
                    {
                        directionX = -1f; directionY = -1f;
                    }

        newAngle += MoveSensitivity * (Input.GetAxis("Mouse X") * directionX + Input.GetAxis("Mouse Y") * directionY);

        
        if (newAngle < 0)
            newAngle = 0;
        if (newAngle > MaxAngle)
            newAngle = MaxAngle;

        RotatedGo.transform.localEulerAngles = newAngle * RotationAxis;
        Parameter = newAngle / MaxAngle;
    }
    
    void Update()
    {
        if (isMouseRotating)
            MouseRotation();           
    }
}
