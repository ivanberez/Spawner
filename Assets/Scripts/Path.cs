using System;
using UnityEngine;

public class Path : MonoBehaviour
{
    private Vector3[] _points;

    public Vector3[] GetPoints => (Vector3[])_points.Clone();

    private void Awake()
    {
        if (_points == null || _points.Length == 0)
        {
            _points = new Vector3[] 
            {
                transform.position 
            };
        }            
    }

    [ContextMenu("Refresh Points")]
    private void OnValidate()
    {
        Transform[] childrensTransform = GetComponentsInChildren<Transform>();

        var length = childrensTransform.Length - 1;

        _points = new Vector3[length];

        for (int i = 0; i < length; i++)
            _points[i] = childrensTransform[i + 1].position;
    }    
}