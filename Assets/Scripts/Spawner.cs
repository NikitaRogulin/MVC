using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner
{
    public event Action<Shuttle> OnSpawnShuttle;
    public event Action OnDespawnShuttle;
    public event Action<Meteorite> OnSpawnMeteorite;
    public event Action<Meteorite> OnDespawnMeteorite;

    private List<Meteorite> _meteorites = new List<Meteorite>();
    private Shuttle _shuttle;

    public Shuttle SpawnShuttle(Vector2 position)
    {
        _shuttle = new Shuttle(position);
        OnSpawnShuttle?.Invoke(_shuttle);
        return _shuttle;
    }
    public void DespawnShuttle()
    {
        _shuttle = null;
        OnDespawnShuttle?.Invoke();
    }
    public Meteorite SpawnMeteorite(Vector2 position, float speed)
    {
        var meteorite = new Meteorite(position, Vector2.down, speed);
        _meteorites.Add(meteorite);
        OnSpawnMeteorite?.Invoke(meteorite);
        return meteorite;
    }
    public void DeSpawnMeteorite(Meteorite meteorite)
    {
        if (_meteorites.Contains(meteorite))
        {
            _meteorites.Remove(meteorite);
            OnDespawnMeteorite?.Invoke(meteorite);
        }
    }
}
