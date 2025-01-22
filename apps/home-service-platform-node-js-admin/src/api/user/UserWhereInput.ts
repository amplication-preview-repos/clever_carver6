import { StringNullableFilter } from "../../util/StringNullableFilter";
import { BookingListRelationFilter } from "../booking/BookingListRelationFilter";
import { StringFilter } from "../../util/StringFilter";
import { ReviewListRelationFilter } from "../review/ReviewListRelationFilter";

export type UserWhereInput = {
  address?: StringNullableFilter;
  bookings?: BookingListRelationFilter;
  email?: StringNullableFilter;
  firstName?: StringNullableFilter;
  id?: StringFilter;
  lastName?: StringNullableFilter;
  name?: StringNullableFilter;
  paymentMethods?: StringNullableFilter;
  phone?: StringNullableFilter;
  reviews?: ReviewListRelationFilter;
  username?: StringFilter;
};
