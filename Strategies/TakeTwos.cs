﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameSimulator.Strategies
{
    public class TakeTwos : IDiceStrategy
    {
        public string Name { get; set; }
        public int DiceLeft1 { get; set; }
        public int DiceLeft2 { get; set; }

        public TakeTwos(string name, int diceLeft1, int diceLeft2)
        {
            Name = name;
            DiceLeft1 = diceLeft1;
            DiceLeft1 = diceLeft2;
        }

        public IEnumerable<int> ChooseDice(IEnumerable<int> givenDice)
        {
            var diceToKeep = new List<int>();
            var givenDiceList = givenDice.ToList();

            foreach (var dice in givenDiceList)
            {
                if (dice < 2 && givenDiceList.Count <= DiceLeft1)
                {
                    diceToKeep.Add(dice);
                } else if (dice < 3 && givenDiceList.Count <= DiceLeft2)
                {
                    diceToKeep.Add(dice);
                }
            }

            if (diceToKeep.Count == 0)
            {
                diceToKeep.Add(givenDice.Min());
            }

            return diceToKeep;
        }
    }
}
