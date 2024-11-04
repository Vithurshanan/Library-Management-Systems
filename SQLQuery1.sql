select * from issues

select * from books

select * from users

SELECT * FROM issues WHERE date_delete IS NULL


ALTER TABLE issues 
ADD date_update VARCHAR(MAX) NULL;