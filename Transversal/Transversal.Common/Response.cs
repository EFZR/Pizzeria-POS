namespace Transversal.Common;

public class Response<T>
{
    public T? Data { get; set; }
    public bool IsSuccess { get; set; }
    public string? Messagae { get; set; }
}