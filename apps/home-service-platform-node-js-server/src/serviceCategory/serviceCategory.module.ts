import { Module, forwardRef } from "@nestjs/common";
import { AuthModule } from "../auth/auth.module";
import { ServiceCategoryModuleBase } from "./base/serviceCategory.module.base";
import { ServiceCategoryService } from "./serviceCategory.service";
import { ServiceCategoryController } from "./serviceCategory.controller";
import { ServiceCategoryResolver } from "./serviceCategory.resolver";

@Module({
  imports: [ServiceCategoryModuleBase, forwardRef(() => AuthModule)],
  controllers: [ServiceCategoryController],
  providers: [ServiceCategoryService, ServiceCategoryResolver],
  exports: [ServiceCategoryService],
})
export class ServiceCategoryModule {}
