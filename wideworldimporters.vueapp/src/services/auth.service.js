import apiService from "./api.service";
import tokenService from "./token.service";

class AuthService {
  login(user) {
    return apiService
      .post("login", {
        email: user.email,
        password: user.password,
      })
      .then((response) => {
        if (response.data.token) {
          tokenService.setUser(response.data);
        }

        return response.data;
      });
  }

  logout() {
    tokenService.removeUser();
  }

  register(user) {
    return apiService.post("registration",{
        email: user.email,
        password: user.password,
        confirmPassword: user.confirmPassword
    });
  }
}

export default new AuthService();
