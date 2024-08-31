using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse> , ITransactionalRequest
{
	public string Name { get; set; }

	class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;
		private readonly BrandBusinessRules _brandBusinessRules;

		public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
			_brandBusinessRules = brandBusinessRules;
		}

		public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			await _brandBusinessRules.IsBrandNameUnique(request.Name);

			var brand = new Brand(Guid.NewGuid(), request.Name);
			await _brandRepository.AddAsync(brand);
			//await _brandRepository.AddAsync(brand); // For testing transaction

			return _mapper.Map<CreatedBrandResponse>(brand);

		}
	}
}
