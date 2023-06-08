using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WaveFunctionCollapse;

public class PatternFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal static PatternDataResults GetPatternDataFromGrid<T>(ValuesManager<T> valuesManager, int patternSize, bool equalWeights)
    {
        throw new NotImplementedException();
    }

    internal static Dictionary<int, PatternNeighbours> FindPossibleNeighboursForAllPatterns(IFindNeighbourStrategy strategy, PatternDataResults patternFinderResult)
    {
        throw new NotImplementedException();
    }
}
