using System.Collections.Generic;

public class DamageController : IUpdatable
{
    private readonly IPlayer _player;
    private readonly IReadOnlyList<IHavePosition> _havePositionObjects;

    public DamageController(List<IHavePosition> havePositionObjects, IPlayer player)
    {
        _havePositionObjects = havePositionObjects;
        _player = player;
    }

    public void Update(float deltaTime)
    {
        foreach (var havePositionObject in _havePositionObjects)
        {
            if (havePositionObject == _player)
                continue;

            if (havePositionObject.WorldPosition == _player.WorldPosition)
                _player.TakeDamage(damage: 1);
        }
    }
}
