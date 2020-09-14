using UnityEngine;

public class Player : IPlayer
{
    public int Hp { get; private set; }
    public bool Alive => Hp > 0;
    public Vector2 WorldPosition => _gameObject.transform.position;
    public Vector2 GridPosition { get; private set; }

    private readonly GameObject _gameObject;

    public Player(GameObject gameObject, int hp)
    {
        _gameObject = gameObject;
        Hp = hp;
    }

    public void TakeDamage(int damage)
    {  
        Hp -= damage;
        Debug.Log("Damage. HP:" + Hp);
        if (Hp <= 0)
        {
            Hp = 0;
            Debug.Log("Game over. HP:" + Hp);
        }
    }

    public void SetGridPosition(Vector2 gridPosition)
    {
        GridPosition = gridPosition;
    }

    public void SetWorldPosition(Vector2 worldPosition)
    {
        _gameObject.transform.position = new Vector3(worldPosition.x, worldPosition.y);
    }
}
