select *
from Journals

select *
from Particulars

exec sp_help Particulars

insert into particulars
    (title,amount,date,journalid)
values
    ('purchase', 34000, '3283-12-13', 2)