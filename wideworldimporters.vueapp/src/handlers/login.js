import axios from "axios";
import { store } from "@/helpers/store";

/*export function SendLoginData (data){
  axios
    .post("https://localhost:7252/api/auth/login", data, {
      headers: {
        //'Authorization': 'Bearer' + 'Your Bearer Pssword',
        "Content-Type": "application/json",
      },
    })
    .then(function (response) {
      //localStorageService.setToken(response.data);
      store.token = response.data;
      return true;
      //console.log(store.token);
    })
    .catch(function (error) {
      console.log(error);
    });
}*/

export const SendLoginData = (data) => {
  return new Promise(async (resolve) => {
    return axios
      .post("https://localhost:7252/api/auth/login", data, {
        headers: {
          //'Authorization': 'Bearer' + 'Your Bearer Pssword',
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        localStorage.setItem('token', response.data);
        store.token = response.data;
        resolve(response);
      })
      .catch(({ response }) => {
        resolve(response);
      });
  });
};
