using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opening : MonoBehaviour
{
    PanelsManager panelsManager;
    Envelope envelope;

    [SerializeField]bool inProcess = false;
    public bool InProcess
    {
        get => inProcess;
        set
        {
            inProcess = value;
            if (inProcess == false)
            {
                Counter = 0;
            }
        }
    }

    [SerializeField]int counter = 0;
    public int Counter
    {
        get => counter;
        set
        {
            counter = value;
            if (counter >= nodes.Length)
            {
                panelsManager.StartOpening(false);
                envelope.EnvelopeGameState = EnvelopeGameState.Opened;
            }
        }
    }

    Node[] nodes;
    private NodeStart nodeStart;

    private void Start()
    {

    }

    private void OnEnable()
    {
        nodeStart = FindObjectOfType<NodeStart>();
        nodes = FindObjectsOfType<Node>();
        panelsManager = FindObjectOfType<PanelsManager>();
        envelope = FindObjectOfType<Envelope>();

        InProcess = false;
        ResetNodesColor();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            InProcess = false;
            ResetNodesColor();
        }
    }

    private void ResetNodesColor()
    {
        nodeStart.ResetColor();
        foreach(var node in nodes)
        {
            node.ResetColor();
        }
    }
}
