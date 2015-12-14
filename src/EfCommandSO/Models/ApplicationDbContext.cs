using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using EfCommandSO.Models.ApiDoc;
using System.Threading;

namespace EfCommandSO.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Gets or sets the DbSet for the ApiGroupDescriptions.
        /// </summary>
        /// <remarks>
        /// While there are other tables, they are only accessed by the navigation properties of
        /// of the ApiGroupDescriptions.
        /// </remarks>

        public DbSet<ApiDescriptionBase>            ApiDescriptions { get; set; }
        public DbSet<ApiGroupDescription>           Groups          { get; set; }
        //public DbSet<ApiMethodSignatureDescription> Methods         { get; set; }
        //public DbSet<ApiExceptionDescription>       Exceptions      { get; set; }
        //public DbSet<ApiParameterDescription>       Parameters      { get; set; }
        //public DbSet<ApiPropertyDescription>        Properties      { get; set; }
        //public DbSet<ApiCodeSample>                 Examples        { get; set; }
        //public DbSet<ApiCodeSnippet>                CodeSnippets    { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        /// <summary>
        /// Overridden to update the Posted and Modified Dates on SaveChanges.
        /// </summary>
        /// <returns>The number of entries written to the database.</returns>
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            var now = DateTime.UtcNow;

            SetPostedAndModified(now);

            return base.SaveChanges();
        }

        /// <summary>
        /// Overridden to update the Posted and Modified Dates on SaveChangesAsync.
        /// </summary>
        /// <param name="cancellationToken"> 
        ///     A System.Threading.CancellationToken to observe while waiting for the task to
        ///     complete.
        /// </param>
        /// <returns> 
        ///     A task that represents the asynchronous save operation. The task result contains
        ///     the number of state entries written to the database.
        /// </returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();
            var now = DateTime.UtcNow;

            SetPostedAndModified(now);

            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetPostedAndModified(DateTime now)
        {
            SetPostedAndModified<ApiGroupDescription>(now);
            SetPostedAndModified<ApiMethodSignatureDescription>(now);
            SetPostedAndModified<ApiParameterDescription>(now);
            SetPostedAndModified<ApiPropertyDescription>(now);
            SetPostedAndModified<ApiExceptionDescription>(now);
            SetPostedAndModified<ApiCodeSample>(now);
            SetPostedAndModified<ApiCodeSnippet>(now);
        }

        /// <summary>
        /// Sets the Posted and Modified properties for the specified type.
        /// </summary>
        /// <typeparam name="T">The Type to have the properties set.</typeparam>
        /// <param name="now">The DateTime to set the properties to.</param>
        private void SetPostedAndModified<T>(DateTime now)  where T : class, IPostedAndModified
        {
            foreach (var item in ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Added))
            {
                item.Property(x => x.Posted).CurrentValue = now;
                item.Property(x => x.Modified).CurrentValue = now;
            }

            foreach (var item in ChangeTracker.Entries<T>().Where(e => e.State == EntityState.Modified))
            {
                item.Property(x => x.Modified).CurrentValue = now;
            }
        }
    }
}
