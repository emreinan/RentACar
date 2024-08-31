using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
	public CreateBrandCommandValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("Brand name is required")
			.MinimumLength(2).WithMessage("Brand name must consist min 2 characters.");
	}
}
