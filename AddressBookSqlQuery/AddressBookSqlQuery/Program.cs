using System; 
namespace AddressBookSqlQuery
{
    class program
    {
        static void Main()
        {
            Operation operation = new Operation();
            // Operation.CreateDataBase();            // Creating the DataBase
            // operation.CreateTable();                  // Creating the Table
            Contact details = new Contact()
            {
                FirstName ="S",
                LastName="Z",
                Address="street1",
                City="Chennai",
                State="Tamilnadu",
                Zip=600001,
                PhoneNumber="9876543210",
                Email="az@gmail.com"
            };
            Contact MappingDetails = new Contact()
            {
                Id = 8,
                Typeid=2
            };
            // operation.AddDetails(details);                 // Adding the contact to the database
            // operation.UpdateDetails(details);              // Edit the Contact in the database by using the firstname
            // operation.DeleteContact("S");                  // Delete the contact in the database by using the firstname
            // operation.SameCityDetails("Bangalore");        // Retrive the Details of the person and sort the list by using city
            //operation.SameStateDetails("Tamilnadu");       // Retrive the Details of the person and sort the list by using State
            //operation.citycount();                          // Get the count of numbers in the city
            // operation.Statecount();                           // Get the count of numbers in the state
            // operation.CreateMappingTable();
            //operation.AddMappingValues(MappingDetails);
            //operation.CountByType();


            operation.GetAllDetails();

            List<Contact> list = new List<Contact>();
            list.Add(new Contact()
            {
                FirstName = "B",
                LastName = "B",
                Address = "B",
                City = "B",
                State = "B",
                Zip = 500320,
                PhoneNumber = "9678984356",
                Email = "b@gmail.com"
            });
            list.Add(new Contact()
            {
                FirstName = "C",
                LastName = "C",
                Address = "C",
                City = "C",
                State = "C",
                Zip = 506798,
                PhoneNumber = "9567654098",
                Email = "C@gmail.com"
            });
            list.Add(new Contact()
            {
                FirstName = "D",
                LastName = "D",
                Address = "D",
                City = "D",
                State = "D",
                Zip = 500001,
                PhoneNumber = "9567651234",
                Email = "d@gmail.com"
            });
            list.Add(new Contact()
            {
                FirstName = "A",
                LastName = "A",
                Address = "A",
                City = "A",
                State = "A",
                Zip = 500001,
                PhoneNumber = "9567654356",
                Email = "a@gmail.com"
            });

            list.Add(new Contact()
            {
                FirstName = "E",
                LastName = "E",
                Address = "E",
                City = "E",
                State = "E",
                Zip = 622001,
                PhoneNumber = "7898654356",
                Email = "E@gmail.com"
            });

            operation.UsingWithoutThread(list);
            operation.UsingwithThread(list);

            
        }
    }
}
