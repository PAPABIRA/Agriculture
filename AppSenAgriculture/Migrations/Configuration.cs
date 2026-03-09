namespace AppSenAgriculture.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppSenAgriculture.Models.BdSenAgricultureContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //pour ne pas perdre les données lors de la migration automatique
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AppSenAgriculture.Models.BdSenAgricultureContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
