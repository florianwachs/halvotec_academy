import React from "react";
import { IUser } from "../../models/user";
import { LoginInfo } from "../LoginInfo/LoginInfo";

interface IUserDetailProps {
  user: IUser;
  onClose: () => void;
}
export const UserDetail: React.FC<IUserDetailProps> = ({ user, onClose }) => {
  return (
    <div>
      <h1>Details</h1>
      <LoginInfo />
      <h5>
        <button onClick={() => onClose()}>BACK</button>
      </h5>
      <ul>
        <li>
          {user.name.first} {user.name.last}
        </li>
      </ul>
    </div>
  );
};
