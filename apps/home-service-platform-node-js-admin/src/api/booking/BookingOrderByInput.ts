import { SortOrder } from "../../util/SortOrder";

export type BookingOrderByInput = {
  bookingDate?: SortOrder;
  createdAt?: SortOrder;
  id?: SortOrder;
  paymentStatus?: SortOrder;
  serviceCategoryId?: SortOrder;
  serviceProviderId?: SortOrder;
  status?: SortOrder;
  updatedAt?: SortOrder;
  userId?: SortOrder;
};
