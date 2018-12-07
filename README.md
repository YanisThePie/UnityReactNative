# Unity-ReactNative

Integrate unity3d within a React Native app. Add a react native component to show unity. Works on both iOS and Android.

## App 

The point was to integrate an unity game whithin react native.
and if possible use some react functions to show why that's cool.

React is used to get an pic from gallery (or take a new one) and it sends it to unity (as a string converted into base64).

Unity decodes it and print its on cubes, each time you shoot those cubes you get points and in the end unity sends your score to react.

This is more an technical demonstration than a proper game but fell free to play if you like it


## How to do

### Conversion base64 dans unity :

	ne pas oublier : using System;


	void printImage(String iconBase64String)
    {
        Texture2D newPhoto = new Texture2D(1, 1);
        newPhoto.LoadImage(Convert.FromBase64String(iconBase64String));
        newPhoto.Apply();
        ListImg.Add(newPhoto);
    }

### Add Unity Project

1. Create an unity project, Example: 'Cube'.
2. Create a folder named `unity` in react native project folder.
2. Move unity project folder to `unity` folder.

Now your project files should look like this.

```
.
├── android
├── ios
├── unity
│   └── <Your Unity Project>    // Example: Cube
├── node_modules
├── package.json
├── README.md
```

### Configure Player Settings

1. First Open Unity Project.

2. Click Menu: File => Build Settings => Player Settings

3. Change `Product Name` to Name of the Xcode project, You can find it follow `ios/${XcodeProjectName}.xcodeproj`.

**IOS Platform**:

Other Settings find the Rendering part, uncheck the `Auto Graphics API` and select only `OpenGLES2`.

### Add Unity Build Scripts and Export

Copy [`Build.cs`](https://github.com/f111fei/react-native-unity-demo/blob/master/unity/Cube/Assets/Scripts/Editor/Build.cs) and [`XCodePostBuild.cs`](https://github.com/f111fei/react-native-unity-demo/blob/master/unity/Cube/Assets/Scripts/Editor/XCodePostBuild.cs) to `unity/<Your Unity Project>/Assets/Scripts/Editor/`

Open your unity project in Unity Editor. Now you can export unity project with `Build/Export Android` or `Build/Export IOS` menu.

![image](https://user-images.githubusercontent.com/7069719/37091489-5417a66c-2243-11e8-8946-4d9e1ac652e8.png)

Android will export unity project to `android/UnityExport`.

IOS will export unity project to `ios/UnityExport`.

### Configure Native Build

#### Android Build

Make alterations to the following files:

- `android/settings.gradle`

```
...
include ":UnityExport"
project(":UnityExport").projectDir = file("./UnityExport")
```

#### IOS Build

1. Open your react native project in XCode.

1. Copy File [`UnityConfig.xcconfig`](https://github.com/f111fei/react-native-unity-demo/blob/master/ios/rnunitydemo/UnityConfig.xcconfig) to `ios/${XcodeProjectName}/`.

2. Drag `UnityConfig.xcconfig` to XCode. Choose `Create folder references`.

3. Setting `.xcconfig` to project.

![image](https://user-images.githubusercontent.com/7069719/37093471-638b7810-224a-11e8-8263-b9882f707c15.png)

4. Go to Targets => Build Settings. Change `Dead Code Stripping` to `YES`.

![image](https://user-images.githubusercontent.com/7069719/37325486-182c7bd4-26c9-11e8-9fc0-8e1a149d30b2.png)

5. Modify `main.m`

```
#import "UnityUtils.h"

int main(int argc, char * argv[]) {
  @autoreleasepool {
    InitArgs(argc, argv);
    return UIApplicationMain(argc, argv, nil, NSStringFromClass([AppDelegate class]));
  }
}
```

### Use In React Native

#### Props

##### `onMessage`

Receive message from unity.

Please copy [`UnityMessageManager.cs`](https://github.com/f111fei/react-native-unity-demo/blob/master/unity/Cube/Assets/Scripts/UnityMessageManager.cs) to your unity project and rebuild first.

Example:

1. Send Message use C#.

```
UnityMessageManager.Instance.SendMessageToRN("Bravo vous avez scoré : " + score);
```

2. Receive Message in javascript

```
onMessage(event) {
    console.log('OnUnityMessage: ' + event.nativeEvent.message);    // OnUnityMessage: click
}

render() {
    return (
        <View style={[styles.container]}>
            <UnityView
                style={style.unity}
                onMessage={this.onMessage.bind(this)}
            />
        </View>
    );
}
```

```

##### `postMessageToUnityManager(message: string)`

Send message to `UnityMessageManager`.

Please copy [`UnityMessageManager.cs`](https://github.com/f111fei/react-native-unity-demo/blob/master/unity/Cube/Assets/Scripts/UnityMessageManager.cs) to your unity project and rebuild first.

Same to `postMessage('UnityMessageManager', 'onMessage', message)`

This is recommended to use.

* `message` The message will post.

Example:

1. Add a message handle method in C#.

```
 void Awake()
    {
        UnityMessageManager.Instance.OnRNMessage += onMessage;
    }

    void onDestroy()
    {
        UnityMessageManager.Instance.OnRNMessage -= onMessage;
    }

    void onMessage(MessageHandler message)
      {
          var data = message.getData<string>();
          Debug.Log("onMessage:" + data);

        
        start = true;

        if (data.Length > 25)
            printImage(data);
        else
            Camera.main.GetComponent<cameraScript>().getGyro(data);
    }
```

2. Send message use javascript.


render() {
    return (
        <View style={[styles.container]}>
            <UnityView
                ref={(ref) => this.unity = ref}
                style={style.unity}
            />
            <Button label="Toggle Rotate" onPress={this.onMessage.bind(this)} />
        </View>
    );
}
```

##### `pause()`

Pause the unity player.

Thanks [@wezzle](https://github.com/wezzle). See [#13](https://github.com/f111fei/react-native-unity-view/pull/13)

##### `resume()`

Resume the unity player.


#### Example Code

```
import React from 'react';
import { StyleSheet, Image, View, Dimensions } from 'react-native';
import UnityView from 'react-native-unity-view';

export default class App extends React.Component<Props, State> {
    render() {
    return (
      <View style={styles.container}>
        <UnityView style={{ position: 'absolute', left: 0, right: 0, top: 0, bottom: 0, }} /> : null}
        <Text style={styles.welcome}>
          Welcome to React Native!
        </Text>
      </View>
    );
  }
}
```

Enjoy!!!
