use [CountriesDb]
go


create table Countries(
	id int not null primary key identity(1, 1),
	CountryName nvarchar(50) not null,
	Capital nvarchar(50) not null,
	[Population] nvarchar(50) not null,
	Area nvarchar(50) not null,
	Continent nvarchar(5) not null
);

insert into Countries values
('Ukraine', 'Kyiv', '41 732 779', '603 549', 'EU'),
('Russia', 'Moskow', '146 748 590', '3 783 533', 'EU'),
('Germany', 'Berlin', '83 019 391', '357 021', 'EU'),
('France', 'Paris', '66 991 000', '547 030', 'EU'),
('UK', 'London', '66 436 000', '244 820', 'EU'),
('Italy', 'Rome', '60 483 973', '301 340', 'EU'),
('Spain','Madrid','46 714 997','498 508', 'EU'),
('Poland','Warsaw','38 411 148','312 685', 'EU'),
('Netherlands','Amsterdam','17 282 163','41 526', 'EU'),
('Belgium','Brussels','11 467 923','32 528', 'EU');