select *
from Journals
select *
from Particulars
select *
from Ledgers

exec sp_help Particulars
exec sp_help Ledgers

insert into particulars
    (title,amount,date,journalid)
values
    ('purchase', 34000, '3283-12-13', 2)