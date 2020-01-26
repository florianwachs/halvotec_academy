import React from "react";
import { IUser } from "../../models/user";

interface IUsersListProps {
  users: IUser[];
  onUserSelected: (user: IUser) => void;
}
export const UsersList: React.FC<IUsersListProps> = ({ users, onUserSelected }) => {
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
