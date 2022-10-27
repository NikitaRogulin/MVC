using System;
using UnityEngine;

public class Meteorite
{
    public event Action<Vector2> OnChangedPosition;
  
    private Vector2 _position;
    private float _speed;
    private Vector2 _direcrion;
    public Meteorite(Vector2 position,Vector2 direcrion,float speed)
    {
        _direcrion = direcrion.normalized;
        _position = position;
        _speed = speed;
    }
    public void Move()
    {
        _position += _direcrion * _speed * Time.deltaTime;
        OnChangedPosition.Invoke(_position);
    }
}
