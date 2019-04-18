using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterTextAssigner : MonoBehaviour
{
    [SerializeField] GameState gameState;

    BoxIn boxIn;
    TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        boxIn = FindObjectOfType<BoxIn>();
        text.text = gameState.CurrentDayLetters[boxIn.CurrentLetter - 1].Body;
    }
}
