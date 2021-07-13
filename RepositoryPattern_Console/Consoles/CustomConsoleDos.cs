using RepositoryPattern_Repository;
using RepositoryPattern_Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Console.Consoles
{
    public class CustomConsoleDos : ICustomConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayActor(Actor actor)
        {
            Console.WriteLine($"Nombre: {actor.FirstName} {actor.LastName} ID:{actor.Id}\n" +
                $"Biografia: {actor.Biography}\n" +
                $"Nacionalidad: {actor.Nationality}\n" +
                $"Edad: {actor.Age} born {actor.BirthMonth} {actor.BirthDay}, {actor.BirthYear}\n");
        }

        public void DisplayStreamingContent(StreamingContent content)
        {
            Console.WriteLine($"Titulo: {content.Title}\n" +
                                $"Descripcion: {content.Description}\n" +
                                $"Anyo: {content.ReleaseYear}\n" +
                                $"Tipo: {content.Genre}\n" +
                                $"Estrellas: {content.StarRating}\n" +
                                $"Maturidad: {content.AgeRating}\n");
        }

        public void DisplayStreamingContentWithCharacter(StreamingContent content, List<Actor> castMembers)
        {
            DisplayStreamingContent(content);

            Console.WriteLine("Proteganazando: ");

            foreach (var actor in castMembers)
            {
                DisplayActor(actor);
            }
        }

        public void EnterActorId()
        {
            Console.Write("Entre ID Para el Actor: ");
        }

        public void EnterADescription()
        {
            Console.WriteLine("Entre una descripcion: ");
        }

        public void EnterAStarRating()
        {
            Console.Write("Entre los estrellas (0-10): ");
        }

        public void EnterATitle()
        {
            Console.Write("Entre un titulo: ");
        }

        public void EnterBiography()
        {
            Console.Write("Entre una biografia: ");
        }

        public void EnterBirthDay()
        {
            Console.Write("Entre una dia de cumpleanyo (1-31): ");
        }

        public void EnterBirthMonth()
        {
            Console.Write("Entre una mez de cumpleanyo(1-12): ");
        }

        public void EnterBirthYear()
        {
            Console.Write("Entre una anyo de cumpleanyo (YYYY): ");
        }

        public void EnterFirstName()
        {
            Console.Write("Entre el nombre primero: ");
        }

        public void EnterLastName()
        {
            Console.Write("Entre el nombre segundo: ");
        }

        public void EnterNationality()
        {
            Console.Write("Entre Nacionalidad: ");
        }

        public void EnterTheReleaseYear()
        {
            Console.Write("Entre el anyo (YYYY): ");
        }

        public void InvalidSelectionPressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Inválido. Presione cualquier tecla para regresar al menú principal.");
        }

        public void PressAnyKeyToReturnToMainMenu()
        {
            Console.WriteLine("Presione cualquier tecla para regresar al menú principal.");
        }

        public void PrintMainMenu()
        {
            Console.WriteLine($"Bienvenidos.\n" +
                $"Seleccionar:\n" +
                $"1. Muestra todo contento\n" +
                $"2. Buscar para contento\n" +
                $"3. Contento Nuevo\n" +
                $"4. Muestra todos los personas de las peliculas\n" +
                $"5. Crear nuevo actor o actriz\n" +
                $"6. Agregar actor o actriz a la pelicula\n" +
                $"7. Salida\n");
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
                            "1. Suspenso\n" +
                            "2. Ciencia Ficción\n" +
                            "3. Accion\n" +
                            "4. Drama\n" +
                            "5. Horror\n" +
                            "6. Misterio\n" +
                            "7. Romance\n" +
                            "8. RomCom\n" +
                            "9. Comedia\n" +
                            "10. Documentario\n" +
                            "11. Vaqueros");

            Console.Write("Ingrese el número correspondiente: ");
        }

        public void SelectAMaturityRating()
        {
            Console.WriteLine("Select a Maturity Rating:\n" +
                            "1. G\n" +
                            "2. PG\n" +
                            "3. PG-13\n" +
                            "4. R\n" +
                            "5. NC17");

            Console.Write("Ingrese el número correspondiente: ");
        }
    }
}
