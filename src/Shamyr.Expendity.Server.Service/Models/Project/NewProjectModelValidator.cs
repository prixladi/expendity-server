﻿using FluentValidation;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class NewProjectModelValidator: AbstractValidator<NewProjectModel>
  {
    public NewProjectModelValidator()
    {
      RuleFor(x => x.Name)
        .NotNull()
        .NotEmpty()
        .MaximumLength(ValidationConstants._MaxNameLength);

      RuleFor(x => x.Description)
        .MaximumLength(ValidationConstants._MaxDescriptionLength);
    }
  }
}