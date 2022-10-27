using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerView : MonoBehaviour
{
    [SerializeField] private MeteoriteView _meteoritePrefabs;
    [SerializeField] private ShuttleView _shuttlePrefabs;
    public Action<MeteoriteView> OnSpawnMeteorite;
    private List<MeteoriteView> _meteoritesView = new List<MeteoriteView>();
    private ShuttleView _shuttleView;

    public void SpawnShuttle(Shuttle shuttle)
    {
        _shuttleView = Instantiate(_shuttlePrefabs);
        _shuttleView.Init(shuttle);
    }
    public void SpawnMeteorite(Meteorite meteorite)
    {
        var newMeteorite = Instantiate(_meteoritePrefabs);
        newMeteorite.Init(meteorite);
        _meteoritesView.Add(newMeteorite);
        OnSpawnMeteorite?.Invoke(newMeteorite);
    }
    public void DespawnShuttle()
    {
        Destroy(_shuttleView.gameObject);
    }
    public void DespawnMeteorite(MeteoriteView meteoriteView)
    {
        _meteoritesView.Remove(meteoriteView);
        Destroy(meteoriteView.gameObject);
    }
    
    public void DespawnMeteorite(Meteorite meteorite)
    {
        foreach(var e in _meteoritesView)
        {
            if (e.Meteorite.Equals(meteorite))
            {
                DespawnMeteorite(e);
                return;
            }
        }
    }

}
