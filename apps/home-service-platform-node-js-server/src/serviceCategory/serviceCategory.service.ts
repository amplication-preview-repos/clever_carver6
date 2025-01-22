import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { ServiceCategoryServiceBase } from "./base/serviceCategory.service.base";

@Injectable()
export class ServiceCategoryService extends ServiceCategoryServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
