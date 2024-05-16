using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Core;

[Table("User")]
public class User(string name, string surname, string birthday, string email, string password)
{
    private static int _contador;
    [Key]
    [Required]
    public int Id { get; set; } = ++_contador;

    [Required]
    [StringLength(50)]
    public string? Name { get; set; } = name;

    [Required]
    [StringLength(50)]
    public string? Surname { get; set; } = surname;

    [Required]
    public string? Birthdate { get; set; } = birthday;

    [Required]
    [StringLength(100)]
    public string? Email { get; set; } = email;

    [Required]
    public string? Password { get; set; } = password;
}
