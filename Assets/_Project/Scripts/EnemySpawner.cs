using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Random = UnityEngine.Random;

namespace ShootEmUp
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyType> _enemyTypeList;
        [SerializeField] private int _maxEnemies = 10;
        [SerializeField] private float _spawnInterval = 2f;

        private List<SplineContainer> _splineList;
        private EnemyFactory _enemyFactory;
        private float _spawnTimer;
        private int _enemiesSpawned;

        private void OnValidate()
        {
            _splineList = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        private void Start()
        {
            _enemyFactory = new EnemyFactory();
        }

        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if (_enemiesSpawned < _maxEnemies && _spawnTimer >= _spawnInterval)
            {
                SpawnEnemy();
                _spawnTimer = 0f;
            }
        }

        private void SpawnEnemy()
        {
            var enemyType = _enemyTypeList[Random.Range(0, _enemyTypeList.Count)];
            var spline = _splineList[Random.Range(0, _splineList.Count)];

            _enemyFactory.CreateEnemy(enemyType, spline);
            _enemiesSpawned++;
        }
    }
}