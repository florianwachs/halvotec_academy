import React from "react";
import "./App.css";
import { UsersList } from "./components/Users/UsersList";
import { Provider } from "react-redux";
import { rootStore } from "./store/store";

const App: React.FC = () => {
  return (
    <Provider store={rootStore}>
      <div className="App">
        <UsersList />
      </div>
    </Provider>
  );
};

export default App;
