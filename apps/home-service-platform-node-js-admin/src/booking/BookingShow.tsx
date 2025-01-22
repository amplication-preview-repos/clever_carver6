import * as React from "react";

import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  DateField,
  ReferenceField,
  ReferenceManyField,
  Datagrid,
} from "react-admin";

import { BOOKING_TITLE_FIELD } from "./BookingTitle";
import { REVIEW_TITLE_FIELD } from "../review/ReviewTitle";
import { SERVICECATEGORY_TITLE_FIELD } from "../serviceCategory/ServiceCategoryTitle";
import { SERVICEPROVIDER_TITLE_FIELD } from "../serviceProvider/ServiceProviderTitle";
import { USER_TITLE_FIELD } from "../user/UserTitle";

export const BookingShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
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
        </ReferenceField>
        <ReferenceManyField reference="Admin" target="bookingId" label="Admins">
          <Datagrid rowClick="show" bulkActionButtons={false}>
            <ReferenceField
              label="Booking"
              source="booking.id"
              reference="Booking"
            >
              <TextField source={BOOKING_TITLE_FIELD} />
            </ReferenceField>
            <DateField source="createdAt" label="Created At" />
            <TextField label="email" source="email" />
            <TextField label="ID" source="id" />
            <TextField label="name" source="name" />
            <TextField label="permissions" source="permissions" />
            <ReferenceField
              label="Review"
              source="review.id"
              reference="Review"
            >
              <TextField source={REVIEW_TITLE_FIELD} />
            </ReferenceField>
            <TextField label="role" source="role" />
            <DateField source="updatedAt" label="Updated At" />
          </Datagrid>
        </ReferenceManyField>
        <ReferenceManyField
          reference="ServiceProvider"
          target="bookingId"
          label="ServiceProviders"
        >
          <Datagrid rowClick="show" bulkActionButtons={false}>
            <TextField label="availability" source="availability" />
            <TextField label="bio" source="bio" />
            <ReferenceField
              label="Booking"
              source="booking.id"
              reference="Booking"
            >
              <TextField source={BOOKING_TITLE_FIELD} />
            </ReferenceField>
            <DateField source="createdAt" label="Created At" />
            <TextField label="email" source="email" />
            <TextField label="hourly_rate" source="hourlyRate" />
            <TextField label="ID" source="id" />
            <TextField label="name" source="name" />
            <TextField label="phone" source="phone" />
            <TextField label="ratings" source="ratings" />
            <ReferenceField
              label="Review"
              source="review.id"
              reference="Review"
            >
              <TextField source={REVIEW_TITLE_FIELD} />
            </ReferenceField>
            <TextField label="service_type" source="serviceType" />
            <DateField source="updatedAt" label="Updated At" />
          </Datagrid>
        </ReferenceManyField>
      </SimpleShowLayout>
    </Show>
  );
};
