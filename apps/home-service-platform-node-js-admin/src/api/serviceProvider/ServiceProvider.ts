import { Booking } from "../booking/Booking";
import { Review } from "../review/Review";
import { ServiceCategory } from "../serviceCategory/ServiceCategory";

export type ServiceProvider = {
  availability: string | null;
  bio: string | null;
  booking?: Booking | null;
  bookings?: Array<Booking>;
  createdAt: Date;
  email: string | null;
  hourlyRate: number | null;
  id: string;
  name: string | null;
  phone: string | null;
  ratings: string | null;
  review?: Review | null;
  reviews?: Array<Review>;
  serviceCategories?: Array<ServiceCategory>;
  serviceType: string | null;
  updatedAt: Date;
};
