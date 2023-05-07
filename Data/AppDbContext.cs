
using Microsoft.EntityFrameworkCore;
using PersonModels;

namespace Labb_4_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        
        }


        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbies { get; set;}
        public DbSet<PersonHobby> PersonHobbies { get; set;}
        public DbSet<Link> Links { get; set;}


        //Seed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Lägg till första data för Person
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, Name = "Anna Svensson", PhoneNumber = "070-1234567" },
                new Person { Id = 2, Name = "Karl Nilsson", PhoneNumber = "072-9876543" },
                new Person { Id = 3, Name = "Emma Johansson", PhoneNumber = "073-4567890" },
                new Person { Id = 4, Name = "Erik Andersson", PhoneNumber = "071-6543210" },
                new Person { Id = 5, Name = "Sofia Gustafsson", PhoneNumber = "075-9876123" }
            );

            // Lägg till första data för Hobby
            modelBuilder.Entity<Hobby>().HasData(
                new Hobby { Id = 1, Title = "Fotografering", Description = "Konsten att ta bilder med en kamera" },
                new Hobby { Id = 2, Title = "Matlagning", Description = "Att skapa kulinariska mästerverk i köket" },
                new Hobby { Id = 3, Title = "Trädgårdsarbete", Description = "Odlar växter och blommor utomhus" },
                new Hobby { Id = 4, Title = "Biljard", Description = "Ett spel som spelas på ett bord med kulor och köer" }
            );

            // Lägg till första data för PersonHobby
            modelBuilder.Entity<PersonHobby>().HasData(
                new PersonHobby { Id = 1, PersonId = 1, HobbyId = 1 },
                new PersonHobby { Id = 2, PersonId = 2, HobbyId = 2 },
                new PersonHobby { Id = 3, PersonId = 3, HobbyId = 1 },
                new PersonHobby { Id = 4, PersonId = 3, HobbyId = 3 },
                new PersonHobby { Id = 5, PersonId = 4, HobbyId = 4 },
                new PersonHobby { Id = 6, PersonId = 5, HobbyId = 2 },
                new PersonHobby { Id = 7, PersonId = 5, HobbyId = 3 }
             );

            // Lägg till första data för Link
            modelBuilder.Entity<Link>().HasData(
                new Link { Id = 1, Url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQcRmT6uWEdqwp8Rb7_ovgPvSxF--xYUzle3w&usqp=CAU", PersonHobbyId = 1 },
                new Link { Id = 2, Url = "https://t4.ftcdn.net/jpg/03/32/75/39/360_F_332753934_tBacXEgxnVplFBRyKbCif49jh0Wz89ns.jpg", PersonHobbyId = 2 },
                new Link { Id = 3, Url = "https://i.guim.co.uk/img/media/ef96c1f2495b60ec83379962d4aec38bfb1ce039/0_187_5600_3363/master/5600.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=a96e7cb435ac3a89558b8315d39c068d", PersonHobbyId = 5 },
                new Link { Id = 4, Url = "https://lirp.cdn-website.com/5152f937/dms3rep/multi/opt/GettyImages-582313494-553w.jpg", PersonHobbyId = 6 }
            );
        }






    }




}
