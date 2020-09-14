using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.Tilemaps;

public class GameInstaller : MonoInstaller
{
    
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private Tilemap _tileMap;
    [SerializeField] private TileBase _tile;
    [SerializeField] private Camera _myCamera;

    [SerializeField] private MapData _mapData;

    public override void InstallBindings()
    {
        Container.BindInstance(_tile);
        Container.BindInstance(_tileMap);

       // Container.Bind<MapData>().AsSingle();

        Container.BindInterfacesTo<Player>().AsSingle().WithArguments(_playerObject, 5);
        Container.BindInterfacesTo<Enemy>().AsSingle().WithArguments(_enemyObject);

        //Container.BindInterfacesTo<MapDynamic>().AsSingle().WithArguments(_mapData);

        Container.BindInterfacesTo<MyCamera>().AsSingle().WithArguments(_myCamera);

        Container.BindInterfacesTo<DamageController>().AsSingle();
        Container.BindInterfacesTo<MovementController>().AsSingle();

        Container.BindInterfacesTo<UpdateMediator>().AsSingle().NonLazy();
    }
}
