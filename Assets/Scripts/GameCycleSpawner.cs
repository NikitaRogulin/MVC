using System;
using System.Collections;
using UnityEngine;

public class GameCycleSpawner : MonoBehaviour
{
    private Spawner _spawner;
    private float _meteoriteSpeed = 6.5f;
    private TimeSpan _timeSpawnMeteorite = new TimeSpan(0, 0, 3);
    private TimeSpan _minTimeSpawnMeteorite = new TimeSpan(0, 0, 0, 0, 500);
    private TimeSpan _spawnTimeStepMeteorite = new TimeSpan(0, 0, 0, 0, 500);
    public void Init(Spawner spawner)
    {
        this._spawner = spawner;
    }
    public void StartSpawning()
    {
        StartCoroutine(MeteoriteСoroutine());
    }
    private IEnumerator MeteoriteСoroutine()
    {
        var isMeteoriteSpawning = true;
        while (isMeteoriteSpawning)
        {
            var positionSpawnMeteorite = new Vector2(UnityEngine.Random.Range(-6f, 6f), 5f);
            _spawner.SpawnMeteorite(positionSpawnMeteorite, _meteoriteSpeed);
            yield return new WaitForSeconds((float)_timeSpawnMeteorite.TotalSeconds);
        }
    }
    public void CalculateTimeSpawn()
    {
        _timeSpawnMeteorite -= _spawnTimeStepMeteorite;
        ProtectedTimeSpawn();
    }
    private void ProtectedTimeSpawn()
    {
        if (_timeSpawnMeteorite < _minTimeSpawnMeteorite)
        {
            _timeSpawnMeteorite = _minTimeSpawnMeteorite;
        }
    }
}
