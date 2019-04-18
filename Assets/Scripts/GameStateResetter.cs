using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO - later move to a different place
public class GameStateResetter : MonoBehaviour
{
    [SerializeField] GameState gameState;

    // Start is called before the first frame update
    void Awake()
    {
        gameState.Reset();
    }
}
