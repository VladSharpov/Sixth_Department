using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knife : MonoBehaviour, IPointerClickHandler
{
    private CursorHandler cursorHandler;

    // Start is called before the first frame update
    void Start()
    {
        cursorHandler = FindObjectOfType<CursorHandler>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cursorHandler.CursorType = CursorType.Knife;
    }
}
