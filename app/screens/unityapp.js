import React from "react";
import {
  StyleSheet,
  Image,
  View,
  PixelRatio,
  Text,
  Button,
  Alert
} from "react-native";
import {
  DeviceEventEmitter // will emit events that you can listen to
} from "react-native";

import { SensorManager } from "NativeModules";
import UnityView from "react-native-unity-view";
import { withGlobalContext } from "../config/context";

// More info on all the options is below in the API Reference... just some common use cases shown here

/**
 * The first arg is the options object for customization (it can also be null or omitted for default options),
 * The second arg is the callback which sends object: response (more info in the API Reference)
 */

class App extends React.Component {
  componentDidMount() {
    if (this.unity) {
      this.unity.postMessageToUnityManager({
        name: "Base64",
        data: this.props.global.b64
      });
    }
  }
  onMessage(event) {
    alert(event); // OnUnityMessage: click
  }
  render() {
    const { navigation } = this.props;
    DeviceEventEmitter.addListener("Gyroscope", function(data) {
      /**
       * data.x
       * data.y
       * data.z
       **/
    });
    SensorManager.startGyroscope(100);
    return (
      <View style={styles.container}>
        <UnityView
          ref={ref => (this.unity = ref)}
          style={{ position: "absolute", left: 0, right: 0, top: 0, bottom: 0 }}
          onMessage={this.onMessage.bind(this)}
        />
        <Text>data.</Text>
      </View>
    );
  }
}

export default withGlobalContext(App);

const styles = StyleSheet.create({
  container: {
    flex: 1,
    borderRadius: 4,
    borderWidth: 0.5,
    borderColor: "#d6d7da"
  },
  avatarContainer: {
    borderColor: "#9B9B9B",
    borderWidth: 1 / PixelRatio.get(),
    justifyContent: "center",
    alignItems: "center"
  },
  avatar: {
    borderRadius: 75,
    width: 150,
    height: 150
  }
});
