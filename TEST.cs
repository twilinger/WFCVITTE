using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using WaveFunctionCollapse;

public class TEST : MonoBehaviour
{
    public Tilemap inputTilemap;
    public Tilemap outputTilemap;
    public int patternSize;
    public int maxIteration = 500;
    public int outputWidth = 5;
    public int outputHeight = 5;
    public bool equalWeights = false;
    ValuesManager<TileBase> valueManager;
    WFCCore core;
    PatternManager manager;
    TileMapOutput output;
    void Start()
    {
        CreateWFC();


    }

    public void CreateWFC()
    {
        InputReader reader = new InputReader(inputTilemap);
        var grid = reader.ReadInputToGrid();
        valueManager = new ValuesManager<TileBase>(grid);
        manager = new PatternManager(patternSize);
        manager.ProcessGrid(valueManager, equalWeights);
        core = new WFCCore(5, 5, 500, manager);

    }

    public void CreateTilemap()
    {
        TileMapOutput output = new TileMapOutput(valueManager, outputTilemap);
        var result = core.CreateOputputGrid();
        output.CreateOutput(manager, result, outputWidth, outputHeight);
    }

    public void SaveTilemap()
    {
            //outputTilemap = output.OutputImage;
            GameObject objectToSave = outputTilemap.gameObject;
            PrefabUtility.SaveAsPrefabAsset(objectToSave,"Assets/TILESETWFC/OUTPUTTILEMAPS/outTilemap.prefab");
    }
}
