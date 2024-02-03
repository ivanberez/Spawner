using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject _effect;    

    private void Awake()
    {
        _effect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            _effect.SetActive(false);
            _effect.SetActive(true);
            Destroy(enemy.gameObject);
        }
    }
}