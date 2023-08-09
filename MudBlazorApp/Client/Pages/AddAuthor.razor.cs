using Application.Interfaces.Services;
using Blazored.FluentValidation;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MudBlazorApp.Client.Pages
{
    public partial class AddAuthor
    {
        [Inject] ISnackbar _snackBar { get; set; }
        [Inject] IAuthorService _authorService{ get; set; }

        private FluentValidationValidator _fluentValidationValidator;
      
        public Author author = new();
        

        
       public async Task RegisterAsync()
        {
            var res = await _authorService.AddAuthor(author);
            if (res.Succeeded)
            {
                _snackBar.Add("Author registered successfully", Severity.Success);
            }
        }


    }
}
