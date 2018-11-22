import React from "react";
import { createStackNavigator, StackNavigator } from "react-navigation";

import Home from "../screens/home";
import Options from "../screens/options";
import UnityApp from "../screens/unityapp";

const optionsGeneral = {
  mode: "modal",
  headerMode: "none"
};

const HomeStack = createStackNavigator({
  Home: {
    screen: Home,
    navigationOptions: {
      header: () => null
    }
  },
  UnityApp: {
    screen: UnityApp,
    navigationOptions: {
      headerTitle: "Unity Application"
    }
  },
  Options: {
    screen: Options,
    navigationOptions: {
      headerTitle: "Options"
    }
  }
});

export default createStackNavigator(
  {
    Home: {
      screen: HomeStack
    }
  },
  optionsGeneral
);
