using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    Transform _myTransform;
    [SerializeField] int _enemySpawned;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }
    public void GenerateEnemy()
    {
        for (int i = 0; i < _enemySpawned; i++)
        {
            GameObject NewEnemy = Instantiate(_enemyPrefab, _myTransform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
