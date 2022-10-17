import axios from "axios";

export const SendLoginData = (data) => {
  return new Promise(async (resolve) => {
    return axios
      .post("https://localhost:7207/login", data, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        /*console.log(response.data);
        console.log(response.data.token);
        console.log(response.data.refreshToken);
        console.log(response.data.isAuthSuccessful);*/
        localStorage.setItem("token", response.data.token);
        localStorage.setItem("refreshToken", response.data.refreshToken);
        localStorage.setItem("expTime", response.data.expTime);
        resolve(response.data.isAuthSuccessful);
      })
      .catch(({ response }) => {
        resolve(response);
      });
  });
};

export const RegisterUser = (data) => {
  return new Promise(async (resolve) => {
    return axios
      .post("https://localhost:7207/registration", data, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        resolve(response);
      })
      .catch(({ response }) => {
        resolve(response);
      });
  });
};

export const LogoutUser = () => {
  localStorage.removeItem("token");
  localStorage.removeItem("refreshToken");
};

export const GetRefreshToken = (tokenDto) => {
  return new Promise(async (resolve) => {
    return axios
      .post("https://localhost:7207/refresh", tokenDto, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        //console.log(response);
        resolve(response.data);
      })
      .catch(({ response }) => {
        //console.log(response);
        resolve(response.data);
      });
  });
};
