using Microsoft.AspNetCore.Mvc;

namespace FlowerStore.Areas.Admin.Components
{
    /// <summary>
    /// Invoked in the admin layout
    /// </summary>
    
    public class AdminMenuComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult<IViewComponentResult>(View());
        }
    }
}
