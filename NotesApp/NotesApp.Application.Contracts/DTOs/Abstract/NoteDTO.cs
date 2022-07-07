﻿using NotesApp.Domain.Aggregates.NoteAggregate.Concrete;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Application.Contracts.DTOs.Abstract
{
    [SwaggerSubType(typeof(TextNote))]
    [SwaggerSubType(typeof(ImageNote))]
    public class NoteDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public Guid AccountId { get; set; }
        // optinal
        public string Type { get; set; }
    }
}