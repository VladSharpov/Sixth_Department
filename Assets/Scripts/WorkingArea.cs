using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WorkingArea : MonoBehaviour/*, IDropHandler*/
{
    public Transform MoneySlot { get; private set; }
    public Transform KeySlot { get; private set; }

    private void Awake()
    {
        Transform[] slots = GetComponentsInChildren<Transform>();
        MoneySlot = slots[1];
        KeySlot = slots[2];
    }

    public void Clear()
    {
        // TODO - Clear slots instead of destroying Coin
        Coin coin = FindObjectOfType<Coin>();
        if (coin)
        {
            Destroy(coin.gameObject);
        }
    }

    //public void OnDrop(PointerEventData eventData)
    //{
    //    //eventData.pointerDrag.transform.position = transform.position;
    //}
}
