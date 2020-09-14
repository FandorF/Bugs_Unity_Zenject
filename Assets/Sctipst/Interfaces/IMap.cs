using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMap 
{
   int Width { get; }
   int Height { get; }
   int MaxRows { get; }
   int MaxCols { get; }
   float СellSize { get; }
}   
