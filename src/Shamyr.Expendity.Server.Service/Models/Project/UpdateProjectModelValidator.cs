﻿using FluentValidation;
using Shamyr.Expendity.Server.Entities;

namespace Shamyr.Expendity.Server.Service.Models.Project
{
  public class UpdateProjectModelValidator: AbstractValidator<UpdateProjectModel>
  {
    public UpdateProjectModelValidator()
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
