using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameState : ScriptableObject
{
    [SerializeField] int currentDay = 1;

    [SerializeField] int loyalty = 0;
    [SerializeField] int wealth = 0;

    [SerializeField] Day[] days;

    public int CurrentDay
    {
        get => currentDay;
        set => currentDay = value;
    }

    public int Loyalty
    {
        get => loyalty;
        set => loyalty = value;
    }

    public int Wealth
    {
        get => wealth;
        set => wealth = value;
    }

    public Day[] Days => days;

    public Letter[] CurrentDayLetters => days[CurrentDay - 1].Letters;

    public void Reset()
    {
        CurrentDay = 1;
        Loyalty = 0;
        Wealth = 0;
    }
}
