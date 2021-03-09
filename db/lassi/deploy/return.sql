-- Deploy lassi:return to pg
-- requires: loan

BEGIN;

create table return (

    loan_id     int references loan,
    date        date not null,
    note        text

);

COMMIT;
