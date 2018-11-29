import React from "react";
import StackNavigator from "./app/config/routes";
import { GlobalContextProvider } from "./app/config/context";
export default class App extends React.Component {
  render() {
    return (
      <GlobalContextProvider>
        <StackNavigator />
      </GlobalContextProvider>
    );
  }
}
