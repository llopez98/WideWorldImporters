import apiService from "./api.service";
import tokenService from "./token.service";

const setup = (store) => {
  apiService.interceptors.request.use(
    (config) => {
      const token = tokenService.getLocalAccessToken();
      if (token) {
        config.headers["Authorization"] = "Bearer" + token;
      }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );

  apiService.interceptors.response.use(
    (res)=>{
        return res;
    },
    async (err) => {
        const originalConfig = err.config;

        if(originalConfig.url !== "/registration" && err.response){
            if(err.response.status === 401 && !originalConfig._retry){
                originalConfig._retry = true;

                try{
                    const rs = await apiService.post("/refresh",{
                        token: tokenService.getLocalAccessToken(),
                        refreshToken: tokenService.getLocalRefreshToken()
                    });

                    const {accessToken} = rs.data.token;

                    store.dispatch('auth/refreshToken', accessToken);
                    tokenService.updateLocalAccessToken(accessToken);

                    return apiService(originalConfig);
                }catch(_error){
                    return Promise.reject(_error);
                }
            }
        }

        return Promise.reject(err);
    }
  );
};

export default setup;
