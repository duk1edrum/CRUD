using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration():base()
        {
            ToTable("Users");
            HasKey(x => x.Id); // you should split HasKey from Property
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("Id")
                .IsRequired();

            //HasKey(u => u.Id);

            //Property(p => p.Id).
            //    HasColumnName("Id").
            //    HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).IsRequired();

            //ToTable("dbo.Users");
        }
    }
}
