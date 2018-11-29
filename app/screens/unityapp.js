import React from "react";
import {
  StyleSheet,
  Image,
  View,
  PixelRatio,
  Text,
  Button
} from "react-native";
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
      // gameobject param also can be 'Cube'.
      this.unity.postMessageToUnityManager(this.props.global.b64);
    }
  }
  render() {
    const { navigation } = this.props;
    return (
      <View style={styles.container}>
        <UnityView
          ref={ref => (this.unity = ref)}
          style={{ position: "absolute", left: 0, right: 0, top: 0, bottom: 0 }}
        />
        <Text>Is online: {this.props.global.b64}</Text>
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
