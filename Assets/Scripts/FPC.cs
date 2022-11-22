using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour
{
    CharacterController Controller;
    /// <summary>
    /// Камера персонажа
    /// </summary>
    Camera cam;
    /// <summary>
    /// Скорость перемещения персонажа.
    /// </summary>
    public float SpeedMove = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            cam.transform.Rotate(Input.GetAxis("Mouse Y"), 0, 0);
            transform.Rotate(0, -Input.GetAxis("Mouse X"), 0); 
        }
        
        Controller.Move((Input.GetAxis("Horizontal")*transform.right + 
            Input.GetAxis("Vertical")*transform.forward)* SpeedMove);
    }
}
