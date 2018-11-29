import React, { createContext, Component } from "react";

const GlobalContext = React.createContext({});

export class GlobalContextProvider extends React.Component {
  state = {
    avatarSource: null,
    b64: "ff"
  };

  switchToOffline = () => {
    this.setState({ b64: "OMG" });
  };

  render() {
    return (
      <GlobalContext.Provider
        value={{
          ...this.state,
          switchToOffline: this.switchToOffline
        }}
      >
        {this.props.children}
      </GlobalContext.Provider>
    );
  }
}

// create the consumer as higher order component
export const withGlobalContext = ChildComponent => props => (
  <GlobalContext.Consumer>
    {context => <ChildComponent {...props} global={context} />}
  </GlobalContext.Consumer>
);
