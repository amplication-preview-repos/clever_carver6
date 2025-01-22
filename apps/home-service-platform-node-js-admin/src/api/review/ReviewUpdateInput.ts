import { AdminUpdateManyWithoutReviewsInput } from "./AdminUpdateManyWithoutReviewsInput";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";
import { ServiceProviderUpdateManyWithoutReviewsInput } from "./ServiceProviderUpdateManyWithoutReviewsInput";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type ReviewUpdateInput = {
  admins?: AdminUpdateManyWithoutReviewsInput;
  comment?: string | null;
  rating?: number | null;
  serviceProvider?: ServiceProviderWhereUniqueInput | null;
  serviceProviders?: ServiceProviderUpdateManyWithoutReviewsInput;
  user?: UserWhereUniqueInput | null;
};
