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
import { SERVICECATEGORY_TITLE_FIELD } from "../serviceCategory/ServiceCategoryTitle";
import { SERVICEPROVIDER_TITLE_FIELD } from "../serviceProvider/ServiceProviderTitle";
import { USER_TITLE_FIELD } from "../user/UserTitle";

export const BookingList = (props: ListProps): React.ReactElement => {
  return (
    <List
      {...props}
      title={"Bookings"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show" bulkActionButtons={false}>
        <TextField label="booking_date" source="bookingDate" />
        <DateField source="createdAt" label="Created At" />
        <TextField label="ID" source="id" />
        <TextField label="payment_status" source="paymentStatus" />
        <ReferenceField
          label="ServiceCategory"
          source="servicecategory.id"
          reference="ServiceCategory"
        >
          <TextField source={SERVICECATEGORY_TITLE_FIELD} />
        </ReferenceField>
        <ReferenceField
          label="ServiceProvider"
          source="serviceprovider.id"
          reference="ServiceProvider"
        >
          <TextField source={SERVICEPROVIDER_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="status" source="status" />
        <DateField source="updatedAt" label="Updated At" />
        <ReferenceField label="User" source="user.id" reference="User">
          <TextField source={USER_TITLE_FIELD} />
        </ReferenceField>{" "}
      </Datagrid>
    </List>
  );
};
