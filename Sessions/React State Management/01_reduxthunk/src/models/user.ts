export interface IUser {
  gender: string;
  name: { title: string; first: string; last: string };
  email: string;
  picture: {
    thumbnail: string;
    large: string;
  };
}
