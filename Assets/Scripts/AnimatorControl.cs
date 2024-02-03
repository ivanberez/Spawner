using UnityEngine;

public class AnimatorControl
{
    private const string XDirection = nameof(XDirection);
    private const string YDirection = nameof(YDirection);

    private readonly Animator _animator;

    public AnimatorControl(Animator animator)
    {
        _animator = animator;        
    }

    public void ChangeParams(Vector2 direction)
    {                
        _animator.SetFloat(XDirection, direction.x);
        _animator.SetFloat(YDirection, direction.y);
    }        
}