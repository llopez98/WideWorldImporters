import * as tokenService from './token'

export const CheckExpTime = () => {
    var expTime = localStorage.getItem('expTime');

    if(expTime == null)
        return false;

    if(new Date(expTime) <= new Date()){
        return tokenService.RefreshToken();
    }
};