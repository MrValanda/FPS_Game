using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private List<Transform> _enemySPawnPoints;

    private void Start()
    {
        Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity, transform);
    }
}
    