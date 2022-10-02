using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLootNote : MonoBehaviour
{
    [SerializeField] private Item[] _items;
    [SerializeField] private Item _requirdItem;

    private Enemy.EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<Enemy.EnemyHealth>();
    }

    private void OnEnable()
    {
        _enemyHealth.OnDie += Drop;
    }

    private void OnDisable()
    {
        _enemyHealth.OnDie -= Drop;
    }

    public void Drop()
    {
        int randomItemIndex =  Random.Range(0, _items.Length - 1);
        Instantiate(_items[randomItemIndex], new Vector3(transform.position.x + Random.Range(1, 5), transform.position.y, transform.position.z + Random.Range(1, 3)), Quaternion.identity);

        if(_requirdItem != null)
        {
            Instantiate(_requirdItem, new Vector3(transform.position.x + Random.Range(1, 5), transform.position.y, transform.position.z + Random.Range(1, 3)), Quaternion.identity);
        }
    }
}
