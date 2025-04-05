using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HeallObject : MonoBehaviour
{
    [SerializeField] private float _heallPoint;

    public float Use()
    {
        return _heallPoint;
    }
}
