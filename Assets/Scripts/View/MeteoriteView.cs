using System;
using UnityEngine;

public class MeteoriteView : MonoBehaviour
{
    public event Action<MeteoriteView> OnDeath;
    public Meteorite Meteorite => _meteorite;
    private Meteorite _meteorite;
    public void Init(Meteorite meteorite)
    {
        _meteorite = meteorite;
        _meteorite.OnChangedPosition += ShowPosition;
    }
    private void Update()
    {
        _meteorite.Move();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MeteoriteView meteoriteView) == false)
        {
            OnDeath?.Invoke(this);
        }
    }
    private void ShowPosition(Vector2 position)
    {
        gameObject.transform.position = position;
    }
}
