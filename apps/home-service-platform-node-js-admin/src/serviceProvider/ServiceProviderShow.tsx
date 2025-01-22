import * as React from "react";

import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  ReferenceField,
  DateField,
  ReferenceManyField,
  Datagrid,
} from "react-admin";

import { SERVICECATEGORY_TITLE_FIELD } from "../serviceCategory/ServiceCategoryTitle";
import { SERVICEPROVIDER_TITLE_FIELD } from "./ServiceProviderTitle";
import { USER_TITLE_FIELD } from "../user/UserTitle";
import { BOOKING_TITLE_FIELD } from "../booking/BookingTitle";
import { REVIEW_TITLE_FIELD } from "../review/ReviewTitle";

export const ServiceProviderShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
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
        <DateField source="updatedAt" label="Updated At" />
        <ReferenceManyField
          reference="Booking"
          target="serviceProviderId"
          label="Bookings"
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
            </ReferenceField>
          </Datagrid>
        </ReferenceManyField>
        <ReferenceManyField
          reference="Review"
          target="serviceProviderId"
          label="Reviews"
        >
          <Datagrid rowClick="show" bulkActionButtons={false}>
            <TextField label="comment" source="comment" />
            <DateField source="createdAt" label="Created At" />
            <TextField label="ID" source="id" />
            <TextField label="rating" source="rating" />
            <ReferenceField
              label="ServiceProvider"
              source="serviceprovider.id"
              reference="ServiceProvider"
            >
              <TextField source={SERVICEPROVIDER_TITLE_FIELD} />
            </ReferenceField>
            <DateField source="updatedAt" label="Updated At" />
            <ReferenceField label="User" source="user.id" reference="User">
              <TextField source={USER_TITLE_FIELD} />
            </ReferenceField>
          </Datagrid>
        </ReferenceManyField>
        <ReferenceManyField
          reference="ServiceCategory"
          target="serviceProviderId"
          label="ServiceCategories"
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
            <DateField source="updatedAt" label="Updated At" />
          </Datagrid>
        </ReferenceManyField>
      </SimpleShowLayout>
    </Show>
  );
};
