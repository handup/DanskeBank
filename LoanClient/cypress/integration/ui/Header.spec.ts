/// <reference types="cypress" />

describe('Basic Tests', () => {
  beforeEach(()=>{
    cy.visit('/');
  })

  it('displays a header!', () => {
    cy.get('[data-cy="header-repayment"]').contains('Repay Loan');
  })

  it('displays a piechart!', () => {
    cy.get('[data-cy="loan-piechart"]');
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

    //ASSERT

    cy.get('[data-cy="loan-piechart"]');
  })
})