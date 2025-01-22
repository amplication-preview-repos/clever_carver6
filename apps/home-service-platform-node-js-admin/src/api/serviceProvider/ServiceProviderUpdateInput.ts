import { BookingWhereUniqueInput } from "../booking/BookingWhereUniqueInput";
import { BookingUpdateManyWithoutServiceProvidersInput } from "./BookingUpdateManyWithoutServiceProvidersInput";
import { ReviewWhereUniqueInput } from "../review/ReviewWhereUniqueInput";
import { ReviewUpdateManyWithoutServiceProvidersInput } from "./ReviewUpdateManyWithoutServiceProvidersInput";
import { ServiceCategoryUpdateManyWithoutServiceProvidersInput } from "./ServiceCategoryUpdateManyWithoutServiceProvidersInput";

export type ServiceProviderUpdateInput = {
  availability?: string | null;
  bio?: string | null;
  booking?: BookingWhereUniqueInput | null;
  bookings?: BookingUpdateManyWithoutServiceProvidersInput;
  email?: string | null;
  hourlyRate?: number | null;
  name?: string | null;
  phone?: string | null;
  ratings?: string | null;
  review?: ReviewWhereUniqueInput | null;
  reviews?: ReviewUpdateManyWithoutServiceProvidersInput;
  serviceCategories?: ServiceCategoryUpdateManyWithoutServiceProvidersInput;
  serviceType?: string | null;
};
