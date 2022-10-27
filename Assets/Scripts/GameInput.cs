using UnityEngine;

public class GameInput : MonoBehaviour
{
    private Shuttle _shuttle;

    public void Setup(Shuttle shuttle)
    {
        _shuttle = shuttle;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _shuttle.Move(Vector2.left);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _shuttle.Move(Vector2.right);
        }
    }
}
