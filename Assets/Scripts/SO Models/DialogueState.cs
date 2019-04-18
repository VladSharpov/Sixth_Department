using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueState : ScriptableObject
{
    [SerializeField] [TextArea(3, 10)] string motherText;

    [SerializeField] [TextArea(3, 10)] string answer1;
    [SerializeField] [TextArea(3, 10)] string answer2;
    [SerializeField] [TextArea(3, 10)] string answer3;
    [SerializeField] [TextArea(3, 10)] string answer4;

    [SerializeField] DialogueState next1;
    [SerializeField] DialogueState next2;
    [SerializeField] DialogueState next3;
    [SerializeField] DialogueState next4;

    public string MotherText => motherText;

    public string Answer1 => answer1;
    public string Answer2 => answer2;
    public string Answer3 => answer3;
    public string Answer4 => answer4;

    public DialogueState Next1 => next1;
    public DialogueState Next2 => next2;
    public DialogueState Next3 => next3;
    public DialogueState Next4 => next4;
}
