using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorHandler : MonoBehaviour
{
    [SerializeField] GameObject KnifeIcon;

    Canvas canvas;

    CursorType cursorType;
    GameObject currentIcon;

    private int phraseToDrag = 0;
    public int PhraseToDrag
    {
        get => phraseToDrag;
        set
        {
            //if (string.IsNullOrEmpty(value))
            //    CursorType = CursorType.Default;
            //else
            //    CursorType = CursorType.KeyPhrase;
            phraseToDrag = value;
        }
    }

    public CursorType CursorType
    {
        get => cursorType;

        set
        {
            cursorType = value;

            switch (cursorType)
            {
                case CursorType.Knife:
                    Cursor.visible = false;
                    AddIcon(KnifeIcon);
                    break;
                default:
                    Destroy(currentIcon);
                    currentIcon = null;
                    Cursor.visible = true;
                    break;
            }
        }
    }

    private void Awake()
    {
        cursorType = CursorType.Default;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIcon)
        {
            currentIcon.transform.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonDown(1))
        {
            CursorType = CursorType.Default;
        }
    }

    private void AddIcon(GameObject icon)
    {
        currentIcon = Instantiate(icon, Input.mousePosition, Quaternion.identity, canvas.transform);
    }

    public void SetIconAsLastSibling()
    {
        if (CursorType != CursorType.Default)
        {
            currentIcon.transform.SetAsLastSibling();
        }
    }
}

public enum CursorType
{
    Default,
    Knife,
    KeyPhrase
}