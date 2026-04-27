using System.ComponentModel.DataAnnotations;

namespace NitelikliKahve.Models;

public class CoffeeBean
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Marka alanı zorunludur.")]
    [MaxLength(25, ErrorMessage = "Marka en fazla 25 karakter olabilir.")]
    public string Brand { get; set; }
    
    [Required(ErrorMessage = "Yöre alanı zorunludur.")]
    [MaxLength(25, ErrorMessage = "Yöre en fazla 25 karakter olabilir.")]
    public string Origin { get; set; }
    
    [MaxLength(25, ErrorMessage = "Kavrum derecesi en fazla 25 karakter olabilir.")]
    public string RoastLevel { get; set; }
    
    public ICollection<Recipe> Recipes { get; set; }
}
