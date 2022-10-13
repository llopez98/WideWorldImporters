import axios from "axios";
import { store } from "@/helpers/store";

export const GetStockItems = () => {
  return new Promise(async (resolve) => {
    return axios
      .get("https://localhost:7207/items", {
        headers: {
          'Authorization': 'Bearer ' + localStorage.getItem('token'),
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        resolve(response.data);
      })
      .catch(({ response }) => {
        resolve(response);
      });
  });
};
