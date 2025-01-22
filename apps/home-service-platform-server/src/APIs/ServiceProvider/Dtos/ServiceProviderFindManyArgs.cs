using HomeServicePlatform.APIs.Common;
using HomeServicePlatform.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeServicePlatform.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class ServiceProviderFindManyArgs
    : FindManyInput<ServiceProvider, ServiceProviderWhereInput> { }
