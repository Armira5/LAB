using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCommerceCustom1.Models
{
   
    public class Mbulesa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Specifikoni emrin")]
        public string Emri { get; set; }
    }
}
