namespace Bmwadforth.Types.Interfaces;

public interface IApiRequest<TRequest, TResponse>
{
    public TRequest Request { get; set; }
    public TResponse Response { get; set; }
}