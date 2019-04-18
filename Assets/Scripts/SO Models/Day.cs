using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Day : ScriptableObject
{
    [SerializeField] int number;

    [SerializeField] Letter[] letters;

    [SerializeField] DialogueState dialogueStart;

    public Letter[] Letters => letters;
}
