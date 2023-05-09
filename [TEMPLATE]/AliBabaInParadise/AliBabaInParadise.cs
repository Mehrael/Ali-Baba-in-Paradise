﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class AliBabaInParadise
    {
        #region YOUR CODE IS HERE

        #region FUNCTION#1: Calculate the Value

        //Your Code is Here:
        //==================
        /// <summary>
        /// Given the Camels maximum load and N items, each with its weight and profit 
        /// Calculate the max total profit that can be carried within the given camels' load
        /// </summary>
        /// <param name="camelsLoad">max load that can be carried by camels</param>
        /// <param name="itemsCount">number of items</param>
        /// <param name="weights">weight of each item</param>
        /// <param name="profits">profit of each item</param>
        /// <returns>Max total profit</returns>
        
        private static int[,] ExtraStorage;
        public static int SolveValue(int camelsLoad, int itemsCount, int[] weights, int[] profits)
        {
            //REMOVE THIS LINE BEFORE START CODING
            // throw new NotImplementedException();
            ExtraStorage = new int[itemsCount + 1, camelsLoad + 1];
            for (int i = 1; i <= itemsCount; i++)
                for (int j = 1; j <= camelsLoad; j++)
                {
                    ExtraStorage[i, j] = ExtraStorage[i - 1, j];

                    if (j >= weights[i - 1])
                        ExtraStorage[i, j] = Math.Max(ExtraStorage[i, j], ExtraStorage[i, j - weights[i - 1]] + profits[i - 1]);

                }

            return ExtraStorage[itemsCount, camelsLoad];
        }

        #endregion

        #region FUNCTION#2: Construct the Solution

        //Your Code is Here:
        //==================
        /// <returns>Tuple array of the selected items to get MAX profit (stored in Tuple.Item1) together with the number of instances taken from each item (stored in Tuple.Item2)
        /// OR NULL if no items can be selected</returns>
        public static Tuple<int, int>[] ConstructSolution(int camelsLoad, int itemsCount, int[] weights, int[] profits)
        {
            //REMOVE THIS LINE BEFORE START CODING
            // throw new NotImplementedException();

            List<Tuple<int, int>> solution = new List<Tuple<int, int>>();
            
            int itemIndex = itemsCount, weightIndex = camelsLoad;
            
            while (itemIndex > 0 && weightIndex > 0)
                if (ExtraStorage[itemIndex, weightIndex] != ExtraStorage[itemIndex - 1, weightIndex])
                {
                    solution.Add(new Tuple<int, int>(itemIndex , weights[itemIndex - 1]));
                    weightIndex -= weights[itemIndex - 1];
                }
                else
                    itemIndex--;

            return solution.ToArray();
        }

        #endregion

        #endregion
    }
}