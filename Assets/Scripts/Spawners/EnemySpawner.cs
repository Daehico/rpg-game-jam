using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;

    private void Awake()
    {
        var enemy = Instantiate(_enemyTemplate, transform);
    }
}
