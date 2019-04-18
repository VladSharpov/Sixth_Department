using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhraseConverter : MonoBehaviour
{
    [SerializeField] GameState gameState;

    BoxIn boxIn;

    private void OnEnable()
    {
        boxIn = FindObjectOfType<BoxIn>();
    }

    public string GeneratePhrase(int id)
    {
        return gameState.CurrentDayLetters[boxIn.CurrentLetter - 1].Values[id - 1];
    }
}
