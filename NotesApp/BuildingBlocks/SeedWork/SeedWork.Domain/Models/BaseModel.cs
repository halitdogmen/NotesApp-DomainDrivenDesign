using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedWork.Domain.Models
{
    public abstract class BaseModel
    {
        //Properties
        public Guid Id { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? UpdateAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }

        // Constructors
        public BaseModel()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            IsDeleted = false;
            DeletedAt = null;
            UpdateAt = null;
        }

        public void Updated()
        {
            UpdateAt = DateTime.Now;
        }

        public void SoftDelete()
        {
            DeletedAt = DateTime.Now;
            IsDeleted = true;
        }

    }
}
