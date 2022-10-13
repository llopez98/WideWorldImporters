import axios from "axios";
import LocalStorageService from "@/helpers/LocalStorageService";

const localStorageService = LocalStorageService.getService();

export function SendLoginData (data){
  axios
    .post("https://localhost:7252/api/auth/login", data, {
      headers: {
        //'Authorization': 'Bearer' + 'Your Bearer Pssword',
        "Content-Type": "application/json",
      },
    })
    .then(function (response) {
      localStorageService.setToken(response.data);
      //console.log(response.data);
    })
    .catch(function (error) {
      console.log(error);
    });
}
