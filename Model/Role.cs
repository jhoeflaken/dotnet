using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    /**
        Represents a role.
    */
    public class Role
    {
         /**
            Identifies the role uniquely in the storage.
          */
        [Key]
        public int Id { get; set; }

        /**
            The unique name of the role.
         */
        [Required(ErrorMessage = "Role name is required")] 
        [MaxLength(50, ErrorMessage = "Role name cannot be longer than 50 characters.")] 
        public string Name { get; set; }

        /**
            If set the role only applies to the specified application.
         */
        public Application Application { get; set; }
    }
}