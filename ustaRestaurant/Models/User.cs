using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ustaRestaurant.Models
{
    public class User:IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
