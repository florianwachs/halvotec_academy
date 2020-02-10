import { createStore, combineReducers, applyMiddleware, DeepPartial } from "redux";
import thunk from "redux-thunk";
import { IUsersState, userReducer } from "./users/reducers";
import { composeWithDevTools } from "redux-devtools-extension";
export interface RootState {
  users: IUsersState;
}

export const rootStore = createStore(
  combineReducers<RootState>({ users: userReducer }),
  composeWithDevTools(applyMiddleware(thunk))
);
