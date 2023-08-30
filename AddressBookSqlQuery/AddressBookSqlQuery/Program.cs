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
            // operation.AddDetails(details);                 // Adding the contact to the database
            // operation.UpdateDetails(details);              // Edit the Contact in the database by using the firstname
            // operation.DeleteContact("S");                  // Delete the contact in the database by using the firstname
             operation.SameCityDetails("Bangalore");        // Retrive the Details of the person and sort the list by using city
            operation.SameStateDetails("Tamilnadu");       // Retrive the Details of the person and sort the list by using State
            //operation.citycount();                          // Get the count of numbers in the city
           // operation.Statecount();                           // Get the count of numbers in the state

        }
    }
}
