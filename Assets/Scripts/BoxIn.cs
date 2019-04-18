using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BoxIn : MonoBehaviour
{
    [SerializeField] GameState gameState;

    WorkingArea workingArea;

    private int envelopesToProceed;

    public int CurrentLetter { get; set; } = 1;

    private void Start()
    {
        envelopesToProceed = gameState.CurrentDayLetters.Length;

        workingArea = FindObjectOfType<WorkingArea>();
    }

    public void OnEnvelopeInsert()
    {
        workingArea.Clear();

        gameState.Loyalty += gameState.CurrentDayLetters[CurrentLetter - 1].
            LoyaltyChange[gameState.CurrentDayLetters[CurrentLetter - 1].ChosenKey - 1];

        switch (gameState.CurrentDayLetters[CurrentLetter - 1].NoteSentTo)
        {
            case NoteSentTo.Gendarmerie:
                gameState.Loyalty += gameState.CurrentDayLetters[CurrentLetter - 1].LoyaltyChangeIfGendarmerie;
                break;
            case NoteSentTo.Archive:
                gameState.Loyalty += gameState.CurrentDayLetters[CurrentLetter - 1].LoyaltyChangeIfArchived;
                break;
        }

        if (CurrentLetter >= envelopesToProceed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        CurrentLetter++;
    }
}
