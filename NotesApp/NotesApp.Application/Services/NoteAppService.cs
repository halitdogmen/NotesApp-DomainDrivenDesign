using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using NotesApp.Application.Contracts.DTOs.Abstract;
using NotesApp.Application.Contracts.DTOs.Concrete;
using NotesApp.Application.Contracts.Services;
using NotesApp.Domain.Aggregates.NoteAggregate.Abstract;
using NotesApp.Domain.Aggregates.NoteAggregate.Concrete;
using NotesApp.Domain.Aggregates.NoteAggregate.ValueObject;
using NotesApp.Domain.Repositories;
using NotesApp.Domain.Specifications.NoteSpecifications;
using SeedWork.Application.Authorization;
using SeedWork.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Services
{
    public class NoteAppService : INoteAppService
    {
        private readonly INoteRepository _noteRepository;
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public NoteAppService(INoteRepository noteRepository, IAuthorizationService authorizationService, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        public async Task<NoteDTO> CreateAsync(ClaimsPrincipal claimsPrincipal, TextNoteCreationDTO textNoteCreationDTO)
        {
            TextNote textNote;
            if (textNoteCreationDTO.Tags is not null && textNoteCreationDTO.Tags.Count != 0)
            {
                List<Tag> tags = textNoteCreationDTO.Tags.Select(x=> new Tag(x)).ToList();
                textNote = new TextNote(textNoteCreationDTO.Title, textNoteCreationDTO.Description, tags, textNoteCreationDTO.AccountId);
            }
            else
            {
                textNote = new TextNote(textNoteCreationDTO.Title, textNoteCreationDTO.Description, textNoteCreationDTO.AccountId);
            }
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, textNote, Operations.Create);
            if(!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            // do operation
            await _noteRepository.CreateAsync(textNote);
            return ToResponseObject(textNote);
        }

        public async Task<NoteDTO> CreateAsync(ClaimsPrincipal claimsPrincipal, ImageNoteCreationDTO imageNoteCreationDTO)
        {
            ImageNote imageNote;
            if (imageNoteCreationDTO.Tags is not null && imageNoteCreationDTO.Tags.Count != 0)
            {
                List<Tag> tags = imageNoteCreationDTO.Tags.Select(x => new Tag(x)).ToList();
                imageNote = new ImageNote(imageNoteCreationDTO.Title, imageNoteCreationDTO.Description,imageNoteCreationDTO.ImageUrl ,tags, imageNoteCreationDTO.AccountId);
            }
            else
            {
                imageNote = new ImageNote(imageNoteCreationDTO.Title, imageNoteCreationDTO.Description, imageNoteCreationDTO.ImageUrl, imageNoteCreationDTO.AccountId);
            }
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, imageNote, Operations.Create);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            // do operation
            await _noteRepository.CreateAsync(imageNote);
            return ToResponseObject(imageNote);
        }

        public async Task<NoteDTO> DeleteAsync(ClaimsPrincipal claimsPrincipal, Guid id)
        {
            var note = await _noteRepository.GetOneAsync(new NoteGetByIdSpecification(id));
            if (note == null) throw new ItemNotFoundException("Note not found.");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal,note,Operations.Delete);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            // Do operation => soft delete
            note.SoftDelete();
            await _noteRepository.UpdateAsync(note);
            return ToResponseObject(note);
        }

        public async Task<List<NoteDTO>> GetAllAsync(ClaimsPrincipal claimsPrincipal, int limit, int offset)
        {
            var notes = await _noteRepository.GetAsync(new NoteGetAllSpecification(), limit, offset);
            if(notes.Count ==0) return new List<NoteDTO>();
            // check permission
            foreach(var note in notes)
            {
                var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, notes, Operations.Read);
                if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            }
            return ToResponseObject(notes);
        }

        public async Task<List<NoteDTO>> GetByAccountIdAsync(ClaimsPrincipal claimsPrincipal, Guid accountId, int limit, int offset)
        {
            var notes = await _noteRepository.GetAsync(new NoteGetByAccountIdSpecification(accountId), limit, offset);
            if (notes.Count == 0) return new List<NoteDTO>();
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, notes.FirstOrDefault(), Operations.Read);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            return ToResponseObject(notes);
        }

        public async Task<NoteDTO> GetByIdAsync(ClaimsPrincipal claimsPrincipal, Guid id)
        {
            var note = await _noteRepository.GetOneAsync(new NoteGetByIdSpecification(id));
            if (note == null) throw new ItemNotFoundException("Note not found.");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, note, Operations.Read);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");
            return ToResponseObject(note);
        }

        public async Task<NoteDTO> PartialUpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, TextNoteUpdateDTO textNoteUpdateDTO)
        {
            var note = await _noteRepository.GetOneAsync(new NoteGetByIdSpecification(id));
            if (note == null) throw new ItemNotFoundException("Note not found.");
            if (note is not TextNote textNote) throw new WrongAttemptException("Note is not TextNote");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, note, Operations.Update);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");

            if (textNoteUpdateDTO.Title is not null) textNote.SetTitle(textNoteUpdateDTO.Title);
            if(textNoteUpdateDTO.Description is not null) textNote.SetDescription(textNoteUpdateDTO.Description);
            if (textNoteUpdateDTO.Tags is not null) 
            {
                List<Tag> tags = textNoteUpdateDTO.Tags.Select(x => new Tag(x)).ToList();
                textNote.SetTags(tags);
            }
            await _noteRepository.UpdateAsync(note);
            return ToResponseObject(note);
        }

        public async Task<NoteDTO> PartialUpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, ImageNoteUpdateDTO imageNoteUpdateDTO)
        {
            var note = await _noteRepository.GetOneAsync(new NoteGetByIdSpecification(id));
            if (note == null) throw new ItemNotFoundException("Note not found.");
            if (note is not ImageNote textNote) throw new WrongAttemptException("Note is not ImageNote");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, note, Operations.Update);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");

            if (imageNoteUpdateDTO.Title is not null) textNote.SetTitle(imageNoteUpdateDTO.Title);
            if (imageNoteUpdateDTO.Description is not null) textNote.SetDescription(imageNoteUpdateDTO.Description);
            if (imageNoteUpdateDTO.Tags is not null)
            {
                List<Tag> tags = imageNoteUpdateDTO.Tags.Select(x => new Tag(x)).ToList();
                textNote.SetTags(tags);
            }
            if (imageNoteUpdateDTO.ImageUrl is not null) textNote.SetImageUrl(imageNoteUpdateDTO.ImageUrl);
            await _noteRepository.UpdateAsync(note);
            return ToResponseObject(note);
        }

        public async Task<NoteDTO> UpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, TextNoteUpdateDTO textNoteUpdateDTO)
        {
            var note = await _noteRepository.GetOneAsync(new NoteGetByIdSpecification(id));
            if (note == null) throw new ItemNotFoundException("Note not found.");
            if (note is not TextNote textNote) throw new WrongAttemptException("Note is not TextNote");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, note, Operations.Update);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");

            textNote.SetTitle(textNoteUpdateDTO.Title);
            textNote.SetDescription(textNoteUpdateDTO.Description);
            List<Tag> tags = textNoteUpdateDTO.Tags.Select(x => new Tag(x)).ToList();
            textNote.SetTags(tags);
            await _noteRepository.UpdateAsync(note);
            return ToResponseObject(note);
        }

        public async Task<NoteDTO> UpdateAsync(ClaimsPrincipal claimsPrincipal, Guid id, ImageNoteUpdateDTO imageNoteUpdateDTO)
        {
            var note = await _noteRepository.GetOneAsync(new NoteGetByIdSpecification(id));
            if (note == null) throw new ItemNotFoundException("Note not found.");
            if (note is not ImageNote textNote) throw new WrongAttemptException("Note is not ImageNote");
            // check permission
            var authorizationStatus = await _authorizationService.AuthorizeAsync(claimsPrincipal, note, Operations.Update);
            if (!authorizationStatus.Succeeded) throw new UnauthorizedException("Permission Denied");

            textNote.SetTitle(imageNoteUpdateDTO.Title);
            textNote.SetDescription(imageNoteUpdateDTO.Description);
            List<Tag> tags = imageNoteUpdateDTO.Tags.Select(x => new Tag(x)).ToList();
            textNote.SetTags(tags);
            textNote.SetImageUrl(imageNoteUpdateDTO.ImageUrl);
            await _noteRepository.UpdateAsync(note);
            return ToResponseObject(note);
        }

        private NoteDTO ToResponseObject(Note note)
        {
            return _mapper.Map<NoteDTO>(note);
        }

        private List<NoteDTO> ToResponseObject(List<Note> notes)
        {
            return _mapper.Map<List<NoteDTO>>(notes);
        }
    }
}
