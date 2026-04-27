using System.ComponentModel.DataAnnotations;

namespace NitelikliKahve.Models;

public class Equipment
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Makine adı zorunludur.")]
    [MaxLength(150, ErrorMessage = "Makine adı en fazla 150 karakter olabilir.")]
    public string MachineName { get; set; }
    
    [MaxLength(50, ErrorMessage = "Portafiltre türü en fazla 50 karakter olabilir.")]
    public string PortafilterType { get; set; }

    
    [Required(ErrorMessage = "Değirmen adı zorunludur.")]
    [MaxLength(150, ErrorMessage = "Değirmen adı en fazla 150 karakter olabilir.")]
    public string GrinderName { get; set; }
}
