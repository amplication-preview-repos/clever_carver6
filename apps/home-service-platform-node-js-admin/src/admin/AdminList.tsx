import * as React from "react";
import {
  List,
  Datagrid,
  ListProps,
  ReferenceField,
  TextField,
  DateField,
} from "react-admin";
import Pagination from "../Components/Pagination";
import { BOOKING_TITLE_FIELD } from "../booking/BookingTitle";
import { REVIEW_TITLE_FIELD } from "../review/ReviewTitle";

export const AdminList = (props: ListProps): React.ReactElement => {
  return (
    <List {...props} title={"Admins"} perPage={50} pagination={<Pagination />}>
      <Datagrid rowClick="show" bulkActionButtons={false}>
        <ReferenceField label="Booking" source="booking.id" reference="Booking">
          <TextField source={BOOKING_TITLE_FIELD} />
        </ReferenceField>
        <DateField source="createdAt" label="Created At" />
        <TextField label="email" source="email" />
        <TextField label="ID" source="id" />
        <TextField label="name" source="name" />
        <TextField label="permissions" source="permissions" />
        <ReferenceField label="Review" source="review.id" reference="Review">
          <TextField source={REVIEW_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="role" source="role" />
        <DateField source="updatedAt" label="Updated At" />{" "}
      </Datagrid>
    </List>
  );
};
