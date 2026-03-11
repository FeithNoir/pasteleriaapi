using Base.Data;
using Microsoft.EntityFrameworkCore;
using Pasteleria.Business.Interfaces.Repositories;
using Pasteleria.Shared.Models;

namespace Pasteleria.Business.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly Context _context;

        public DocumentRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(Document dto)
        {
            await _context.Documents.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);
            _context.Documents.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Document>> GetAllAsync()
        {
            return await _context.Documents.AsNoTracking().ToListAsync();
        }

        public async Task<Document> GetByIdAsync(Guid id)
        {
            var result = await _context.Documents.FirstOrDefaultAsync(r => r.Id == id);
            return result == null ? throw new KeyNotFoundException($"Document with ID {id} not found.") : result;
        }

        public async Task UpdateAsync(Document dto)
        {
            var existingDocument = await GetByIdAsync(dto.Id);
            _context.Entry(existingDocument).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();
        }
    }
}
