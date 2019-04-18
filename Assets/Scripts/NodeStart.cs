using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeStart : MonoBehaviour, IPointerDownHandler
{
    Opening opening;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        ResetColor();
    }

    // Start is called before the first frame update
    void Start()
    {
        opening = FindObjectOfType<Opening>();
    }

    public void ResetColor()
    {
        image.color = Color.green;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        opening.InProcess = true;
        image.color = Color.red;
    }
}
