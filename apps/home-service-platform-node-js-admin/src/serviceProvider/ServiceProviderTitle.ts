import { ServiceProvider as TServiceProvider } from "../api/serviceProvider/ServiceProvider";

export const SERVICEPROVIDER_TITLE_FIELD = "name";

export const ServiceProviderTitle = (record: TServiceProvider): string => {
  return record.name?.toString() || String(record.id);
};
