using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CoverNote : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    private TextMeshProUGUI text;

    private CursorHandler cursorHandler;
    private Envelope envelope;
    private PanelsManager panelsManager;
    private PhraseConverter phraseConverter;
    private BoxIn boxIn;

    public bool PhraseInserted { get; set; } = false;

    private string toReplace;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        cursorHandler = FindObjectOfType<CursorHandler>();
        panelsManager = FindObjectOfType<PanelsManager>();
        phraseConverter = FindObjectOfType<PhraseConverter>();
    }

    private void OnEnable()
    {
        text.text = "Word word word word word word word word word word word____________________________________________________word word.";
        toReplace = new string(text.text.Where(c => c == '_').ToArray());
        PhraseInserted = false;
        envelope = FindObjectOfType<Envelope>();
        boxIn = FindObjectOfType<BoxIn>();
    }

    public void PhraseDragged()
    {
        if (cursorHandler.PhraseToDrag == 0)
            return;

        string toInsert = "<color=\"red\"> " + phraseConverter.GeneratePhrase(cursorHandler.PhraseToDrag) + "</color> ";
        text.text = text.text.Replace(toReplace, toInsert);
        toReplace = toInsert;
        PhraseInserted = true;

        gameState.CurrentDayLetters[boxIn.CurrentLetter - 1].ChosenKey = cursorHandler.PhraseToDrag;
    }

    public void Submit(bool gendarmerie)
    {
        if (PhraseInserted)
        {
            gameState.CurrentDayLetters[boxIn.CurrentLetter - 1].NoteSentTo = 
                gendarmerie ? NoteSentTo.Gendarmerie : NoteSentTo.Archive;

            envelope.EnvelopeGameState = EnvelopeGameState.Ready;
            panelsManager.StartReading(false);
        }
    }
}
