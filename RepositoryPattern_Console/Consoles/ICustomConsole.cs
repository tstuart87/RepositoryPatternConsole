using RepositoryPattern_Repository;
using RepositoryPattern_Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Console.Consoles
{
    public interface ICustomConsole
    {
        void DisplayStreamingContent(StreamingContent content);
        void DisplayStreamingContentWithCharacter(StreamingContent content, List<Actor> castMembers);
        void DisplayActor(Actor actor);

        void Clear();
        ConsoleKeyInfo ReadKey();
        string ReadLine();

        void PrintMainMenu();
        void InvalidSelectionPressAnyKeyToReturnToMainMenu();
        void PressAnyKeyToReturnToMainMenu();

        void EnterATitle();
        void EnterADescription();
        void EnterTheReleaseYear();
        void SelectAGenre();
        void EnterAStarRating();
        void SelectAMaturityRating();

        void EnterFirstName();
        void EnterLastName();
        void EnterNationality();
        void EnterBiography();
        void EnterBirthMonth();
        void EnterBirthDay();
        void EnterBirthYear();

        void EnterActorId();
    }
}
