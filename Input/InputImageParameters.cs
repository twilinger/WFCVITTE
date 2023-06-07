using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace WaveFunctionCollapse
{

    public class InputImageParameters 
    {
        Vector2Int? bottomRightTileCoords = null;
        Vector2Int? topLeftTileCoords = null;
        BoundsInt inputTileMapBounds;
        TileBase[] inputTilemapTilesArray;
        Queue<TileContainer> stackOfTiles = new Queue<TileContainer>();
        private int width = 0, height = 0;
        private Tilemap inputTilemap;

        public Queue<TileContainer> StackOfTiles { get => stackOfTiles; set => stackOfTiles = value; }
        public int Height { get => height;}
        public int Width { get => width;}
        public InputImageParameters(Tilemap inputTilemap)
        {
            this.inputTilemap = inputTilemap;
            this.inputTileMapBounds = this.inputTilemap.cellBounds;
            this.inputTilemapTilesArray = this.inputTilemap.GetTilesBlock(this.inputTileMapBounds);
            ExtractNonEmptyTiles();
            VerifyInputTiles();
        }

        private void VerifyInputTiles()
        {
            throw new NotImplementedException();
        }

        private void ExtractNonEmptyTiles()
        {
            throw new NotImplementedException();
        }
    }
}
