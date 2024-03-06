using UnityEngine;

[RequireComponent(typeof(Mover), typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]

public class Enemy : MonoBehaviour
{
    private Mover _movement;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private View _view;    

    private void Awake()
    {
        _movement = GetComponent<Mover>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _view = new View(_spriteRenderer, _animator);
    }

    public void Init(Path way)
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