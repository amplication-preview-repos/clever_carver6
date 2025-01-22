import { Booking } from "../booking/Booking";
import { ServiceProvider } from "../serviceProvider/ServiceProvider";

export type ServiceCategory = {
  bookings?: Array<Booking>;
  categoryName: string | null;
  createdAt: Date;
  description: string | null;
  id: string;
  serviceProvider?: ServiceProvider | null;
  updatedAt: Date;
};
