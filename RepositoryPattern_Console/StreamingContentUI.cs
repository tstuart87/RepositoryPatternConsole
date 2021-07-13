using RepositoryPattern_Console.Consoles;
using RepositoryPattern_Repository;
using RepositoryPattern_Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Console
{
    public class StreamingContentUI
    {
        private bool _isRunning = true;
        private ICustomConsole _console;

        private readonly IStreamingContentRepository _contentRepo = new StreamingContentRepository();
        private readonly IActorRepository _actorRepo = new ActorRepository();

        public StreamingContentUI(ICustomConsole console)
        {
            _console = console;
        }

        public void Start()
        {
            Seed();
            RunMenu();
        }

        private void RunMenu()
        {
            while (_isRunning)
            {
                string userInput = GetMenuSelection();
                OpenMenuItem(userInput);
            }
        }

        private string GetMenuSelection()
        {
            _console.Clear();
            _console.PrintMainMenu();

            string userInput = _console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            _console.Clear();

            switch (userInput)
            {
                case "1":
                    //show all content
                    DisplayAllContent();
                    break;
                case "2":
                    //find streaming content
                    DisplayContentByTitle();
                    break;
                case "3":
                    //add new streaming content
                    CreateNewContent();
                    break;
                case "4":
                    //show all cast members
                    DisplayAllActors();
                    break;
                case "5":
                    //add new cast member
                    CreateNewActor();
                    break;
                case "6":
                    //add existing cast member to streaming content
                    AddActorToStreamingContent();
                    break;
                case "7":
                    //exit
                    _isRunning = false;
                    break;
                default:
                    _console.InvalidSelectionPressAnyKeyToReturnToMainMenu();
                    _console.ReadKey();
                    RunMenu();
                    break;
            }
        }

        private void DisplayAllContent()
        {
            _console.Clear();
            List<StreamingContent> listOfContent = _contentRepo.GetAllStreamingContent();

            foreach (var content in listOfContent)
            {
                _console.DisplayStreamingContent(content);
            }

            _console.PressAnyKeyToReturnToMainMenu();
            _console.ReadKey();
        }

        private void DisplayContentByTitle()
        {
            _console.Clear();
            _console.EnterATitle();
            string title = _console.ReadLine();

            List<StreamingContent> listOfContent = _contentRepo.GetContentByTitleSearch(title);

            if (listOfContent != null)
            {
                foreach (var content in listOfContent)
                {
                    if (content.CastMemberIds.Any())
                    {
                        List<Actor> castMembers = new List<Actor>();
                        foreach (int id in content.CastMemberIds)
                        {
                            castMembers.Add(_actorRepo.GetActorById(id));
                        }

                        _console.DisplayStreamingContentWithCharacter(content, castMembers);

                    }
                    else
                    {
                        _console.DisplayStreamingContent(content);
                    }
                }
            }
        }

        private void CreateNewContent()
        {
            _console.Clear();
            _console.EnterATitle();
            string title = _console.ReadLine();

            _console.EnterADescription();
            string description = _console.ReadLine();

            _console.EnterTheReleaseYear();
            int releaseYear = int.Parse(_console.ReadLine());

            _console.SelectAGenre();
            GenreType genre = GetGenreType();

            _console.EnterAStarRating();
            double starRating = double.Parse(_console.ReadLine());

            _console.SelectAMaturityRating();
            MaturityRating ageRating = GetAgeRating();

            StreamingContent content = new StreamingContent(title, description, ageRating, starRating, releaseYear, genre);

            if (_contentRepo.AddContentToDirectory(content))
            {
                _console.PressAnyKeyToReturnToMainMenu();
                _console.ReadKey();
            }
            else
            {
                _console.InvalidSelectionPressAnyKeyToReturnToMainMenu();
                _console.ReadKey();
            }
        }

        private void DisplayAllActors()
        {
            _console.Clear();
            List<Actor> listOfActors = _actorRepo.GetAllActors();

            foreach(var actor in listOfActors)
            {
                _console.DisplayActor(actor);
            }

            _console.PressAnyKeyToReturnToMainMenu();
            _console.ReadKey();
        }

        private void CreateNewActor()
        {
            _console.Clear();
            int id = _actorRepo.GetAllActors().Count + 1;

            _console.EnterFirstName();
            string firstName = _console.ReadLine();

            _console.EnterLastName();
            string lastName = _console.ReadLine();

            _console.EnterNationality();
            string nationality = _console.ReadLine();

            _console.EnterBiography();
            string biography = _console.ReadLine();

            _console.EnterBirthMonth();
            int monthNum = int.Parse(_console.ReadLine());
            Month birthMonth = (Month)monthNum;

            _console.EnterBirthDay();
            int birthDay = int.Parse(_console.ReadLine());

            _console.EnterBirthYear();
            int birthYear = int.Parse(_console.ReadLine());

            Actor actor = new Actor(id, firstName, lastName, nationality, biography, birthYear, birthMonth, birthDay);

            if (_actorRepo.AddActorToDirectory(actor))
            {
                _console.PressAnyKeyToReturnToMainMenu();
                _console.ReadKey();
            }
            else
            {
                _console.InvalidSelectionPressAnyKeyToReturnToMainMenu();
                _console.ReadKey();
            }
        }

        private void AddActorToStreamingContent()
        {
            _console.Clear();
            _console.EnterATitle();

            StreamingContent content = _contentRepo.GetContentByTitle(_console.ReadLine());

            if(content != null)
            {
                List<Actor> listOfActors = _actorRepo.GetAllActors();
                foreach(var actor in listOfActors)
                {
                    _console.DisplayActor(actor);
                }

                _console.EnterActorId();
                int id = int.Parse(_console.ReadLine());

                content.CastMemberIds.Append(id);

                _console.PressAnyKeyToReturnToMainMenu();
                _console.ReadKey();
                RunMenu();
            }

            _console.InvalidSelectionPressAnyKeyToReturnToMainMenu();
            _console.ReadKey();
            RunMenu();
        }

        private GenreType GetGenreType()
        {
            while (true)
            {
                switch (_console.ReadLine())
                {
                    case "1":
                        return GenreType.Thriller;
                    case "2":
                        return GenreType.SciFi;
                    case "3":
                        return GenreType.Action;
                    case "4":
                        return GenreType.Drama;
                    case "5":
                        return GenreType.Horror;
                    case "6":
                        return GenreType.Mystery;
                    case "7":
                        return GenreType.Romance;
                    case "8":
                        return GenreType.RomCom;
                    case "9":
                        return GenreType.Comedy;
                    case "10":
                        return GenreType.Documentary;
                    case "11":
                        return GenreType.Western;
                    default:
                        _console.InvalidSelectionPressAnyKeyToReturnToMainMenu();
                        _console.ReadKey();
                        RunMenu();
                        break;
                }
            }
        }

        private MaturityRating GetAgeRating()
        {
            while (true)
            {
                switch (_console.ReadLine())
                {
                    case "1":
                        return MaturityRating.G;
                    case "2":
                        return MaturityRating.PG;
                    case "3":
                        return MaturityRating.PG13;
                    case "4":
                        return MaturityRating.R;
                    case "5":
                        return MaturityRating.NC17;
                    default:
                        _console.InvalidSelectionPressAnyKeyToReturnToMainMenu();
                        _console.ReadKey();
                        RunMenu();
                        break;
                }
            }
        }

        public void Seed()
        {
            Actor jimCarrey = new Actor(1, "Jim", "Carrey", "Canadian", "Famous for his physical brand of comedy.", 1962, Month.Jan, 17);
            Actor bruceWillis = new Actor(2, "Bruce", "Willis", "American", "Famous for being cool and bald.", 1955, Month.Mar, 19);
            Actor jodieFoster = new Actor(3, "Jodie", "Foster", "American", "The only one in the Seed method that can actually act.", 1962, Month.Nov, 19);

            _actorRepo.AddActorToDirectory(jimCarrey);
            _actorRepo.AddActorToDirectory(bruceWillis);
            _actorRepo.AddActorToDirectory(jodieFoster);

            StreamingContent dumbAndDumber = new StreamingContent("Dumb and Dumber", "For Harry and Lloyd, everyday is a no-brainer.", MaturityRating.PG13, 7.3, 1994, GenreType.Comedy, new List<int?> { 1 });
            StreamingContent dieHard = new StreamingContent("Die Hard", "The best Die Hard movie.", MaturityRating.R, 8.2, 1988, GenreType.Action, new List<int?> { 2 });
            StreamingContent silenceOfLambs = new StreamingContent("The Silence of the Lambs", "Hello, Clarice.", MaturityRating.R, 8.6, 1991, GenreType.Horror, new List<int?> { 3 });

            _contentRepo.AddContentToDirectory(dumbAndDumber);
            _contentRepo.AddContentToDirectory(dieHard);
            _contentRepo.AddContentToDirectory(silenceOfLambs);
        }
    }
}
