using BulkyBookWebASP.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWebASP.Data
{
    /**
     * create a seperate folder for data related classes
     * this calss can have any name
     * should extend this class from DbContext which is comming from EntityFrameworkCore
     * 
     * 
     * **/

    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            //pass the options parameter arguments to the base class and it will configure our db context

            //for the models to create in the databse, should create a dbset first
            //this will create a table called categories inside the database, which related to the model Category
            //the attributes for the table are defined by the Category class

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Customer> customers { get; set; }
    }
}
