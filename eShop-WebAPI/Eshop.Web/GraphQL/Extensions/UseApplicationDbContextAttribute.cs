using System.Reflection;
using Eshop.Web.Data.EFModels;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;

namespace Eshop.Web.GraphQL.Extensions
{
    public class UseApplicationDbContextAttribute : ObjectFieldDescriptorAttribute
    {
        public override void OnConfigure(
            IDescriptorContext context,
            IObjectFieldDescriptor descriptor,
            MemberInfo member)
        {
            descriptor.UseDbContext<EshopdbContext>();
        }
    }
}
