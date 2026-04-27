using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NitelikliKahve.Models;

public class Recipe
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Dozaj alanı zorunludur.")]
    [Range(0.1, 100, ErrorMessage = "Dozaj 0.1 ile 100 gram arasında olmalıdır.")]
    public float Dose { get; set; }
    
    [Required(ErrorMessage = "Çıktı alanı zorunludur.")]
    [Range(0.1, 200, ErrorMessage = "Çıktı 0.1 ile 200 gram arasında olmalıdır.")]
    public float Yield { get; set; }
    
    [Required(ErrorMessage = "Demleme süresi zorunludur.")]
    [Range(1, 300, ErrorMessage = "Demleme süresi 1 ile 300 saniye arasında olmalıdır.")]
    public int BrewTime { get; set; }
    
    [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
    public int Rating { get; set; }
    
    [MaxLength(500, ErrorMessage = "Notlar en fazla 500 karakter olabilir.")]
    public string Notes { get; set; }
    
    public int CoffeeBeanId { get; set; }
    
    [ForeignKey("CoffeeBeanId")]
    public CoffeeBean CoffeeBean { get; set; }
    
    public int EquipmentId { get; set; }
    
    [ForeignKey("EquipmentId")]
    public Equipment Equipment { get; set; }
}
