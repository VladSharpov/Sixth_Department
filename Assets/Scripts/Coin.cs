using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameState gameState;
    [SerializeField] BoxIn boxIn;

    int givenMoney;

    private void Start()
    {
        boxIn = FindObjectOfType<BoxIn>();
        givenMoney = gameState.CurrentDayLetters[boxIn.CurrentLetter - 1].Money;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // TODO - check if clicked with left mouse button

        gameState.Wealth += givenMoney;
        Destroy(gameObject);
    }
}
