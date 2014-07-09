# Coding Challenge: Cash Flow Projection Model

## Problem statement
Acme Mortgage Company (AMC) owns servicing rights on 500,000 loans which
are spread across 1,000 accounts.  Each month, AMC receives payments
from the borrower and forwards this payment onto the investor, less a
small servicing fee. However, each month some of the loans are
delinquent and do not make their payment.  AMC is still obligated to
send the full amount of the payment that was expected but not received
on to the investor, and must borrow money from another bank to make up
the difference.

In order to gain insight into their business, AMC would like to build
a model to project their cash flow, including incoming and outgoing
payments, account balance, and outstanding debt.  Your goal is to
write a program that projects AMC's cash flow each month for the next
15 years.  Your program should output a pipe-delimited CSV file for
each of AMC's 1,000 accounts with the information specified below, as
well as a pipe-delimited CSV file with information aggregated at the
company level for all 1,000 accounts.  Finally, you should also
generate a PNG file with a graph of the end-of-month cash balance at
the firm level vs time.

You are free to write your program in any language of your choice, but
please include clear instructions for how to run the program with your
submission.  Your solution should be submitted via email as a zip file
including your program, the CSV files, and the PNG file.

## Input
loans.csv: CSV file with data as represented below, one row for each of
the 500,000 loans.

|LoanNumber|AccountNumber|AsOfDate|LoanAmount|MonthlyPayment|LoanStatus|
|----------|-------------|--------|----------|--------------|----------|
|100001|2504|2014-01-01|$180,000|$850|Active|
|100002|2504|2014-01-01|$434,000|$1,900|Active|
|100003|2916|2014-01-01|$840,000|$3,800|Active|
|...|...|...|...|...|...|

accounts.csv: CSV file with data as representednted below, one row for each of the 1,000 accounts.

|AccountNumber|AsOfDate|CashBalance|DebtBalance|
|-------------|--------|-----------|-----------|
|2504|2014-01-01|$0|$150,000|
|2916|2014-01-01|$280,000|$94,000|
|3820|2014-01-01|$443,100|$0|
|...|...|...|...|

## Output
One file for each of the 1000 accounts, account-XXXX.csv (XXXX=account
number), and one file aggregated for all accounts.

|Date|Incoming Payments|Outgoing Payments|Starting Cash Balance|Ending Cash Balance|Debt Taken/Paid Off|Debt Balance|
|----|-----------------|-----------------|---------------------|-------------------|-------------------|------------|
|2014-01-31|$480,000|$500,000|$75,000|$55,000|$0|$198,000|
|2014-02-28|$680,000|$500,000|$55,000|$55,000|-$180,000|$0|
|2014-03-31|$400,000|$500,000|$55,000|$0|$45,000|$45,000|
|...|...|...|...|...|...|...|

## Model Details
#### Active loans
* Active loans make a scheduled payment each month of MonthlyPayment
* With each payment, the LoanAmount is decreased by 0.8 * MonthlyPayment;
  if the LoanAmount goes to zero, the LoanStatus goes to "Sold" and
  there are no longer any payments of any kind for this loan.
* An active loan has a 1% chance of being sold each month, and an
  unschedule payment is made of the full remaining LoanAmount.
* Active loans have a 2% chance of going delinquent each month.

#### Delinquent loans
* Delinquent loans never make their monthly payment, but their expected
  scheduled monthly payment of MonthlyPayment is still due to the
  investor.
* Once a loan goes delinquent it never goes back to active.
* The expected payment from a delinquent loan still needs to be sent on
  to the investor.
* After 2 years of being delinquent, the loan is sold and an unscheduled
  payment is made of 50% of the LoanAmount; the loan is marked as "Sold"
  and there are no longer any payment of any kind for this loan.

#### Investor Payments & Debt
* All scheduled monthly payments received or expected each month must be
  forwarded on to the investor.
* Any unscheduled payments (payment from an active or delinquent loan
  being sold) are first used to pay down any outstanding debt.  Any
  remaining amount is forwarded on to the investor.

