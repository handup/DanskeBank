import React from 'react';
import { Header } from 'semantic-ui-react';

type Props = {
  active: Boolean
}

const CalculatorForm = ({ active } : Props) => {

  return (
  <div>
    <Header as='h2' icon textAlign='center'>Repay Loan</Header>
  </div> 
  )
}

export default CalculatorForm