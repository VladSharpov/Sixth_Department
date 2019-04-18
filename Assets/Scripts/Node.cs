using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour, IPointerEnterHandler
{
    public int Number { get; set; }

    Opening opening;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        ResetColor();

        string name = gameObject.name;
        int.TryParse(name[name.Length - 2].ToString(), out int number);
        Number = number;
    }

    // Start is called before the first frame update
    void Start()
    {
        opening = FindObjectOfType<Opening>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (opening.InProcess && Number == opening.Counter + 1)
        {
            opening.Counter++;
            image.color = Color.red;
        }
    }

    public void ResetColor()
    {
        image.color = Color.green;
    }
}
