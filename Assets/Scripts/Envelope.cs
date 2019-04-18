using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Envelope : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    [SerializeField] Sprite openedSprite;
    [SerializeField] Sprite closedSprite;

    WorkingArea workingArea;
    BoxOut boxOut;
    CursorHandler cursorHandler;
    SteamKey steamKey;
    PanelsManager panelsManager;
    BoxIn boxIn;

    Image image;

    EnvelopeGameState envelopeGameState = EnvelopeGameState.Default;
    public EnvelopeGameState EnvelopeGameState
    {
        get => envelopeGameState;
        set
        {
            envelopeGameState = value;
            if (envelopeGameState == EnvelopeGameState.Opened)
            {
                steamKey.enabled = false;
                image.enabled = true;
                image.sprite = openedSprite;
            }
            else if (envelopeGameState == EnvelopeGameState.Ready)
            {
                image.enabled = true;
                image.sprite = closedSprite;
            }
        }
    }

    public EnvelopeState EnvelopeState { get; set; }

    void Awake()
    {
        image = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cursorHandler = FindObjectOfType<CursorHandler>();
        workingArea = FindObjectOfType<WorkingArea>();
        boxOut = FindObjectOfType<BoxOut>();
        steamKey = FindObjectOfType<SteamKey>();
        panelsManager = FindObjectOfType<PanelsManager>();
        boxIn = FindObjectOfType<BoxIn>();

        steamKey.enabled = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (cursorHandler != null && cursorHandler.CursorType == CursorType.Default)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;

        if (EnvelopeState == EnvelopeState.FromBox &&
            RectTransformUtility.RectangleContainsScreenPoint(workingArea.GetComponent<RectTransform>(), Input.mousePosition))
        {
            gameObject.transform.position = workingArea.transform.position;
            EnvelopeState = EnvelopeState.WorkingArea;
            boxOut.enabled = false;
        }
        else
        {
            if (EnvelopeState == EnvelopeState.WorkingArea)
            {
                if (EnvelopeGameState == EnvelopeGameState.Ready &&
                RectTransformUtility.RectangleContainsScreenPoint(boxIn.GetComponent<RectTransform>(), Input.mousePosition))
                {
                    boxOut.enabled = true;
                    boxIn.OnEnvelopeInsert();
                    Destroy(gameObject);
                }
                else
                {
                    transform.position = workingArea.transform.position;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (cursorHandler.CursorType == CursorType.Knife && EnvelopeGameState == EnvelopeGameState.Default)
        {
            panelsManager.StartOpening(true);
            image.enabled = false;
        }
        else if (cursorHandler.CursorType == CursorType.Default && EnvelopeGameState == EnvelopeGameState.Opened)
        {
            panelsManager.StartReading(true);
            image.enabled = false;
        }
    }
}

public enum EnvelopeState
{
    FromBox,
    WorkingArea,
}

public enum EnvelopeGameState
{
    Default,
    Opened,
    Ready
}