using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPAM_Repo.Models
{
    public class ServerType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ServerTypeId { get; set; }
        public string Name { get; set; }
    }
}
