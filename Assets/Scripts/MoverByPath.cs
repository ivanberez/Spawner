using UnityEngine;

public class MoverByPath : MonoBehaviour
{
    private const int StartWayPoint = 0;

    [SerializeField] private float _speed = 4;
    [SerializeField] private Path _path;

    private int _curentWayPoint;
    private Vector3 _targetPosition;

    private void Awake()
    {
        if (_path != null)
            _targetPosition = _path.Points[_curentWayPoint = StartWayPoint];
    }

    private void Update()
    {
        if (_path != null)
        {
            CheckTargetPosition();
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
    }

    private void CheckTargetPosition()
    {
        if (transform.position == _targetPosition)
        {
            _curentWayPoint = (++_curentWayPoint) % _path.Points.Length;
            _targetPosition = _path.Points[_curentWayPoint];
        }
    }
}