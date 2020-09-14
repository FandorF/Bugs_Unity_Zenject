using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : IUpdatable
{
    private readonly IMap _map;
    private readonly Camera _myCamera;

    public MyCamera(IMap map, Camera myCamera)
    {
        _map = map;
        _myCamera = myCamera;

        _myCamera.transform.position = new Vector3(_map.MaxRows + _map.СellSize / 2, _map.MaxCols + _map.СellSize / 2);
    }

    public void Update(float deltaTime)
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        _myCamera.transform.position = new Vector3(
            _map.Width + _map.СellSize/2,
            _map.Height + _map.СellSize/2,
            _map.Height * -(_map.СellSize / 2) + _map.Height * -(_map.СellSize / 2) 
        );
    }
}
