
namespace CarBook.Application.Dtos
{
    public interface ITokenResponseDto
    {
        DateTime ExpireDate { get; set; }
        string Token { get; set; }
    }
}