using FSK_BusinessObjects;
using FSK_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSK_Services
{
    public class CompatibilityService
    {
        private ElementRepo elementRepo;
        private TankRepo tankRepo;

        public enum ErrorCode
        {
            ELEMENT_NOT_EXIST,
            TANK_NOT_FOUND
        }

        public class AppException : Exception
        {
            public ErrorCode ErrorCode { get; private set; }

            public AppException(ErrorCode errorCode) : base($"Error: {errorCode}")
            {
                ErrorCode = errorCode;
            }
        }

        public CompatibilityService(ElementRepo elementRepo, TankRepo tankRepo)
        {
            this.elementRepo = elementRepo;
            this.tankRepo = tankRepo;
        }

        public CompatibilityResponse CompatibilityScore(int elementId, int tankElementId,
                                                        HashSet<HashSet<int>> fishElementIds,
                                                        CompatibilityRequest request)
        {
            var userElement = elementRepo.GetElement(elementId);
            if (userElement == null)
            {
                throw new AppException(ErrorCode.ELEMENT_NOT_EXIST);
            }

            double finalScore;
            double totalFishScore = 0;
            int numFish = fishElementIds.Count;

            foreach (var koiFish in fishElementIds)
            {
                double fishScore = 0;
                int numElements = koiFish.Count;

                foreach (var fishElementId in koiFish)
                {
                    double weight = 1.0 / numElements;
                    double score = CalculateElementScore(userElement, fishElementId);

                    fishScore += score * weight;
                }

                totalFishScore += fishScore;
            }

            double averageFishScore = totalFishScore / numFish;
            double finalFishScore = (averageFishScore / 50) * 100;

            double tankScore = CalculateElementScore(userElement, tankElementId);

            finalScore = tankScore < 0
                ? (averageFishScore * 0.8) + (tankScore * 0.2)
                : (averageFishScore * 0.5) + (tankScore * 0.5);

            double finalTankScore = TankCompatibilityScore(elementId, tankElementId);

            return new CompatibilityResponse(
                Math.Clamp(finalFishScore, 0, 100),
                finalTankScore,
                Math.Clamp(finalScore, 0, 100)
            );
        }

        private double CalculateElementScore(Element userElement, int elementId)
        {
            if (userElement.ElementId == elementId)
            {
                return 50;
            }
            else if (userElement.Generation == elementId.ToString())  // Assuming Generation is stored as a string
            {
                return 50;
            }
            else if (userElement.Inhibition == elementId.ToString())  // Assuming Inhibition is stored as a string
            {
                return -50;
            }
            else
            {
                return 25;
            }
        }

        public double TankCompatibilityScore(int elementId, int tankElementId)
        {
            var userElement = elementRepo.GetElement(elementId);
            if (userElement == null)
            {
                throw new AppException(ErrorCode.ELEMENT_NOT_EXIST);
            }

            if (userElement.ElementId == tankElementId)
            {
                return 100;
            }
            else if (userElement.Generation == tankElementId.ToString())  // Assuming Generation is stored as a string
            {
                return 100;
            }
            else if (userElement.Inhibition == tankElementId.ToString())  // Assuming Inhibition is stored as a string
            {
                return 0;
            }
            else
            {
                return 50;
            }
        }
    }
}
