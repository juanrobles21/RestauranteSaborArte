using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ustaRestaurant.Data.Base;
using ustaRestaurant.Data.Enum;
namespace ustaRestaurant.Models
{
    public class Comment:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Name is required")]
        public string FullName { get; set; }

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "qualification is required")]
        public QualityProduct qualification { get; set; }

        [Display(Name = "Opinion")]
        [Required(ErrorMessage = "Opinion is required")]
        public string Opinion { get; set; }

    }
}
