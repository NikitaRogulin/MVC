using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class ShuttleView : MonoBehaviour
{
    private Shuttle _shuttle;

    public void Init(Shuttle shuttle)
    {
        _shuttle = shuttle;
        _shuttle.OnChangedPosition += ShowPosition;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MeteoriteView meteoriteView))
        {
            _shuttle.Death();
        }
    }
    private void ShowPosition(Vector2 position)
    {
        gameObject.transform.position = position;
    }
}
