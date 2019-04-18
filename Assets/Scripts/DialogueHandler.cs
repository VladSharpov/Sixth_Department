using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueHandler : MonoBehaviour
{
    private bool completed = false;

    [SerializeField] DialogueState firstDialogueState;

    [SerializeField] TextMeshProUGUI motherText;

    [SerializeField] Button answer1Button;
    [SerializeField] Button answer2Button;
    [SerializeField] Button answer3Button;
    [SerializeField] Button answer4Button;

    TextMeshProUGUI answer1Text;
    TextMeshProUGUI answer2Text;
    TextMeshProUGUI answer3Text;
    TextMeshProUGUI answer4Text;

    private DialogueState currentState;
    private DialogueState CurrentState
    {
        get => currentState;
        set
        {
            currentState = value;
            ApplyState(currentState);
        }
    }

    private void Start()
    {
        answer1Text = answer1Button.GetComponentInChildren<TextMeshProUGUI>();
        answer2Text = answer2Button.GetComponentInChildren<TextMeshProUGUI>();
        answer3Text = answer3Button.GetComponentInChildren<TextMeshProUGUI>();
        answer4Text = answer4Button.GetComponentInChildren<TextMeshProUGUI>();

        CurrentState = firstDialogueState;
    }

    private void Update()
    {
        if (completed && Input.GetMouseButton(0))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void ApplyState(DialogueState dialogueState)
    {
        motherText.text = currentState.MotherText;

        if (!currentState.Next1)
        {
            completed = true;
            answer1Button.gameObject.SetActive(false);
            answer2Button.gameObject.SetActive(false);
            answer3Button.gameObject.SetActive(false);
            answer4Button.gameObject.SetActive(false);
            return;
        }

        answer1Text.text = currentState.Answer1;
        answer2Text.text = currentState.Answer2;
        answer3Text.text = currentState.Answer3;
        answer4Text.text = currentState.Answer4;
    }

    public void NextState(int buttonIndex)
    {
        switch(buttonIndex)
        {
            case 1:
                CurrentState = currentState.Next1;
                break;
            case 2:
                CurrentState = currentState.Next2;
                break;
            case 3:
                CurrentState = currentState.Next3;
                break;
            case 4:
                CurrentState = currentState.Next4;
                break;
        }
    }
}
