import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  ReferenceArrayInput,
  SelectArrayInput,
  DateTimeInput,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

import { AdminTitle } from "../admin/AdminTitle";
import { ServiceCategoryTitle } from "../serviceCategory/ServiceCategoryTitle";
import { ServiceProviderTitle } from "../serviceProvider/ServiceProviderTitle";
import { UserTitle } from "../user/UserTitle";

export const BookingEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <ReferenceArrayInput source="admins" reference="Admin">
          <SelectArrayInput
            optionText={AdminTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <DateTimeInput label="booking_date" source="bookingDate" />
        <TextInput label="payment_status" source="paymentStatus" />
        <ReferenceInput
          source="serviceCategory.id"
          reference="ServiceCategory"
          label="ServiceCategory"
        >
          <SelectInput optionText={ServiceCategoryTitle} />
        </ReferenceInput>
        <ReferenceInput
          source="serviceProvider.id"
          reference="ServiceProvider"
          label="ServiceProvider"
        >
          <SelectInput optionText={ServiceProviderTitle} />
        </ReferenceInput>
        <ReferenceArrayInput
          source="serviceProviders"
          reference="ServiceProvider"
        >
          <SelectArrayInput
            optionText={ServiceProviderTitle}
            parse={(value: any) => value && value.map((v: any) => ({ id: v }))}
            format={(value: any) => value && value.map((v: any) => v.id)}
          />
        </ReferenceArrayInput>
        <TextInput label="status" source="status" />
        <ReferenceInput source="user.id" reference="User" label="User">
          <SelectInput optionText={UserTitle} />
        </ReferenceInput>
      </SimpleForm>
    </Edit>
  );
};
