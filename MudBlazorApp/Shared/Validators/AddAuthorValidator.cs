using FluentValidation;
using Microsoft.Extensions.Localization;
using MudBlazorApp.Shared.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazorApp.Shared.Validators
{
    public class AuthorModelFluentValidator : AbstractValidator<AuthorDto>
    {
        public AuthorModelFluentValidator(IStringLocalizer<AuthorModelFluentValidator> localizer)
        {


            RuleFor(request => request.FirstName)
               .Must(x => x != null).WithMessage(x => localizer["First Name is required"]);
            RuleFor(request => request.LastName)
               .Must(x => x != null).WithMessage(x => localizer["Last Name is required"]);




        }

    }
}