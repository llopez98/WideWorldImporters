import * as authService from './auth';

export const RefreshToken = async () => {
    var token = localStorage.getItem("token");
    var refreshToken = localStorage.getItem("refreshToken");
  
    var tokenDto = {
      Token: token,
      RefreshToken: refreshToken,
    };
  
    var refreshResult = await authService.GetRefreshToken(tokenDto);
  
    if(!refreshResult.isAuthSuccessful){
        console.log("Something went wrong during the refresh token action");
        return false;
    }

    localStorage.setItem('token', refreshResult.token);
    localStorage.setItem('refreshToken', refreshResult.refreshToken);
    localStorage.setItem('expTime', refreshResult.expTime);

    //console.log(refreshResult);

    return true;
};