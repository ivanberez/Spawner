using UnityEngine;

[RequireComponent(typeof(MoverToTarget), typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer), typeof(Collider2D))]

public class Enemy : MonoBehaviour
{
    private MoverToTarget _mover;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private View _view;

    public void Init(Transform target)
    {
        _mover.SetTarget(target);        
    }

    private void Awake()
    {
        _mover = GetComponent<MoverToTarget>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _view = new View(_spriteRenderer, _animator);
    }    

    private void OnEnable()
    {
        _mover.ChangedDirection += _view.RefreshByDirection;            
    }

    private void OnDisable()
    {
        _mover.ChangedDirection -= _view.RefreshByDirection;        
    }    
}