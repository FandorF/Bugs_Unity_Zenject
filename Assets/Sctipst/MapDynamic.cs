using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Linq;
using Random = UnityEngine.Random;

public class MapDynamic : IMap, IUpdatable
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int MaxRows { get; private set; }
    public int MaxCols { get; private set; }
    public float СellSize { get; private set; }

    private readonly Tilemap _tilemap;
    private readonly TileBase _tile;

    private readonly IReadOnlyList<IHavePosition> _havePositions;

    private readonly int _minSizeX;
    private readonly int _minSizeY;

    public MapDynamic(List<IHavePosition> havePositions, Tilemap tilemap, TileBase tile, MapSettings mapData)
    {
        _tilemap = tilemap;
        _tile = tile;
        
        MaxRows = mapData.MaxRows;
        MaxCols = mapData.MaxCols;
        _minSizeX = mapData.MinRows;
        _minSizeY = mapData.MinCols;

        СellSize = mapData.CellSize;
        
        GenerateMap((MaxRows, MaxCols));

        _havePositions = havePositions;
    }

    private void GenerateMap((int, int) nextSize)
    {
        var grid = _tilemap.layoutGrid;
        grid.cellSize = new Vector3(СellSize, СellSize, 0);

        var nextValueX = nextSize.Item1;
        var nextValueY = nextSize.Item2;

        var deltaX = nextValueX - Width;
        var deltaY = nextValueY - Height;

        if (deltaX > 0)
        {
            for (int x = Width; x < nextValueX; x++)
            {
                for (int y = 0; y < MaxCols; y++)
                {
                    _tilemap.SetTile(new Vector3Int(x, y, 0), y < nextValueY ? _tile : null);
                }
            }
        }
        else if (deltaX < 0)
        {
            for (int x = Width - 1; x >= nextValueX; x--)
            {
                for (int y = 0; y < MaxCols; y++)
                {
                    _tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }

        if (deltaY > 0)
        {
            for (int y = Height; y < nextValueY; y++)
            {
                for (int x = 0; x < MaxRows; x++)
                {
                    _tilemap.SetTile(new Vector3Int(x, y, 0), x < nextValueX ? _tile : null);
                }
            }
        }
        else if (deltaY < 0)
        {
            for (int y = Height -1; y >= nextValueY; y--)
            {
                for (int x = 0; x < MaxCols; x++)
                {
                    _tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
        
        Width = nextValueX;
        Height = nextValueY;
    }

    public void Update(float deltaTime)
    {
        var sizeRandom = RandomSize();
        GenerateMap(sizeRandom);
    }

    private (int, int) RandomSize()
    {
        var minRows = Math.Max(_minSizeX, (int) _havePositions.Max(h => h.GridPosition.x)+1);
        var minCols = Math.Max(_minSizeY, (int) _havePositions.Max(h => h.GridPosition.y)+1);

        var x = Random.Range(min: minRows, max: MaxRows);
        var y = Random.Range(min: minCols, max: MaxCols);

        return (x, y);
    }
}
