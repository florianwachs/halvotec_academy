import React from "react";
import "./App.css";
import { Users } from "./components/Users/Users";
import { LoginContext } from "./models/LoginInformation";

const loggedInUser = {
  user: "Uli",
  token: "TOP_SECRET"
};

const App: React.FC = () => {
  return (
    <LoginContext.Provider value={loggedInUser}>
      <div className="App">
        <Users />
      </div>
    </LoginContext.Provider>
  );
};

export default App;
