namespace OrenHakaton
{
    using System.Linq;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using OrenHakaton.Models;

    using NLog;

    public class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //using (var db = new OrenHakatonContext())
            //{
            //    // Create
            //    logger.Trace("Inserting a new Apartments");
            //    db.Add(new Apartments { Number = "8888888" });
            //    db.SaveChanges();

            //    // Read
            //    logger.Trace("Querying for a Apartments");
            //    var apartments = db.Apartments
            //        .OrderBy(b => b.ApartmentId)
            //        .First();

            //    // Update
            //    logger.Trace("Updating the blog and adding a post");
            //    apartments.Number = "1111111";
            //    db.SaveChanges();

            //    // Delete
            //    //logger.Trace("Delete the blog");
            //    //db.Remove(blog);
            //    //db.SaveChanges();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
