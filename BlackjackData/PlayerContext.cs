using BlackjackData.Models;
using Microsoft.EntityFrameworkCore;

/*
 * Nuget Packages Required
 *  Microsoft entity framework core
 *      orm - object rational mapping
 *      maps data from our entity models (poco) to our data source (sql server)
 *
 *  Microsoft entity framework core sqlsserver
 *      our database
 *  Microsoft entity framework core tools
 *      use package manager console to to data migrations
 *
 * DBContext
 * link between  entity classes and database.  Think DbContext - represents the database
 * DBSet - represents a table in the database
*/

namespace BlackjackData
{
    public class PlayerContext : DbContext
    {

        public PlayerContext(DbContextOptions options) : base(options)
        {
            
        }

         public DbSet<PlayerSessionData> PlayerSessionInformation { get; set; }



    }
}
