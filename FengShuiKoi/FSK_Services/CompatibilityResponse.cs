using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class CompatibilityResponse
    {
        public double FishCompatibilityScore { get; set; }
        public double TankCompatibilityScore { get; set; }
        public double CalculateCompatibilityScore { get; set; }

        public CompatibilityResponse(double fishCompatibilityScore, double tankCompatibilityScore, double calculateCompatibilityScore)
        {
            FishCompatibilityScore = fishCompatibilityScore;
            TankCompatibilityScore = tankCompatibilityScore;
            CalculateCompatibilityScore = calculateCompatibilityScore;
        }
    }
}
