import { getAxiosInstance } from './axioshelper';
import * as LoanApi from './loan.client';

// TODO: move to config later
const getLoanUrl = ()  => "https://localhost:5001";

export const getLoanApi = () : LoanApi.Client => {
  const client = new LoanApi.Client(getLoanUrl(), getAxiosInstance());
  return client;
};

export * as LoanApi from './loan.client';