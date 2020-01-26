import React, { useContext } from "react";
import { LoginContext } from "../../models/LoginInformation";

export const LoginInfo: React.FC = () => {
  const loginCtx = useContext(LoginContext);

  return <h6>{loginCtx.user}</h6>;
};
