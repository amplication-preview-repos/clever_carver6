import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  TextInput,
  ReferenceInput,
  SelectInput,
  ReferenceArrayInput,
  SelectArrayInput,
  NumberInput,
} from "react-admin";

import { BookingTitle } from "../booking/BookingTitle";
import { ReviewTitle } from "../review/ReviewTitle";
import { ServiceCategoryTitle } from "../serviceCategory/ServiceCategoryTitle";

export const ServiceProviderCreate = (
  props: CreateProps
): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="availability" multiline source="availability" />
        <TextInput label="bio" multiline source="bio" />
        <ReferenceInput source="booking.id" reference="Booking" label="Booking">
          <SelectInput optionText={BookingTitle} />
        </ReferenceInput>
        <ReferenceArrayInput source="bookings" reference="Booking">
          <SelectArrayInput
            optionText={BookingTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <TextInput label="email" source="email" type="email" />
        <NumberInput label="hourly_rate" source="hourlyRate" />
        <TextInput label="name" source="name" />
        <TextInput label="phone" source="phone" />
        <TextInput label="ratings" multiline source="ratings" />
        <ReferenceInput source="review.id" reference="Review" label="Review">
          <SelectInput optionText={ReviewTitle} />
        </ReferenceInput>
        <ReferenceArrayInput source="reviews" reference="Review">
          <SelectArrayInput
            optionText={ReviewTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <ReferenceArrayInput
          source="serviceCategories"
          reference="ServiceCategory"
        >
          <SelectArrayInput
            optionText={ServiceCategoryTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <TextInput label="service_type" source="serviceType" />
      </SimpleForm>
    </Create>
  );
};
