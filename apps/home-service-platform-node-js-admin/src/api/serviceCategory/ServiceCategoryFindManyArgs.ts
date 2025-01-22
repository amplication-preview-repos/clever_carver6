import { ServiceCategoryWhereInput } from "./ServiceCategoryWhereInput";
import { ServiceCategoryOrderByInput } from "./ServiceCategoryOrderByInput";

export type ServiceCategoryFindManyArgs = {
  where?: ServiceCategoryWhereInput;
  orderBy?: Array<ServiceCategoryOrderByInput>;
  skip?: number;
  take?: number;
};
