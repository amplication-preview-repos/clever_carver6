import { BookingWhereUniqueInput } from "../booking/BookingWhereUniqueInput";
import { BookingCreateNestedManyWithoutServiceProvidersInput } from "./BookingCreateNestedManyWithoutServiceProvidersInput";
import { ReviewWhereUniqueInput } from "../review/ReviewWhereUniqueInput";
import { ReviewCreateNestedManyWithoutServiceProvidersInput } from "./ReviewCreateNestedManyWithoutServiceProvidersInput";
import { ServiceCategoryCreateNestedManyWithoutServiceProvidersInput } from "./ServiceCategoryCreateNestedManyWithoutServiceProvidersInput";

export type ServiceProviderCreateInput = {
  availability?: string | null;
  bio?: string | null;
  booking?: BookingWhereUniqueInput | null;
  bookings?: BookingCreateNestedManyWithoutServiceProvidersInput;
  email?: string | null;
  hourlyRate?: number | null;
  name?: string | null;
  phone?: string | null;
  ratings?: string | null;
  review?: ReviewWhereUniqueInput | null;
  reviews?: ReviewCreateNestedManyWithoutServiceProvidersInput;
  serviceCategories?: ServiceCategoryCreateNestedManyWithoutServiceProvidersInput;
  serviceType?: string | null;
};
