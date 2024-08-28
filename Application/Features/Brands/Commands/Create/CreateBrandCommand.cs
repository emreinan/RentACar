using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>
{
	public string Name { get; set; }

	class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
	{
		private readonly IBrandRepository _brandRepository;

		public CreateBrandCommandHandler(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			var brand = new Brand(Guid.NewGuid(), request.Name);
			await _brandRepository.AddAsync(brand);

			return new CreatedBrandResponse
			{
				Id = brand.Id,
				Name = brand.Name
			};
		}
	}
}
