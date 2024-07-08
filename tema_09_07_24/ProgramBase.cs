using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public interface IBorrowable
    {
        void Borrow();
        void Return();
        bool IsBorrowed { get; }
    }

    public abstract class LibraryItem : IBorrowable
    {
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public int AnPublicare { get; set; }
        public bool IsBorrowed { get; private set; }

        public LibraryItem(string titlu, string autor, int anPublicare)
        {
            Titlu = titlu;
            Autor = autor;
            AnPublicare = anPublicare;
            IsBorrowed = false;
        }

        public void Borrow()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine($"{Titlu} a fost imprumutat.");
            }
            else
            {
                Console.WriteLine($"{Titlu} este deja imprumutat.");
            }
        }

        public void Return()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine($"{Titlu} a fost returnat.");
            }
            else
            {
                Console.WriteLine($"{Titlu} nu a fost imprumutat.");
            }
        }
    }

    public class Book : LibraryItem
    {
        public Book(string titlu, string autor, int anPublicare)
            : base(titlu, autor, anPublicare)
        {
        }
    }

    public class Magazine : LibraryItem
    {
        public Magazine(string titlu, string autor, int anPublicare)
            : base(titlu, autor, anPublicare)
        {
        }
    }

    public class DVD : LibraryItem
    {
        public DVD(string titlu, string autor, int anPublicare)
            : base(titlu, autor, anPublicare)
        {
        }
    }

    public class Library
    {
        private List<LibraryItem> items;

        public Library()
        {
            items = new List<LibraryItem>();
        }

        public void AddItem(LibraryItem item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Titlu} a fost adaugat în biblioteca.");
        }

        public void BorrowItem(string titlu)
        {
            LibraryItem item = items.Find(i => i.Titlu == titlu);
            if (item != null)
            {
                item.Borrow();
            }
            else
            {
                Console.WriteLine($"Itemul {titlu} nu a fost gasit in biblioteca.");
            }
        }
        public void ReturnItem(string titlu)
        {
            LibraryItem item = items.Find(i => i.Titlu == titlu);
            if (item != null)
            {
                item.Return();
            }
            else
            {
                Console.WriteLine($"Itemul {titlu} nu a fost gasit în biblioteca.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            library.AddItem(new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925));
            library.AddItem(new Magazine("National Geographic", "Diverse", 2021));
            library.AddItem(new DVD("Inception", "Christopher Nolan", 2010));

            library.BorrowItem("The Great Gatsby");
            library.ReturnItem("The Great Gatsby");
            library.BorrowItem("National Geographic");
            library.ReturnItem("Inception");
        }
    }
}
