using Bilet1.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Bilet1.Models
{
    public class Member:BaseEntity
    {
        [MaxLength(30,ErrorMessage ="30-dan artiq yazmaq olmaz")]
        public string? Image {  get; set; }
        public string Name { get; set; }
        public string? Job { get; set; }

    }
}
