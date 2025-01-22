import { AdminCreateNestedManyWithoutBookingsInput } from "./AdminCreateNestedManyWithoutBookingsInput";
import { ServiceCategoryWhereUniqueInput } from "../serviceCategory/ServiceCategoryWhereUniqueInput";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";
import { ServiceProviderCreateNestedManyWithoutBookingsInput } from "./ServiceProviderCreateNestedManyWithoutBookingsInput";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type BookingCreateInput = {
  admins?: AdminCreateNestedManyWithoutBookingsInput;
  bookingDate?: Date | null;
  paymentStatus?: string | null;
  serviceCategory?: ServiceCategoryWhereUniqueInput | null;
  serviceProvider?: ServiceProviderWhereUniqueInput | null;
  serviceProviders?: ServiceProviderCreateNestedManyWithoutBookingsInput;
  status?: string | null;
  user?: UserWhereUniqueInput | null;
};
