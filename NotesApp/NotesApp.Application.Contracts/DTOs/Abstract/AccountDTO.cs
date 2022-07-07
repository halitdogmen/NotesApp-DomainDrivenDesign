using NotesApp.Application.Contracts.DTOs.Concrete;
using Swashbuckle.AspNetCore.Annotations;

namespace NotesApp.Application.Contracts.DTOs.Abstract
{
    [SwaggerSubType(typeof(StandartUserDTO))]
    public abstract class AccountDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        // optinal
        public string Type { get; set; }
    }
}
