using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerMessenger.Core.Entities;


namespace PowerMessenger.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {

            entity.HasData(new User[]
            {
                new User
                {      
                    Id = 1,
                    Name = "PowerBlaze",
                    PasswordHash = "7bb2c3cc45130c6c05d2591ed43a6dab5ea11dadb439090b7db0c194ad7b75eb",
                    Email = "power@mail.ru",
                    DateRegistration = DateTime.Now,
                },
                new User
                {      
                    Id = 2,
                    Name = "TowerBlaze",
                    PasswordHash = "a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3",
                    Email = "tower.blaze@mail.ru",
                    DateRegistration = DateTime.Now,
                }
            });
        }
    }
}
