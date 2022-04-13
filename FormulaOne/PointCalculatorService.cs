using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne
{
    public class PointCalculatorService : IPointCalculatorService
    {
        /// <summary>
        /// Bereken punten voor één race:
        /// Winnaar: 25 punten
        /// Tweede: 18 punten
        /// Derde: 15 punten
        /// Vierde: 12 punten
        /// Vijfde: 10 punten
        /// Zesde: 8 punten
        /// Zevende: 6 punten
        /// Achtste: 4 punten
        /// Negende: 2 punten
        /// Tiende: 1 punt
        /// De rest krijgt 0 punten. Degene met de snelste rondetijd krijgt 1 punt erbij.
        /// </summary>
        /// <param name="position">De finish positie (winnaar is 1, tweede is 2 etc.)</param>
        /// <param name="fastestLap">Geeft aan of degene op deze positie wel/niet de snelste rondetijd had</param>
        /// <returns></returns>
        public int CalculatePoints(int position, bool fastestLap)
        {
            if (position < 1)
            {
                throw new ArgumentOutOfRangeException("positie ongeldig");
            }
            int points;
            switch (position)
            {
                case 1: points = 25; break;
                case 2: points = 18; break;
                case 3: points = 15; break;
                case 4: points = 12; break;
                case 5: points = 10; break;
                case 6: points = 8; break;
                case 7: points = 6; break;
                case 8: points = 4; break;
                case 9: points = 2; break;
                case 10: points = 1; break;
                default: points = 0; break;
            }
            if (fastestLap)
            {
                points++;
            }
            return points;
        }
    }
}
