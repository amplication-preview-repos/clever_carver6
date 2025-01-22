import * as React from "react";
import {
  List,
  Datagrid,
  ListProps,
  TextField,
  ReferenceField,
  DateField,
} from "react-admin";
import Pagination from "../Components/Pagination";
import { BOOKING_TITLE_FIELD } from "../booking/BookingTitle";
import { REVIEW_TITLE_FIELD } from "../review/ReviewTitle";

export const ServiceProviderList = (props: ListProps): React.ReactElement => {
  return (
    <List
      {...props}
      title={"ServiceProviders"}
      perPage={50}
      pagination={<Pagination />}
    >
      <Datagrid rowClick="show" bulkActionButtons={false}>
        <TextField label="availability" source="availability" />
        <TextField label="bio" source="bio" />
        <ReferenceField label="Booking" source="booking.id" reference="Booking">
          <TextField source={BOOKING_TITLE_FIELD} />
        </ReferenceField>
        <DateField source="createdAt" label="Created At" />
        <TextField label="email" source="email" />
        <TextField label="hourly_rate" source="hourlyRate" />
        <TextField label="ID" source="id" />
        <TextField label="name" source="name" />
        <TextField label="phone" source="phone" />
        <TextField label="ratings" source="ratings" />
        <ReferenceField label="Review" source="review.id" reference="Review">
          <TextField source={REVIEW_TITLE_FIELD} />
        </ReferenceField>
        <TextField label="service_type" source="serviceType" />
        <DateField source="updatedAt" label="Updated At" />{" "}
      </Datagrid>
    </List>
  );
};
