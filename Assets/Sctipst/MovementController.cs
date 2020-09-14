using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MovementController : IUpdatable
{
    private readonly IMap _map;
    private readonly IReadOnlyList<IMoveable> _moveableObjects;
    private readonly Vector2[] _offsets =
    {
       new Vector2(0,1),
       new Vector2(0,-1),
       new Vector2(1,0),
       new Vector2(-1,0)      
    };                 

    public MovementController(List<IMoveable> moveableObjects, IMap map)
    {
        _moveableObjects = moveableObjects;
        _map = map;
    }
    
    public void Update(float deltaTime)
    {
        foreach (var moveableObject in _moveableObjects)
        {
            var newPositionOnGrid = GetNewRandomPos(moveableObject);
            moveableObject.SetGridPosition(newPositionOnGrid);
            var worldPosition = new Vector2(newPositionOnGrid.x * _map.СellSize + _map.СellSize / 2,  newPositionOnGrid.y * _map.СellSize + _map.СellSize / 2);
            moveableObject.SetWorldPosition(worldPosition);
        }
    }

    private Vector2 GetNewRandomPos(IMoveable moveableObject)
    {
        while (true)
        {
            var randomOffsets = _offsets[Random.Range(min:0, max:_offsets.Length)];
            var newRandomPosition = moveableObject.GridPosition + randomOffsets;

            if (newRandomPosition.x < _map.Width && newRandomPosition.x >= 0 && newRandomPosition.y < _map.Height && newRandomPosition.y >= 0)
                return newRandomPosition;
        }
    }
}
