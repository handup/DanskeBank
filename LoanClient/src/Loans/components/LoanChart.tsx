import { PieChart } from 'react-minimal-pie-chart';

type Props = {
 interest: number
}

export const LoanChart = ({ interest } : Props) => 
  <PieChart data-cy="loan-piechart"
    label={(data) => data.dataEntry.percentage.toFixed()} 
    data={[
      { title: 'InterestRate', value: interest, color: '#E38627' },
      { title: 'Debt', value: 100 - interest, color: '#C13C37' },
    ]}
  />;