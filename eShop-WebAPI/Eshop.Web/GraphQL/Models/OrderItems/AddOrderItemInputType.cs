using Eshop.Web.GraphQL.OrderItems;
using HotChocolate.Types;

namespace Eshop.Web.GraphQL.Models.OrderItems
{
    public class AddOrderItemInputType : InputObjectType<AddOrderItemInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddOrderItemInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a OrderItem.");

            //descriptor
            //    .Field(c => c.OrganisationOrPerson)
            //    .Description("Организация или физ. лицо.");
            //descriptor
            //    .Field(c => c.Gender)
            //    .Description("Гендер.");
            //descriptor
            //    .Field(c => c.Age)
            //    .Description("Возраст.");
            //descriptor
            //    .Field(c => c.FirstName)
            //    .Description("Имя.");
            //descriptor
            //    .Field(c => c.LastName)
            //    .Description("Фамилия.");
            //descriptor
            //    .Field(c => c.EmailAddress)
            //    .Description("Эл. почта.");
            //descriptor
            //    .Field(c => c.LoginName)
            //    .Description("Логин.");
            //descriptor
            //    .Field(c => c.LoginPassword)
            //    .Description("Пароль.");

            base.Configure(descriptor);
        }
    }
}
