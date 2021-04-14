﻿using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace FormsApp
{
    public class Form : BasicAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDraft { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<FormManager> Owners { get; set; }
    }
}