using UnityEngine;

public class View
{    
    private const string Up = nameof(Up);
    private const string Down = nameof(Down);
    private const string Side = nameof(Side);    

    private readonly int _upIndex;
    private readonly int _downIndex;
    private readonly int _sideIndex;

    private readonly SpriteRenderer _spriteRenderer;
    private readonly Animator _animator;
    
    private int _curentLayerIndex;

    public View(SpriteRenderer spriteRenderer, Animator animator)
    {
        _spriteRenderer = spriteRenderer;
        _animator = animator;

        _upIndex = _animator.GetLayerIndex(nameof(Up));        
        _downIndex = _animator.GetLayerIndex(nameof(Down));        
        _sideIndex = _animator.GetLayerIndex(nameof(Side));                    
    }

    public void RefreshByDirection(Direction direction) 
    {
        _spriteRenderer.flipX = direction == Direction.Right;

        SetActiveLayer(direction);
    }

    private void SetActiveLayer(Direction direction)
    {
        _animator.SetLayerWeight(_curentLayerIndex, 0);

        switch (direction)
        {
            case Direction.Up:
                _curentLayerIndex = _upIndex;
                break;
            case Direction.Left:
                _curentLayerIndex = _sideIndex;
                break;
            case Direction.Right:
                _curentLayerIndex = _sideIndex;
                break;
            case Direction.Down:
                _curentLayerIndex = _downIndex;
                break;
        }

        _animator.SetLayerWeight(_curentLayerIndex, 1);
    }
}