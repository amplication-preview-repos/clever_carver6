import { BookingWhereUniqueInput } from "../booking/BookingWhereUniqueInput";
import { ReviewWhereUniqueInput } from "../review/ReviewWhereUniqueInput";

export type AdminUpdateInput = {
  booking?: BookingWhereUniqueInput | null;
  email?: string | null;
  name?: string | null;
  permissions?: string | null;
  review?: ReviewWhereUniqueInput | null;
  role?: string | null;
};
