using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using PaintballTournaments.Core.Accounts;
using PaintballTournaments.Core.Locations;
using PaintballTournaments.Core.Tournaments;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;

namespace PaintballTournaments.Data.NHibernateMaps
{
    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {
        #region IAutoPersistenceModelGenerator Members

        public AutoPersistenceModel Generate()
        {
            var mappings = new AutoPersistenceModel();
            mappings.AddEntityAssembly(typeof(Layout).Assembly).Where(GetAutoMappingFilter);
            mappings.Conventions.Setup(GetConventions());
            mappings.Setup(GetSetup());
            mappings.IgnoreBase<Entity>();
            mappings.IgnoreBase<BasicLocation>();
            mappings.IncludeBase<BasicUser>();
            //mappings.IncludeBase<RegisteredUser>();
            //mappings.IncludeBase<Contact>();
            mappings.IgnoreBase(typeof(EntityWithTypedId<>));
            mappings.UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();

            return mappings;

        }

        #endregion

        private Action<AutoMappingExpressions> GetSetup()
        {
            return c =>
            {
                c.FindIdentity = type => type.Name == "Id";
                //c.IsComponentType = type => (type == typeof(GarmentTags) || type == typeof(ColorBlendingRules) || type == typeof(Rating));
                c.GetComponentColumnPrefix = type => type.Name + "_";
            };
        }

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
            {
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.ForeignKeyConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.HasManyConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.HasManyToManyConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.ManyToManyTableNameConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.PrimaryKeyConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.ReferenceConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.TableNameConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.EnumConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.ColumnNullabilityConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.StringColumnLengthConvention>();
                c.Add<PaintballTournaments.Data.NHibernateMaps.Conventions.DomainSignatureConvention>();

            };
        }

        /// <summary>
        /// Provides a filter for only including types which inherit from the IEntityWithTypedId interface.
        /// </summary>

        private bool GetAutoMappingFilter(Type t)
        {
            return t.GetInterfaces().Any(x =>
                                         x.IsGenericType &&
                                         x.GetGenericTypeDefinition() == typeof(IEntityWithTypedId<>));
        }
    }
}
