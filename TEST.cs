using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Tilemaps;
using WaveFunctionCollapse;

public class TEST : MonoBehaviour
{
    public Tilemap input;
    // Start is called before the first frame update
    void Start()
    {
        InputReader reader = new InputReader(input);
        var grid = reader.ReadInputToGrid();
        //for (int row = 0; row < grid.Length; row++)
        //{
        //    for (int col = 0; col < grid[0].Length; col++)
        //    {
        //        Debug.Log("Row: " + row + "Col:" + col + "tile name" + grid[row][col].Value.name);
        //    }
        //}
        ValuesManager<TileBase> valueManager = new ValuesManager<TileBase>(grid);
        PatternManager manager = new PatternManager(2);
        manager.ProcessGrid(valueManager, false);
        foreach( Direction dir in Enum.GetValues(typeof(Direction)))
        {
            Debug.Log(dir.ToString() + " " + string.Join(" ", manager.GetPOssibleNeighboursForPatternInDirection(0, dir).ToArray()));
        }
        //StringBuilder builder = null;
        //List<string> list = new List<string>();
        //for (int row = 0; row < grid.Length; row++)
        //{
        //    builder = new StringBuilder();
        //    for (int col = 0; col < grid[0].Length; col++)
        //    {
        //        builder.Append(valueManager.GetGridValuesIncludingOffset(col, row) + " ");
        //    }
        //    list.Add(builder.ToString());
        //}
        //list.Reverse();
        //foreach (var item in list)
        //{
        //    Debug.Log(item);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
