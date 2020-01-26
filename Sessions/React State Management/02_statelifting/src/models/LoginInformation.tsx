import React from "react";

export interface ILoginContext {
  user: string;
  token: string;
}
export const LoginContext = React.createContext<ILoginContext>({ user: "UNKNOWN", token: "UNKNOWN" });
