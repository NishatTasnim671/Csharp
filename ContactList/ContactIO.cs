using System;

namespace ContactList
{
    /// <summary>
    /// This class is for user input
    /// </summary>
    public class ContactIO
    {
        public string Name;
        int num;
        string input;
        bool check = true;
        /// <summary>
        /// the method adds new contacts
        /// </summary>
        public void AddNewContact()
        {
           structure info = new structure();
        

        Console.Write("Name : ");
            info.name = Console.ReadLine();
            info.name = info.name.ToUpper();

            Console.Write("Phone : ");
            info.phone = Console.ReadLine();

            Console.Write("Address : ");
            info.address = Console.ReadLine();
            //read the option but it may cause exception if non-neumeric input is given
            //handle exception
            try
            {
                Console.Write("Relation : \n1.FAMILY/2.FRIEND/3.BUSINESS");
                Console.Write("\nChoose Option :");
                num = Convert.ToInt32(Console.ReadLine());

               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " Enter an integer value ");
                Console.Write("Choose an option :  ");
                num = Convert.ToInt32(Console.ReadLine());
            }


            if (num == 1)
            {
                info.relation = RelationType.FAMILY;

            }
            else if (num == 2)
            {
                info.relation = RelationType.FRIEND;

            }
            else if (num == 3)
            {
                info.relation = RelationType.BUSINESS;

            }

            new ContactBook().AddContact(info);
            
        }
        /// <summary>
        /// this method will take user input
        /// to do the operation which  you want to execute
        /// </summary>
        public void ContactInfo()
        {


            while (check)
            {
                    Console.WriteLine("What would you like to do today (ADD/DELETE/UPDATE/SEARCH/CLOSE)?");
                    input = Console.ReadLine();
                    input = input.ToUpper();

                if (input.Equals("ADD"))
                {
                    new ContactIO().AddNewContact();
                }


                else if (input.Equals("DELETE"))
                {
                    string Name;
                    Console.Write("Enter a name to delete a contact : ");
                    Name = Console.ReadLine();
                    Name = Name.ToUpper();
                    new ContactBook().DeleteContact(Name);
                    
                }


                else if (input.Equals("UPDATE"))
                {
                    Console.Write("Enter the name or part of the name you want to search by -  ");
                    Name = Console.ReadLine();
                    Name = Name.ToUpper();
                    new ContactBook().UpdateContact(Name);
                }


                else if (input.Equals("SEARCH"))
                {
                   
                    Console.Write("Enter a name to Search Contact by - ");
                    Name = Console.ReadLine();
                    Name = Name.ToUpper();
                    new ContactBook().SearchContact(Name);
                  
                }

                else if (input.Equals("CLOSE"))
                {
                    Console.WriteLine("Software is closed!!! ");
                    check = false;
                }


                else
                {
                    Console.WriteLine("Wrong input");
                }
                }
            }
        }

    }
