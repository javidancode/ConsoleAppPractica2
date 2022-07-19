using Domain.Models;
using LibraryApp.Controllers;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;

namespace LibraryApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            LibraryController libraryController = new LibraryController();

            BookControllers bookControllers = new BookControllers();

            Helper.WriteConsole(ConsoleColor.Yellow,"Select one option :");

            GetMenues();

            while (true)
            {
                SelectOption: string selectOption = Console.ReadLine();

                int SelectTrueOption;

                bool isSelectOption = int.TryParse(selectOption, out SelectTrueOption);

                if (isSelectOption)
                {
                    switch (SelectTrueOption)
                    {
                        case (int)Menues.CreatLibrary:

                            libraryController.Create();

                            break;
                        case (int)Menues.GetLibraryById:

                            libraryController.GetById();

                            break;
                        case (int)Menues.UpdateLibrary:

                            Console.WriteLine(SelectTrueOption);

                            break;
                        case (int)Menues.DeleteLibrary:

                            libraryController.Delete();

                            break;
                        case (int)Menues.GetAllLibraries:

                            libraryController.GetAll();

                            break;

                        case (int)Menues.SearchLibrary:

                            libraryController.Search();

                            break;
                        case (int)Menues.CreateBook:

                            bookControllers.Create();

                            break;
                        default:
                            Helper.WriteConsole(ConsoleColor.Red, "Select correct option number");
                            break;
                            
                    }
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Select correct option");
                    goto SelectOption;
                }
            }
        }

        private static void GetMenues()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "1 - Create library, 2 - Get library by id, 3 - Update library," +
                " 4 - Delete library, 5 - Get all libraries, 6 - Search for library by name, 7 - Creat book");
        }



    }


}
