using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Letter : ScriptableObject
{
    [SerializeField] [TextArea(20, 100)] string body;

    [SerializeField] string[] keys;
    [SerializeField] string[] values;
    [SerializeField] sbyte[] loyaltyChange;
    [SerializeField] sbyte loyaltyChangeIfGendarmerie;
    [SerializeField] sbyte loyaltyChangeIfArchived;
    [SerializeField] int money;

    [SerializeField] NoteSentTo noteSentTo;
    [SerializeField] int chosenKey;

    public string Body => body;

    public string[] Keys => keys;
    public string[] Values => values;

    public sbyte[] LoyaltyChange => loyaltyChange;
    public sbyte LoyaltyChangeIfGendarmerie => loyaltyChangeIfGendarmerie;
    public sbyte LoyaltyChangeIfArchived => loyaltyChangeIfArchived;
    public int Money => money;

    public NoteSentTo NoteSentTo
    {
        get => noteSentTo;
        set => noteSentTo = value;
    }

    public int ChosenKey
    {
        get => chosenKey;
        set => chosenKey = value;
    }
}

public enum NoteSentTo
{
    Gendarmerie,
    Archive
}