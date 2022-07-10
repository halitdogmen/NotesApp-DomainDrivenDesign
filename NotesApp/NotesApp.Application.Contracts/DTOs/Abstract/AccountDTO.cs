using NotesApp.Application.Contracts.DTOs.Concrete;
using Swashbuckle.AspNetCore.Annotations;

namespace NotesApp.Application.Contracts.DTOs.Abstract
{
    /// <summary>
    /// Represents Account Data Transfer Object
    /// </summary>
    [SwaggerSubType(typeof(StandartUserDTO))]
    [SwaggerSubType(typeof(AdminDTO))]
    public abstract class AccountDTO
    {
        /// <summary>
        /// Represents Account Unique Identifier.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Represents Account Email.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Represents Account Type.
        /// </summary>
        public string Type { get; set; }
    }
}
