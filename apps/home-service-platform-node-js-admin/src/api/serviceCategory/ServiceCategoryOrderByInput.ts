import { SortOrder } from "../../util/SortOrder";

export type ServiceCategoryOrderByInput = {
  categoryName?: SortOrder;
  createdAt?: SortOrder;
  description?: SortOrder;
  id?: SortOrder;
  serviceProviderId?: SortOrder;
  updatedAt?: SortOrder;
};
