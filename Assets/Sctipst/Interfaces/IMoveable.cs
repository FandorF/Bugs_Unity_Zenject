using UnityEngine;

public interface IMoveable  : IHavePosition
{
  void SetGridPosition(Vector2 position);
  void SetWorldPosition(Vector2 position);
}
