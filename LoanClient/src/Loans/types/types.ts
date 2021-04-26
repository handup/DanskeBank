import { LoanApi } from '../../_shared/apihelper'

export type Loan = {
  totalAmountRepaid: number,
  loanTerm: number,
  totalDebt: number,
  returnedValue: LoanApi.RepayResponseDTO
};