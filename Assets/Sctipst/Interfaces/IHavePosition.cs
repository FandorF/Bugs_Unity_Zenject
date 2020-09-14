using UnityEngine;

public interface IHavePosition 
{
    Vector2 WorldPosition { get; }
    Vector2 GridPosition { get; }
}

