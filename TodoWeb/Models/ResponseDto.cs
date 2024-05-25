namespace TodoWeb.Models
{
    public record ResponseDto<TDto>(bool Success, string Message, TDto Data);
}
