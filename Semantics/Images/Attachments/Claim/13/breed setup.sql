select * from DefPagePath where PagePath='Ensure/Setup/Underwriting/UW/BreedSetup.aspx'

select * from DefPageSecurity where pageid = 226

select * from TBL_SECURITYNAME


insert into DefPagePath (PageName,PagePath) values ('Breed Setup','Ensure/Setup/Underwriting/UW/BreedSetup.aspx')

insert into TBL_SECURITYNAME (MODULEID,SECURITYNAME,ISVISIBLE,SecuritySno)
values (1,'Breed Setup Add',1,130)

insert into TBL_SECURITYNAME (MODULEID,SECURITYNAME,ISVISIBLE,SecuritySno)
values (1,'Breed Setup Edit',1,131)

insert into TBL_SECURITYNAME (MODULEID,SECURITYNAME,ISVISIBLE,SecuritySno)
values (1,'Breed Setup Delete',1,132)



