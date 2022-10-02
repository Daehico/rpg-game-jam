using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerClassPrefabs;

    private const string KeySaveName = "HeroClassId";

    private int _idOfSpawnPlayer;

    private void Awake()
    {
        _idOfSpawnPlayer = PlayerPrefs.GetInt(KeySaveName);
        Instantiate(_playerClassPrefabs[_idOfSpawnPlayer], transform);
    }
}
