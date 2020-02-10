import React, { useState, useEffect } from "react";
import { getUsers } from "../../services/userService";
import { IUser } from "../../models/user";
import useSWR from "swr";
import { UserDetail } from "./UserDetail";

export const UsersList: React.FC<{}> = () => {
  const { data } = useSWR("users", getUsers);
  const [user, setUser] = useState<IUser>();

  if (!data) {
    return <div>Is LOaDiNg</div>;
  }

  if (user) {
    return <UserDetail user={user} onClose={() => setUser(undefined)} />;
  }

  return (
    <ul>
      {data.map((user, idx) => (
        <li onClick={() => setUser(user)} key={idx}>
          {user.email}
        </li>
      ))}
    </ul>
  );
};
