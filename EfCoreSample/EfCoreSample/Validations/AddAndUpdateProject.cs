using EfCoreSample.Doman;
using EfCoreSample.Doman.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreSample.Validations
{
    public class AddAndUpdateProject : AbstractValidator<Project>
    {
        public AddAndUpdateProject()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(30)
                .WithMessage("'Title' must be filled and not shorter than 6 characters or longer 30 ");

            RuleFor(m => m.Description)
                .MaximumLength(256)
                .WithMessage("'Description' can't be longer than 256 chars");

            RuleFor(m => m.Status)
                .NotEmpty()
                .Must(m => m == Status.Pending || m == Status.InProgress || m == Status.Completed || m == Status.Cancelled)
                .WithMessage("'Status' must be filled and can be only Pending, InProgress, Completed, Cancelled");

        }
    }
}
