import { ThunkAction, ThunkDispatch } from "redux-thunk";
import { AnyAction } from "redux";
import { IUser } from "../../models/user";
import { getUsers } from "../../services/userService";

export interface UsersLoaded {
  type: "USERS_LOADED";
  users: IUser[];
}

export type Action = UsersLoaded;

export function usersLoaded(users: IUser[]): UsersLoaded {
  return {
    type: "USERS_LOADED",
    users: users
  };
}

export function loadUsers(): ThunkAction<Promise<void>, {}, {}, AnyAction> {
  return async (dispatch: ThunkDispatch<{}, {}, AnyAction>): Promise<void> => {
    const users = await getUsers();
    dispatch(usersLoaded(users));
  };
}
