using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    /**
        Represents a role.
    */
    public class Application
    {
         /**
            Identifies the role uniquely in the storage.
          */
        [Key]
        public int Id { get; set; }

        /**
            The unique name of the role.
         */
        [Required(ErrorMessage = "Application name is required")] 
        [MaxLength(50, ErrorMessage = "Application name cannot be longer than 50 characters.")] 
        public string Name { get; set; }
    }
}