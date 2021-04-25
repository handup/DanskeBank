import React from 'react';
import './App.css';
import InterestCalculator from './Loans/components/InterestCalculator';

function App() {
  return (
    <div className="App">
      <InterestCalculator active={true} />
    </div>
  );
}

export default App;
