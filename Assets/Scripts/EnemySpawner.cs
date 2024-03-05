using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float Delay = 2;

    [SerializeField] private Enemy _prefabEnemy;
    [SerializeField] private Path _way;             

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, Delay);        
    }    

    private void Spawn()
    {
        Instantiate(_prefabEnemy, transform.position, Quaternion.identity).Init(_way);        
    }    
}