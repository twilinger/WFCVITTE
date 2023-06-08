using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WaveFunctionCollapse
{

    public class PatternManager
    {
        Dictionary<int, PatternData> patternDataIndexDictionary;
        Dictionary<int, PatternNeighbours> patternPossibleNeighbourDictionary;
        int _patternSize = -1;
        IFindNeighbourStrategy strategy;
        public PatternManager(int patternSize)
        {
            _patternSize = patternSize;
        }
        public void ProcessGrid<T>(ValuesManager<T> valuesManager, bool equalWeights, string strategyName = null)
        {
            NeighbourStrategyFactory strategyFactory = new NeighbourStrategyFactory();
            strategy = strategyFactory.CreateInstance(strategyName == null ? _patternSize + "" : strategyName);
            CreatePatterns(valuesManager, strategy, equalWeights);
        }

        private void CreatePatterns<T>(ValuesManager<T> valuesManager, IFindNeighbourStrategy strategy, bool equalWeights)
        {
            var patternFinderResult = PatternFinder.GetPatternDataFromGrid(valuesManager, _patternSize, equalWeights);
            patternDataIndexDictionary = patternFinderResult.PatternIndexDictionary;
            GetPatternNeighbours(patternFinderResult, strategy);
        }

        private void GetPatternNeighbours(PatternDataResults patternFinderResult, IFindNeighbourStrategy strategy)
        {
            patternPossibleNeighbourDictionary = PatternFinder.FindPossibleNeighboursForAllPatterns(strategy, patternFinderResult);
        }

        public PatternData GetPatternDataFromIndex(int index)
        {
            return patternDataIndexDictionary[index];
        }

        public HashSet<int> GetPOssibleNeighboursForPatternInDirection(int patternIndex, Direction dir)
        {
            return patternPossibleNeighbourDictionary[patternIndex].GetNeighboursInDirection(dir);
        }

        public float GetPatternFrequency(int index)
        {
            return GetPatternDataFromIndex(index).FrequencyRelative;
        }

        public float GetPatternFrequencyLog2(int index)
        {
            return GetPatternDataFromIndex(index).FrequencyRelativeLog2;
        }
        public int GetNumberOfPatterns()
        {
            return patternDataIndexDictionary.Count;
        }
    }
}
