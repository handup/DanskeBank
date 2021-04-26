import React, { useState } from 'react';
import { Header, Grid } from 'semantic-ui-react';
import RepayForm from './RepayForm';
import { Loan } from '../types/types';
import { LoanChart } from './LoanChart';

const RepaymentCalculator = () => {
  const [activeLoan, setActiveLoan] = useState({} as Loan);
  const activeInterest = activeLoan?.returnedValue?.interestRatePercentage ?? 0;
  
  return (
  <div>
    <Header data-cy={"header-repayment"} as='h2' icon textAlign='center'>Repay Loan</Header>
    <Grid centered>
      <Grid.Column width={3}>
        <RepayForm onSubmit={setActiveLoan}/>
      </Grid.Column>
      <Grid.Column width={3}>
        <LoanChart interest={activeInterest}/>
      </Grid.Column>
    </Grid>
  </div> 
  )
}

export default RepaymentCalculator