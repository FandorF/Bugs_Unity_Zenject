using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "MapSettings", menuName = "Map Settings")]
public class MapSettings : ScriptableObject
{
    public int MaxRows;
    public int MaxCols;
    public int MinRows;
    public int MinCols;
    public float CellSize;
}
