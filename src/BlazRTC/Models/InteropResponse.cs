namespace BlazRTC.Models;

internal class InteropResponse<T>
{
    public bool Succeeded { get; set; }
    public string? Error { get; set; }
    public T? Data { get; set; } 
}
