using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Snackis.Domain.Entities;

namespace Snackis.Presentation.Components.Pages
{
    public partial class Admin
    {
        private bool isLoaded;
        private bool isAdmin;

        private CategoryModel NewCategory = new();
        private TopicModel NewTopic = new();

        public List<Category> Categories { get; set; } = new();
        public List<Topic> Topics { get; set; } = new();
        public List<Report> Reports { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = await UserManager.GetUserAsync(authState.User);

            isAdmin = user != null && user.IsAdmin;

            if (isAdmin)
            {
                Categories = await CategoryService.GetAllAsync();
                Topics = await TopicService.GetAllAsync();
                Reports = await ReportService.GetUnhandledReportsAsync();
            }

            isLoaded = true;
        }
        //------------------------
        private async void CategoryForm(EditContext editContext)
        {
            bool formIsValidated = editContext.Validate();

            if (formIsValidated)
            {
                var newCategory = (CategoryModel)editContext.Model;

                var dbCategory = new Category();

                dbCategory.Name = newCategory.Name;

                await CategoryService.CreateAsync(newCategory.Name);

                Categories = await CategoryService.GetAllAsync();

                await InvokeAsync(StateHasChanged);
            }
        }
        public class CategoryModel : IValidatableObject
        {
            [Required(ErrorMessage ="Namn är obligatorisk")]
            public string Name { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Name.Any(char.IsDigit))
                {
                    yield return new ValidationResult(
                        "Inga siffror i namnet, tack",
                        new[] { nameof(Name) });
                }
            }
        }
        //-------------------------------------

        private async void TopicForm(EditContext editContext)
        {
            if (!editContext.Validate())
                return;

            var topic = (TopicModel)editContext.Model;

            await TopicService.CreateAsync(
                topic.Name,
                topic.CategoryId);

            Topics = await TopicService.GetAllAsync();

            NewTopic = new();

            await InvokeAsync(StateHasChanged);
            
        }
        public class TopicModel : IValidatableObject
        {
            [Required(ErrorMessage = "Namn är obligatoriskt")]
            public string Name { get; set; }

            [Range(1, int.MaxValue, ErrorMessage = "Välj kategori")]
            public int CategoryId { get; set; }
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                if (Name.Any(char.IsDigit))
                {
                    yield return new ValidationResult(
                        "Inga siffror i namnet, tack",
                        new[] { nameof(Name) });
                }
            }

        }
        //------------------------------------------------------
        private async Task HandleReport(int reportId)
        {
            await ReportService.HandleReportAsync(reportId);

            Reports = await ReportService.GetUnhandledReportsAsync();

            await InvokeAsync(StateHasChanged);
        }

    }
}