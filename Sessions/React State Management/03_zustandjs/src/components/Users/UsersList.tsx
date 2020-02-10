import React, {  } from "react";
import { IUser } from "../../models/user";

export const UsersList: React.FC<{ users: IUser[]; onUserSelected: (user: IUser) => void }> = ({ users, onUserSelected }) => {
  return (
    <ul>
      {users.map((user, idx) => (
        <li onClick={() => onUserSelected(user)} key={idx}>
          {user.email}
        </li>
      ))}
    </ul>
  );
};
