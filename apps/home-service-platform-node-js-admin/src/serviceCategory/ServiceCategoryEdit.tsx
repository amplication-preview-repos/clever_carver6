import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  ReferenceArrayInput,
  SelectArrayInput,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

import { BookingTitle } from "../booking/BookingTitle";
import { ServiceProviderTitle } from "../serviceProvider/ServiceProviderTitle";

export const ServiceCategoryEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <ReferenceArrayInput source="bookings" reference="Booking">
          <SelectArrayInput
            optionText={BookingTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <TextInput label="category_name" source="categoryName" />
        <TextInput label="description" multiline source="description" />
        <ReferenceInput
          source="serviceProvider.id"
          reference="ServiceProvider"
          label="ServiceProvider"
        >
          <SelectInput optionText={ServiceProviderTitle} />
        </ReferenceInput>
      </SimpleForm>
    </Edit>
  );
};
