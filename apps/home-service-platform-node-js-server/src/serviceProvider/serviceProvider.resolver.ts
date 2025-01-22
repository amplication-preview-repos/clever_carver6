import * as graphql from "@nestjs/graphql";
import * as nestAccessControl from "nest-access-control";
import * as gqlACGuard from "../auth/gqlAC.guard";
import { GqlDefaultAuthGuard } from "../auth/gqlDefaultAuth.guard";
import * as common from "@nestjs/common";
import { ServiceProviderResolverBase } from "./base/serviceProvider.resolver.base";
import { ServiceProvider } from "./base/ServiceProvider";
import { ServiceProviderService } from "./serviceProvider.service";

@common.UseGuards(GqlDefaultAuthGuard, gqlACGuard.GqlACGuard)
@graphql.Resolver(() => ServiceProvider)
export class ServiceProviderResolver extends ServiceProviderResolverBase {
  constructor(
    protected readonly service: ServiceProviderService,
    @nestAccessControl.InjectRolesBuilder()
    protected readonly rolesBuilder: nestAccessControl.RolesBuilder
  ) {
    super(service, rolesBuilder);
  }
}
