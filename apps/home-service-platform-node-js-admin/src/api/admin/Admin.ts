import { Booking } from "../booking/Booking";
import { Review } from "../review/Review";

export type Admin = {
  booking?: Booking | null;
  createdAt: Date;
  email: string | null;
  id: string;
  name: string | null;
  permissions: string | null;
  review?: Review | null;
  role: string | null;
  updatedAt: Date;
};
