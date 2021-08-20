using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporalObject : MonoBehaviour
{
    private Stack worldline;
    public Rigidbody rbody;

    private void Awake()
    {
        worldline = new Stack(new Stack.ListData(transform.position, transform.rotation, rbody.velocity));
    }
    void FixedUpdate()
    {
        if (Timeline.reversing)
        {
            Stack.ListData data = worldline.RemoveAndReturn();
            transform.position = data.Pos;
            transform.rotation = data.Rot;
            rbody.velocity = data.Vel;
        }
        else
        {
            Stack.ListData data = new Stack.ListData(transform.position, transform.rotation, rbody.velocity);
            worldline.Add(data);
        }
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
        public ListData(Vector3 pos, Quaternion rot, Vector3 vel)
        {
            Pos = pos;
            Rot = rot;
            Vel = vel;
        }
        public Vector3 Pos;
        public Quaternion Rot;
        public Vector3 Vel;
    }


}
