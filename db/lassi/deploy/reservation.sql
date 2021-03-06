-- Deploy lassi:reservation to pg
-- requires: book
-- requires: member

BEGIN;

create table reservation (

    reservation_id  int generated by default as identity primary key,
    book_id         int references book on delete cascade,
    member_id       uuid references member on delete cascade,
    date            date

);

COMMIT;
