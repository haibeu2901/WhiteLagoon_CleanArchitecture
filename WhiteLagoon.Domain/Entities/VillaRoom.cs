using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Domain.Common;

namespace WhiteLagoon.Domain.Entities
{
    public class VillaRoom : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }

        [ForeignKey("Villa")]
        public int VillaId {  get; set; }

        public Villa Villa { get; set; } = null!;

        public string? SpecialDetails { get; set; }
    }
}
