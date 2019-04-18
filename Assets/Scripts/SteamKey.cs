using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SteamKey : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TextMeshProUGUI text;

    Envelope envelope;

    [SerializeField] int ticksToOpen = 3;
    int currentTick = 0;
    bool working = false;

    void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (working && Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
            currentTick = 0;
            text.enabled = false;
            working = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.dragging)
        {
            //envelope = eventData.pointerDrag.GetComponent<EnvelopeNew>();
            envelope = FindObjectOfType<Envelope>();

            text.enabled = true;

            working = true;

            InvokeRepeating("Tick", 0, 1);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.dragging)
        {
            text.enabled = true;

            if (currentTick == ticksToOpen)
            {
                envelope.EnvelopeGameState = EnvelopeGameState.Opened;
                text.text = "OPENED";
            }
            else
            {
                text.text = "NOT ENOUGH";
            }

            currentTick = 0;
            CancelInvoke();
        }
    }

    public void OnDisable()
    {
        CancelInvoke();
        currentTick = 0;
        text.enabled = false;
        working = false;
    }

    private void Tick()
    {
        currentTick++;
        text.text = currentTick.ToString();

        if (currentTick > 3)
        {
            CancelInvoke();
            envelope.EnvelopeGameState = EnvelopeGameState.Opened;
            text.text = "OPENED WITH PENALTY";
        }
    }
}
