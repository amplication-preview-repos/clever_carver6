import { ServiceCategory as TServiceCategory } from "../api/serviceCategory/ServiceCategory";

export const SERVICECATEGORY_TITLE_FIELD = "categoryName";

export const ServiceCategoryTitle = (record: TServiceCategory): string => {
  return record.categoryName?.toString() || String(record.id);
};
