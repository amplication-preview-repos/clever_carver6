import { SortOrder } from "../../util/SortOrder";

export type AdminOrderByInput = {
  bookingId?: SortOrder;
  createdAt?: SortOrder;
  email?: SortOrder;
  id?: SortOrder;
  name?: SortOrder;
  permissions?: SortOrder;
  reviewId?: SortOrder;
  role?: SortOrder;
  updatedAt?: SortOrder;
};
