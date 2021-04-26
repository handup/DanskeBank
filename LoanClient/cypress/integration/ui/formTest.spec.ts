/// <reference types="cypress" />

describe('Basic Tests', () => {
  beforeEach(()=>{
    cy.visit('/');
  })

  it('displays a form!', () => {
    // ARRANGE
    cy.intercept(
      {
        method: 'POST',
        url: '/Loan/repay',
      },
      [{
        "interestRatePercentage": 7.635,
        "decision": true
      }]
    )

    //ACT
    cy.get('[data-cy="input-amount"]').type("3000");
    cy.get('[data-cy="input-term"]').type("3");
    cy.get('[data-cy="input-debt"]').type("4000");

    //ASSERT

  })
})