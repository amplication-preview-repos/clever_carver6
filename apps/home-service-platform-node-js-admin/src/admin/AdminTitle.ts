import { Admin as TAdmin } from "../api/admin/Admin";

export const ADMIN_TITLE_FIELD = "name";

export const AdminTitle = (record: TAdmin): string => {
  return record.name?.toString() || String(record.id);
};
