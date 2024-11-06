using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Components
{
    /// <summary>
    /// Invoked in the user layout
    /// </summary>
    
    public class MainMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
