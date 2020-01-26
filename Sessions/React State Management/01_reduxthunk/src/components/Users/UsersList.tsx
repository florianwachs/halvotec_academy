import React from "react";
import { IUser } from "../../models/user";
import { connect } from "react-redux";
import { RootState } from "../../store/store";
import { ThunkDispatch } from "redux-thunk";
import { loadUsers } from "../../store/users/actions";

interface IUsersListProps {
  loadUsers: () => void;
  users: IUser[];
}

const UsersListRaw: React.FC<IUsersListProps> = ({ users, loadUsers }) => {
  if (users.length === 0) {
    return <button onClick={loadUsers}>Load Users</button>;
  }

  // TODO: Implement this with redux on your own
  //   if (user) {
  //     return <UserDetail user={user} onClose={() => setUser(undefined)} />;
  //   }

  return (
    <ul>
      {users.map((user, idx) => (
        <li key={idx}>{user.email}</li>
      ))}
    </ul>
  );
};

function mapStateToProps(state: RootState) {
  return {
    users: state.users.users
  };
}

function mapDispatchToProps(dispatch: ThunkDispatch<{}, {}, any>) {
  return {
    loadUsers: () => dispatch(loadUsers())
  };
}

export const UsersList = connect(mapStateToProps, mapDispatchToProps)(UsersListRaw);
