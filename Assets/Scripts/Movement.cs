using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    private const int StartWayPoint = 0;

    [SerializeField] private float _speed = 4;
    
    private Way _way;
    private int _curentWayPoint;
    private Vector3 _targetPosition;
    private Direction _direction;

    private UnityEvent<Direction> _changedDirection = new UnityEvent<Direction>();

    public event UnityAction<Direction> ChangedDirection
    {
        add => _changedDirection.AddListener(value);
        remove => _changedDirection.RemoveListener(value);
    }

    private void Awake()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        CheckTargetPosition();
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }           

    private void CheckTargetPosition()
    {
        if (transform.position == _targetPosition)
        {
            _curentWayPoint = (_curentWayPoint + 1) % _way.Points.Length;
            SetTargetPosition(_way.Points[_curentWayPoint]);            
        }
    }

    private void SetTargetPosition(Vector3 newPosition)
    {
        _targetPosition = newPosition;

        var targetDirection = DefineDirection(newPosition);

        if(_direction != targetDirection)
            _changedDirection.Invoke(_direction = targetDirection);
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

    public void SetWay(Way way)
    {
        _way = way;
        _curentWayPoint = StartWayPoint;
        SetTargetPosition(_way.Points[_curentWayPoint]);
        _changedDirection.Invoke(_direction);
    }
}