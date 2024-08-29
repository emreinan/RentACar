using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ModelRepository : EfBaseRepository<Model, Guid, BaseDbContext>, IModelRepository
{
	public ModelRepository(BaseDbContext context) : base(context)
	{
	}
}
