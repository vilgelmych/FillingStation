using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tablet : MonoBehaviour
{
    /// <summary>
    /// Планшет
    /// </summary>
    public GameObject ModelTabletGo;

    /// <summary>
    /// Экран планшета
    /// </summary>
    public RawImage ScreenTabletImage;

    /// <summary>
    /// Камера, которая рендерит на экран планшета
    /// </summary>
    public Camera ScreenTabletRenderCamera;

    /// <summary>
    /// Канвас планшета
    /// </summary>
    Canvas UITabletCanvas;

    /// <summary>
    /// Коллайдер планшета
    /// </summary>
    BoxCollider collider;

    Vector3 angleTabletCanvas;
    RectTransform rectTrsmTablet;
    Vector2 sizeCanvas;
    void OnMouseDown()
    {
        HomeClick(false);
    }

    public void HomeClick(bool isActive)
    {
        ModelTabletGo.SetActive(isActive);
        collider.enabled = isActive;
    }

    void Orientation(bool isPortret)
    {
        transform.localEulerAngles = isPortret ? Vector3.zero : new Vector3(0,0, 90);
        UITabletCanvas.transform.localEulerAngles = isPortret ? angleTabletCanvas : 
            new Vector3(angleTabletCanvas.x, angleTabletCanvas.y, -90);
        rectTrsmTablet.sizeDelta = isPortret ? sizeCanvas : new Vector2(sizeCanvas.y, sizeCanvas.x);
        SetTabletRender();
    }

    void SetTabletRender()
    {
        var render = new RenderTexture((int)ScreenTabletImage.GetComponent<RectTransform>().rect.size.x,
                (int)ScreenTabletImage.GetComponent<RectTransform>().rect.size.y, 1, RenderTextureFormat.ARGB32);
        ScreenTabletImage.texture = render;
        ScreenTabletRenderCamera.targetTexture = render;
    }
    private void Start()
    {
        UITabletCanvas = GetComponentInChildren<Canvas>();
        angleTabletCanvas = UITabletCanvas.transform.localEulerAngles;
        rectTrsmTablet = UITabletCanvas.GetComponent<RectTransform>();
        sizeCanvas = rectTrsmTablet.rect.size;
        collider = GetComponent<BoxCollider>();
        SetTabletRender();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            HomeClick(true);

        if (Input.GetKeyDown(KeyCode.Q))
            Orientation(true);

        if (Input.GetKeyDown(KeyCode.E))
            Orientation(false);
    }
}
