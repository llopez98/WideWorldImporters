import axios from "axios";

export function SendLoginData (data){
  axios
    .post("https://localhost:7252/api/auth/login", data, {
      headers: {
        //'Authorization': 'Bearer' + 'Your Bearer Pssword',
        "Content-Type": "application/json",
      },
    })
    .then(function (response) {
      console.log(response);
    })
    .catch(function (error) {
      console.log(error);
    });
}
