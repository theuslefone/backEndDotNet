using curso.api.Bussines.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Infraestruture.data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        void IEntityTypeConfiguration<Curso>.Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.HasKey(p => p.Codigo)
        }
    }
}
