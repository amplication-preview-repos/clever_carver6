import { BookingCreateNestedManyWithoutServiceCategoriesInput } from "./BookingCreateNestedManyWithoutServiceCategoriesInput";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";

export type ServiceCategoryCreateInput = {
  bookings?: BookingCreateNestedManyWithoutServiceCategoriesInput;
  categoryName?: string | null;
  description?: string | null;
  serviceProvider?: ServiceProviderWhereUniqueInput | null;
};
