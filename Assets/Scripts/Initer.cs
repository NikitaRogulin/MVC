using System;
using System.Collections;
using UnityEngine;

public class Initer : MonoBehaviour
{
    [SerializeField] GameInput _gameInput;
    [SerializeField] SpawnerView _spawnerView;
    [SerializeField] GameCycleSpawner _gameCycleSpawner;

    private Spawner spawner;
    private void Awake()
    {
        spawner = new Spawner();
        spawner.OnDespawnShuttle += _spawnerView.DespawnShuttle;
        spawner.OnSpawnShuttle += _spawnerView.SpawnShuttle;
        spawner.OnSpawnMeteorite += _spawnerView.SpawnMeteorite;
        spawner.OnDespawnMeteorite += _spawnerView.DespawnMeteorite;
        spawner.OnDespawnMeteorite += (x) => _gameCycleSpawner.CalculateTimeSpawn();
        spawner.OnSpawnShuttle += _gameInput.Setup;
        _gameCycleSpawner.Init(spawner);

        spawner.OnSpawnShuttle += (shuttle) =>
        {
            shuttle.OnRebirth += () =>
            {
                spawner.DespawnShuttle();
                spawner.SpawnShuttle(new Vector2(0, -3.5f));
            };
            shuttle.OnDeath += () =>
            {
                spawner.DespawnShuttle();
            };

        };
        _spawnerView.OnSpawnMeteorite += (meteoriteView) =>
        {
            meteoriteView.OnDeath += (x) => spawner.DeSpawnMeteorite(x.Meteorite);
        };
        spawner.SpawnShuttle(new Vector2(0, -3.5f));
    }
    private void Start()
    {
        _gameCycleSpawner.StartSpawning();
    }

    private void OnDestroy()
    {
        spawner.OnSpawnShuttle -= _spawnerView.SpawnShuttle;
        spawner.OnSpawnMeteorite -= _spawnerView.SpawnMeteorite;
        spawner.OnSpawnShuttle -= _gameInput.Setup;
        spawner.OnSpawnShuttle -= (x) => x.OnRebirth += () => spawner.SpawnShuttle(new Vector2(0, -3.5f));
    }
}
