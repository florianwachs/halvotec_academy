import React, { useEffect } from "react";
import { UserDetail } from "./Users/UserDetail";
import { UsersList } from "./Users/UsersList";
import { useUserStore } from "../services/userStore";

export const Users: React.FC = () => {
  let error = useUserStore(state => state.error);
  let users = useUserStore(state => state.users);
  let user = useUserStore(state => state.user);
  let isLoading = useUserStore(state => state.isLoading);
  let loadUsers = useUserStore(state => state.loadUsers);
  let setUser = useUserStore(state => state.setUser);

  useEffect(() => loadUsers(), [loadUsers]);

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
