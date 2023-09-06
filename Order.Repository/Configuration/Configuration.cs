using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace Order.Repository.Configuration
{
    public abstract class Configuration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Order.Entity.Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            // Essencial para manter a integridade dos dados em um ambiente com concorrência
            builder.Property(p => p.Version).IsRowVersion();
        }
    }

    public static class EntityExt
    {
        public static ReferenceReferenceBuilder<TPrincipalEntity, TDependentEntity> Child<TPrincipalEntity, TDependentEntity>(
            this EntityTypeBuilder<TPrincipalEntity> builder,
            Expression<Func<TPrincipalEntity, TDependentEntity?>> navigationPrincipalDependent,
            Expression<Func<TDependentEntity, TPrincipalEntity?>>? navigationDependentPrincipal,
            Expression<Func<TDependentEntity, object?>> foreignKeyExpression)
            where TDependentEntity : class
            where TPrincipalEntity : class
        {
            return builder.HasOne(navigationPrincipalDependent).WithOne(navigationDependentPrincipal).HasForeignKey(foreignKeyExpression).OnDelete(DeleteBehavior.Cascade);
        }

        public static ReferenceCollectionBuilder<TPrincipalEntity, TDependentEntity> Children<TPrincipalEntity, TDependentEntity>(
            this EntityTypeBuilder<TPrincipalEntity> builder,
            Expression<Func<TPrincipalEntity, IEnumerable<TDependentEntity>?>>? navigationPrincipalDependent,
            Expression<Func<TDependentEntity, TPrincipalEntity?>>? navigationDependentPrincipal,
            Expression<Func<TDependentEntity, object?>> foreignKeyExpression)
            where TDependentEntity : class
            where TPrincipalEntity : class
        {
            return builder.HasMany(navigationPrincipalDependent).WithOne(navigationDependentPrincipal).HasForeignKey(foreignKeyExpression).OnDelete(DeleteBehavior.Cascade);
        }

        public static ReferenceCollectionBuilder<TPrincipalEntity, TDependentEntity> Reference<TPrincipalEntity, TDependentEntity>(
            this EntityTypeBuilder<TDependentEntity> builder,
            Expression<Func<TDependentEntity, TPrincipalEntity?>>? navigationDependentPrincipal,
            Expression<Func<TPrincipalEntity, IEnumerable<TDependentEntity>?>>? navigationPrincipalDependent,
            Expression<Func<TDependentEntity, object?>> foreignKeyExpression)
            where TDependentEntity : class
            where TPrincipalEntity : class
        {
            return builder.HasOne(navigationDependentPrincipal).WithMany(navigationPrincipalDependent).HasForeignKey(foreignKeyExpression).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
