using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NpcSpawnScript : MonoBehaviour
{

    [SerializeField]private GameObject _enemyPrefab;
    public float _minimumSpawnTime;
    public float _maximumSpawnTime;
    private float _timeUntilSpawn;


    // Start is called before the first frame update
    void Awake(){

    }

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
            if(_enemyPrefab != null){
                Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
                SetTimeUnitlSpawn();
            }
        }
    }

    private void SetTimeUnitlSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

}
