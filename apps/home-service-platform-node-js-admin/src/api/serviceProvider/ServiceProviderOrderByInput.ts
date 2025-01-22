import { SortOrder } from "../../util/SortOrder";

export type ServiceProviderOrderByInput = {
  availability?: SortOrder;
  bio?: SortOrder;
  bookingId?: SortOrder;
  createdAt?: SortOrder;
  email?: SortOrder;
  hourlyRate?: SortOrder;
  id?: SortOrder;
  name?: SortOrder;
  phone?: SortOrder;
  ratings?: SortOrder;
  reviewId?: SortOrder;
  serviceType?: SortOrder;
  updatedAt?: SortOrder;
};
