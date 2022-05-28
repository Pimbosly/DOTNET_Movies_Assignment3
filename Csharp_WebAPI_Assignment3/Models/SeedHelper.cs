namespace Csharp_WebAPI_Assignment3.Models
{
    public class SeedHelper
    {
        public static IEnumerable<Movie> GetMovieSeeds()
        {
            var movie = new List<Movie>()
            {
                new Movie(){
                Id = 1,
                Title = "Batman",
                Genre = "Action",
                ReleaseYear = new DateTime(2003, 5, 1),
                Director = "batman director",
                Picture = "www.batmanpicture.com",
                Trailer = "www.batmantrailer.com",
                CharacterId = 3,
                FranchiseId = 1
                },
                new Movie(){
                Id = 2,
                Title = "Superman",
                Genre = "Action",
                ReleaseYear = new DateTime(2002, 6, 12),
                Director = "superman director",
                Picture = "www.supermanpicture.com",
                Trailer = "www.supermantrailer.com",
                CharacterId = 2,
                FranchiseId = 2
                },
                new Movie(){
                Id = 3,
                Title = "Sherlock Holmes",
                Genre = "Detective, Action",
                ReleaseYear = new DateTime(2010, 3, 2),
                Director = "holmes director",
                Picture = "www.holmespicture.com",
                Trailer = "www.holmestrailer.com",
                CharacterId = 1,
                FranchiseId = 3
                },
                new Movie(){
                Id = 4,
                Title = "IT",
                Genre = "Horror",
                ReleaseYear = new DateTime(2012, 1, 21),
                Director = "IT director",
                Picture = "www.itpicture.com",
                Trailer = "www.ittrailer.com",
                CharacterId = 2,
                FranchiseId = 3
                },
                new Movie(){
                Id = 5,
                Title = "Stardust",
                Genre = "Fantasy, Adventure",
                ReleaseYear = new DateTime(2009, 8, 1),
                Director = "stardust director",
                Picture = "www.stardustpicture.com",
                Trailer = "www.stardusttrailer.com",
                CharacterId = 1,
                FranchiseId = 2
                }
            };
            return movie;
        }

        public static IEnumerable<Character> GetCharacterSeeds()
        {
            IEnumerable<Character> characters = new List<Character>()
            {
                new Character()
                {
                    Id = 1,
                    FullName = "Pim Westervoort",
                    Alias = "The Pim",
                    Gender = "Male",
                    Picture = "www.picturepim.com"
                },
                new Character()
                {
                    Id = 2,
                    FullName = "Warren West",
                    Alias = "Master of .NET",
                    Gender = "Male",
                    Picture = "www.picturewarren.com"
                },
                new Character()
                {
                    Id = 3,
                    FullName = "Dewald Els",
                    Alias = "Master of Javascript",
                    Gender = "Male",
                    Picture = "www.picturedewald.com"
                }
            };

            return characters;
        }
    
        public static IEnumerable<Franchise> GetFranchiseSeeds()
        {
            IEnumerable<Franchise> Franchises = new List<Franchise>()
            {
                new Franchise()
                {
                    Id = 1,
                    Name = "Batman Trilogy",
                    Description = "Movies about a superhero in a batcostume"
                },
                new Franchise()
                {
                    Id = 2,
                    Name = "Superman Trilogy",
                    Description = "Movies about a flying superhero in a cape"
                },
                new Franchise()
                {
                    Id = 3,
                    Name = "Holmes",
                    Description = "Movies about a detective solving mysteries"
                }
            };
            return Franchises;
        }
    }
}
