import React from "react";
import { IUser } from "../../models/user";
import { LoginInfo } from "../LoginInfo/LoginInfo";

interface IUsersListProps {
  users: IUser[];
  onUserSelected: (user: IUser) => void;
}

export const UsersList: React.FC<IUsersListProps> = ({ users, onUserSelected }) => {
  return (
    <>
      <LoginInfo />
      <ul>
        {users.map((user, idx) => (
          <li onClick={() => onUserSelected(user)} key={idx}>
            {user.email}
          </li>
        ))}
      </ul>
    </>
  );
};
