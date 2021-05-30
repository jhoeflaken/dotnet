using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Models
{
    /**
      Defines a role for a specific user.
     */
    public class UserRole
    {
        /**
            Uniquely identifies the user role.
         */   
        [Key] 
        public int Id { get; set; }

        /**
            The role associated with the user.
         */ 
        [Required(ErrorMessage = "Role must be set.")]   
        public Role Role { get; set; }

        /**
            The user to which the role applies.
         */
        [Required(ErrorMessage = "User must be set.")]       
        public User User { get; set; }

        /**
            If set the user role only applies to the specified application.
         */
        public Application Application { get; set; }        

        /**
            If set the role only applies for the specified country.
         */
        [MaxLength(2, ErrorMessage = "Country code cannot be longer than 2 characters.")]    
        public string CountryCode { get; set; }

        /**
            If set the role only applies for the specified park.
         */   
        [MaxLength(3, ErrorMessage = "Park code cannot be longer than 3 characters.")]    
        public string ParkCode { get; set; }

        /**
            If set the role only applies for the specified brand.
         */   
        [MaxLength(2, ErrorMessage = "Brand code cannot be longer than 2 characters.")] 
        public string BrandCode { get; set; }
    }
}