using FluentNHibernate.Conventions;
using FluentNHibernate.Mapping;

namespace PaintballTournaments.Data.NHibernateMaps.Conventions
{
    public class PrimaryKeyConvention : IIdConvention
    {
        public void Apply(FluentNHibernate.Conventions.Instances.IIdentityInstance instance)
        {
            instance.Column(instance.EntityType.Name + "Id");
            instance.GeneratedBy.Identity();
//            instance.UnsavedValue("0");
//            instance.GeneratedBy.HiLo("1000");
        }
    }
}
