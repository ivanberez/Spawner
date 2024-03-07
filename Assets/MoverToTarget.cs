using System;
using UnityEngine;

public class MoverToTarget : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    public event Action<Direction> ChangedDirection;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        ChangeDirection(_target.position);
    }
    
    private void ChangeDirection(Vector3 position)
    {
        var vectorDirecion = transform.position - position;
        var x = vectorDirecion.x < 0 ? -vectorDirecion.x : vectorDirecion.x;
        var y = vectorDirecion.y < 0 ? -vectorDirecion.y : vectorDirecion.y;

        if (x > y)
        {
            ChangedDirection?.Invoke(vectorDirecion.x > 0 ? Direction.Left : Direction.Right);
        }
        else
        {
            ChangedDirection?.Invoke(vectorDirecion.y > 0 ? Direction.Down : Direction.Up);
        }
    }
}