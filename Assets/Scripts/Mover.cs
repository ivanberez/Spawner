using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private const int StartWayPoint = 0;

    [SerializeField] private float _speed = 4;
    
    private Path _way;
    private int _curentWayPoint;
    private Vector3 _targetPosition;
    private Direction _direction;
    
    public event Action<Direction> ChangedDirection;        

    private void Update()
    {
        if(_way != null)
        {
            CheckTargetPosition();
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }        
    }

    public void SetWay(Path way)
    {
        _way = way;
        _curentWayPoint = StartWayPoint;
        SetTargetPosition(_way.GetPoints[_curentWayPoint]);
        ChangedDirection?.Invoke(_direction);
    }

    private void CheckTargetPosition()
    {        
        if (transform.position == _targetPosition)
        {
            _curentWayPoint = (_curentWayPoint + 1) % _way.GetPoints.Length;
            SetTargetPosition(_way.GetPoints[_curentWayPoint]);            
        }
    }

    private void SetTargetPosition(Vector3 newPosition)
    {
        _targetPosition = newPosition;

        var targetDirection = DefineDirection(newPosition);

        if(_direction != targetDirection)
            ChangedDirection?.Invoke(_direction = targetDirection);
    }

    private Direction DefineDirection(Vector3 position)
    {
        var vectorDirecion = transform.position - position;
        var x = vectorDirecion.x < 0 ? -vectorDirecion.x : vectorDirecion.x;
        var y = vectorDirecion.y < 0 ? -vectorDirecion.y : vectorDirecion.y;

        if (x > y)
        {
            return vectorDirecion.x > 0 ? Direction.Left : Direction.Right;
        }
        else
        {
            return vectorDirecion.y > 0 ? Direction.Down : Direction.Up;
        }        
    }    
}