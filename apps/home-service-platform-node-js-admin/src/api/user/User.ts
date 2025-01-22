import { Booking } from "../booking/Booking";
import { Review } from "../review/Review";
import { JsonValue } from "type-fest";

export type User = {
  address: string | null;
  bookings?: Array<Booking>;
  createdAt: Date;
  email: string | null;
  firstName: string | null;
  id: string;
  lastName: string | null;
  name: string | null;
  paymentMethods: string | null;
  phone: string | null;
  reviews?: Array<Review>;
  roles: JsonValue;
  updatedAt: Date;
  username: string;
};
