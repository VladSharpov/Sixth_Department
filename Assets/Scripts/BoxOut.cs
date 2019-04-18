using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BoxOut : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] GameState gameState;
    [SerializeField] Envelope envelopePrefab;
    [SerializeField] Parcel parcelPrefab;
    [SerializeField] BoxIn boxIn;

    Envelope envelope;
    Parcel parcel;
    Canvas canvas;

    [SerializeField] BoxOutState boxOutState = BoxOutState.Envelope;
    BoxOutState BoxOutState
    {
        get => boxOutState;
        set => boxOutState = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        boxIn = FindObjectOfType<BoxIn>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (gameState.CurrentDayLetters[boxIn.CurrentLetter - 1].Money != 0)
        {
            BoxOutState = BoxOutState.Parcel;
        }
        else
        {
            BoxOutState = BoxOutState.Envelope;
        }

        if (BoxOutState == BoxOutState.Envelope)
        {
            envelopePrefab.EnvelopeState = EnvelopeState.FromBox;
            envelope = Instantiate(envelopePrefab, Input.mousePosition, Quaternion.identity, canvas.transform);
            envelope.GetComponent<Image>().raycastTarget = false;
        }
        else if (BoxOutState == BoxOutState.Parcel)
        {
            parcel = Instantiate(parcelPrefab, Input.mousePosition, Quaternion.identity, canvas.transform);
            parcel.GetComponent<Image>().raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (BoxOutState == BoxOutState.Envelope)
        {
            envelope.OnDrag(eventData);
        }
        else if (BoxOutState == BoxOutState.Parcel)
        {
            parcel.OnDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (BoxOutState == BoxOutState.Envelope)
        {
            envelope.OnEndDrag(eventData);
        }
        else if (BoxOutState == BoxOutState.Parcel)
        {
            parcel.OnEndDrag(eventData);
        }
    }
}

public enum BoxOutState
{
    Envelope,
    Parcel
}