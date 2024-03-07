using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    [SerializeField] private MoverByPath _mover;
    [SerializeField] private Effecter _effect;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _effect.Show();           
            Destroy(enemy.gameObject);
        }
    }
}