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
    
    [Required(ErrorMessage = "Fiyat alanı zorunludur.")]
    [Range(0.01, 1000000, ErrorMessage = "Fiyat 0.01 ile 1.000.000 arasında olmalıdır.")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Paket gramajı zorunludur.")]
    [Range(1, 100000, ErrorMessage = "Paket gramajı 1 ile 100000 gram arasında olmalıdır.")]
    public int PackageWeight { get; set; }
    
    public virtual ICollection<Recipe>? Recipes { get; set; } = new List<Recipe>();
}
