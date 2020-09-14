using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : IMap
{
    public int Width => MaxRows;
    public int Height => MaxCols;
    public int MaxRows { get; private set; }
    public int MaxCols { get; private set; }
    public float СellSize { get; private set; }

    public Map(int rows, int cols, float cellSize)
    {
        MaxRows = rows;
        MaxCols = cols;
        СellSize = cellSize;
    }
  
    public void GenerateMap(Tilemap tilemap, TileBase tile)
    {
        var grid = tilemap.layoutGrid;
        grid.cellSize = new Vector3(СellSize, СellSize, 0);

        for (int row = 0; row < MaxRows; row++)
        {
           for (int col = 0; col < MaxCols; col++)
           {
              tilemap.SetTile(new Vector3Int(row, col, 0), tile);
           }
        }
    }
}
