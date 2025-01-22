import { StringNullableFilter } from "../../util/StringNullableFilter";
import { BookingWhereUniqueInput } from "../booking/BookingWhereUniqueInput";
import { BookingListRelationFilter } from "../booking/BookingListRelationFilter";
import { FloatNullableFilter } from "../../util/FloatNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { ReviewWhereUniqueInput } from "../review/ReviewWhereUniqueInput";
import { ReviewListRelationFilter } from "../review/ReviewListRelationFilter";
import { ServiceCategoryListRelationFilter } from "../serviceCategory/ServiceCategoryListRelationFilter";

export type ServiceProviderWhereInput = {
  availability?: StringNullableFilter;
  bio?: StringNullableFilter;
  booking?: BookingWhereUniqueInput;
  bookings?: BookingListRelationFilter;
  email?: StringNullableFilter;
  hourlyRate?: FloatNullableFilter;
  id?: StringFilter;
  name?: StringNullableFilter;
  phone?: StringNullableFilter;
  ratings?: StringNullableFilter;
  review?: ReviewWhereUniqueInput;
  reviews?: ReviewListRelationFilter;
  serviceCategories?: ServiceCategoryListRelationFilter;
  serviceType?: StringNullableFilter;
};
