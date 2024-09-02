using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Delete;

public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, ICacheRemoverRequest
{
	public Guid Id { get; set; }

	public string CacheKey => "";
	public bool BypassCache => false;
	public string? CacheGroupKey => "GetBrands";

	public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;

		public DeleteBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}

		public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
		{
			var brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id);
			await _brandRepository.DeleteAsync(brand);
			return _mapper.Map<DeletedBrandResponse>(brand);
		}
	}
}
