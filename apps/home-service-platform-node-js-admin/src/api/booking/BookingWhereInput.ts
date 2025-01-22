import { AdminListRelationFilter } from "../admin/AdminListRelationFilter";
import { DateTimeNullableFilter } from "../../util/DateTimeNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { ServiceCategoryWhereUniqueInput } from "../serviceCategory/ServiceCategoryWhereUniqueInput";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";
import { ServiceProviderListRelationFilter } from "../serviceProvider/ServiceProviderListRelationFilter";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type BookingWhereInput = {
  admins?: AdminListRelationFilter;
  bookingDate?: DateTimeNullableFilter;
  id?: StringFilter;
  paymentStatus?: StringNullableFilter;
  serviceCategory?: ServiceCategoryWhereUniqueInput;
  serviceProvider?: ServiceProviderWhereUniqueInput;
  serviceProviders?: ServiceProviderListRelationFilter;
  status?: StringNullableFilter;
  user?: UserWhereUniqueInput;
};
