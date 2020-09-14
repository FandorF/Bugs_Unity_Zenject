using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bootstrapper : MonoBehaviour
{
    //[SerializeField] private GameObject _playerObject;
    //[SerializeField] private GameObject _enemyObject;
    //[SerializeField] private Tilemap _tileMap;
    //[SerializeField] private TileBase _tile;
    //[SerializeField] private Camera _myCamera;

    //private UpdateMediator _updateMediator;
    //private IPlayer _player;
    //private MapDynamic _mapDynamic;

    //private void Awake()
    //{
    //    _player = new Player(_playerObject, hp: 5);
    //    var enemy = new Enemy(_enemyObject);

    //    _mapDynamic = new MapDynamic(
    //        new List<IHavePosition> {_player, enemy},
    //        maxRows: 6,
    //        maxCols: 6,
    //        minSizeX: 3,
    //        minSizeY: 3,
    //        cellSize: 2.5f,
    //        _tileMap, _tile
    //    );

    //    var movementController = new MovementController(new List<IMoveable> { _player, enemy }, _mapDynamic);
    //    var myCamera = new MyCamera(_mapDynamic, _myCamera);
    //    var damageController = new DamageController(new List<IHavePosition> {_player, enemy}, _player);
    //    _updateMediator = new UpdateMediator(new List<IUpdatable>  {movementController, damageController, _mapDynamic, myCamera });
    //}

    //private void Update()
    //{
    //    if(_player.Alive)
    //        _updateMediator.Update(Time.deltaTime);
    //}
}
