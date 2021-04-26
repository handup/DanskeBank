/* eslint-disable no-param-reassign */
import axios from 'axios';

export const getAxiosInstance = (baseUrl? : string) => {
  const instance = axios.create({
    baseURL: baseUrl,
    timeout: 10000
  });

  instance.interceptors.response.use(
    (response) => response,
    (error) => {
      return Promise.reject(error);
    }
  );

  return instance;
}

export { axios };
