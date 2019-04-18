//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Line : MonoBehaviour
//{
//    const int DEFAULT = 0;
//    const int IGNORE_RAYCAST = 2;

//    private LineRenderer lineRenderer;

//    public bool Built { get; set; } = false;

//    private void Awake()
//    {
//        gameObject.layer = IGNORE_RAYCAST;
//        lineRenderer = GetComponent<LineRenderer>();

//        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        lineRenderer.SetPosition(0, cursorPosition);
//        lineRenderer.SetPosition(1, cursorPosition);
//    }

//    void Update()
//    {
//        if (!Built)
//        {
//            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            lineRenderer.SetPosition(lineRenderer.positionCount - 1, cursorPosition);
//        }
//    }

//    public void AddVertex(int i, Vector3 position)
//    {
//        lineRenderer.positionCount++;
//        lineRenderer.SetPosition(i, position);
//    }
//}
