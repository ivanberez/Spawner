using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private const float Delay = 2;

    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _target;             

    private void Start()
    {
        StartCoroutine(Spawn());        
    }    

    private IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(_prefab, transform.position, Quaternion.identity).Init(_target);
            yield return new WaitForSeconds(Delay);
        }        
    }
}