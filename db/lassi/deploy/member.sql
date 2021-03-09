-- Deploy lassi:member to pg

BEGIN;

create table member (

    member_id           uuid primary key default gen_random_uuid( ),
    user_id             text, -- This is a external (for us) identifier, we don't know the type honestly
    expiration_date     date

);

COMMIT;
