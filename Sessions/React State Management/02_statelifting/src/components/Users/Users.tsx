import React, { useState } from "react";
import useSWR from "swr";
import { getUsers } from "../../services/userService";
import { UserDetail } from "./UserDetail";
import { UsersList } from "./UsersList";
import { IUser } from "../../models/user";

export const Users: React.FC = () => {
  const { data: users, error, revalidate } = useSWR("users", getUsers);
  const [user, setUser] = useState<IUser | null>();

  if (error) {
    return <h1>Shit Happens</h1>;
  }

  if (!users) {
    return <h1>Is Loading</h1>;
  }

  if (user) {
    return (
      <UserDetail
        user={user}
        onClose={() => {
          setUser(null);
          revalidate();
        }}
      />
    );
  }

  return <UsersList users={users} onUserSelected={setUser} />;
};
