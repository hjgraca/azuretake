using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDB.Entities
{
    public class PostCode
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string CityName { get; set; }

        public virtual Region Region { get; set; }

        [StringLength(500)]
        public string Synonyms { get; set; }
    }
}
