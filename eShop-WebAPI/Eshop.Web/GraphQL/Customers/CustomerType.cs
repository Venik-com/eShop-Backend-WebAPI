using Eshop.Web.Data.EFModels;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop.Web.GraphQL.Customers
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Description("Represents any executable customer.");

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

            //descriptor
            //    .Field(c => c.Platform)
            //    .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
            //    .UseDbContext<AppDbContext>()
            //    .Description("This is the platform to which the command belongs.");

        }

        //private class Resolvers
        //{
        //    public Platform GetPlatform(Command command, [ScopedService] AppDbContext context)
        //    {
        //        return context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);
        //    }
        //}
    }
}
