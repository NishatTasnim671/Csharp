using System;
namespace ContactList
{
   /// <summary>
   /// this class contains main method
   /// </summary>
    class Entrypoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to contact management software.");
            ContactIO co = new ContactIO();
            co.ContactInfo();
            
        }
    }
}

