using Microsoft.AspNetCore.Mvc;
using Pasteleria.Business.Interfaces.Services;
using Pasteleria.Shared.DTOs;

namespace Pasteleria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _documentService.GetAllDocumentsAsync();
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _documentService.GetDocumentByIdAsync(id);
            return result.IsSuccessful ? Ok(result) : NotFound(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDocumentDto documentDto)
        {
            var result = await _documentService.AddDocumentAsync(documentDto);
            return result.IsSuccessful ? CreatedAtAction(nameof(GetById), new { id = result.Data.Id }, result) : BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DocumentDto documentDto)
        {
            if (id != documentDto.Id)
            {
                return BadRequest("Document ID in URL does not match Document ID in body.");
            }
            var result = await _documentService.UpdateDocumentAsync(documentDto);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _documentService.DeleteDocumentAsync(id);
            return result.IsSuccessful ? NoContent() : BadRequest(result);
        }
    }
}
