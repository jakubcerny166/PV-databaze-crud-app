create database zamestnanec
use zamestnanec

create table zam(
id int primary key identity(1,1),
jmeno varchar(20) not null,
vek int not null,
datum date
);