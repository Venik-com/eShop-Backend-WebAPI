using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Customers
{
    public class AddCustomerInputType : InputObjectType<AddCustomerInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddCustomerInput> descriptor)
        {
            descriptor.Description("Represents the input to add for a customer.");

            descriptor
                .Field(c => c.OrganisationOrPerson)
                .Description("Организация или физ. лицо.");
            descriptor
                .Field(c => c.Gender)
                .Description("Гендер.");
            descriptor
                .Field(c => c.Age)
                .Description("Возраст.");
            descriptor
                .Field(c => c.FirstName)
                .Description("Имя.");
            descriptor
                .Field(c => c.LastName)
                .Description("Фамилия.");
            descriptor
                .Field(c => c.EmailAddress)
                .Description("Эл. почта.");
            descriptor
                .Field(c => c.LoginName)
                .Description("Логин.");
            descriptor
                .Field(c => c.LoginPassword)
                .Description("Пароль.");

            base.Configure(descriptor);
        }
    }
}
