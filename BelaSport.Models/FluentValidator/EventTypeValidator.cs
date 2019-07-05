using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelaSport.Models.FluentValidator
{
    public class EventTypeValidator : AbstractValidator<EventType>
    {
        public EventTypeValidator()
        {
            RuleFor(eventType => eventType.EventTypeId).NotEmpty().WithMessage("Must have a Event Type that exists.");

            RuleFor(eventType => eventType.NameEventType)
                .NotEmpty().WithMessage("Title of the Type Event must be completed")
                .Length(3,50).WithMessage("Please Complete with more than 3 characters and 50 maximun.");

        }
    }
}
