import { Booking as TBooking } from "../api/booking/Booking";

export const BOOKING_TITLE_FIELD = "paymentStatus";

export const BookingTitle = (record: TBooking): string => {
  return record.paymentStatus?.toString() || String(record.id);
};
