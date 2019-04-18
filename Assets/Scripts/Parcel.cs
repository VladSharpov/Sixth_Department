using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Parcel : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] Envelope envelopeToSpawn;
    [SerializeField] GameObject coin;
    //[SerializeField] GameObject key;

    CursorHandler cursorHandler;
    WorkingArea workingArea;
    BoxOut boxOut;
    Canvas canvas;

    Image image;

    bool onWorkingArea = false;

    private void Awake()
    {
        image = FindObjectOfType<Image>();
    }

    private void Start()
    {
        cursorHandler = FindObjectOfType<CursorHandler>();
        workingArea = FindObjectOfType<WorkingArea>();
        boxOut = FindObjectOfType<BoxOut>();
        canvas = FindObjectOfType<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (cursorHandler != null && !onWorkingArea)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (onWorkingArea)
            return;

        onWorkingArea = true;

        image.raycastTarget = true;

        if (RectTransformUtility.RectangleContainsScreenPoint(workingArea.GetComponent<RectTransform>(), Input.mousePosition))
        {
            gameObject.transform.position = workingArea.transform.position;
            boxOut.enabled = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (cursorHandler.CursorType == CursorType.Default)
            OpenParcel();
    }

    private void OpenParcel()
    {
        Envelope spawnedEnvelope = 
            Instantiate(envelopeToSpawn, workingArea.transform.position, Quaternion.identity, canvas.transform);
        spawnedEnvelope.EnvelopeState = EnvelopeState.WorkingArea;

        // TODO - Create and call here Working Area method
        Instantiate(coin, workingArea.MoneySlot.position, Quaternion.identity, canvas.transform);
        //Instantiate(key, workingArea.KeySlot.position, Quaternion.identity, canvas.transform);

        Destroy(gameObject);
    }
}
