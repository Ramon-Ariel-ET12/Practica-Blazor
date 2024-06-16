using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Core;

[Table("User")]
public class User
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Indica que la base de datos generará automáticamente el valor
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }

    [Required]
    [StringLength(50)]
    public string? Surname { get; set; }

    [Required]
    public DateTime Birthdate { get; set; }

    [Required]
    [StringLength(15)]
    public string? Sex { get; set; }

    [Required]
    [StringLength(30)]
    public string? Nationality { get; set; }

    [Required]
    [StringLength(100)]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    // Constructor vacío requerido por Entity Framework Core
    public User() {}

    // Constructor con parámetros (no se deberia usar)
    public User(string name, string surname, DateTime birthday, string sex, string nationality, string email, string password)
    {
        Name = name;
        Surname = surname;
        Birthdate = birthday;
        Sex = sex;
        Nationality = nationality;
        Email = email;
        Password = password;
    }
}
