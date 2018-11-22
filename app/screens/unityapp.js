import React from 'react';
import { StyleSheet, Image, View, Text } from 'react-native';
import UnityView from 'react-native-unity-view';

export default class App extends React.Component {
    render() {
    return (
      <View>
        <UnityView style={{ position: 'absolute', left: 0, right: 0, top: 0, bottom: 0}} />
        <Text>
          Welcome to React Native!
        </Text>
      </View>
    );
  }
}