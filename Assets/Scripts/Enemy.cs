using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class Enemy : MonoBehaviour
{    
    private Movement _movement;
    private Animator _animator;
    private AnimatorControl _animatorControl;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _animator = GetComponent<Animator>();

        _animatorControl = new AnimatorControl(_animator);
    }

    public void Init(Vector2 direction)
    {
        _movement.SetDirection(direction);
        _animatorControl.ChangeParams(direction);
    }       
}