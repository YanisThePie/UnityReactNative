import React, { Component } from "react";
import {
  View,
  StyleSheet,
  Text,
  Button,
  PixelRatio,
  TouchableOpacity,
  Image
} from "react-native";
import PropTypes from "prop-types";
import styled from "styled-components";
import ImgToBase64 from "react-native-image-base64";
import ImagePicker from "react-native-image-picker";
import { withGlobalContext } from "../config/context";
import GlobalContext from "../config/context";

// More info on all the options is below in the API Reference... just some common use cases shown here

const BackgroundView = styled.View`
  background-color: #baffc9;
  flex: 1;
  justify-content: center;
  align-items: center;
`;

const ButtonContainer = styled.View`
  flex-direction: row;
`;

export default class App extends Component {
  constructor(props) {
    super(props);

    this.selectPhotoTapped = this.selectPhotoTapped.bind(this);
  }

  state = {
    avatarSource: null,
    b64: null
  };

  selectPhotoTapped() {
    const options = {
      quality: 1.0,
      maxWidth: 500,
      maxHeight: 500,
      storageOptions: {
        skipBackup: true
      }
    };

    ImagePicker.showImagePicker(options, response => {
      console.log("Response = ", response);

      if (response.didCancel) {
        console.log("User cancelled image picker");
      } else if (response.error) {
        console.log("ImagePicker Error: ", response.error);
      } else if (response.customButton) {
        console.log("User tapped custom button: ", response.customButton);
      } else {
        const source = { uri: response.uri };

        // You can also display the image using data:
        // const source = { uri: 'data:image/jpeg;base64,' + response.data };

        this.setState({
          avatarSource: source
        });
        ImgToBase64.getBase64String(response.uri).then(base64String => {
          this.setState({
            b64: base64String
          }),
            (GlobalContext.Provider.value = "dfd");
        });
      }
    });
  }
  static propTypes = {
    navigation: PropTypes.object
  };

  // handle navigation
  handleUnityAppButtonPress = () => {
    this.props.navigation.navigate("UnityApp");
  };

  handleParameterButtonPress = () => {
    this.props.navigation.navigate("Options");
  };

  render() {
    return (
      <BackgroundView>
        <TouchableOpacity onPress={this.selectPhotoTapped.bind(this)}>
          <View
            style={[
              styles.avatar,
              styles.avatarContainer,
              { marginBottom: 20 }
            ]}
          >
            {this.state.avatarSource === null ? (
              <Text>Select a Photo</Text>
            ) : (
              <Image
                style={styles.avatar}
                source={this.state.avatarSource}
                onLoad={() => {
                  /* 1. Navigate to the Details route with params */
                  this.props.navigation.navigate("Details", {
                    itemId: this.state.avatarSource
                  });
                }}
              />
            )}
          </View>
        </TouchableOpacity>
        <Button
          title="Unity Application"
          onPress={this.handleUnityAppButtonPress}
        />
      </BackgroundView>
    );
  }
}

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
