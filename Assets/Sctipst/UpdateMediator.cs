using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpdateMediator  : ITickable
{
    private float _timer;
    private const float Delay = 0.5f;
    private readonly List<IUpdatable> _updatableObjects;

    public UpdateMediator(List<IUpdatable> updatableObjects)
    {
        _updatableObjects = updatableObjects;
        _timer = Delay;
    }

    private void Update(float deltaTime)
    {
        if(_timer <= 0)
        {
            _timer = Delay;
            foreach (var updatableObject in _updatableObjects)
            {
                updatableObject?.Update(deltaTime);
            }
        }
        _timer -= deltaTime;
    }

    public void Tick()
    {
        Update(Time.deltaTime);
    }
}
