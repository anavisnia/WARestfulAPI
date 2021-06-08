using System.ComponentModel.DataAnnotations;

namespace WARestfulAPI.Modules.Base
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }
}