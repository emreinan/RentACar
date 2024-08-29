using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class FuelRepository : EfBaseRepository<Fuel, Guid, BaseDbContext>, IFuelRepository
{
	public FuelRepository(BaseDbContext context) : base(context)
	{
	}
}
