using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    /**
        Represents a user.
     */
    public class User
    {
        /**
            Identifies the user uniquely in the storage.
         */
         [Key]
        public int Id { get; set; }

        /**
            Uniquely identifies the user. This should be part of the access token.
         */
        [Required(ErrorMessage = "Email cannot be empty")]
        [MaxLength(320, ErrorMessage = "Email address cannot be longer than 320 characters")]
        public string Email { get; set; }

        /**
            The first name of the user.
         */
        [MaxLength(50, ErrorMessage = "First name cannot be longer than 50 characters")] 
        public string Firstname { get; set; }

        /**
            The last name of the user.
         */
         [MaxLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]  
        public string Lastname { get; set; }

        /**
            The roles that apply to this user,
         */
        public List<UserRole> UserRoles { get; set; }

    }
}