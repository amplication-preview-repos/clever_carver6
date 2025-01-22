import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import * as nestAccessControl from "nest-access-control";
import { ServiceCategoryService } from "./serviceCategory.service";
import { ServiceCategoryControllerBase } from "./base/serviceCategory.controller.base";

@swagger.ApiTags("serviceCategories")
@common.Controller("serviceCategories")
export class ServiceCategoryController extends ServiceCategoryControllerBase {
  constructor(
    protected readonly service: ServiceCategoryService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
