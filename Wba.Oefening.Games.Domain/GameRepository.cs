using System.Collections.Generic;
using System.Linq;

namespace Wba.Oefening.Games.Domain
{
    public class GameRepository
    {
        public IEnumerable<Game> GetGames()
        {
            DeveloperRepository developerRepository = new DeveloperRepository();
            return new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Title = "Wolfenstein Colossus",
                    Developer = 
                        developerRepository.GetDevelopers().
                            First(d => d.Id == 1)
                },
                new Game
                {
                    Id = 1,
                    Title ="FIFA 2020",
                    Developer =
                        developerRepository.GetDevelopers().
                            First(d => d.Id == 2)
                },
                new Game
                {
                    Id = 1,
                    Title ="Elder Scrolls V: Skyrim",
                    Developer =
                        developerRepository.GetDevelopers().
                            First(d => d.Id == 3)
                }
            };
        }
    }
}
