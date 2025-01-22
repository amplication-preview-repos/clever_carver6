import * as React from "react";
import {
  Show,
  SimpleShowLayout,
  ShowProps,
  ReferenceField,
  TextField,
  DateField,
} from "react-admin";
import { BOOKING_TITLE_FIELD } from "../booking/BookingTitle";
import { REVIEW_TITLE_FIELD } from "../review/ReviewTitle";

export const AdminShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
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
        <DateField source="updatedAt" label="Updated At" />
      </SimpleShowLayout>
    </Show>
  );
};
