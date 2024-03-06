using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float Delay = 2;

    [SerializeField] private Enemy _prefab;
    [SerializeField] private Path _way;             

    private void Start()
    {
        StartCoroutine(Spawn());        
    }    

    private IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(_prefab, transform.position, Quaternion.identity).Init(_way);
            yield return new WaitForSeconds(Delay);
        }        
    }
}