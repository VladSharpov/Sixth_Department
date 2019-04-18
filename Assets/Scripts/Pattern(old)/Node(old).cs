//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class Node : MonoBehaviour
//{
//    public int Number { get; set; }

//    private Pattern pattern;

//    void Awake()
//    {
//        string name = gameObject.name;
//        int.TryParse(name[name.Length - 2].ToString(), out int number);
//        number--;
//        Number = number;
//    }

//    void Start()
//    {
//        pattern = FindObjectOfType<Pattern>();
//    }

//    private void OnMouseEnter()
//    {
//        pattern.currentNode = this;
//    }

//    private void OnMouseExit()
//    {
//        pattern.currentNode = null;
//    }
//}
