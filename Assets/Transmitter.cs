using UnityEngine;

public class Transmitter : MonoBehaviour
{
    [SerializeField] private Path _path;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Mover movement))
        {
            movement.SetWay(_path);            
        }
    }
}