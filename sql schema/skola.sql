drop database skola;
create database skola
use skola;
create table adresa (
	id BIGINT ,
	ulica VARCHAR(25)  NOT NULL,
	broj int not null,
	grad varchar(25) not null,
	drzava varchar(25) not null,
	primary key(id)
);
create table skola (
	id bigint,
	naziv varchar(25) not null,
	adresa_id bigint not null,
	primary key(id),
	foreign key(adresa_id) references adresa(id)
);
create table skola_jezik (
	skola_id bigint, 
	jezik varchar(25) not null,
	foreign key(skola_id) references skola(id)
);
create table registrovani_korisnik (
	ime varchar(25) not null,
	prezime varchar(25) not null,
	jmbg int unique not null,
	pol varchar(25) not null,
	adresa_id bigint not null,
	email varchar(25),
	lozinka varchar(25) not null,
	tip varchar(25) not null,
	aktivan bit not null,
	primary key(email),
	foreign key(adresa_id) references adresa(id)
);
create table profesor (
	korisnik_email varchar(25),
	skola_id bigint not null,
	primary key(korisnik_email),
	foreign key(korisnik_email) references registrovani_korisnik(email)
);
create table student (
	korisnik_email varchar(25),
	primary key(korisnik_email),
	foreign key(korisnik_email) references registrovani_korisnik(email)
);
create table cas (
	id bigint,
	profesor_email varchar(25) not null,
	datum_odrzavanja date not null,
	vreme_pocetka time not null,
	trajanje int not null,
	status_casa varchar(25) not null,
	student_email varchar(25) not null,
	primary key(id),
	foreign key(profesor_email) references profesor(korisnik_email),
	foreign key(student_email) references student(korisnik_email)
);
create table profesor_jezik (
	profesor_email varchar(25),
	jezik varchar(25) not null,
	foreign key(profesor_email) references profesor(korisnik_email)
);
create table profesor_cas (
	profesor_email varchar(25),
	cas_id bigint,
	foreign key(profesor_email) references profesor(korisnik_email),
	foreign key(cas_id) references cas(id)
);
create table student_cas (
	student_email varchar(25),
	cas_id bigint,
	foreign key(student_email) references student(korisnik_email),
	foreign key(cas_id) references cas(id)
);
insert into adresa values(1, 'ulica 1', 1, 'grad1', 'drzava1');
insert into adresa values(2, 'ulica 2', 2, 'grad2', 'drzava2');
insert into adresa values(3, 'ulica 3', 3, 'grad3', 'drzava3');
insert into adresa values(4, 'ulica 4', 4, 'grad4', 'drzava4');
insert into adresa values(5, 'ulica 5', 5, 'grad5', 'drzava5');

insert into skola values(1, 'skola 1', 1);
insert into skola values(2, 'skola 2', 2);
insert into skola values(3, 'skola 3', 3);
insert into skola values(4, 'skola 4', 4);

insert into skola_jezik values(1, 'SRPSKI');
insert into skola_jezik values(2, 'SRPSKI');
insert into skola_jezik values(3, 'SRPSKI');
insert into skola_jezik values(4, 'SRPSKI');
insert into skola_jezik values(1, 'ENGLESKI');
insert into skola_jezik values(2, 'ENGLESKI');
insert into skola_jezik values(3, 'ENGLESKI');
insert into skola_jezik values(4, 'ENGLESKI');
insert into skola_jezik values(1, 'NEMACKI');
insert into skola_jezik values(2, 'NEMACKI');
insert into skola_jezik values(3, 'NEMACKI');

insert into registrovani_korisnik values('ime1', 'prezime1', '1111111', 'MUSKI', 1, '1@mail.com', '1', 'ADMINISTRATOR', 1);
insert into registrovani_korisnik values('ime2', 'prezime2', '2222222', 'MUSKI', 2, '2@mail.com', '2', 'PROFESOR', 1);
insert into registrovani_korisnik values('ime3', 'prezime3', '3333333', 'MUSKI', 3, '3@mail.com', '3', 'PROFESOR', 1);
insert into registrovani_korisnik values('ime4', 'prezime4', '4444444', 'MUSKI', 4, '4@mail.com', '4', 'PROFESOR', 1);
insert into registrovani_korisnik values('ime5', 'prezime5', '5555555', 'MUSKI', 1, '5@mail.com', '5', 'STUDENT', 1);
insert into registrovani_korisnik values('ime6', 'prezime6', '6666666', 'MUSKI', 1, '6@mail.com', '6', 'STUDENT', 1);

insert into profesor values('2@mail.com', 1);
insert into profesor values('3@mail.com', 1);
insert into profesor values('4@mail.com', 2);

insert into student values('5@mail.com');
insert into student values('6@mail.com');

insert into cas values(1, '2@mail.com', '2023-1-1', '01:00', 30, 'SLOBODAN', '5@mail.com');
insert into cas values(2, '2@mail.com', '2023-2-2', '02:00', 30, 'SLOBODAN', '5@mail.com');
insert into cas values(3, '3@mail.com', '2023-3-3', '03:00', 30, 'SLOBODAN', '6@mail.com');
insert into cas values(4, '2@mail.com', '2023-4-4', '04:00', 30, 'SLOBODAN', '5@mail.com');
insert into cas values(5, '3@mail.com', '2023-5-5', '05:00', 30, 'SLOBODAN', '6@mail.com');

insert into profesor_jezik values('2@mail.com', 'SRPSKI');
insert into profesor_jezik values('3@mail.com', 'SRPSKI');
insert into profesor_jezik values('4@mail.com', 'SRPSKI');
insert into profesor_jezik values('2@mail.com', 'ENGLESKI');
insert into profesor_jezik values('3@mail.com', 'ENGLESKI');
insert into profesor_jezik values('4@mail.com', 'ENGLESKI');
insert into profesor_jezik values('2@mail.com', 'NEMACKI');
insert into profesor_jezik values('3@mail.com', 'NEMACKI');

insert into profesor_cas values('2@mail.com', 1);
insert into profesor_cas values('3@mail.com', 2);
insert into profesor_cas values('2@mail.com', 3);
insert into profesor_cas values('4@mail.com', 4);
insert into profesor_cas values('2@mail.com', 5);

insert into student_cas values('5@mail.com', 1);
insert into student_cas values('5@mail.com', 2);
insert into student_cas values('6@mail.com', 3);
insert into student_cas values('5@mail.com', 4);
insert into student_cas values('6@mail.com', 5);

