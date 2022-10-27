using System;
using UnityEngine;

public class Shuttle
{
    public event Action OnDeath;
    public event Action OnRebirth;
    public event Action<Vector2> OnChangedPosition;
    private int _hp;
    private Vector2 _position;
    private float _speed;
   
    public Shuttle(Vector2 position, int hp = 5, float speed = 5f)
    {
        _position = position;
        _hp = hp;
        _speed = speed;
    }
    public void Death()
    {
        if (_hp > 0)
        {
            _hp--;
            OnRebirth.Invoke();
        }
        else
        {
            OnDeath.Invoke();
        }
    }
    public void Move(Vector2 direcrion)
    {
        direcrion = ProtectDirection(direcrion);
        _position += direcrion * _speed * Time.deltaTime;
        OnChangedPosition?.Invoke(_position);
    }
    private Vector2 ProtectDirection(Vector2 direcrion)
    {
        var newDirecrion = new Vector2(direcrion.x, 0);

        return newDirecrion.normalized;
    }
}
