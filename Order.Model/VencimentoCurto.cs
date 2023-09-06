using System.ComponentModel.DataAnnotations;

namespace Order.Model
{
    public sealed class VencimentoCurto
    {
        [Required]
        [Range(1, 30)]
        public int? ValidadeVencimentoCurto { get; set; }
    }
}
