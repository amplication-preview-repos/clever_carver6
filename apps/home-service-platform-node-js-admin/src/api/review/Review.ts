import { Admin } from "../admin/Admin";
import { ServiceProvider } from "../serviceProvider/ServiceProvider";
import { User } from "../user/User";

export type Review = {
  admins?: Array<Admin>;
  comment: string | null;
  createdAt: Date;
  id: string;
  rating: number | null;
  serviceProvider?: ServiceProvider | null;
  serviceProviders?: Array<ServiceProvider>;
  updatedAt: Date;
  user?: User | null;
};
