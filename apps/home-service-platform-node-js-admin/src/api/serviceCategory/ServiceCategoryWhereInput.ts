import { BookingListRelationFilter } from "../booking/BookingListRelationFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";

export type ServiceCategoryWhereInput = {
  bookings?: BookingListRelationFilter;
  categoryName?: StringNullableFilter;
  description?: StringNullableFilter;
  id?: StringFilter;
  serviceProvider?: ServiceProviderWhereUniqueInput;
};
