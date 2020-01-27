import React, { useState, useEffect } from "react";
import { getUsers } from "../../services/userService";
import { IUser } from "../../models/user";

export const Users: React.FC = () => {
  const [user, setUser] = useState<IUser>();
  const [users, setUsers] = useState<IUser[]>();
  const [error, setError] = useState<string>();

  useEffect(() => {
    let loadUsers = async () => {
      try {
        let data = await getUsers();
        setUsers(data);
      } catch (e) {
        setError(e);
      }
    };
    loadUsers();
  }, []);

  if (error) {
    return <h1 style={{ color: "red" }}>Jetzt mach doch nicht dein Problem zu meinem!</h1>;
  }

  if (!users) {
    return <div>Is LOaDiNg</div>;
  }

  if (user) {
    return (
      <div>
        <h1>Details</h1>
        <h5>
          <button onClick={() => setUser(undefined)}>BACK</button>
        </h5>
        <ul>
          <li>
            {user.name.first} {user.name.last}{" "}
          </li>
        </ul>
      </div>
    );
  }

  return (
    <ul>
      {users.map((user, idx) => (
        <li onClick={() => setUser(user)} key={idx}>
          <div>{user.email}</div>
          <div>
            {user.name.first} {user.name.last}
          </div>
        </li>
      ))}
    </ul>
  );
};
