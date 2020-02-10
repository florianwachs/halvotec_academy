import React, { useEffect } from "react";
import create from "zustand";
import { IUser } from "../models/user";
import { getUsers } from "../services/userService";
import { UserDetail } from "./Users/UserDetail";
import { UsersList } from "./Users/UsersList";

interface IUserStore {
  error?: string;
  users: IUser[];
  user?: IUser;
  isLoading: boolean;
  loadUsers: () => void;
  setUser: (user: IUser | undefined) => void;
}
const [useUserStore] = create<IUserStore>(set => ({
  users: [],
  isLoading: false,
  loadUsers: async () => {
    set({ isLoading: true });
    try {
      let users = await getUsers();
      set({ users: users });
    } catch {
      // TODO: Set Error
    } finally {
      set({ isLoading: false });
    }
  },
  setUser: user => set({ user: user })
}));

export const Users: React.FC = () => {
  let error = useUserStore(state => state.error);
  let users = useUserStore(state => state.users);
  let user = useUserStore(state => state.user);
  let isLoading = useUserStore(state => state.isLoading);
  let loadUsers = useUserStore(state => state.loadUsers);
  let setUser = useUserStore(state => state.setUser);

  useEffect(() => loadUsers(), []);

  if (error) {
    return <h1>Shit Happens</h1>;
  }

  if (isLoading) {
    return <h1>Is Loading</h1>;
  }

  if (user) {
    return (
      <UserDetail
        user={user}
        onClose={() => {
          setUser(undefined);
          loadUsers();
        }}
      />
    );
  }

  return <UsersList users={users} onUserSelected={setUser} />;
};
