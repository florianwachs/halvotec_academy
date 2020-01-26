import React from "react";
import logo from "./logo.svg";
import "./App.css";
import { UsersList } from "./components/Users/UsersList";

const App: React.FC = () => {
  return (
    <div className="App">
      <UsersList />
    </div>
  );
};

export default App;
