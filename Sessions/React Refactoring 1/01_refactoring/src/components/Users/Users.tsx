import React, { useState, useEffect } from "react";
import { getUsers } from "../../services/userService";
import { IUser } from "../../models/user";
import styles from "./Users.module.css";
import useSWR from "swr";

export const Users: React.FC = () => {
  const [user, setUser] = useState<IUser>();
  const [userId, setUserId] = useState<string>("122");
  const { data: users, error } = useSWR(userId, getUsers);

  if (error) {
    return <ErrorMessages error={error} />;
  }

  if (!users) {
    return <Spinner />;
  }

  if (user) {
    return <UserDetail user={user} onClose={() => setUser(undefined)} />;
  }

  return <UserList users={users} onSelect={user => setUser(user)} />;
};

const ErrorMessages: React.FC<{ error: string | undefined }> = ({ error }) => {
  if (!error) {
    return null;
  }
  return <h1 style={{ color: "red" }}>{error}: Jetzt mach doch nicht dein Problem zu meinem!</h1>;
};

const Spinner: React.FC = () => {
  return <div>Is LOaDiNg</div>;
};

interface IUserDetailsProps {
  user: IUser;
  onClose: () => void;
}
const UserDetail: React.FC<IUserDetailsProps> = ({ user, onClose }) => {
  return (
    <Page header="Details">
      <h5>
        <button onClick={onClose}>Zurück</button>
      </h5>
      <ul>
        <li>
          <UserName user={user} />
        </li>
      </ul>
    </Page>
  );
};

interface IUserListProps {
  users: IUser[];
  onSelect: (user: IUser) => void;
}
const UserList: React.FC<IUserListProps> = ({ users, onSelect }) => {
  return (
    <Page header="Liste">
      <ul>
        {users.map((user, idx) => (
          <li onClick={() => onSelect(user)} key={idx}>
            <div>{user.email}</div>
            <div>
              <UserName user={user} />
            </div>
          </li>
        ))}
      </ul>
    </Page>
  );
};

const Page: React.FC<{ header: string }> = ({ header, children }) => {
  return (
    <div style={{boxShadow:"0 3.2px 7.2px 0 rgba(0,0,0,.132), 0 0.6px 1.8px 0 rgba(0,0,0,.108)"}}>
      <h1>{header}</h1>
      <div>{children}</div>
    </div>
  );
};

const UserName: React.FC<{ user: IUser }> = ({ user }) => (
  <span className={styles.username}>
    {user.name.first} {user.name.last}
  </span>
);
