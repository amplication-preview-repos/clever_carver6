import * as React from "react";
import {
  Create,
  SimpleForm,
  CreateProps,
  ReferenceInput,
  SelectInput,
  TextInput,
} from "react-admin";
import { BookingTitle } from "../booking/BookingTitle";
import { ReviewTitle } from "../review/ReviewTitle";

export const AdminCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <ReferenceInput source="booking.id" reference="Booking" label="Booking">
          <SelectInput optionText={BookingTitle} />
        </ReferenceInput>
        <TextInput label="email" source="email" type="email" />
        <TextInput label="name" source="name" />
        <TextInput label="permissions" multiline source="permissions" />
        <ReferenceInput source="review.id" reference="Review" label="Review">
          <SelectInput optionText={ReviewTitle} />
        </ReferenceInput>
        <TextInput label="role" source="role" />
      </SimpleForm>
    </Create>
  );
};
