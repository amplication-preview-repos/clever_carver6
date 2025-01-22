import * as React from "react";
import {
  List,
  Datagrid,
  ListProps,
  TextField,
  DateField,
  ReferenceField,
} from "react-admin";
import Pagination from "../Components/Pagination";
import { SERVICEPROVIDER_TITLE_FIELD } from "../serviceProvider/ServiceProviderTitle";

export const ServiceCategoryList = (props: ListProps): React.ReactElement => {
  return (
    <List
      {...props}
      title={"ServiceCategories"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show" bulkActionButtons={false}>
        <TextField label="category_name" source="categoryName" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="description" source="description" />
        <TextField label="ID" source="id" />
        <ReferenceField
          label="ServiceProvider"
          source="serviceprovider.id"
          reference="ServiceProvider"
        >
          <TextField source={SERVICEPROVIDER_TITLE_FIELD} />
        </ReferenceField>
        <DateField source="updatedAt" label="Updated At" />{" "}
      </Datagrid>
    </List>
  );
};
