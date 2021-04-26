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
})