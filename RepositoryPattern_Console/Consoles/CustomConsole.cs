using RepositoryPattern_Repository;
using RepositoryPattern_Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Console.Consoles
{
    public class CustomConsole : ICustomConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayActor(Actor actor)
        {
            Console.WriteLine($"Name: {actor.FirstName} {actor.LastName} ID:{actor.Id}\n" +
                $"Biography: {actor.Biography}\n" +
                $"Nationality: {actor.Nationality}\n" +
                $"Age: {actor.Age} born {actor.BirthMonth} {actor.BirthDay}, {actor.BirthYear}\n");
        }

        public void DisplayStreamingContent(StreamingContent content)
        {
            Console.WriteLine($"Title: {content.Title}\n" +
                                $"Description: {content.Description}\n" +
                                $"Release Year: {content.ReleaseYear}\n" +
                                $"Genre: {content.Genre}\n" +
                                $"Stars: {content.StarRating}\n" +
                                $"Maturity Rating: {content.AgeRating}\n");
        }

        public void DisplayStreamingContentWithCharacter(StreamingContent content, List<Actor> castMembers)
        {
            DisplayStreamingContent(content);

            Console.WriteLine("Starring: ");

            foreach(var actor in castMembers)
            {
                DisplayActor(actor);
            }
        }

        public void EnterActorId()
        {
            Console.Write("Enter Actor ID to add to Streaming Content: ");
        }

        public void EnterADescription()
        {
            Console.WriteLine("Enter a description: ");
        }

        public void EnterAStarRating()
        {
            Console.Write("Enter a Star Rating (0-10): ");
        }

        public void EnterATitle()
        {
            Console.Write("Enter a title: ");
        }

        public void EnterBiography()
        {
            Console.Write("Enter a short biography: ");
        }

        public void EnterBirthDay()
        {
            Console.Write("Enter Day of Birth (1-31): ");
        }

        public void EnterBirthMonth()
        {
            Console.Write("Enter Month of Birth (1-12): ");
        }

        public void EnterBirthYear()
        {
            Console.Write("Enter Year of Birth (YYYY): ");
        }

        public void EnterFirstName()
        {
            Console.Write("Enter First Name: ");
        }

        public void EnterLastName()
        {
            Console.Write("Enter Last Name: ");
        }

        public void EnterNationality()
        {
            Console.Write("Enter Nationality: ");
        }

        public void EnterTheReleaseYear()
        {
            Console.Write("Enter Release Year (YYYY): ");
        }

        public void InvalidSelectionPressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Invalid. Press any key to return to Main Menu.");
        }

        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
        }

        public void PrintMainMenu()
        {
            Console.WriteLine($"Welcome to the Streaming Content Management System.\n" +
                $"Select Menu Item:\n" +
                $"1. Show all Streaming Content\n" +
                $"2. Find Streaming Content\n" +
                $"3. Add New Streaming Content\n" +
                $"4. Show all Actors and Actresses\n" +
                $"5. Add New Actor or Actress\n" +
                $"6. Add Existing Actor or Actress to Streaming Content\n" +
                $"7. Exit\n");
        }

        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void SelectAGenre()
        {
            Console.WriteLine("Select a Genre:\n" +
                            "1. Thriller\n" +
                            "2. Scifi\n" +
                            "3. Action\n" +
                            "4. Drama\n" +
                            "5. Horror\n" +
                            "6. Mystery\n" +
                            "7. Romance\n" +
                            "8. RomCom\n" +
                            "9. Comedy\n" +
                            "10. Documentary\n" +
                            "11. Western");

            Console.Write("Enter Corresponding Number: ");
        }

        public void SelectAMaturityRating()
        {
            Console.WriteLine("Select a Maturity Rating:\n" +
                            "1. G\n" +
                            "2. PG\n" +
                            "3. PG-13\n" +
                            "4. R\n" +
                            "5. NC17");

            Console.Write("Enter Corresponding Number: ");
        }
    }
}
