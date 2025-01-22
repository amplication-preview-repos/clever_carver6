import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { ServiceProviderService } from "./serviceProvider.service";
import { ServiceProviderControllerBase } from "./base/serviceProvider.controller.base";

@swagger.ApiTags("serviceProviders")
@common.Controller("serviceProviders")
export class ServiceProviderController extends ServiceProviderControllerBase {
  constructor(
    protected readonly service: ServiceProviderService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
