//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Pattern : MonoBehaviour
//{
//    [SerializeField] GameObject line;
//    [SerializeField] Text text;

//    private int nodesPassed = 0;
//    private Line currentLine;

//    public Node currentNode { get; set; }

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0) && currentNode)
//        {
//            if (nodesPassed == 0 && currentNode?.Number == 0)
//            {
//                currentLine = Instantiate(line, transform.position, Quaternion.identity).GetComponent<Line>();
//                currentLine.GetComponent<LineRenderer>().SetPosition(0, currentNode.transform.position);
//                nodesPassed = 1;
//            }
//        }
//        else if (currentNode?.Number == nodesPassed)
//        {
//            if (nodesPassed == 1 && currentNode.Number == 1)
//            {
//                currentLine.AddVertex(1, currentNode.transform.position);
//                nodesPassed++;
//            }
//            else if (nodesPassed == 2 && currentNode.Number == 2)
//            {
//                currentLine.GetComponent<LineRenderer>().SetPosition(2, currentNode.transform.position);
//                currentLine.Built = true;
//                text.enabled = true;
//            }
//        }

//        if (Input.GetMouseButtonUp(0) && currentLine && !currentLine.Built)
//        {
//            Destroy(currentLine.gameObject);
//            currentLine = null;
//            nodesPassed = 0;
//        }
//    }
//}
