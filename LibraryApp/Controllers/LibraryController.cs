using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Controllers
{
    public class LibraryController
    {
        LibraryService libraryService = new LibraryService();

        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library name : ");
            string libraryName = Console.ReadLine();

            Helper.WriteConsole(ConsoleColor.Blue, "Add library seat count : ");
        SeatCount: string librarySeatCount = Console.ReadLine();

            int seatCount;

            bool isSeatCount = int.TryParse(librarySeatCount, out seatCount);

            if (isSeatCount)
            {
                Library library = new Library()
                {
                    Name = libraryName,
                    SeatCount = seatCount
                };

                var result = libraryService.Create(library);
                Helper.WriteConsole(ConsoleColor.Green, $"Library id : {result.Id}, Name : {result.Name}, Seat count : {result.SeatCount} ");
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct seat count : ");
                goto SeatCount;
            }
        }

        public void GetById()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");
            LibraryId: string libraryId = Console.ReadLine();
            int id;

            bool isLibraryId = int.TryParse(libraryId, out id);

            if (isLibraryId)
            {
                Library library = libraryService.GetById(id);
                if (library != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library id : {library.Id}, Name : {library.Name}, Seat count : {library.SeatCount} ");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                    goto LibraryId;
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type");
                goto LibraryId;
            }
        }

        public void GetAll()
        {
            List<Library> libraries = libraryService.GetAll();
            foreach (var item in libraries)
            {
                Helper.WriteConsole(ConsoleColor.Green, $"Library id : {item.Id}, Name : {item.Name}, Seat count : {item.SeatCount} ");
            }
        }

        public void Search()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library search text : ");
        SearchText: string search = Console.ReadLine();

            List<Library> resultLibraries = libraryService.Search(search);
            if (resultLibraries.Count != 0)
            {
                foreach (var item in resultLibraries)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Library id : {item.Id}, Name : {item.Name}, Seat count : {item.SeatCount} ");
                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Library not found");
                goto SearchText;
            }
        }

        public void Delete()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");
            LibraryId: string libraryId = Console.ReadLine();
            int id;

            bool isLibraryId = int.TryParse(libraryId, out id);

            if (isLibraryId)
            {
                libraryService.Delete(id);
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Select correct id type");
                goto LibraryId;
            }
        }

        public void Update()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");

            LibraryId: string updateLibraryId = Console.ReadLine();

            int libraryId;

            bool isLibraryId = int.TryParse(updateLibraryId, out libraryId);

            if (isLibraryId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add library new name : ");

                string libraryNewName = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add library new seat cont : ");

                SeatCount: string libraryNewSeatCount = Console.ReadLine();

                int SeatCount;

                bool isSeatCount = int.TryParse(libraryNewSeatCount, out SeatCount);

                if (isSeatCount || libraryNewSeatCount == "")
                {
                    bool isSeatCountEmpty = string.IsNullOrEmpty(libraryNewName);

                    int? count = null;

                    if (isSeatCountEmpty)
                    {
                        count = null;
                    }
                    else
                    {
                        count = SeatCount;
                    }

                    Library library = new Library
                    {
                        Name = libraryNewName,
                        SeatCount = count
                    };

                    var resultlibrary = libraryService.Uptade(libraryId, library);

                    if(resultlibrary == null)
                    {
                        Helper.WriteConsole(ConsoleColor.Red, "Library not found,please try again : ");
                        goto LibraryId;
                    }
                    else
                    {
                        Helper.WriteConsole(ConsoleColor.Green, $"Library id : {resultlibrary.Id}, Name : {resultlibrary.Name}, Seat count : {resultlibrary.SeatCount} ");
                    }


                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Add correct library id : ");
                    goto SeatCount;
                }
                
                
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct library id : ");
                goto LibraryId;
            }
            
        }
    }
}
