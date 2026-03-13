using Pasteleria.Shared.DTOs;
using Base.Shared.Extensions;

namespace Pasteleria.Business.Interfaces.Services
{
    public interface IDocumentService
    {
        Task<Result<PagedList<ListDocumentDto>>> GetAllDocumentsAsync(int pageNumber, int pageSize);
        Task<Result<DocumentDto>> GetDocumentByIdAsync(Guid id);
        Task<Result<DocumentDto>> AddDocumentAsync(CreateDocumentDto documentDto);
        Task<Result<DocumentDto>> UpdateDocumentAsync(DocumentDto documentDto);
        Task<Result<bool>> DeleteDocumentAsync(Guid id);
    }
}