namespace Identity.Models
{
    public record User(
        Guid Id, 
        string Email,
        string Name,
        string Image,
        string Password,
        string[] Roles);
}
