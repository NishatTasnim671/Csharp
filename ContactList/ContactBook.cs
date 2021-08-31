using System;

namespace  ContactList
{
    /// <summary>
    /// this class save the information of contactlist
    /// </summary>
    public class ContactBook
    {
        static int totalContact = 30;
        public static int UserNumber = 0;
        public static structure[] Str = new structure[totalContact];
        bool find = false;

        /// <summary>
        /// Add contatct
        /// </summary>

        public void AddContact(structure info)
        {

            
               Str[UserNumber] = info;
                Console.WriteLine("Contact added successfully. ");
                UserNumber++;
           
        }

        /// <summary>
        /// this method search by name and
        /// delete the contact
        /// </summary>
       

        public void DeleteContact(string Name)
        {


            
            for (int i = 0; i < UserNumber; i++)
            {
                if (Str[i].name.Contains(Name))
                {
                    find = true;
                    Console.WriteLine("Contact deleted successfully.");
                    for (int j = i; j < UserNumber; j++)
                    {
                        Str[j] = Str[j + 1];
                    }

                   UserNumber--;
                    break;


                  
                }
            }
            if (find == false)
            {
                Console.WriteLine("Name doesn't found !!");
            }

        }
        /// <summary>
        /// this method search by name and
        /// Update the contact in details
        /// </summary>

        public void UpdateContact(string Name)
        {
            
            for (int i = 0; i < UserNumber; i++)
            {
                if (Str[i].name.Contains(Name))
                {
                    find = true;
                    Console.Write("Name : ");
                    Str[i].name = Console.ReadLine();
                    Str[i].name = Str[i].name.ToUpper();

                    Console.Write("Phone : ");
                    Str[i].phone = Console.ReadLine();


                    Console.Write("Address : ");
                    Str[i].address = Console.ReadLine();


                    Console.Write("Relation : \n1.FAMILY\n2.FRIEND\n3.BUSINESS");
                    Console.Write("\nChoose Option :");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num == 1)
                    {
                        Str[i].relation = RelationType.FAMILY;

                    }
                    if (num == 2)
                    {
                        Str[i].relation = RelationType.FRIEND;

                    }
                    if (num == 3)
                    {
                        Str[i].relation = RelationType.BUSINESS;

                    }

                    Console.WriteLine("Contact updated successfully.");
                    break;
                }
            }
            if (find == false)
            {
                Console.WriteLine("Name doesn't found !!");
            }

        }

        /// <summary>
        /// this method search by name 
        /// </summary>
        public void SearchContact(string Name)
        {
          
          for (int i = 0; i < UserNumber; i++)
            {
                if (Str[i].name.Contains(Name))
                {
                    find = true;

                    Console.WriteLine("Name : " + Str[i].name);
                    Console.WriteLine("Phone : " + Str[i].phone);
                    Console.WriteLine("Address : " + Str[i].address);
                    Console.WriteLine("Relation  : " + Str[i].relation);


                    break;
                }
            }
            if (find == false)
            {
                Console.WriteLine("Name doesn't found !!");
            }


        }

      

    }
}