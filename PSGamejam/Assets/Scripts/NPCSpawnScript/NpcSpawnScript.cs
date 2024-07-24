using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawnScript : MonoBehaviour
{

    public GameObject _enemyPrefab;

    public float _minimumSpawnTime;

    public float _maximumSpawnTime;

    private float _timeUntilSpawn;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeUnitlSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefab, new Vector2);
            SetTimeUnitlSpawn();
        }
    }

    private void SetTimeUnitlSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
