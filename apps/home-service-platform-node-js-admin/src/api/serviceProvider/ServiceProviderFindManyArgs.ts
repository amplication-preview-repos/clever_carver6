import { ServiceProviderWhereInput } from "./ServiceProviderWhereInput";
import { ServiceProviderOrderByInput } from "./ServiceProviderOrderByInput";

export type ServiceProviderFindManyArgs = {
  where?: ServiceProviderWhereInput;
  orderBy?: Array<ServiceProviderOrderByInput>;
  skip?: number;
  take?: number;
};
