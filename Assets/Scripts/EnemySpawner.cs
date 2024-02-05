using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float Delay = 2;

    [SerializeField] private Enemy _prefabEnemy;
    
    private Vector2[] _directions;    

    private Vector2 RandomDirection => _directions[Random.Range(0, _directions.Length)];

    private void Awake()
    {        
        _directions = new Vector2[]
        {
            Vector2.down, Vector2.up, Vector2.left, Vector2.right
        };
    }    

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, Delay);
    }    

    private void Spawn()
    {
        Instantiate(_prefabEnemy, transform.position, Quaternion.identity).Init(RandomDirection);        
    }    
}