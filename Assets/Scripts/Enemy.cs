using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class Enemy : MonoBehaviour
{
    private Movement _movement;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private View _view;    

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _view = new View(_spriteRenderer, _animator);
    }

    public void Init(Way way)
    {
        _movement.SetWay(way);
    }

    private void OnEnable()
    {
        _movement.ChangedDirection += _view.RefreshByDirection;        
    }

    private void OnDisable()
    {
        _movement.ChangedDirection -= _view.RefreshByDirection;        
    }    
}