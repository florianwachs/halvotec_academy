import { combineReducers } from "redux";
import { IUser } from "../../models/user";
import { Action } from "./actions";

export interface IUsersState {
  users: IUser[];
}

function handleUsers(state: IUser[] = [], action: Action): IUser[] {
  switch (action.type) {
    case "USERS_LOADED":
      return action.users;
  }

  return state;
}

export const userReducer = combineReducers<IUsersState>({ users: handleUsers });
