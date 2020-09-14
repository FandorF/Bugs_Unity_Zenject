using UnityEngine;

public class Enemy : IEnemy
{
    public Vector2 WorldPosition => _gameObject.transform.position;
    public Vector2 GridPosition { get; private set; }

    private readonly GameObject _gameObject;

    public Enemy(GameObject gameObject)
    {
        _gameObject = gameObject;
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
