import { IUser } from "../models/user";
import { create } from "zustand";
import { getUsers } from "./userService";

export interface IUserStore {
  error?: string;
  users: IUser[];
  user?: IUser;
  isLoading: boolean;
  loadUsers: () => void;
  setUser: (user: IUser | undefined) => void;
}
export const [useUserStore] = create<IUserStore>(set => ({
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
