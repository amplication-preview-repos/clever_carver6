import React, { useEffect, useState } from "react";
import { Admin, DataProvider, Resource } from "react-admin";
import dataProvider from "./data-provider/graphqlDataProvider";
import { theme } from "./theme/theme";
import Login from "./Login";
import "./App.scss";
import Dashboard from "./pages/Dashboard";
import { ServiceProviderList } from "./serviceProvider/ServiceProviderList";
import { ServiceProviderCreate } from "./serviceProvider/ServiceProviderCreate";
import { ServiceProviderEdit } from "./serviceProvider/ServiceProviderEdit";
import { ServiceProviderShow } from "./serviceProvider/ServiceProviderShow";
import { ServiceCategoryList } from "./serviceCategory/ServiceCategoryList";
import { ServiceCategoryCreate } from "./serviceCategory/ServiceCategoryCreate";
import { ServiceCategoryEdit } from "./serviceCategory/ServiceCategoryEdit";
import { ServiceCategoryShow } from "./serviceCategory/ServiceCategoryShow";
import { AdminList } from "./admin/AdminList";
import { AdminCreate } from "./admin/AdminCreate";
import { AdminEdit } from "./admin/AdminEdit";
import { AdminShow } from "./admin/AdminShow";
import { BookingList } from "./booking/BookingList";
import { BookingCreate } from "./booking/BookingCreate";
import { BookingEdit } from "./booking/BookingEdit";
import { BookingShow } from "./booking/BookingShow";
import { ReviewList } from "./review/ReviewList";
import { ReviewCreate } from "./review/ReviewCreate";
import { ReviewEdit } from "./review/ReviewEdit";
import { ReviewShow } from "./review/ReviewShow";
import { UserList } from "./user/UserList";
import { UserCreate } from "./user/UserCreate";
import { UserEdit } from "./user/UserEdit";
import { UserShow } from "./user/UserShow";
import { jwtAuthProvider } from "./auth-provider/ra-auth-jwt";

const App = (): React.ReactElement => {
  return (
    <div className="App">
      <Admin
        title={"HomeServicePlatformNodeJS"}
        dataProvider={dataProvider}
        authProvider={jwtAuthProvider}
        theme={theme}
        dashboard={Dashboard}
        loginPage={Login}
      >
        <Resource
          name="ServiceProvider"
          list={ServiceProviderList}
          edit={ServiceProviderEdit}
          create={ServiceProviderCreate}
          show={ServiceProviderShow}
        />
        <Resource
          name="ServiceCategory"
          list={ServiceCategoryList}
          edit={ServiceCategoryEdit}
          create={ServiceCategoryCreate}
          show={ServiceCategoryShow}
        />
        <Resource
          name="Admin"
          list={AdminList}
          edit={AdminEdit}
          create={AdminCreate}
          show={AdminShow}
        />
        <Resource
          name="Booking"
          list={BookingList}
          edit={BookingEdit}
          create={BookingCreate}
          show={BookingShow}
        />
        <Resource
          name="Review"
          list={ReviewList}
          edit={ReviewEdit}
          create={ReviewCreate}
          show={ReviewShow}
        />
        <Resource
          name="User"
          list={UserList}
          edit={UserEdit}
          create={UserCreate}
          show={UserShow}
        />
      </Admin>
    </div>
  );
};

export default App;
