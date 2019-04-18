using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelsManager : MonoBehaviour
{
    [SerializeField] GameObject BlockingPanel;
    [SerializeField] GameObject OpeningPanel;
    [SerializeField] GameObject ReadingPanel;

    CursorHandler cursorHandler;

    private void Start()
    {
        cursorHandler = FindObjectOfType<CursorHandler>();
    }

    public void StartOpening(bool f)
    {
        SetBlockingPanel(f);

        OpeningPanel.transform.SetAsLastSibling();
        OpeningPanel.GetComponentInChildren<Opening>().enabled = f;
        OpeningPanel.SetActive(f);

        cursorHandler.SetIconAsLastSibling();
    }

    public void StartReading(bool f)
    {
        SetBlockingPanel(f);

        ReadingPanel.transform.SetAsLastSibling();
        ReadingPanel.SetActive(f);

        cursorHandler.SetIconAsLastSibling();
    }

    private void SetBlockingPanel(bool f)
    {
        BlockingPanel.transform.SetAsLastSibling();
        BlockingPanel.SetActive(f);
    }
}