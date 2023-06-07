using Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace WaveFunctionCollapse
{
    public class InputReader : IInputReader<TileBase>
    {
        private Tilemap _inputTilemap;
        public InputReader(Tilemap input)
        {
            _inputTilemap = input;
        }
        public IValue<TileBase>[][] ReadInputToGrid()
        {
            var grid = ReadInputTilemap();

            TileBaseValue[][] gridOfValues = null;
            if(grid != null)
            {
                gridOfValues = MyCollectionExtension.CreateJaggedArray<TileBaseValue[][]>(grid.Length, grid[0].Length);
                for(int row = 0; row < grid.Length; row++)
                {
                    for (int col = 0; col < grid[0].Length; col++)
                    {
                        gridOfValues[row][col] = new TileBaseValue(grid[row][col]);
                    }
                }
            }
            return gridOfValues;
        }

        private TileBase[][] ReadInputTilemap()
        {
            InputImageParameters imageParameters = new InputImageParameters(_inputTilemap);
            return CreateTileBaseGrid(imageParameters);
        }

        private TileBase[][] CreateTileBaseGrid(InputImageParameters imageParameters)
        {
            throw new NotImplementedException();
        }
    }
}
