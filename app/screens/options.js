import React from "react";
import { Text, TouchableOpacity } from "react-native";
import styled from "styled-components";
import PropTypes from "prop-types";

const OptionsContainer = styled.View`
  align-items: center;
  background-color: "#ffffff";
  flex: 1;
  justify-content: center;
`;

export default class Options extends React.Component {
  static propTypes = {
    navigation: PropTypes.object
  };

  render() {
    return (
      <View>
        <Text>Welcome to React Native!</Text>
      </View>
    );
  }
}
