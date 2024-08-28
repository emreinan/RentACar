﻿using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Brand, CreatedBrandResponse>().ReverseMap();
		CreateMap<Brand, CreateBrandCommand>().ReverseMap();
		CreateMap<Brand, GetListBrandListItemDto>().ReverseMap();
		CreateMap<Paginate<Brand>, GetListResponse<GetListBrandListItemDto>>().ReverseMap();

	}
}
