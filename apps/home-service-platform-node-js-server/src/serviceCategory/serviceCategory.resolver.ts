import * as graphql from "@nestjs/graphql";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { ServiceCategoryResolverBase } from "./base/serviceCategory.resolver.base";
import { ServiceCategory } from "./base/ServiceCategory";
import { ServiceCategoryService } from "./serviceCategory.service";

@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => ServiceCategory)
export class ServiceCategoryResolver extends ServiceCategoryResolverBase {
  constructor(
    protected readonly service: ServiceCategoryService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
