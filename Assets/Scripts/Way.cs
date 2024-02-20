using System;
using UnityEngine;

public class Way : MonoBehaviour
{    
    [field: SerializeField] public Vector3[] Points { get; private set; }

    private void Awake()
    {
        if (Points == null)
        {
            Points = new Vector3[] 
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

        Points = new Vector3[length];

        for (int i = 0; i < length; i++)
            Points[i] = childrensTransform[i + 1].position;
    }
}