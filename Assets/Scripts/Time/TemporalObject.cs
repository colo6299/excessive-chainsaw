using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalObject : MonoBehaviour
{
    private Stack worldline;

    private void Awake()
    {
        worldline = new Stack(new Stack.ListData(transform.position));
    }
    void FixedUpdate()
    {
        worldline.Add(new Stack.ListData(transform.position));
        Debug.Log(worldline.Length);
    }
}

public class Stack
{
    public Stack(ListData headData)
    {
        Length = 0;
        Head = new ListElement(headData, null);
    }
    public int Length;
    public ListElement Head;

    public void Add(ListData newData)
    {
        Head = new ListElement(newData, Head);
        Length += 1;
    }

    public ListData RemoveAndReturn()
    {
        ListData data = Head.Data;
        Head = Head.NextElement;
        Length -= 1;
        return data;
    }

    public class ListElement
    {
        public ListElement(ListData data, ListElement nextElement)
        {
            Data = data;
            NextElement = nextElement;
        }
        public ListElement NextElement;
        public ListData Data;
    }

    public class ListData
    {
        public ListData(Vector3 data)
        {
            Data = data;
        }
        public Vector3 Data;
    }


}
