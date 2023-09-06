using Microsoft.AspNetCore.Http;

namespace Order.Processor
{
    public interface IProcessor<T>
    {
        Task<IResult> ProcessAsync(T data);
    }
}
