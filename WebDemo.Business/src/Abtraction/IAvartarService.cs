using WebDemo.Business.src.DTO;

namespace WebDemo.Business.src.Abtraction
{
    public interface IAvartarService
    {
        Task<string> CreateAvartarAsync(AvartarCreateDto avartarCreateDto);
    }
}