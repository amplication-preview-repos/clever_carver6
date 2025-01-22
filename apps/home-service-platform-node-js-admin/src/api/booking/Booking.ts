import { Admin } from "../admin/Admin";
import { ServiceCategory } from "../serviceCategory/ServiceCategory";
import { ServiceProvider } from "../serviceProvider/ServiceProvider";
import { User } from "../user/User";

export type Booking = {
  admins?: Array<Admin>;
  bookingDate: Date | null;
  createdAt: Date;
  id: string;
  paymentStatus: string | null;
  serviceCategory?: ServiceCategory | null;
  serviceProvider?: ServiceProvider | null;
  serviceProviders?: Array<ServiceProvider>;
  status: string | null;
  updatedAt: Date;
  user?: User | null;
};
