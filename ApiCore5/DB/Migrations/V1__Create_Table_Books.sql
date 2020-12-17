create table if not exists tb_books
(
	id_book bigint not null auto_increment,
    name_book varchar(100) not null,
    name_author varchar(100),
	Primary key (id_book)
);