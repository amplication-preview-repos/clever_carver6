import { SortOrder } from "../../util/SortOrder";

export type ReviewOrderByInput = {
  comment?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  rating?: SortOrder;
  serviceProviderId?: SortOrder;
  updatedAt?: SortOrder;
  userId?: SortOrder;
};
