import { AdminCreateNestedManyWithoutReviewsInput } from "./AdminCreateNestedManyWithoutReviewsInput";
import { ServiceProviderWhereUniqueInput } from "../serviceProvider/ServiceProviderWhereUniqueInput";
import { ServiceProviderCreateNestedManyWithoutReviewsInput } from "./ServiceProviderCreateNestedManyWithoutReviewsInput";
import { UserWhereUniqueInput } from "../user/UserWhereUniqueInput";

export type ReviewCreateInput = {
  admins?: AdminCreateNestedManyWithoutReviewsInput;
  comment?: string | null;
  rating?: number | null;
  serviceProvider?: ServiceProviderWhereUniqueInput | null;
  serviceProviders?: ServiceProviderCreateNestedManyWithoutReviewsInput;
  user?: UserWhereUniqueInput | null;
};
