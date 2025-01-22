import { BookingUpdateManyWithoutServiceCategoriesInput } from "./BookingUpdateManyWithoutServiceCategoriesInput";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";

export type ServiceCategoryUpdateInput = {
  bookings?: BookingUpdateManyWithoutServiceCategoriesInput;
  categoryName?: string | null;
  description?: string | null;
  serviceProvider?: ServiceProviderWhereUniqueInput | null;
};
