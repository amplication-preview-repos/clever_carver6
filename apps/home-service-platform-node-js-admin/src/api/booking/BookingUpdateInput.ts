import { AdminUpdateManyWithoutBookingsInput } from "./AdminUpdateManyWithoutBookingsInput";
import { ServiceCategoryWhereUniqueInput } from "../serviceCategory/ServiceCategoryWhereUniqueInput";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";
import { ServiceProviderUpdateManyWithoutBookingsInput } from "./ServiceProviderUpdateManyWithoutBookingsInput";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type BookingUpdateInput = {
  admins?: AdminUpdateManyWithoutBookingsInput;
  bookingDate?: Date | null;
  paymentStatus?: string | null;
  serviceCategory?: ServiceCategoryWhereUniqueInput | null;
  serviceProvider?: ServiceProviderWhereUniqueInput | null;
  serviceProviders?: ServiceProviderUpdateManyWithoutBookingsInput;
  status?: string | null;
  user?: UserWhereUniqueInput | null;
};
