import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { ServiceProviderServiceBase } from "./base/serviceProvider.service.base";

@Injectable()
export class ServiceProviderService extends ServiceProviderServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
