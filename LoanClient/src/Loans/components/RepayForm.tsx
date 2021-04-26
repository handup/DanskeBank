import React, { useEffect, useState } from 'react';
import { Form, Message } from 'semantic-ui-react';
import { getLoanApi } from '../../_shared/apihelper';

const loanAPI = getLoanApi();

type Props = {
  onSubmit: Function
}

const RepayForm = ({ onSubmit } : Props ) => {

  const [totalAmountRepaid, setTotalAmountRepaid] = useState(0);
  const [loanTerm, setLoanTerm] = useState(0);
  const [totalDebt, setTotalDebt] = useState(0);
  const [sucess, setSuccess] = useState('');

  const submitRepay = () => {
    loanAPI.repay(totalAmountRepaid, loanTerm, totalDebt).then(
      (returnedValue) => {
        onSubmit({totalAmountRepaid, loanTerm, totalDebt, returnedValue});
        console.log(returnedValue);
        setSuccess('sucess');
      }
    ).catch(
      // TODO: add more client-side validation
      (err) => {
        alert("Something went wrong, Pavel should do more client-side validation")
        setSuccess('failure');
      })
  }

  const getMessage = (success: string) => {
    switch (success) {
      case 'sucess':
          return <Message
            success
            header='Form Successful'
          />;
      case 'failure':
        return <Message
            negative
            header='Form Failed'
          />;
      default:
        return "";
    }
  }

  return (
  <div>
    <Form>
      <Form.Input 
        data-cy="input-amount"
        label="Amount Repaid:"
        type="number"
        value={totalAmountRepaid} 
        onChange={(e, data) => setTotalAmountRepaid(parseFloat(data.value))}
      />
      <Form.Input 
        data-cy="input-term"
        label="Loan Term:"
        type="number"
        value={loanTerm} 
        onChange={(e, data) => setLoanTerm(parseInt(data.value))}
      />
      <Form.Input 
        data-cy="input-debt"
        label="Total Debt:"
        type="number"
        value={totalDebt} 
        onChange={(e, data) => setTotalDebt(parseFloat(data.value))}
      />
      <Form.Button 
        data-cy="input-submit"
        content="Submit"
        onClick={submitRepay}
      />
      {getMessage(sucess)}
      
    </Form>
  </div> 
  )
}

export default RepayForm