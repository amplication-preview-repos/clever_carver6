import { AdminListRelationFilter } from "../admin/AdminListRelationFilter";
import { StringNullableFilter } from "../../util/StringNullableFilter";
import { StringFilter } from "../../util/StringFilter";
import { IntNullableFilter } from "../../util/IntNullableFilter";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";
import { ServiceProviderListRelationFilter } from "../serviceProvider/ServiceProviderListRelationFilter";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type ReviewWhereInput = {
  admins?: AdminListRelationFilter;
  comment?: StringNullableFilter;
  id?: StringFilter;
  rating?: IntNullableFilter;
  serviceProvider?: ServiceProviderWhereUniqueInput;
  serviceProviders?: ServiceProviderListRelationFilter;
  user?: UserWhereUniqueInput;
};
