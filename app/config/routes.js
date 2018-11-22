import { StackNavigator } from 'react-navigation'

import Home from '../screens/home'
import Options from '../screens/options'
import UnityApp from '../screens/UnityApp'

const optionsGeneral = {
  mode: 'modal',
  headerMode: 'none'
}

const HomeStack = StackNavigator({
  Home: {
    screen: Home,
    navigationOptions: {
      header: () => null
    }
  },
  UnityApp: {
    screen: UnityApp,
    navigationOptions: {
      headerTitle: 'Unity Application'
    }
  },
  Options: {
    screen: Options,
    navigationOptions: {
      headerTitle: 'Options'
    }
  }
})

export default StackNavigator(
  {
    Home: {
      screen: HomeStack
    }
  },
  optionsGeneral
)
