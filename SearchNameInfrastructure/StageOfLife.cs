using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNameInfrastructure
{
    public static class StageOfLifeCalculate
    {
        public static string Calculate(int age)
        {
            string stageOfLife;
            switch (age)
            {
                case < 7:
                    stageOfLife = "Early Childhood";
                    break;
                case < 14:
                    stageOfLife = "ChildHood";
                    break;
                case < 28:
                    stageOfLife = "Adolescence";
                    break;
                case < 50:
                    stageOfLife = "Youth";
                    break;
                case < 70:
                    stageOfLife = "Maturily";
                    break;
                case >= 70:
                    stageOfLife = "Old Age";
                    break;
                default:
                    stageOfLife = string.Empty;
                    break;
            }
            return stageOfLife;
        }
    }
}
