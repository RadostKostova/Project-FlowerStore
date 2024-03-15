using System.ComponentModel.DataAnnotations;
using static FlowerStore.Infrastructure.Constants.DataConstants;

namespace FlowerStore.Core.ViewModels.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool Availability { get; set; }
        public string FullDescription { get; set; } = string.Empty;

        [DisplayFormat(DataFormatString = DateFormatNeeded, ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; } 
        public int FlowersCount { get; set; }
        public string Category { get; set; } = null!;

    }
}
