import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { ServiceProviderModuleBase } from "./base/serviceProvider.module.base";
import { ServiceProviderService } from "./serviceProvider.service";
import { ServiceProviderController } from "./serviceProvider.controller";
import { ServiceProviderResolver } from "./serviceProvider.resolver";

@Module({
  imports: [ServiceProviderModuleBase, forwardRef(() => AuthModule)],
  controllers: [ServiceProviderController],
  providers: [ServiceProviderService, ServiceProviderResolver],
  exports: [ServiceProviderService],
})
export class ServiceProviderModule {}
