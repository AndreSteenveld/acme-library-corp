-- Deploy lassi:isbn_author to pg
-- requires: book
-- requires: author

BEGIN;

create table isbn_author (

    isbn        text, -- Can't be a foreign key as isbn is not uniqe, for now I also can't be bothered remodeling.
    author_id   int references author,

    unique( isbn, author_id )

);

COMMIT;
