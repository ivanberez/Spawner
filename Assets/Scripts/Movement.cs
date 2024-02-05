using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 2;
    [SerializeField] private Vector2[] _pointsWay;

    private Vector2 _direction = Vector2.zero;

    private void Update()
    {
        var targetPosition = (Vector2)transform.position + _direction;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }
    
    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
        _direction.Normalize();
    }
}