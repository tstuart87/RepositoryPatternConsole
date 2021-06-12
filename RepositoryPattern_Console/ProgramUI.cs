using RepositoryPattern_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Console
{
    public class ProgramUI
    {
        private bool _isRunning = true;

        //newing up an instance of StreamingContentRepository Class so I can get to my CRUD methods.
        private readonly StreamingContentRepository _repo = new StreamingContentRepository();

        public void Start()
        {
            //Seeds data into our app.
            SeedContentList();

            //Run Menu method
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
            Console.Clear();
            Console.WriteLine("Welcome to the Streaming Content Management System.\n" +
                            "Select Menu Item:\n" +
                            "1. Show All Streaming Content\n" +
                            "2. Find Streaming Content by title\n" +
                            "3. Add New Streaming Content\n" +
                            "4. Update Existing Content Description\n" +
                            "5. Remove Streaming Content\n" +
                            "6. Exit\n");

            string userInput = Console.ReadLine();
            return userInput;
        }

        private void OpenMenuItem(string userInput)
        {
            Console.Clear();

            switch (userInput)
            {
                case "1":
                    //Show all content
                    DisplayAllContent();
                    break;
                case "2":
                    //Display content by title
                case "3":
                    //Add new content
                case "4":
                    //Update content description
                case "5":
                    //Remove content
                case "6":
                    //Exit
                    _isRunning = false;
                    return;
                default:
                    Console.WriteLine("Invalid Selection. Press any key to return to main menu.");
                    GetMenuSelection();
                    return;
            }

        }

        private void DisplayAllContent()
        {
            List<StreamingContent> listOfContent = _repo.GetAllStreamingContent();

            foreach (StreamingContent content in listOfContent)
            {
                Console.WriteLine($"Title: {content.Title}\n" +
                                $"Description: {content.Description}\n" +
                                $"Release Year: {content.ReleaseYear}\n" +
                                $"Genre: {content.Genre}\n" +
                                $"Stars: {content.StarRating}\n" +
                                $"Maturity Rating: {content.AgeRating}\n");
            }

            PressAnyKeyToReturnToMainMenu();
        }


        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            RunMenu();
        }

        //Seed Content
        private void SeedContentList()
        {
            StreamingContent jaws = new StreamingContent("Jaws", "Scary shark movie", MaturityRating.PG, 8.0, 1975, GenreType.Thriller);
            StreamingContent dieHard = new StreamingContent("Die Hard", "The best Die Hard movie", MaturityRating.R, 8.2, 1988, GenreType.Action);
            StreamingContent silenceOfLambs = new StreamingContent("The Silence of the Lambs", "Hello, Clarice", MaturityRating.R, 8.6, 1991, GenreType.Horror);

            _repo.AddContentToDirectory(jaws);
            _repo.AddContentToDirectory(dieHard);
            _repo.AddContentToDirectory(silenceOfLambs);
        }
    }
}
