-- Deploy lassi:fee to pg
-- requires: loan

BEGIN;

create table fee (

    fee_id      int generated by default as identity primary key,
    loan_id     int references loan,
    type        text, -- should actually be an enum of "damage" and "late"
    amount      int, -- The amount in cents, this is very imperfect but it does make sure our money doesn't float away
    paid        date
    
);

COMMIT;