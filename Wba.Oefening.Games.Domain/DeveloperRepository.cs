using System.Collections.Generic;

namespace Wba.Oefening.Games.Domain
{
    public class DeveloperRepository
    {
        public IEnumerable<Developer> GetDevelopers()
        {
            return new List<Developer>
            {
                new Developer{DeveloperId = 1,DeveloperName = "Ubisoft" },
                new Developer{DeveloperId = 2,DeveloperName = "EA" },
                new Developer{DeveloperId = 3,DeveloperName = "Bethesda" }
            };
        }
    }
}
