import { BookingWhereUniqueInput } from "../booking/BookingWhereUniqueInput";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { ReviewWhereUniqueInput } from "../review/ReviewWhereUniqueInput";

export type AdminWhereInput = {
  booking?: BookingWhereUniqueInput;
  email?: StringNullableFilter;
  id?: StringFilter;
  name?: StringNullableFilter;
  permissions?: StringNullableFilter;
  review?: ReviewWhereUniqueInput;
  role?: StringNullableFilter;
};
