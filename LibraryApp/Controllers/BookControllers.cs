using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Controllers
{
    public class BookControllers
    {
        BookService bookService = new BookService();

        public void Create()
        {
            Helper.WriteConsole(ConsoleColor.Blue, "Add library id : ");

            LibraryId: string libraryId = Console.ReadLine();

            int selectedLibraryId;

            bool isSelectedId = int.TryParse(libraryId, out selectedLibraryId);

            if (isSelectedId)
            {
                Helper.WriteConsole(ConsoleColor.Blue, "Add book name : ");

                string bookname = Console.ReadLine();

                Helper.WriteConsole(ConsoleColor.Blue, "Add book author : ");

                string author = Console.ReadLine();

                Book book = new Book()
                {
                    Name = bookname,
                    Author = author
                };

                var result = bookService.Create(selectedLibraryId, book);

                if(result != null)
                {
                    Helper.WriteConsole(ConsoleColor.Green, $"Book id : {result.Id}, Name : {result.Name}, Seat count : {result.Author}, Book library : {result.Library.Name} ");
                }
                else
                {
                    Helper.WriteConsole(ConsoleColor.Red, "Library not found, please add correct library id : ");
                    goto LibraryId;

                }
            }
            else
            {
                Helper.WriteConsole(ConsoleColor.Red, "Add correct library id type : ");
                goto LibraryId;
            }


            
            
        }
    }
}
