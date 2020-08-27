    
     drop proc      [acc_accCategory_insertUpdate]
	 go    
	 
/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_ACC_TRANSACTION]    Script Date: 04/03/2019 06:45:14 ******/
DROP TYPE [dbo].[TBLTYPE_ACC_TRANSACTION]
GO

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_ACC_TRANSACTION]    Script Date: 04/03/2019 06:45:14 ******/
CREATE TYPE [dbo].[TBLTYPE_ACC_TRANSACTION] AS TABLE(
	[CATID] [int] NULL,
	[TRANID] [int] NULL
)
GO



              
CREATE proc [dbo].[acc_accCategory_insertUpdate] (                       
   @CATID  int  = 0 ,                       
   @SNO  varchar(30)  = NULL ,                       
   @ECATEGORY  varchar(125)  = NULL ,                       
   @NCATEGORY  varchar(125)  = NULL ,                       
   @GLCODE varchar(50)  = NULL ,                       
   @DEPARTMENT  varchar(5)  = NULL ,                       
   @FIXEDCAT  int  = NULL ,                       
   @HASCHILD  tinyint ,                       
   @LEVEL1  int  = NULL ,                       
   @LEVEL2  int  = NULL ,                       
   @LEVEL3  int  = NULL ,                       
   @LEVEL4  int  = NULL ,                       
   @LEVEL5  int  = NULL ,                       
   @LEVELNO  int  = NULL ,                       
   @OFTYPE  int  = NULL ,                       
   @REFID int  = NULL ,                       
   @AUID  varchar(20)  = NULL ,                       
   @ADT  date  = NULL ,                       
   @UUID  varchar(20)  = NULL ,                       
   @UDT  date  = NULL  ,                      
 @msg varchar(40) output,                      
 @DEPTID int = null ,            
 @branchid int=null ,        
 @DRCRTYPE int=null ,      
 @TRANTYPE TBLTYPE_ACC_TRANSACTION readonly        ,  
 @islock int =null,    
 @islockpartyadj int =null ,  
 @tbGroup int = null,  
 @tbPart  int = null,  
 @MgmtExpGroup int = null            
 ) AS                       
 declare @errcode int, @NewCatid int , @RecCnt int , @FormattedSno varchar(20),@id_new int                     
 begin transaction                    
    if exists (select 1 from TBACCCATEGORY where CATID = @CATID )                            
          Begin                       
             Update TBACCCATEGORY SET                   
             ECATEGORY = @ECATEGORY,                       
             NCATEGORY = @NCATEGORY,                       
             GLCODE = @GLCODE,                      
             DEPTID = @DEPTID,                        
             OFTYPE = @OFTYPE,                       
             UUID = @UUID,                       
             UDT = GETDATE(),        
             DRCRTYPE=@DRCRTYPE   ,  
   ShowOnVPrint=@islock ,  
   partyadjustment=@islockpartyadj,  
   tbgroup = @tbGroup,  
   tbpart = @tbPart,  
   tbsubgroup = @MgmtExpGroup                     
             where CATID = @CATID     
         --if exists (select 1 from TBACCCATEGORY_TRANSACTION where CATID = @CATID )     
   begin       
    delete from TBACCCATEGORY_TRANSACTION where CATID=@CATID      
    insert into TBACCCATEGORY_TRANSACTION( CATID,TRANID)                         
    select c.CATID,c.TRANID  from @TRANTYPE  c    
   end    
                                
             set @msg='UPDATE'  
    set @id_new= @CATID                     
          End                       
    else                         
         Begin                       
            Insert into TBACCCATEGORY (                       
           SNO,  ECATEGORY,  NCATEGORY,                       
            GLCODE,  DEPTID,   LEVEL1,                       
            LEVEL2,  LEVEL3,  LEVEL4,  LEVEL5,  LEVELNO,                       
            OFTYPE,  REFID,  AUID,  ADT,  UUID,                       
            UDT,DRCRTYPE,ShowOnVPrint,partyadjustment, tbgroup, tbpart, tbsubgroup )                       
            VALUES (                      
              @SNO, @ECATEGORY, @NCATEGORY,                       
              @GLCODE, @DEPTID, @LEVEL1,                       
              @LEVEL2, @LEVEL3, @LEVEL4, @LEVEL5, @LEVELNO,                       
              @OFTYPE, @REFID, @AUID, GETDATE(), @UUID,                       
              GETDATE() ,@DRCRTYPE  ,@islock ,@islockpartyadj, @tbGroup, @tbPart, @MgmtExpGroup  
            )                      
            set @NewCatid = (select SCOPE_IDENTITY())                    
                                
            if (@LEVELNO=1)                    
     begin               
      update TBACCCATEGORY set LEVEL1 = @NewCatid where CATID = @NewCatid                      
     end                    
          if (@LEVELNO=2)                    
     begin                    
      update TBACCCATEGORY set LEVEL2 = @NewCatid where CATID = @NewCatid                      
     end             
   if (@LEVELNO=3)               
     begin                    
      update TBACCCATEGORY set LEVEL3 = @NewCatid where CATID = @NewCatid                      
     end                     if (@LEVELNO=4)                    
     begin                    
      update TBACCCATEGORY set LEVEL4 = @NewCatid where CATID = @NewCatid                      
     end                    
   if (@LEVELNO=5)                    
     begin                    
      update TBACCCATEGORY set LEVEL5 = @NewCatid where CATID = @NewCatid                      
     end     
      if(@REFID>0)    
      begin    
      insert into TBACCCATEGORY_TRANSACTION( CATID,TRANID)                         
         select @NewCatid,c.TRANID  from @TRANTYPE  c     
           end     
            set @msg='INSERT'   
     
   --added by sunil   
     select @id_new = SCOPE_IDENTITY() from TBACCCATEGORY_TRANSACTION    
                     
         End    
                    
           begin --for user activity log                     
  declare @nbranchid int=@branchid,                      
     @nuserid int=@uuid,                      
     @ntaskname varchar(200)='Account setup- Account Chart Defination',                      
     @ntaskdescription varchar(200)='Account Chart Defination  :'+isnull(@ECATEGORY,''),                    
     @nactivity varchar(200)=@msg ,  
  @nPrimarykey int =@id_new                  
                         
  exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimarykey                    
 end                            
    select @errcode = @@ERROR                       
    if(@errcode <> 0) goto problem                       
    commit transaction                       
    problem:                       
    if(@errcode <> 0)                        
    begin                       
  declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)               
   set @ErrID = ( select  ERROR_NUMBER()  )              
   set @ErrSeverity = ( select  ERROR_SEVERITY()  )              
   set @ErrState = (select ERROR_STATE())              
   set @ErrProc = (select ERROR_PROCEDURE())              
   set @ErrLine = (select ERROR_LINE())              
   set @ErrMsg = (select ERROR_MESSAGE())              
                 
   rollback transaction                 
                 
   insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)              
   values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)                       
    end 

	go

	IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_AccCategoryChild_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_AccCategoryChild_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE  proc [dbo].[acc_AccCategoryChild_get]
(
@REFID int  = NULL
)
as
begin
SELECT DISTINCT * from TBACCCATEGORY where REFID=@REFID order by CATID
end
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_chartOfAccount_getSNO]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_chartOfAccount_getSNO]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE procedure acc_chartOfAccount_getSNO    
(    
@REFID int=null,    
@CATID int=null    
)    
as    
begin    
    Select (ISNULL(max(cast(sno as int)),0)+1)  as sno from TBACCCATEGORY where REFID =@CATID    
--Select (ISNULL(max(sno),0)+1)  as sno from TBACCCATEGORY where REFID =@CATID    
end 

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_transactionList_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_transactionList_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[acc_transactionList_get]    
(    
@CATID int=NULL    
)    
as    
begin    
SELECT * from TBACCCATEGORY_TRANSACTION where CATID=@CATID  
end
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_AccHead_getSLcode]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_AccHead_getSLcode]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[acc_AccHead_getSLcode]  
(  
@GLCODE varchar(10)=null
)  
as  
begin  
create table #temp
(
SLCODE varchar(10)
)
--set nocount off
  insert into #temp(SLCODE)
Select (ISNULL(max(SLCODE),0)+1)  as SLCODE from ac_accounthead where GLCODE =@GLCODE

Select SLCODE from #temp
end  
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_accHead_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_accHead_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[acc_accHead_insertUpdate] (                   
   @ACCOUNTCODE  int  = NULL ,                     
   @ACCOUNTDESC  varchar(200)  = NULL ,                     
   @ACCOUNTDESCN  varchar(100)  = NULL ,                     
   @ACCOUNTTYPE  smallint  = NULL ,                     
   @AGENTCODE  varchar(10)  = NULL ,                     
   @ATYPE  smallint  = NULL ,                           
   @BRANCHCODE  int  = NULL ,                     
   @CATID  int  = NULL ,                     
   @CLASSID  int  = NULL ,                    
   @CURRENCYACCOUNT  smallint  = NULL ,                     
   @DEPTID  int = NULL ,                      
   @PLCATEGORY  tinyint  = NULL ,                     
   @TYPE  tinyint  = NULL ,                           
   @DEPTCODE  varchar(3)  = NULL ,                     
   @GLCODE  varchar(10)  = NULL ,                    
   @SLCODE  varchar(10)  = NULL ,                     
   @TBGROUP  varchar(10)  = NULL ,                     
   @TBPART  varchar(10)  = NULL ,                     
   @TBSUBGROUP  varchar(10)  = NULL ,                     
   @AUID  int  = NULL ,                   
   @UUID  int  = NULL ,                  
    @msg varchar(max) output  ,                
    @branchid int=null,          
    @surveyorid int=null,      
    @ISBANK int=null,    
    @minimunbalance numeric(16,2)=null,    
    @bankaccno varchar(50)=null,    
    @balance_typeid int =null ,  
 @IsVatOnSales int = null,
 @RICompanyID int = null ,
 @islock int = null               
 ) AS                     
 declare @errcode int,@id_new int                            
 begin transaction           
 BEGIN TRY                  
    -- change the 3 lines below as per your requirement                    
    if exists (select 1 from AC_AccountHead where ACCOUNTCODE = @ACCOUNTCODE )                            
          Begin                     
             Update AC_AccountHead SET                     
             ACCOUNTDESC = @ACCOUNTDESC,                     
             ACCOUNTDESCN = @ACCOUNTDESCN,                     
             ACCOUNTTYPE = @ACCOUNTTYPE,                     
             AGENTCODE = @AGENTCODE,                     
             ATYPE = @ATYPE,                   
             BRANCHCODE = @BRANCHCODE,                     
             CATID = @CATID,                     
             CLASSID = @CLASSID,                  
             CURRENCYACCOUNT = @CURRENCYACCOUNT,                     
             DEPTID = @DEPTID,                     
             PLCATEGORY = @PLCATEGORY,                  
             TYPE = @TYPE,                   
             DEPTCODE = @DEPTCODE,                     
             GLCODE = @GLCODE,                   
             SLCODE = @SLCODE,                       
             TBGROUP = @TBGROUP,                     
             TBPART = @TBPART,                     
             TBSUBGROUP = @TBSUBGROUP,               
             BRANCHID=@branchid,                 
             UUID = @UUID,                     
             UDT = GETDATE() ,          
             surveyorid=@surveyorid,      
             ISBANK=@ISBANK,    
             min_balance = @minimunbalance,    
              Bank_Acc_No = @bankaccno,    
              balancetypeid = @balance_typeid,  
			   IsVatOnSales = @IsVatOnSales,
			   RICOMPANYID = @RICompanyID ,
			   locked=@islock 
             where ACCOUNTCODE = @ACCOUNTCODE                  
             set @msg='UPDATE'    
    set @id_new = @ACCOUNTCODE                   
          End                     
    else                       
             Begin                     
                Insert into AC_AccountHead (                     
                 ACCOUNTDESC,  ACCOUNTDESCN,                     
                ACCOUNTTYPE,  AGENTCODE,  ATYPE,                     
                BRANCHCODE,  CATID,  CLASSID,                      
                CURRENCYACCOUNT,  DEPTID,                    
                PLCATEGORY,   TYPE,                     
                  DEPTCODE,                     
                GLCODE,    SLCODE,                       
                TBGROUP,  TBPART,  TBSUBGROUP,   AUID,                     
                ADT,  UUID,  UDT,BRANCHID,surveyorid,ISBANK,min_balance,
				Bank_Acc_No, balancetypeid,IsVatOnSales,RICOMPANYID,locked)                   
                VALUES (           
                  @ACCOUNTDESC, @ACCOUNTDESCN,                     
                  @ACCOUNTTYPE, @AGENTCODE, @ATYPE,                      
                  @BRANCHCODE, @CATID, @CLASSID,                     
                  @CURRENCYACCOUNT, @DEPTID,                   
                  @PLCATEGORY, @TYPE,                     
                    @DEPTCODE,                     
                  @GLCODE,  @SLCODE,                      
              @TBGROUP, @TBPART, @TBSUBGROUP,  @AUID,                     
                  GETDATE(), @UUID, GETDATE(),@branchid,@surveyorid,@ISBANK,@minimunbalance,  
				  @bankaccno, @balance_typeid ,@IsVatOnSales,@RICompanyID ,@islock   
                )                    
                set @msg='INSERT'    
    --added by sunil     
     select @id_new = SCOPE_IDENTITY() from AC_AccountHead                      
      End                  
    begin --for user activity log                         
      declare @nbranchid int=@branchid,                          
      @nuserid int=@uuid,            
      @ntaskname varchar(200)='Account-Account Head Creation',                          
      @ntaskdescription varchar(200)='Account Head Creation Description  :'+isnull(@ACCOUNTDESC,''),                        
      @nactivity varchar(200)=@msg,    
  @nPrimarykey int =@id_new                    
                           
  exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimarykey                      
    end                                  
                         
    commit transaction           
 END TRY        
 BEGIN CATCH        
  select @errcode = @@ERROR        
            
  ROLLBACK TRAN        
  set @msg='FAIL'         
  if(@errcode <> 0) goto problem         
  problem:           
  if(@errcode <> 0)                      
  begin                       
     declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)                   
     set @ErrID = ( select  ERROR_NUMBER()  )                  
     set @ErrSeverity = ( select  ERROR_SEVERITY()  )                  
     set @ErrState = (select ERROR_STATE())                  
     set @ErrProc = (select ERROR_PROCEDURE())                  
     set @ErrLine = (select ERROR_LINE())                  
     set @ErrMsg = (select ERROR_MESSAGE())                  
                       
     rollback transaction                     
                       
     insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)                  
     values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)                     
  end               
 END CATCH 

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_accHead_accCategory_list]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_accHead_accCategory_list]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




  
      
                                    
CREATE proc [dbo].[acc_accHead_accCategory_list]                                      
(                                      
@CATID int=null,                            
@AccountDesc varchar(200)=null                                      
)                                      
as                                      
begin                 
 declare @SQL NVARCHAR(MAX)                                  
 SET @SQL = N'SELECT DISTINCT convert(int,ROW_NUMBER() over (order by b.ACCOUNTDESC)) as sno,                                  
 b.ACCOUNTCODE,b.ACCOUNTDESC,b.ACCOUNTTYPE,b.DEPTID,b.ACCOUNTCODE as ACCHEADID,                                  
 a.CATID as accCatid,a.CATID,a.REFID,b.SLCODE,a.GLCODE,b.ACCOUNTDESCN,b.DEPTCODE,b.TBGROUP,b.TBPART,b.TBSUBGROUP                                
 ,b.CLASSID,b.ACCOUNTTYPE,b.CURRENCYACCOUNT,b.AGENTCODE,b.PLCATEGORY,b.BRANCHID ,b.surveyorid,b.ISBANK,b.ISBANK,  
 b.Bank_Acc_No,b.min_balance,ISNULL(b.balancetypeid,0)balancetypeid, b.IsVatonSales, b.ricompanyid, isnull(b.locked,0) Locked
 FROM         dbo.TBACCCATEGORY as a LEFT OUTER JOIN                                      
 dbo.AC_AccountHead as b ON a.CATID = b.CATID                                   
 where  1 = 1 '            
 if (isnull(@CATID,0)>0) set @SQL = @SQL + ' AND a.CATID = ' + CONVERT(VARCHAR,@CATID )            
 IF (ISNULL(@AccountDesc,'')<> '')            
 BEGIN            
  set @SQL = @SQL + ' and ( b.Accountdesc like ''' + '%' + @AccountDesc + '%'''            
  set @SQL = @SQL + ' or '            
  set @SQL = @SQL + ' convert(varchar,b.accountcode) = ''' + @AccountDesc + ''''            
  set @SQL = @SQL + ' ) '              
 END            
 set @SQL = @SQL + ' ORDER BY b.ACCOUNTDESC '       
 EXECUTE sp_executesql @Sql            
 --print @sql            
end   

select * from AC_AccountHead where locked = 0



GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[company_SubBranch_getList]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[company_SubBranch_getList]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE procedure [dbo].[company_SubBranch_getList]      
 (      
 @SUBBRANCHCODE varchar(4)='',      
 @BRANCHID int=null      
 )      
 as begin      
 select * from MSSUBBRANCH where     (ISNULL(@BRANCHID,'')='' or BRANCHID=@BRANCHID)  order by  ISDEFAULT desc  
  --and(ISNULL(@SUBBRANCHCODE,'')='' or SUBBRANCHCODE=@SUBBRANCHCODE)   
      
 end  

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[company_FiscalYr_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[company_FiscalYr_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE procedure [dbo].[company_FiscalYr_get]          
(          
 @ID int =0          
 )          
as begin          
select a.*,b.RATE as taxrate,d.username as enteredby,c.username as updatedby from FISCALYEAR   a         
 LEFT join [vw_TaxRate] b on a.ID=b.fiscalid 
 left join tbluser d on d.id=a.auid
left join tbluser c on c.id=a.uuid        
where (ISNULL(@ID,0)=0 or  a.ID=@ID)    order by ENGSTARTDATE desc  
end   

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vw_TaxRate]')  )
DROP VIEW  [dbo].[vw_TaxRate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE view [dbo].[vw_TaxRate] as

SELECT t1.*
FROM taxrate t1
WHERE t1.id = (SELECT MAX(id) as id
                 FROM taxrate t2
                 WHERE t2.fiscalid = t1.fiscalid)
                 
                 
--select  a.* from taxrate a
--inner join (
--	select MAX(rate) as rate,id, fiscalid from taxrate
--	group by id, fiscalid  
--) b on a.id = b.id and a.fiscalid=b.fiscalid 



GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fiscalyear_startend_Date_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[fiscalyear_startend_Date_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create procedure fiscalyear_startend_Date_get
(
	@ID int=0
)
as
begin
select ENGENDDATE,ENGSTARTDATE,STARTDATE,ENDDATE from FISCALYEAR where ID=@ID
end
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[company_FiscalYr_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[company_FiscalYr_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[company_FiscalYr_insertUpdate] 
(                 
   @ID  int  = null,                 
   @ENGSTARTDATE  date  = NULL ,                 
   @STARTDATE  varchar(50)  = NULL ,                 
   @ENGENDDATE  date  = NULL ,                 
   @ENDDATE  varchar(50)  = NULL ,                 
   @ENGFISCALYEAR  varchar(20)  = NULL ,                 
   @FISCALYEAR  varchar(20)  = ' ' ,                 
   @YEAR  varchar(5)  = NULL ,                 
   @STATUS  tinyint = NULL ,                 
   @FISCALYEARCODE  int  = NULL ,                 
   @ISCURRENTFY  tinyint = NULL ,                 
   @AUID  varchar(20)  = NULL ,                 
   @ADT  datetime  = NULL ,                 
   @UUID  varchar(20)  = NULL ,                 
   @UDT  datetime  = NULL  ,                
   @msg varchar(20) output  ,              
   @TAXRATE numeric(16,4),            
   @branchid int =null ,    
   @ALIAS varchar(50)=null,
   @islock int=null              
 ) AS                 
 declare @errcode int  ,@IDnew int               
 begin transaction           
   begin try               
  if exists (select 1 from FISCALYEAR where ID = @ID)           
   Begin                   
  update FISCALYEAR                
   set ENGSTARTDATE = @ENGSTARTDATE,                
   STARTDATE = @STARTDATE,                
   ENGENDDATE = @ENGENDDATE,                
   ENDDATE = @ENDDATE,                         
   ENGFISCALYEAR = @ENGFISCALYEAR,                
   FISCALYEAR = @ENGFISCALYEAR,                         
   [YEAR] = @YEAR,                        
   [STATUS] = @STATUS,                
   FISCALYEARCODE = @FISCALYEARCODE,                
   ISCURRENTFY = @ISCURRENTFY,                   
   UUID = @UUID,                
   UDT = GETDATE(),    
   ALIAS = @ALIAS,
   islock=@islock    
                 
  where ID = @ID                
  set @msg='update' 
  set @IDnew=@ID        
   End                 
  else                 
   Begin                  
  insert into FISCALYEAR(ENGSTARTDATE,STARTDATE,ENGENDDATE,ENDDATE,ENGFISCALYEAR,FISCALYEAR,YEAR,                
   STATUS,FISCALYEARCODE,ISCURRENTFY,AUID,ADT,UUID,UDT,ALIAS,islock)                
  values (                
   (case @ENGSTARTDATE when '0001-01-01' then null else @ENGSTARTDATE end),              
   (case @STARTDATE when '' then null else @STARTDATE end),                
   (case @ENGENDDATE when '0001-01-01' then null else @ENGENDDATE end),              
   (case @ENDDATE when '' then null else @ENDDATE end),                
   (case @ENGFISCALYEAR when '' then null else @ENGFISCALYEAR end),                
   --(case @FISCALYEAR when '' then null else @FISCALYEAR end),      
   (case @ENGFISCALYEAR when '' then null else @ENGFISCALYEAR end),                   
   (case @YEAR when '' then null else @YEAR end),                
   @STATUS,                
   (case @FISCALYEARCODE when 0 then null else @FISCALYEARCODE end),                
   @ISCURRENTFY,                
   (case @AUID when '' then null else @AUID end),                
   GETDATE(),                
   (case @UUID when '' then null else @UUID end),                
   GETDATE() ,    
   @ALIAS ,
   @islock            
   )                
              
  set @msg='insert'
   select @IDnew=SCOPE_IDENTITY() from FISCALYEAR          
   End               
           
  insert into TAXRATE (fiscalid,RATE,TDSRATE,AUID,ADT,UUID,UDT)              
  values (  @ID,@TAXRATE,@TAXRATE,@AUID,GETDATE(),@UUID,GETDATE())             
           
  --if(@msg!= 'duplicate'  )              
   begin --for user activity log               
    declare @nbranchid int=@branchid,                
    @nuserid int=@uuid,                
    @ntaskname varchar(200)='Setup-Master Setup-Fiscal Year Setup',                
    @ntaskdescription varchar(200)='Fiscal Year:- '+isnull(@ENGFISCALYEAR,'') + 'on date '+convert(varchar,@UDT),                
    @nactivity varchar(200)=@msg,                       
    @nPrimaryKey int = @IDnew               
  
    exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimaryKey          
  end
   end try          
   begin catch          
    set @errcode = (select  ERROR_NUMBER())          
    goto problem          
   end catch                       
          
 select @errcode = @@ERROR               
 if(@errcode <> 0) goto problem                 
commit transaction                 
problem:                 
if(@errcode <> 0)                  
 begin                 
  declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)                 
  set @ErrID = ( select  ERROR_NUMBER()  )                
  set @ErrSeverity = ( select  ERROR_SEVERITY()  )                
  set @ErrState = (select ERROR_STATE())                
  set @ErrProc = (select ERROR_PROCEDURE())                
  set @ErrLine = (select ERROR_LINE())                
  set @ErrMsg = (select ERROR_MESSAGE())                
          
  rollback transaction                  
          
  insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)                
  values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)           
            
  set   @msg='error/'+cast((select SCOPE_IDENTITY()) as varchar)          
 end 

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[company_FiscalYr_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[company_FiscalYr_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE procedure [dbo].[company_FiscalYr_get]          
(          
 @ID int =0          
 )          
as begin          
select a.*,b.RATE as taxrate,d.username as enteredby,c.username as updatedby from FISCALYEAR   a         
 LEFT join [vw_TaxRate] b on a.ID=b.fiscalid 
 left join tbluser d on d.id=a.auid
left join tbluser c on c.id=a.uuid        
where (ISNULL(@ID,0)=0 or  a.ID=@ID)    order by ENGSTARTDATE desc  
end   

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_icVoucherType_getList]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_icVoucherType_getList]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE proc [dbo].[acc_icVoucherType_getList]    
(    
    
@ID int=null,  
@mode int =null,--0 for entry mode and 1 for report  
@showondisbursement int=null  
)    
as    
begin    
 declare @Sql nvarchar(max)  
 set @Sql=N'select  * from ic_vouchertype where 1=1'  
  
 if (ISNULL(@ID,0) > 0)  
  begin  
   set @Sql = @Sql + ' and ID = ' + CONVERT(varchar, @ID)  
  end  
 else  
  begin  
   --set @Sql = @Sql + ' and TOSHOW = 1'   
   if(isnull(@mode,0)=0)  
    begin  
     set @Sql = @Sql + ' and VOUCHERTYPE = 0'  
    end  
      
   if(isnull(@showondisbursement,0)=1)  
    begin  
     set @Sql = @Sql + ' and ShowOnDisbursement = 1'  
    end  
  end  
    
 set @Sql = @Sql + ' order by SNO'    
   
 EXECUTE sp_executesql @Sql  
end    
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_icVoucherType_getList]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_icVoucherType_getList]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE proc [dbo].[acc_icVoucherType_getList]    
(    
    
@ID int=null,  
@mode int =null,--0 for entry mode and 1 for report  
@showondisbursement int=null  
)    
as    
begin    
 declare @Sql nvarchar(max)  
 set @Sql=N'select  * from ic_vouchertype where 1=1'  
  
 if (ISNULL(@ID,0) > 0)  
  begin  
   set @Sql = @Sql + ' and ID = ' + CONVERT(varchar, @ID)  
  end  
 else  
  begin  
   --set @Sql = @Sql + ' and TOSHOW = 1'   
   if(isnull(@mode,0)=0)  
    begin  
     set @Sql = @Sql + ' and VOUCHERTYPE = 0'  
    end  
      
   if(isnull(@showondisbursement,0)=1)  
    begin  
     set @Sql = @Sql + ' and ShowOnDisbursement = 1'  
    end  
  end  
    
 set @Sql = @Sql + ' order by SNO'    
   
 EXECUTE sp_executesql @Sql  
end    
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_voucherType_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_voucherType_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  --asp_search_sp acc_voucherType_insertUpdate
  
   
CREATE proc [dbo].[acc_voucherType_insertUpdate] (               
   @ID  int  = 0 ,               
   @SNO  int = NULL ,               
   @ETITLE  varchar(255)  = NULL ,               
   @NTITLE  nvarchar(260)  = NULL ,               
   @EABBRV  varchar(20)  = NULL ,               
   @NABBRV  nvarchar(25)  = NULL ,               
   @VOUCHERTYPE  int  = NULL ,               
   @SHOW  int = NULL ,               
   @TOSHOW  int = NULL ,               
   @STATUS  int  = NULL ,               
   @AUID  int = NULL ,               
   @ADT  datetime  = NULL ,               
   @UUID int  = NULL ,               
   @UDT  datetime  = NULL  ,              
    @msg varchar(40) output,            
    @branchid int=null ,    
    @moduleid int = null,  
    @islock int=null             
 ) AS               
 declare @errcode int  ,@idnew int             
 begin transaction              
 begin try        
 if exists (select 1 from ic_vouchertype where ID=@ID)            
          Begin               
             Update ic_vouchertype SET             
             ETITLE = @ETITLE,               
             NTITLE = @NTITLE,               
             EABBRV = @EABBRV,               
             NABBRV = @NABBRV,               
             VOUCHERTYPE = @VOUCHERTYPE,               
             SHOW = @SHOW,               
             TOSHOW = @TOSHOW,               
             STATUS = @STATUS,           
             UUID = @UUID,               
             UDT = @UDT  ,    
             moduleid=@moduleid ,  
             islock=@islock           
             where ID=@ID              
             set @msg='update'       
			 	set @idnew=@ID        
          End               
    else                
             Begin               
                Insert into ic_vouchertype (               
                ETITLE,  NTITLE,               
                EABBRV,  NABBRV,  VOUCHERTYPE,  SHOW,  TOSHOW,               
                STATUS,  AUID,  ADT,  UUID,  UDT,moduleid,islock )               
                VALUES (              
                  @ETITLE, @NTITLE,               
                  @EABBRV, @NABBRV, @VOUCHERTYPE, @SHOW, @TOSHOW,               
                  @STATUS, @AUID, @ADT, @UUID, @UDT,@moduleid,@islock              
                )              
                set @msg='insert' 
				select @idnew = SCOPE_IDENTITY() from ic_vouchertype               
             End              
              --if(@msg!= 'duplicate'  )            
              begin --for user activity log             
  declare @nbranchid int=@branchid,              
     @nuserid int=@uuid,              
     @ntaskname varchar(200)='Seup-Account-Voucher Type ',              
     @ntaskdescription varchar(200)='Voucher Type Title:-'+ isnull(@ETITLE,''),              
     @nactivity varchar(200)=@msg,                   
	 @nPrimaryKey int = @idnew                
  
    exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimaryKey          
  end              
 end try        
 begin catch           
    select @errcode = @@ERROR               
    if(@errcode <> 0) goto problem          
    end catch             
    commit transaction               
    problem:               
    if(@errcode <> 0)                
    begin              
    declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)                 
  set @ErrID = ( select  ERROR_NUMBER()  )                
  set @ErrSeverity = ( select  ERROR_SEVERITY()  )                
  set @ErrState = (select ERROR_STATE())                
  set @ErrProc = (select ERROR_PROCEDURE())                
  set @ErrLine = (select ERROR_LINE())                
  set @ErrMsg = (select ERROR_MESSAGE())             
       rollback transaction            
       insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)       
  values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)           
            
  set   @msg='error/'+cast((select SCOPE_IDENTITY()) as varchar)              
    end 
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[USP_INSERTUPDATE_DISBURDEMENT]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[USP_INSERTUPDATE_DISBURDEMENT]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE USP_INSERTUPDATE_DISBURDEMENT    
(        
 @ID int,        
 @ETITLE varchar(250),        
 @NTITLE varchar(250),        
 @EABBRV varchar(250),        
 @NABBRV varchar(250),  
 @AUID int,  
 @ADT DATETIME,  
 @UUID int,  
 @UDT DATETIME,        
 @msg varchar(20) output  ,        
 @STATUS int,  
 @branchid int=null      
)        
AS         
 declare @errcode int ,@id_new int
declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)                                                        
begin transaction           
   begin try        
    if exists (select 1 from tblDisbursementType where ID=@ID )        
    BEGIN        
     UPDATE tblDisbursementType        
     SET ETITLE=@ETITLE,  
  NTITLE=@NTITLE,  
  EABBRV=@EABBRV,  
  NABBRV=@NABBRV,  
  AUID=@AUID,  
  ADT=@ADT,  
  UUID=@UUID,  
  UDT=GETDATE(),  
  STATUS=@STATUS       
       where ID=@ID      
       set @msg='update'
	   set @id_new= @ID       
    END        
    Else        
     BEGIN        
      INSERT INTO tblDisbursementType(ETITLE,NTITLE,EABBRV,NABBRV,AUID,ADT,UUID,UDT,STATUS)        
        VALUES(@ETITLE,@NTITLE,@EABBRV,@NABBRV,@AUID,@ADT,@UUID,GETDATE(),@STATUS)        
                
           set @msg='insert' 
		       
        select @id_new = SCOPE_IDENTITY() from tblDisbursementType  
     END  
  begin /*for user activity log*/ 
			declare @nbranchid int=@branchid,   
			@nuserid int=@uuid,  
			@ntaskname varchar(200)='Underwritting KYC Entry',  
			@nactivity varchar(200)=@msg ,
			@nPrimaryKey int = 1,   
			@ntaskdescription varchar(200)='Add Customer of Insued Name ' --+ isnull(@TITLE,'') + ' Mobile No :.' + isnull(@MOBILENO,'') + ' On date :. ' + cast(isnull(@UDT,'')as varchar)

			 
					set @ntaskdescription = @ntaskdescription +' Citizenship No :.'-- + isnull(@CITIZENSHIPNO,'')
				         
			exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimaryKey          
		end                                               
	END TRY                                       
	BEGIN CATCH                                                      
		SET @errcode=(SELECT ERROR_NUMBER())                                                                                               
		set @ErrID = ( select  ERROR_NUMBER()  )                                                      
		set @ErrSeverity = ( select  ERROR_SEVERITY()  )                                                      
		set @ErrState = (select ERROR_STATE())                                                      
		set @ErrProc = (select ERROR_PROCEDURE())                                           
		set @ErrLine = (select ERROR_LINE())                                                      
		set @ErrMsg = (select ERROR_MESSAGE())                                     
		GOTO PROBLEM                                 
	END CATCH                                                   
                                                   
	select @errcode = @@ERROR                                                     
	if(@errcode <> 0) 
		BEGIN                                                                                     
			set @ErrID = ( select  ERROR_NUMBER()  )                                                      
			set @ErrSeverity = ( select  ERROR_SEVERITY()  )                                                      
			set @ErrState = (select ERROR_STATE())                                                      
			set @ErrProc = (select ERROR_PROCEDURE())                                           
			set @ErrLine = (select ERROR_LINE())                                                      
			set @ErrMsg = (select ERROR_MESSAGE())  
			goto problem                                                     
		END
commit transaction                                          
problem:                                               
if(@errcode <> 0)                                                      
	begin                                                   
		rollback transaction                                                         
                                            
		insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)              
		values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)                                                       
                                               
		set   @msg='error/'+cast((select SCOPE_IDENTITY()) as varchar)                                                     
                                                  
	end 

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_DESBURSEMENT_LIST]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[GET_DESBURSEMENT_LIST]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE procedure GET_DESBURSEMENT_LIST      
 (      
       
 @ID int=null    
   
 )      
 as begin      
 select * from tblDisbursementType where       
  (ISNULL(@ID,'')='' or ID=@ID)    
      
 end
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_accType_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_accType_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[acc_accType_get]
as
begin
	select f.username as enteredby,g.username as updatedby,a.* from TBACCOUNTTYPE  a
	left join tbluser f on f.id=a.auid      
	left join tbluser g on g.id=a.uuid
end

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_accType_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_accType_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  --asp_search_sp acc_accType_insertUpdate
  
/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_ACCOUNTTYPE]    Script Date: 04/03/2019 09:25:28 ******/
DROP TYPE [dbo].[TBLTYPE_ACCOUNTTYPE]
GO

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_ACCOUNTTYPE]    Script Date: 04/03/2019 09:25:28 ******/
CREATE TYPE [dbo].[TBLTYPE_ACCOUNTTYPE] AS TABLE(
	[ROWNUMBER] [int] NULL,
	[ACCOUNTTYPE] [varchar](3) NULL,
	[DESCRIPTION] [varchar](50) NULL
)
GO



  
          
CREATE proc [dbo].[acc_accType_insertUpdate] (             
   @ACCTYPEID  int  = NULL ,             
   @ACCOUNTTYPE  varchar(3)  = NULL ,             
   @DESCRIPTION  nvarchar(60)  = NULL  ,            
   @ACCOUNT [dbo].[TBLTYPE_ACCOUNTTYPE] readonly,            
    @msg varchar(40) output ,        
     --@UUID  varchar(20)  = NULL ,           
     @branchid int=null,  
     @islock int=null,  
     @AUID int=null,  
     @UUID int=null,  
     @ADT datetime=null,  
     @UDT datetime=null          
 ) AS             
 declare @errcode int ,@idnew int                
 begin transaction           
 begin try         
    if exists (select 1 from TBACCOUNTTYPE where ACCTYPEID = @ACCTYPEID )            
  --if exists (select 1 from TBACCOUNTTYPE where DESCRIPTION=@DESCRIPTION and ACCTYPEID <> @ACCTYPEID)            
  -- set @msg='DUPLICATE'            
  --else            
  -- if exists (select 1 from TBACCOUNTTYPE where ACCOUNTTYPE=@ACCOUNTTYPE and ACCTYPEID <> @ACCTYPEID)            
  --  set @msg='DUPLICATE'          
  -- ELSE          
     Begin             
     Update TBACCOUNTTYPE SET             
      ACCOUNTTYPE = @ACCOUNTTYPE,             
      DESCRIPTION = @DESCRIPTION,  
      islock=@islock,  
      UUID=@UUID,  
      UDT=@UDT            
      where ACCTYPEID = @ACCTYPEID            
      set @msg='UPDATE'   
	  set @idnew=@ACCTYPEID           
      End             
    else              
         Begin             
            Insert into TBACCOUNTTYPE             
            (             
             ACCOUNTTYPE,  DESCRIPTION,islock ,AUID,ADT,UUID ,UDT           
             )             
            VALUES (            
              @ACCOUNTTYPE, @DESCRIPTION ,@islock ,@AUID ,@ADT ,@UUID ,@UDT       
            )            
            set @msg='INSERT'  
				select @idnew = SCOPE_IDENTITY() from TBACCOUNTTYPE                
         End             
               
         --if(@msg!= 'duplicate'  )        
              begin --for user activity log         
  declare @nbranchid int=@branchid,          
     @nuserid int=@uuid,          
     @ntaskname varchar(200)='Seup-Account-Account Type Setting ',          
     @ntaskdescription varchar(200)='Voucher Type Setting Decription:- '+ isnull(@DESCRIPTION,''),          
     @nactivity varchar(200)=@msg,                   
	 @nPrimaryKey int = @idnew                
  
    exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimaryKey          
  end        
 end try      
 begin catch                   
    select @errcode = @@ERROR             
    if(@errcode <> 0) goto problem          
    end catch         
    commit transaction             
    problem:             
  if(@errcode <> 0)              
  begin             
   declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)           
   set @ErrID = ( select  ERROR_NUMBER()  )          
   set @ErrSeverity = ( select  ERROR_SEVERITY()  )          
   set @ErrState = (select ERROR_STATE())          
   set @ErrProc = (select ERROR_PROCEDURE())          
   set @ErrLine = (select ERROR_LINE())          
   set @ErrMsg = (select ERROR_MESSAGE())          
             
   rollback transaction             
             
   insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)          
   values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)        
   set   @msg='error/'+cast((select SCOPE_IDENTITY()) as varchar)           
  end           
            
            
            

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_TransactionType_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_TransactionType_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc acc_TransactionType_insertUpdate (             
   @ID  int  = 0 ,             
     @VOUCHERTYPEID int = null,  
     @TRANSACTIONNAME varchar(100) =null,  
     @TRANSACTIONNAMEnep varchar(100)=null,  
     @ABBR varchar(50) = null,  
     @CODE varchar(50) = NULL,        
    @msg varchar(40) output, 
	
	 @AUID int,  
 @ADT DATETIME,  
 @UUID int,  
 @UDT DATETIME,  
	@branchid int=null             
               
 ) AS             
 declare @errcode int,@id_new int             
 begin transaction            
 begin try      
 if exists (select 1 from TBACCTRANSACTIONTYPE where ID=@ID)          
          Begin             
             Update TBACCTRANSACTIONTYPE SET           
                  VOUCHERTYPEID=@VOUCHERTYPEID,  
                  TRANSACTIONNAME=@TRANSACTIONNAME,  
                  NTRANSACTIONNAME=@TRANSACTIONNAMEnep,  
                  ABBR=@ABBR,  
                  CODE=@CODE,
				   AUID=@AUID,  
                  ADT=@ADT,  
                 UUID=@UUID,  
               UDT=GETDATE()    
             where ID=@ID            
             set @msg='update'
			set @id_new= @ID           
          End             
    else              
        Begin             
        Insert into TBACCTRANSACTIONTYPE (VOUCHERTYPEID,TRANSACTIONNAME,ABBR,  CODE,AUID,ADT,UUID,UDT,NTRANSACTIONNAME)             
        VALUES (@VOUCHERTYPEID, @TRANSACTIONNAME, @ABBR, @CODE,@AUID,@ADT,@UUID,GETDATE(),@TRANSACTIONNAMEnep) 
				             
        set @msg='insert'   
				         
        select @id_new = SCOPE_IDENTITY() from TBACCTRANSACTIONTYPE  
END  
     begin --for user activity log                               
   declare @nbranchid int=@branchid,                                
   @nuserid int=@uuid,                                
   @ntaskname varchar(200)='Transaction Type ',                                
   @ntaskdescription varchar(200)='Transaction enteres as:'+isnull(@TRANSACTIONNAME,''),                                
   @nactivity varchar(200)=@msg,
     @nprimarykey int =@id_new                                         
      
  exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nprimarykey
               
  End             
 end try      

 begin catch       
  declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)                 
    select @errcode = @@ERROR      
	  set @ErrID = ( select  ERROR_NUMBER()  )              
  set @ErrSeverity = ( select  ERROR_SEVERITY()  )              
  set @ErrState = (select ERROR_STATE())              
  set @ErrProc = (select ERROR_PROCEDURE())              
  set @ErrLine = (select ERROR_LINE())              
  set @ErrMsg = (select ERROR_MESSAGE())        
    if(@errcode <> 0) 
	  set @ErrID = ( select  ERROR_NUMBER()  )              
  set @ErrSeverity = ( select  ERROR_SEVERITY()  )              
  set @ErrState = (select ERROR_STATE())              
  set @ErrProc = (select ERROR_PROCEDURE())              
  set @ErrLine = (select ERROR_LINE())              
  set @ErrMsg = (select ERROR_MESSAGE()) goto problem        
    end catch           
    commit transaction             
    problem:             
    if(@errcode <> 0)              
    begin            
   
  set @ErrID = ( select  ERROR_NUMBER()  )              
  set @ErrSeverity = ( select  ERROR_SEVERITY()  )              
  set @ErrState = (select ERROR_STATE())              
  set @ErrProc = (select ERROR_PROCEDURE())              
  set @ErrLine = (select ERROR_LINE())              
  set @ErrMsg = (select ERROR_MESSAGE())           
       rollback transaction          
       insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)              
  values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)         
          
  set   @msg='error/'+cast((select SCOPE_IDENTITY()) as varchar)            
    end 
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_LoadvendorName_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_LoadvendorName_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[acc_LoadvendorName_get]  
(  
@VEN_ID int=null  
)  
as   
begin  
--select VEN_ID,ADDRESS,EMAILADDRESS,MOBILENO,PANNO,TELEPHONENO,VATNO,  
--VENDORCODE,VENDORDESC,NVENDORDESC from TBLVENDORINFO  
  
select ROW_NUMBER() over (order by a.VEN_ID) as  RowNumber ,a.VEN_ID,a.ADDRESS,a.EMAILADDRESS,a.MOBILENO,a.PANNO,a.TELEPHONENO,a.VATNO,a.ACCOUNTID,
b.KYCNO , 
VENDORCODE,VENDORDESC,NVENDORDESC from TBLVENDORINFO a
inner join MSACNAME b on b.ID=a.ACCOUNTID  
  
end  
  
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_vendorName_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_vendorName_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  --asp_search_sp acc_vendorName_insertUpdate
  
  
          
CREATE proc [dbo].[acc_vendorName_insertUpdate] (           
@VEN_ID int=0,          
   @ADDRESS  nvarchar(90)   = NULL ,           
   @EMAILADDRESS  varchar(20)  = NULL ,           
   @MOBILENO  varchar(20)  = NULL ,           
   @PANNO  varchar(20)  = NULL ,           
   @TELEPHONENO  varchar(20)  = NULL ,           
   @VATNO  varchar(20)  = NULL ,           
   @VENDORDESC  varchar(60)  = NULL ,           
   @NVENDORDESC  nvarchar(70)  = NULL ,           
   @VENDORCODE  varchar(25) = NULL ,           
   @AUID  varchar(20)  = NULL ,           
   @ADT  date  = NULL ,           
   @UUID  varchar(20)  = NULL ,           
   @UDT  date  = NULL  ,          
    @msg varchar(40) output,  
    @ACCOUNTID int,        
    @branchid int=null          
 ) AS           
 declare @errcode int    ,@idnew int        
 begin transaction          
     begin try      
 if exists (select 1 from TBLVENDORINFO where  VEN_ID=@VEN_ID)          
          
          Begin           
             Update TBLVENDORINFO SET           
                        
             ADDRESS = @ADDRESS,           
             EMAILADDRESS = @EMAILADDRESS,           
             MOBILENO = @MOBILENO,           
             PANNO = @PANNO,           
             TELEPHONENO = @TELEPHONENO,           
             VATNO = @VATNO,           
             VENDORCODE = @VENDORCODE,           
             VENDORDESC = @VENDORDESC,          
             NVENDORDESC = @NVENDORDESC,           
             AUID = @AUID,           
             ADT = @ADT,           
             UUID = @UUID,           
             UDT = @UDT,  
             ACCOUNTID=@ACCOUNTID          
             where VEN_ID=@VEN_ID          
             set @msg='update'  
			  set @idnew=@VEN_ID         
          End           
    else           
                 
             Begin           
                Insert into TBLVENDORINFO ( ADDRESS,EMAILADDRESS,MOBILENO,PANNO,TELEPHONENO,VATNO,          
                VENDORCODE,VENDORDESC,NVENDORDESC,  AUID,  ADT,  UUID,  UDT,ACCOUNTID )           
                VALUES (          
                  @ADDRESS, @EMAILADDRESS, @MOBILENO,           
                  @PANNO, @TELEPHONENO, @VATNO, @VENDORCODE, @VENDORDESC,           
                  @NVENDORDESC, @AUID, @ADT, @UUID, @UDT,@ACCOUNTID          
                )          
                set @msg='insert'   
				select @idnew = SCOPE_IDENTITY() from TBLVENDORINFO         
             End          
                     
              begin --for user activity log         
  declare @nbranchid int=@branchid,          
     @nuserid int=@uuid,          
     @ntaskname varchar(200)='Setup-Account-Vendor setup',          
     @ntaskdescription varchar(200)='Vendor Name:-' + isnull(@VENDORDESC,'') + 'Mobile No:-' + isnull(@MOBILENO,'') + 'Pan No:-' + isnull(@PANNO,''),          
     @nactivity varchar(200)=@msg,                   
	 @nPrimaryKey int = @idnew                
  
    exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimaryKey          
  end       
 end try      
 begin catch             
    select @errcode = @@ERROR           
    if(@errcode <> 0) goto problem           
    end catch      
    commit transaction           
    problem:           
    if(@errcode <> 0)            
    begin          
    declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)           
   set @ErrID = ( select  ERROR_NUMBER()  )          
   set @ErrSeverity = ( select  ERROR_SEVERITY()  )          
   set @ErrState = (select ERROR_STATE())          
   set @ErrProc = (select ERROR_PROCEDURE())          
   set @ErrLine = (select ERROR_LINE())          
   set @ErrMsg = (select ERROR_MESSAGE())          
       rollback transaction       
       insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)          
   values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)        
   set   @msg='error/'+cast((select SCOPE_IDENTITY()) as varchar)             
    end 
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_LoadvendorName_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_LoadvendorName_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[acc_LoadvendorName_get]  
(  
@VEN_ID int=null  
)  
as   
begin  
--select VEN_ID,ADDRESS,EMAILADDRESS,MOBILENO,PANNO,TELEPHONENO,VATNO,  
--VENDORCODE,VENDORDESC,NVENDORDESC from TBLVENDORINFO  
  
select ROW_NUMBER() over (order by a.VEN_ID) as  RowNumber ,a.VEN_ID,a.ADDRESS,a.EMAILADDRESS,a.MOBILENO,a.PANNO,a.TELEPHONENO,a.VATNO,a.ACCOUNTID,
b.KYCNO , 
VENDORCODE,VENDORDESC,NVENDORDESC from TBLVENDORINFO a
left join MSACNAME b on b.ID=a.ACCOUNTID  
  
end  
  
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_INSERTUPDATE_PURCHASE]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[SP_INSERTUPDATE_PURCHASE]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROC SP_INSERTUPDATE_PURCHASE  
(  
@PURCHASEID INT=NULL,  
@EDESCRIPTION VARCHAR(200)=NULL,  
@NDESCRIPTION VARCHAR(200)=NULL,  
@ACCOUNTCODE VARCHAR(200)=NULL,  
@FIXEDACCESS INT=NULL,  
@MSG VARCHAR(20) OUTPUT,
@branchid int=null,
@IsInventoryItem int = null,
@uuid int=null      
)  
AS  
 BEGIN  
  declare @errcode int, @id_new int      
   BEGIN TRY      
    IF EXISTS(SELECT 1 FROM TBL_PURCHASE_ITEM WHERE PURCHASEID= @PURCHASEID)  
    BEGIN  
     UPDATE TBL_PURCHASE_ITEM  
     SET EDESCRIPTION=@EDESCRIPTION,  
      NDESCRIPTION=@NDESCRIPTION,  
      ACCOUNTCODE=@ACCOUNTCODE,  
      FIXEDACCESS=@FIXEDACCESS,  
	  IsInventoryItem=@IsInventoryItem
      WHERE PURCHASEID= @PURCHASEID  
      SET @MSG='update'
	  set @id_new=@PURCHASEID  
    END  
    ELSE  
     BEGIN  
      INSERT INTO TBL_PURCHASE_ITEM (EDESCRIPTION,NDESCRIPTION,ACCOUNTCODE,FIXEDACCESS,IsInventoryItem)  
        VALUES(@EDESCRIPTION,@NDESCRIPTION,@ACCOUNTCODE,@FIXEDACCESS,@IsInventoryItem)  
      SET @MSG='insert'
	    select @id_new = SCOPE_IDENTITY() from TBL_PURCHASE_ITEM  
  
     END  
     begin --for user activity log                               
   declare @nbranchid int=@branchid,                                
   @nuserid int=@uuid,                                
   @ntaskname varchar(200)='Account-Setup-Purchase Items',                                
   @ntaskdescription varchar(200)='Purchase Item:'+isnull(@EDESCRIPTION,''),                                
   @nactivity varchar(200)=@msg,
   @nprimarykey int=@id_new                     
                                    
   exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nprimarykey                              
  end 
   END TRY  
     
   BEGIN CATCH      
  select @errcode = @@ERROR          
     set @msg='FAIL'        
                
  if(@errcode <> 0) goto problem           
  problem:             
  if(@errcode <> 0)                        
  begin                         
   declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)                     
   set @ErrID = ( select  ERROR_NUMBER()  )                    
   set @ErrSeverity = ( select  ERROR_SEVERITY()  )                    
   set @ErrState = (select ERROR_STATE())                    
   set @ErrProc = (select ERROR_PROCEDURE())                    
   set @ErrLine = (select ERROR_LINE())                    
   set @ErrMsg = (select ERROR_MESSAGE())                    
                            
   insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)                    
   values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)                       
  end      
 END CATCH      
END 

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_ALL_PARTICULAR]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[GET_ALL_PARTICULAR]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC GET_ALL_PARTICULAR
(
@PURCHASEID INT
)
AS
	BEGIN
		SELECT * FROM TBL_PURCHASE_ITEM WHERE PURCHASEID=@PURCHASEID
		END
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vw_acc_accHeadCategory]')  )
DROP VIEW  [dbo].[vw_acc_accHeadCategory]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[vw_acc_accHeadCategory] as    
select b.ACCOUNTCODE, b.ACCOUNTDESC, b.ACCOUNTDESCN,     
c.ECATEGORY as L1, d.ECATEGORY as L2, e.ECATEGORY as L3, f.ECATEGORY as L4, g.ECATEGORY as L5,     
a.catid, a.REFID, a.LEVELNO, a.LEVEL1, a.LEVEL2, a.LEVEL3, a.LEVEL4, a.LEVEL5, isnull(a.DRCRTYPE,0) DrCrType from TBACCCATEGORY a    
inner join AC_AccountHead b on a.CATID = b.CATID    
left join TBACCCATEGORY c on  c.CATID   =a.LEVEL1  
left join TBACCCATEGORY d on d.CATID  =a.LEVEL2  
left join TBACCCATEGORY e on e.CATID  =a.LEVEL3  
left join TBACCCATEGORY f on f.CATID  =a.LEVEL4  
left join TBACCCATEGORY g on g.CATID  =a.LEVEL5 
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proc_accountheadSE]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[proc_accountheadSE]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[proc_accountheadSE]    
(    
@accountcode int = null,    
@Accountdesc varchar(100) = null,    
@SLcode varchar(100)=null,    
@isbank int=null,    
@deptid int=null,    
@classid int =null,    
@surveyorid int=null,    
@agentcode varchar(100)=null,    
@catid varchar(100)    
)    
as    
begin    
 declare @Sql nvarchar(max)    
    
 set @Sql = N'select  ROW_NUMBER() over (order by a.ACCOUNTCODE) as  RowNumber, a.ACCOUNTCODE,     
 b.ACCOUNTDESC, a.L1, a.L2, a.L3, a.L4, a.L5, b.CATID, b.DEPTID, c.DEPTNAME, b.GLCODE, b.SLCODE, b.ACCOUNTTYPE  ,  
 b.AGENTCODE, b.surveyorid     
 from vw_acc_accHeadCategory a    
 inner join AC_AccountHead b on a.ACCOUNTCODE = b.ACCOUNTCODE    
 left join MSDEPARTMENT c on b.DEPTID = c.ID where 1 = 1'    
 if (ISNULL(@accountcode,0) > 0)    
 begin    
  set @Sql = @Sql + ' and b.accountcode = ' + CONVERT(varchar, @accountcode)    
 end    
 if (ISNULL(@Accountdesc,'') <> '')    
 begin    
  set @Sql = @Sql + ' and b.accountdesc like ''' + '%' + @Accountdesc + '%' + ''''    
 end    
    if (ISNULL(@SLcode,'') <> '')    
 begin    
  set @Sql = @Sql + ' and b.SLCODE = ''' +  @SLcode +''''    
 end    
 if (ISNULL(@isbank,0) > 0)    
 begin    
  set @Sql = @Sql + ' and b.ISBANK = ' +  CONVERT(varchar, @isbank)    
 end    
 if (ISNULL(@deptid,0) > 0)    
 begin    
  set @Sql = @Sql + ' and b.DEPTID = ' + CONVERT(varchar, @deptid)    
 end    
 if (ISNULL(@classid,0) > 0)    
 begin    
  set @Sql = @Sql + ' and b.CLASSID = ' +CONVERT(varchar, @classid)    
 end    
 if (ISNULL(@surveyorid,0) > 0)    
 begin    
  set @Sql = @Sql + ' and b.surveyorid = ' +CONVERT(varchar, @surveyorid)    
 end    
 if (ISNULL(@agentcode,'') <> '')    
 begin    
  set @Sql = @Sql + ' and b.AGENTCODE = ''' +  @agentcode +''''    
 end    
 if (ISNULL(@catid,'') <> '')    
 begin    
  set @Sql = @Sql + ' and b.CATID = ''' +  @catid +''''    
 end  
  set @Sql = @Sql + ' order by  b.accountdesc ' 
 --print @sql    
 EXECUTE sp_executesql @Sql    
end

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_head_mapping]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_head_mapping]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[acc_head_mapping]
(
  @ACCOUNTCODE  int  = NULL ,
  @CATID  int  = NULL ,
@UUID varchar(20)=null, 
 @branchid int,
  @msg varchar(max) output            
)as
DECLARE @decs varchar (30)
  if exists (select 1 from AC_AccountHead where ACCOUNTCODE = @ACCOUNTCODE )
  
    
	begin
		update AC_AccountHead
		set CATID=@CATID
		where ACCOUNTCODE=@ACCOUNTCODE
		set @msg='update'
		
--added by sunil
		select  @decs=ACCOUNTDESC from AC_AccountHead where ACCOUNTCODE = @ACCOUNTCODE  
 begin --for user activity log           
  declare @nbranchid int=@branchid,            
     @nuserid int=@uuid,            
     @ntaskname varchar(200)='Setup-Account Head Mapping',            
     @ntaskdescription varchar(200)='Account Head Mapping  Account Description is:- ' + isnull(@decs,'') ,            
     @nactivity varchar(200)=@msg,                   
	 @nPrimaryKey int = @ACCOUNTCODE                
  
    exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nPrimaryKey          
  end 


		end


		select * from AC_AccountHead order  by ACCOUNTCODE desc

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROC_SEC_LOAD_ACCESSBRANCH]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[PROC_SEC_LOAD_ACCESSBRANCH]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE proc [dbo].[PROC_SEC_LOAD_ACCESSBRANCH]                    
(                      
 @USERID    INT,                      
 @MODULEGNAME  varchar(50),                      
 @MODEULENAME  varchar(50),                      
 @SECURITYNAME  VARCHAR(1000)                      
)                      
AS                      
BEGIN                      
 declare @SQL nvarchar(max), @ModuleGrpID int, @ModuleID int, @IsAdmin int, @Skip_Security int
 
 select @Skip_Security=isnull(Skip_Security,0) from DEFREPORTS where [NAME] = @SECURITYNAME  and isnull(ISCHILD,0)=1

 select @IsAdmin = isnull(ISADMIN,0) from tbluser  where ID = @USERID              
               
 select @ModuleGrpID = MODULE_GROUP_ID from TBL_MODULE_GROUP where MODULE_GROUP_NAME = @MODULEGNAME                  
                   
 select @ModuleID = MODULEID from TBL_MODULELIST where MODULENAME = @MODEULENAME and MODULE_GROUP_ID= @ModuleGrpID                

if isnull(@Skip_Security,0) = 0
begin                       
 SET @SQL = N'                     
	select distinct a.branchid, c.ename as BRANCHNAME, c.branchcode from (                    
		select a.userid, b.BRANCHID, a.SECURITYID from tbl_permission_UserAccessBranch a  
		inner join tbuser_accessbranch b on a.userid = b.userid  
		where a.userid = ' + CONVERT(VARCHAR,@USERID) + '                    
		union all                    
		select b.ID UserID, b.BRANCHID, a.SECURITYID from tbl_permission_UserGroup a                    
		inner join tbluser b on a.USERGROUPID = b.GROUPID                    
		where b.ID = ' + CONVERT(VARCHAR,@USERID) + '  and isnull(a.IsDelete,0)=0                           
	) a                     
	inner join TBL_SECURITYNAME b on a.SECURITYID = b.SECURITYID                    
	inner join TBL_MODULELIST e on b.ModuleID = e.ModuleID                  
	inner join dbo.BreakStringIntoRows(''' + @SECURITYNAME + ''') ss on b.SECURITYNAME = ss.column1                   
	inner join msbranch c on a.branchid = c.branchid '                  
	set @SQL = @SQL + ' WHERE b.MODULEID = ' + CONVERT(VARCHAR,@ModuleID)                  
	set @SQL = @SQL + ' and e.Module_Group_ID = ' + CONVERT(VARCHAR,@ModuleGrpID)     
	set @SQL = @SQL + ' order by a.branchid'               
end             
             
 if @IsAdmin=1 or isnull(@Skip_Security,0) = 1           
 begin            
 SET @SQL = N'select distinct branchid, ename as BRANCHNAME, branchcode from Msbranch  order by branchid'            
 end             
 EXECUTE sp_executesql @Sql                  
END     

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PROC_SEC_LOAD_ACCESS_SUBBRANCH]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[PROC_SEC_LOAD_ACCESS_SUBBRANCH]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE proc [dbo].[PROC_SEC_LOAD_ACCESS_SUBBRANCH]                
(                  
 @USERID    INT,                  
 @MODULEGNAME  varchar(50),                  
 @MODEULENAME  varchar(50),                  
 @SECURITYNAME  VARCHAR(1000),              
 @BRANCHID int                  
)                  
AS                  
BEGIN                  
 declare @SQL nvarchar(max)  , @IsAdmin int , @Skip_Security int          
 select @IsAdmin = isnull(ISADMIN,0) from tbluser  where ID = @USERID             
 select @Skip_Security=isnull(Skip_Security,0) from DEFREPORTS where [NAME] = @SECURITYNAME  and isnull(ISCHILD,0)=1
 
 if isnull(@Skip_Security,0)=0
 begin              
 SET @SQL = N'                 
	 select distinct BRANCHID,isnull(ISDEFAULT,0),c.SUBBRANCHID, c.ENAME SUBBRANCHNAME, c.subbranchcode from (                
		  select a.userid, b.SUBBRANCHID, a.SECURITYID from tbl_permission_UserAccessBranch  a              
		  inner join tbuser_accessbranch b on a.userid = b.userid  
		  where a.userid = ' + CONVERT(VARCHAR,@USERID) + '                
		  union all                
		  select b.ID UserID, b.SUBBRANCHID, a.SECURITYID from tbl_permission_UserGroup a                
		  inner join tbluser b on a.USERGROUPID = b.GROUPID                
		  where b.ID = ' + CONVERT(VARCHAR,@USERID) + '  and isnull(a.IsDelete,0)=0                       
	 ) a                 
	 inner join TBL_SECURITYNAME b on a.SECURITYID = b.SECURITYID                
	 inner join dbo.BreakStringIntoRows(''' + @SECURITYNAME + ''') ss on b.SECURITYNAME = ss.column1                 
	 inner join mssubbranch c on a.subbranchid = c.subbranchid'                
	 IF ISNULL(@BRANCHID ,0) > 0 set @SQL = @SQL + ' where c.branchid = ' + convert(varchar,@BRANCHID)              
 end           
 if @IsAdmin=1  or @Skip_Security = 1        
 begin          
	 SET @SQL = N'select distinct BRANCHID,isnull(ISDEFAULT,0),SUBBRANCHID, ENAME SUBBRANCHNAME, subbranchcode from mssubbranch c '          
	 IF ISNULL(@BRANCHID ,0) > 0 set @SQL = @SQL + ' where branchid = ' + convert(varchar,@BRANCHID)            
 end     
   
 set @sql= @sql + ' order by c.branchid asc,isnull(c.ISDEFAULT,0) desc,c.subbranchid asc' 
             
  EXECUTE sp_executesql @Sql                               
END       

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_AccHeadSearch_List]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_AccHeadSearch_List]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[acc_AccHeadSearch_List]               
(              
@ACCOUNTDESC varchar(200),              
@BRANCHCODE varchar(2),  
@ACCOUNTCODE int=null              
 )              
as              
 begin        
 Select ACCOUNTCODE,(isnull(a.GLCODE,'')+' '+a.ACCOUNTDESC) as ACCOUNTDESC,b.ECATEGORY from AC_AccountHead   a   
 left join   TBACCCATEGORY   b on a.CATID=b.CATID       
   where a.ACCOUNTDESC= @ACCOUNTDESC and a.ACCOUNTCODE=@ACCOUNTCODE           
  --where  a.ACCOUNTDESC like '%' +@ACCOUNTDESC +'%'   or a.GLCODE=@ACCOUNTDESC           
end 
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_InsertUpdate_VoucherEntry]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_InsertUpdate_VoucherEntry]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/****** Object:  UserDefinedTableType [dbo].[TABLTYPE_AC_TRANSACTION]    Script Date: 04/03/2019 10:06:07 ******/
DROP TYPE [dbo].[TABLTYPE_AC_TRANSACTION]
GO

/****** Object:  UserDefinedTableType [dbo].[TABLTYPE_AC_TRANSACTION]    Script Date: 04/03/2019 10:06:07 ******/
CREATE TYPE [dbo].[TABLTYPE_AC_TRANSACTION] AS TABLE(
	[ROWNUMBER] [int] NULL,
	[ACCOUNTCODE] [int] NULL,
	[ACCOUNTDESC] [varchar](200) NULL,
	[CHQNO] [varchar](50) NULL,
	[ISSUEDTO] [varchar](255) NULL,
	[DESCRIPTION] [varchar](4000) NULL,
	[DRAMOUNT] [numeric](16, 2) NULL,
	[CRAMOUNT] [numeric](16, 2) NULL,
	[BILLNO] [varchar](40) NULL,
	[PANNO] [varchar](40) NULL
)
GO



  
  
CREATE proc [dbo].[acc_InsertUpdate_VoucherEntry] (                                       
 @TRANID  int  = 0 ,                                       
 @DocID  int  = NULL ,                                          
 @CLAIMID  int  = NULL ,                                      
 @RECEIPTNO  varchar(20)  = NULL ,                                       
 @BANKID  int  = NULL ,                                       
 @FiscalID  int  = NULL ,                                        
 @branchid int = null,                                      
 @VOUCHERNO  int  = NULL ,                                       
 @EDATE  datetime = NULL ,                                       
 @NDATE  varchar(20) = NULL ,                                       
 @ACCOUNTCODE  varchar(10)  = NULL ,                                      
 @DRAMOUNT  numeric(16,2)  = NULL ,                                       
 @CRAMOUNT  numeric(16,2)  = NULL ,                                       
 @IFPREVBALANCE  tinyint  = NULL ,                                       
 @OFDATE  date  = NULL ,                                       
 @TTYPE  tinyint  = NULL ,                                          
 @ENTRYNO  int  = NULL ,                                       
 @AGENTCODE  varchar(10)  = NULL ,                                       
 @APPROVED  tinyint  = NULL ,                                      
 @CHQNO  varchar(50)  = NULL ,                                       
 @CLAIMPAYID  tinyint  = NULL ,                                       
 @CLAIMTYPE  tinyint  = NULL ,                                       
 @CLIENTCODE  varchar(10)  = NULL ,                                       
 @DECLARATIONNO  varchar(10)  = NULL ,                                       
 @DEPOSITID  int  = NULL ,                                       
 @DESCRIPTION  varchar(4000)  = NULL ,                                          
 @FACID  int  = NULL ,                                       
 @FCAMOUNT  numeric(16,2)  = NULL ,                                       
 @ISSUEDTO  varchar(255)  = NULL ,                                       
 @MANUALVN  varchar(50)  = NULL ,                                       
 @PNARRATION  varchar(2000)  = NULL ,                                        
 @RELATEDTO  tinyint  = NULL ,                                       
 @REMARKS  varchar(512)  = NULL ,                                       
 @RIID  int  = NULL ,                                       
 @RIPOOLID  int  = NULL ,                                       
 @CHQDATE  varchar(20)  = NULL ,                                       
 @ISMANUAL  tinyint  = NULL ,                                       
 @PD_ID  int  = NULL ,                                       
 @AUID  int  = NULL ,                                       
 @ADT  date  = NULL ,                                       
 @UUID  int  = NULL ,                                       
 @UDT  date  = NULL  ,                            
 @TRANSACTIONTYPEID int =null,                          
 @purchaseid int =null,                          
 @VOUCHERTYPE [TABLTYPE_AC_TRANSACTION] readonly,                                      
 @msg varchar(40) output,                                      
 @Master_id int output,                        
 @vendorid  int  = NULL ,                               
 @billno  varchar(50)  = NULL ,                               
 @pAmount  numeric(15,2)  = NULL ,                               
 @pdiscAmt  numeric(15,2)  = NULL ,                               
 @pVatAmt  numeric(15,2)  = NULL ,                               
 @pNetAmt  numeric(15,2) = NULL ,                               
 @IsDeleted  int  = NULL ,                          
 @vatoptionid int = null,                          
 @pTypeid int = null   ,                      
 @TRANSMITI VARCHAR(20)=NULL,              
 @SIGNATURECODE1 varchar(50) = null,              
 @SIGNATURECODE2 varchar(50) = null ,            
 @SUBBRANCHID int =null  ,          
 @AMTINWORDS varchar(256) = null,
 @FISCALYRTYPEID int=null           
) AS                
declare @errcode int , @MaxVno int,@TotAmt numeric(16,2),@id_new int,  
@FTRANID int =null, @PurID int=null    
set @TotAmt = (select SUM(DRAMOUNT) from @VOUCHERTYPE)  
set @AMTINWORDS = 'Rs. ' +  dbo.FxNumtoWords(@TotAmt)  
                 
begin transaction                                       
 if exists ( select 1 from AC_TRANSACTION_MASTER where MASTERID=@TRANID and @TRANID > 0)                                      
  begin                                      
   update AC_TRANSACTION_MASTER                                      
   set                                       
   trans_date=@EDATE,                                      
   uuid = @UUID,                                      
   udt=GETDATE() ,                    
   NARRATION=@DESCRIPTION,        
   AMTINWORDS = @AMTINWORDS,
   trans_miti=  @TRANSMITI                                         
   where MASTERID=@TRANID                                      
      
   SET @FTRANID = @TRANID                                      
   set @msg='UPDATE'                              
   set @Master_id = @TRANID
   set @id_new= @TRANID      
       
   delete from AC_TRANSACTION_DETAILS where TRANID=@Master_id                                    
  end       
                                      
 else       
  begin        
   insert into tbl_MaxNumber_Vno (fiscalid,branchid,vouchertype,Voucherno)                                
   values(@FiscalID,@BranchID,@TTYPE,@VOUCHERNO)                 
   set @MaxVno=@VOUCHERNO        
      
   Insert  into AC_TRANSACTION_MASTER                                       
   ( BRANCHID,FISCALID,VOUCHERTYPEID,NARRATION,VOUCHERNO, trans_date,approved, auid, adt,uuid, udt,ifprevbalance,bsyear, Bsmonth, claimid, docid, receiptno,TRANSACTIONTYPEID,PURCHASEID,trans_miti,SUBBRANCHID, AMTINWORDS,FISCALYRTYPEID)                                  



  
    
   values(@branchid,@FiscalID,@TTYPE,@DESCRIPTION,@MaxVno,@EDATE,@APPROVED,@AUID, GETDATE(), @UUID, GETDATE(),@IFPREVBALANCE,0,0, @CLAIMID, @DocID, @RECEIPTNO,@TRANSACTIONTYPEID,@PurID,@TRANSMITI,@SUBBRANCHID, @AMTINWORDS,@FISCALYRTYPEID)                                 


  
    
     
      
   set @FTRANID=SCOPE_IDENTITY()                                      
   set @msg='INSERT'                                       
   set @Master_id = @FTRANID

     select @id_new = SCOPE_IDENTITY() from AC_TRANSACTION_MASTER  
                                  
  end                                      
      
 delete from AC_TRANSACTION_DETAILS where TRANID=@Master_id                                            
      
 Insert into AC_TRANSACTION_DETAILS (  TRANID,ACCOUNTCODE, DRAMOUNT,  CRAMOUNT, ENTRYNO,  CHQNO,DESCRIPTION,                                      
 ISSUEDTO, RELATEDTO, CHQDATE ,BILLNO,PANNO,SIGNATURECODE1,SIGNATURECODE2                                      
 )                                       
      
 select  @Master_id, CONVERT(int, frDT.ACCOUNTCODE), CONVERT(numeric(16,2), frDT.DRAMOUNT), CONVERT(numeric(16,2), frDT.CRAMOUNT),                                       
 convert(int,frDT.ROWNUMBER), frDT.CHQNO, frDT.DESCRIPTION,                                       
 frDT.ISSUEDTO, @RELATEDTO, @CHQDATE,frDT.BILLNO,frDT.PANNO,@SIGNATURECODE1,@SIGNATURECODE2 from @VOUCHERTYPE as frDT                                           
      
 begin --for user activity log                                           
  declare @nbranchid int=@branchid,                                            
  @nuserid int=@uuid,        
                                    
  @ntaskname varchar(200)='Account-Normal Voucher Entry',                                            
  @ntaskdescription varchar(200)='Normal Voucher Entry where voucher no is :'+cast(isnull(@VOUCHERNO,'') as varchar),                                          
  @nactivity varchar(200)=@msg,
  @nprimarykey int =@id_new                                         
      
  exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nprimarykey
  end                           
      
 select @errcode = @@ERROR                                       
 if(@errcode <> 0) goto problem                                       
commit transaction                                       
problem:                                       
 if(@errcode <> 0)                                    
  begin                                       
   declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)       
   set @ErrID = ( select  ERROR_NUMBER()  )                                      
   set @ErrSeverity = ( select  ERROR_SEVERITY()  )                                      
   set @ErrState = (select ERROR_STATE())                                      
   set @ErrProc = (select ERROR_PROCEDURE())                                     set @ErrLine = (select ERROR_LINE())                                 
   set @ErrMsg = (select ERROR_MESSAGE())                                      
      
   rollback transaction                                         
      
   insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)                                      
   values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)                                       
  end 

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[checkfor_voucherentry]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[checkfor_voucherentry]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE proc checkfor_voucherentry    
(    
@branchid int,    
@subbranchid int,    
@fiscalid int,    
@vouchertypeid int,    
@vdate date,    
@msg varchar(20) output    
)    
as declare @maxdate date    , @AllowBackDt int
 begin    
	select @AllowBackDt = ISNULL(Allow_Backdate_voucher,0) from CompanyProfile
	
	select @maxdate= dbo.fxcheckforvoucherentry(@branchid,@subbranchid,@fiscalid,@vouchertypeid)    
	if(@vdate  > = @maxdate )    
		begin
			set @msg='false'    
		end
	else    
		begin
			set @msg='true'    
		end
		
	if (@AllowBackDt = 1)
		begin
			set @msg='false'    
		end
 end    
    
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_Voucher_getvoucherno]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_Voucher_getvoucherno]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc acc_Voucher_getvoucherno         
(          
 @FISCALYEAR int,          
 @BRANCHCODE int,          
 @VTYPE int ,      
 @VOUCHERNO int =null ,   
 @msg varchar(20) output             
 )          
as  declare @vno int     
 begin          
 select @vno=isnull(VOUCHERNO,0)   from AC_TRANSACTION_MASTER          
  where  VOUCHERNO = @VOUCHERNO           
  and BRANCHID=@BRANCHCODE and VOUCHERTYPEID=@VTYPE and FISCALID=@FISCALYEAR   
    
  if(@vno= @VOUCHERNO)  
 begin  
  set @msg='FALSE'  
 end  
 else  
  begin  
   set @msg='TRUE'  
  end  
   
end 
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[fxcheckforvoucherentry]') AND type IN (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION  [dbo].[fxcheckforvoucherentry]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

    
CREATE function fxcheckforvoucherentry    
(    
@branchid int,    
@subbranchid int,    
@fiscalid int,    
@vouchertypeid int    
    
    
)    
returns date    
as    
begin     
 declare @maximumdate date  , @compid int  
 select @compid = id from CompanyProfile  
   if (@compid=2)  
   begin  
 select @maximumdate = ISNULL(max(trans_date), '1-JAN-2000') from AC_TRANSACTION_MASTER    
    where BRANCHID=@branchid  
    and FISCALID=@fiscalid and VOUCHERTYPEID=@vouchertypeid  
   end  
   else  
   begin  
    select @maximumdate =ISNULL(max(trans_date), '1-JAN-2000') from AC_TRANSACTION_MASTER    
    where BRANCHID=@branchid   
    and subbranchid=@subbranchid   
    and FISCALID=@fiscalid and VOUCHERTYPEID=@vouchertypeid   
    end  
 return  @maximumdate    
     
 end 
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_vw_acctransaction_get]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_vw_acctransaction_get]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc acc_vw_acctransaction_get           
(           
 @Master_id int= null    ,       
 @payId int =null,     
 @PurchaseID int = null       
)           
as           
begin         
declare @Sql nvarchar(max), @AmtinWords varchar(500)   
create table #AmtWords
(
	Amtinwords varchar(500)
)

set @Sql = N'insert into #AmtWords (Amtinwords) select dbo.FxNumtoWords(sum(dramount))  from vw_acc_transactions  a     where 1 = 1 '  
if isnull(@Master_id,0)>0 set @Sql = @Sql + ' and MASTERID = ' + convert(varchar(10),@Master_id)     
if isnull(@payId,0)>0 set @Sql = @Sql + ' and PayID=' + convert(varchar(10),@payId)     
if isnull(@PurchaseID,0)>0 set @Sql = @Sql + ' and Purchaseid =' + convert(varchar(10),@PurchaseID)
EXECUTE sp_executesql @Sql          

select @AmtinWords = Amtinwords from #AmtWords

drop table #AmtWords

set @Sql = N'select a.MASTERID, a.FISCALID, a.FISCALYEAR, a.ENGFISCALYEAR, a.BRANCHID, a.branchnameeng, a.PrintingNarration, a.VOUCHERNO, a.fvoucherno  
 , a.VOUCHERTYPEID, a.vouchertype, a.vtypeAbbr, a.trans_date, a.NepaliDate, a.approved, a.docid, a.claimid, a.receiptno, a.auid, a.USERNAME  
 , a.adt, a.uuid, a.udt, a.GLCODE, a.SLCODE, a.ACCOUNTCODE, glcode + ''.'' + slcode as GL_SL_CODE,  a.accountdesc , a.glcode, a.slcode,  
 a.CATID, a.REFID, a.L1, a.L2, a.L3, a.L4, a.L5, a.LEVELNO, a.LEVEL1, a.LEVEL2, a.LEVEL3, a.LEVEL4, a.LEVEL5, a.DRAMOUNT, a.CRAMOUNT,  
 a.CHQNO, a.ISSUEDTO, a.Narration, a.ifPrevBalance, a.PrevBlnce, a.LIMIT_AMOUNT, a.BILLNO, a.PANNO, a.TRANSACTIONTYPEID, a.trans_miti,   
 a.SubBranchNameEng, a.SUBBRANCHID, a.ENTRYNO, ''' + @AmtinWords + ''' AMTINWORDS, a.SubBranchAddEng, a.VisibleType, a.PayID, a.depositid, a.PURCHASEID,   
 a.TRANSACTIONNAME, a.showonVPrint  from vw_acc_transactions  a     where 1 = 1 '  
 if isnull(@Master_id,0)>0 set @Sql = @Sql + ' and MASTERID = ' + convert(varchar(10),@Master_id  )     
 if isnull(@payId,0)>0 set @Sql = @Sql + ' and PayID=' + convert(varchar(10),@payId)     
 if isnull(@PurchaseID,0)>0 set @Sql = @Sql + ' and Purchaseid =' + convert(varchar(10),@PurchaseID)     
 set @Sql = @Sql + ' order by MASTERID,ENTRYNO          '       
 EXECUTE sp_executesql @Sql          
end 
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[acc_voucher_LastUsedNo]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[acc_voucher_LastUsedNo]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[acc_voucher_LastUsedNo] (    
@FiscalID int = NULL,    
@BranchID int = NULL,   
@SubBranchID int = NULL,     
@VoucherType int = NULL   
)    
as    
begin
	declare @VOUCHERNO varchar(200),@FVOUCHERNO varchar(200),@ISINDIVIDUAL TINYINT,@COMPANYID INT    
	--SELECT @ISINDIVIDUAL=ISINDIVIDUAL FROM MSSUBBRANCH WHERE SUBBRANCHID=@SubBranchID    
	SELECT @COMPANYID=ID FROM CompanyProfile 
	
	
		BEGIN
			select isnull(max(voucherno),0)+1 voucherno from (    
			 select voucherno from AC_TRANSACTION_MASTER     
			 where fiscalid = @FiscalID and branchid = @BranchID and vouchertypeid = @VoucherType    
			 union all    
			 select 0    
			) tmp
		END
end	

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vw_acc_transactions]')  )
DROP VIEW  [dbo].[vw_acc_transactions]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

        
CREATE VIEW [dbo].[vw_acc_transactions]        
AS        
SELECT     a.MASTERID, a.FISCALID, d.FISCALYEAR, d.ENGFISCALYEAR, a.BRANCHID, c.ENAME AS branchnameeng, a.NARRATION AS PrintingNarration, a.VOUCHERNO,a.fvoucherno ,         
                      a.VOUCHERTYPEID, b.ETITLE AS vouchertype, b.EABBRV AS vtypeAbbr, a.trans_date,a.trans_miti as NepaliDate, isnull(a.approved,0) approved, a.docid, a.claimid, a.receiptno, a.auid, g.USERNAME,         
                      a.adt, a.uuid, a.udt, cat.GLCODE, e.SLCODE, dtl.ACCOUNTCODE, e.ACCOUNTDESC, e.CATID, f.REFID, f.L1, f.L2, f.L3, f.L4, f.L5, f.LEVELNO, f.LEVEL1, f.LEVEL2, f.LEVEL3, f.LEVEL4, f.LEVEL5,         
                    dtl.DRAMOUNT, dtl.CRAMOUNT, dtl.CHQNO, dtl.ISSUEDTO, dtl.DESCRIPTION AS Narration, isnull(coalesce(tt.ifprevbalance, b.ifprevbalance),0) AS ifPrevBalance,         
                      dtl.IFPREVBALANCE AS PrevBlnce, h.LIMIT_AMOUNT, dtl.BILLNO, dtl.PANNO, a.TRANSACTIONTYPEID,a.trans_miti,i.ENAME as SubBranchNameEng,a.SUBBRANCHID, dtl.ENTRYNO     
                      , a.AMTINWORDS,i.ADDRESS as SubBranchAddEng,isnull(dtl.VTYPE,0) as VisibleType,a.PayID,a.depositid,a.PURCHASEID,  tt.TRANSACTIONNAME, 
					  isnull(cat.showonVPrint,0) showonVPrint, isnull(a.declarationid,0) declarationid    
FROM         dbo.AC_TRANSACTION_MASTER AS a INNER JOIN        
                      dbo.AC_TRANSACTION_DETAILS AS dtl ON a.MASTERID = dtl.TRANID inner JOIN        
                      dbo.ic_vouchertype AS b ON a.VOUCHERTYPEID = b.ID   
       left join TBACCTRANSACTIONTYPE tt on a.TRANSACTIONTYPEID = tt.ID  
       inner JOIN                            dbo.MSBRANCH AS c ON a.BRANCHID = c.BRANCHID left JOIN     
                      MSSUBBRANCH as i on i.SUBBRANCHID= a.SUBBRANCHID inner join    
                      dbo.FISCALYEAR AS d ON a.FISCALID = d.ID inner JOIN        
                      dbo.AC_AccountHead AS e ON dtl.ACCOUNTCODE = e.ACCOUNTCODE LEFT OUTER JOIN       
                      dbo.TBACCCATEGORY as cat on e.CATID = cat.CATID left outer join     
                      dbo.vw_acc_accHeadCategory AS f ON e.ACCOUNTCODE = f.ACCOUNTCODE LEFT OUTER JOIN        
                      dbo.tblUser AS g ON a.auid = g.ID LEFT OUTER JOIN        
                      dbo.TBLUSER_VOUCHER_APPLIMIT AS h ON a.auid = h.USERID   
  
  
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[vw_defaultbank]')  )
DROP VIEW  [dbo].[vw_defaultbank]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
/*where a.ISBANK=1*/  
CREATE VIEW [dbo].[vw_defaultbank]  
AS  

select ACCOUNTDESC,ACCOUNTCODE from AC_AccountHead where ISBANK=1
--SELECT     b.ModuleId, b.BranchId, b.SUBBRANCHID, a.ISBANK, a.ACCOUNTCODE, a.ACCOUNTDESC, ISNULL(b.isDefault, 0) AS isDefault, 
--a.GLCODE, isnull(b.paymentsourceid,0) paymentsourceid  
--FROM         dbo.AC_AccountHead AS a LEFT OUTER JOIN  
--                      dbo.defdefaultbank AS b ON a.ACCOUNTCODE = b.BankId  
--                      where  ISNULL(b.isdelete, 0)=0
                      



GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_default_bank]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[get_default_bank]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 
       
CREATE procedure [dbo].[get_default_bank]                                        
(                                        
@ModuleId int,                                        
@BranchId int,                                    
@SUBBRANCHID int,                                  
@FLAG INT                                        
)                                        
as      
select * from [vw_defaultbank]                            
--if(@FLAG=1)                                  
-- begin                                    
--  if exists(select 1 from vw_defaultbank       
--   where (ISNULL (@ModuleId,0)=0 or ModuleId =@ModuleId) and                                 
--     (ISNULL( @BranchId,0)=0 or BranchId=@BranchId) AND                                 
--     (ISNULL(@SUBBRANCHID,0)=0 OR SUBBRANCHID=@SUBBRANCHID))        
--   begin            
--    declare @companyid int      
--    select @companyid=id from CompanyProfile      
--    if(@companyid=1)/*National*/       
--   select distinct ACCOUNTDESC,GLCODE +'-'+ACCOUNTDESC as GLDESC, moduleid,isbank,            
--    accountcode,isnull(isDefault,0) isdefault,glcode, paymentsourceid,ACCOUNTDESC + ' [' + cast(accountcode as varchar) + ']'  as defbankname from vw_defaultbank                       
--   where (ISNULL (@ModuleId,0)=0 or ModuleId =@ModuleId) and                                 
--     (ISNULL( @BranchId,0)=0 or BranchId=@BranchId) AND                                 
--     (ISNULL(@SUBBRANCHID,0)=0 OR SUBBRANCHID=@SUBBRANCHID)      
--   order by isnull(isDefault,0) desc, ACCOUNTDESC asc       
--    else      
--     select distinct ACCOUNTDESC,GLCODE +'-'+ACCOUNTDESC as GLDESC, moduleid,isbank,            
--      accountcode,isnull(isDefault,0) isdefault,glcode, paymentsourceid,ACCOUNTDESC + ' [' + cast(accountcode as varchar) + ']'  as defbankname from vw_defaultbank                       
--     where (ISNULL (@ModuleId,0)=0 or ModuleId =@ModuleId) and                                 
--       (ISNULL( @BranchId,0)=0 or BranchId=@BranchId) AND                                 
--       (ISNULL(@SUBBRANCHID,0)=0 OR SUBBRANCHID=@SUBBRANCHID)                    
--     order by  ACCOUNTDESC asc ,isnull(isDefault,0) desc         
--   end                    
--  else                  
--   select 'None'accountdesc , 0 accountcode ,'none'  defbankname ,0    paymentsourceid                              
-- end                                   
--else                                  
-- begin                              
--  if exists (select 1 from  vw_defaultbank where ModuleId=@ModuleId and BranchId=@BranchId and SUBBRANCHID=@SUBBRANCHID)                              
--   select GLCODE,GLCODE +'-'+ACCOUNTDESC as GLDESC,*,ACCOUNTDESC + ' [' + cast(accountcode as varchar) + ']' as defbankname  from vw_defaultbank                                 
--   where (ModuleId =@ModuleId) and                                 
--    (BranchId=@BranchId) AND                                 
--    (SUBBRANCHID=@SUBBRANCHID)                                     
--   order by isnull(isDefault,0) desc   , ACCOUNTDESC asc                            
--  else                                  
--   select distinct GLCODE +'-'+ACCOUNTDESC as GLDESC,ISBANK,ACCOUNTCODE,    
--   ACCOUNTDESC  + ' [' + cast(accountcode as varchar) + ']' ACCOUNTDESC,GLCODE,paymentsourceid from [vw_defaultbank]
--    where ModuleId=@ModuleId and BranchId=@BranchId                                   
--   order by ACCOUNTDESC asc                    
-- end 


GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[get_paymenttype]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[get_paymenttype]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc get_paymenttype  
as  
begin  
select * from def_paymenttype where isnull(islocked,0)=0  
end


GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GET_PURCHASE_ITEM]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[GET_PURCHASE_ITEM]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc GET_PURCHASE_ITEM
(
@EDESCRIPTION VARCHAR(50)
)as
	begin
		select * from TBL_PURCHASE_ITEM
		where EDESCRIPTION like '%'+@EDESCRIPTION+'%'
	end
	

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[INSERTUPDATE_PURCHASEENTRY_DETAILS]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[INSERTUPDATE_PURCHASEENTRY_DETAILS]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/****** Object:  UserDefinedTableType [dbo].[Tbltype_newpurchaseentrydetails]    Script Date: 04/03/2019 11:21:40 ******/
DROP TYPE [dbo].[Tbltype_newpurchaseentrydetails]
GO

/****** Object:  UserDefinedTableType [dbo].[Tbltype_newpurchaseentrydetails]    Script Date: 04/03/2019 11:21:40 ******/
CREATE TYPE [dbo].[Tbltype_newpurchaseentrydetails] AS TABLE(
	[ROWNUMBER] [varchar](50) NULL,
	[item] [varchar](100) NULL,
	[rate] [varchar](100) NULL,
	[quantity] [varchar](100) NULL,
	[amount] [varchar](100) NULL,
	[itemid] [int] NULL
)
GO



CREATE proc INSERTUPDATE_PURCHASEENTRY_DETAILS                  
(                  
@PurchaseID int=null,                  
@Fiscalid int=null,                  
@branchid int=null,                  
@pdate date=null,                  
@vendorid int=null,                  
@billno int=null,                  
@pAmount numeric(16,2)=null,                  
@pdiscAmt numeric(16,2)=null,                  
@pVatAmt numeric(16,2)=null,                  
@pNetAmt numeric(16,2)=null,                  
--@IsDeleted int=null,                  
@vatoptionid int=null,                  
@pTypeid int=null,                  
@Transactionno int=null,                  
@subbranchid int=null,                  
@ndate varchar(20)=null,                  
@Remarks varchar(200)=null,                  
@detailid int=null,                  
@dtpurchaseentrydetails Tbltype_newpurchaseentrydetails READONLY,                  
  @msg varchar(40) output ,          
            
   @uuid int=null  ,      
   @Bankid int = null,      
   @CheqNo varchar(50) = null,      
   @CheqDate date = null,           
   @CheqAmt numeric(16,2),    
   @BillType int = null,    
   @BillDate date = null,    
   @BillDateNep varchar(20) = null,            
   @Vatrate  numeric(6,3) = null,    
   @DiscRate numeric(6,3) = null,    
    
   @pTdsAmt numeric(16,2) =null,    
   @pTdsRate numeric(6,3)=null,    
   @ptdsGLcode varchar(20)=null    
)                  
 AS                  
  declare @errcode int, @PurID int=null, @CompanyId int,@id_new int  
  select @CompanyId = id from CompanyProfile  
                    
  BEGIN TRANSACTION                  
   BEGIN TRY                  
     if exists (select 1 from tblpurchaseEntry where  PurchaseID=@PurchaseID)                   
     BEGIN                  
                       
                   
     UPDATE tblpurchaseEntry                  
  SET                   
   pdate=@pdate,                  
   vendorid=@vendorid,                  
   billno=@billno,                  
   pAmount=@pAmount,                  
   pdiscAmt=@pdiscAmt,                  
   pVatAmt=@pVatAmt,                  
   pNetAmt=@pNetAmt,                  
   vatoptionid=@vatoptionid,                  
   pTypeid=@pTypeid,                  
   ndate=@ndate,                  
   Remarks=@Remarks,      
   bankid = @Bankid,       
   cheqno  = @CheqNo,      
   cheqdt  = @CheqDate,       
   cheqAmt     = @CheqAmt,    
   BillType = @BillType,    
   BillDate = @BillDate,    
   BillDateNep = @BillDateNep,    
     lmuid = @uuid,    
  lmdt = getdate(),    
  pvatrate = @Vatrate,    
  pDiscRate = @DiscRate,    
  ptdsamt= @ptdsamt,    
  ptdsRate=@pTdsRate,    
  ptdsGLcode=@ptdsGLcode    
      
                  
  WHERE PurchaseID=@PurchaseID                
                  
                  
    delete from tblpurchaseentrydetails where PurchaseID=@PurchaseID                
    INSERT INTO tblpurchaseentrydetails (rate,quantity,amount,itemid,purchaseid)                  
    SELECT rate,quantity,amount,itemid,@PurchaseID from  @dtpurchaseentrydetails                
                    
    set @PurID = @PurchaseID                
    SET @msg='update'+'/'+cast (isnull(@PurID,'') as varchar)   
 set @id_new=  @PurchaseID                    
  END                  
 ELSE                  
  BEGIN                  
  declare @transno int                
  set @transno=(select isnull(MAX(Transactionno),0)+1 from tblpurchaseEntry where Fiscalid=@Fiscalid and branchid=@branchid and subbranchid=@subbranchid)                
   INSERT INTO tblpurchaseEntry(Fiscalid,branchid,pdate,vendorid,billno,pAmount,pdiscAmt,pVatAmt,                  
      pNetAmt,vatoptionid,pTypeid,Transactionno,subbranchid,ndate,Remarks, bankid, cheqno ,cheqdt , cheqAmt,BillType, BillDate, BillDateNep    
   ,lsuid, lmuid, lsdt, lmdt,pvatrate,  pDiscRate ,ptdsamt,ptdsRate,ptdsGLcode)                  
     VALUES(@Fiscalid,@branchid,@pdate,@vendorid,@billno,@pAmount,@pdiscAmt,@pVatAmt,@pNetAmt,                  
      @vatoptionid,@pTypeid,@transno,@subbranchid,@ndate,@Remarks, @Bankid, @CheqNo, @CheqDate, @CheqAmt, @BillType, @BillDate, @BillDateNep    
   ,@uuid, @uuid, getdate(), getdate(), @Vatrate, @DiscRate,@ptdsamt,@ptdsRate,@ptdsGLcode)                  
     set @PurID =SCOPE_IDENTITY()                   
                       
   INSERT INTO tblpurchaseentrydetails(itemid,rate,quantity,amount,purchaseid)                  
    SELECT itemid,rate,quantity,amount,@PurID from  @dtpurchaseentrydetails 
	
	
    SET @msg='insert'+'/'+cast (isnull(@PurID,'') as varchar)   
 --added by sunil   
     select @id_new = SCOPE_IDENTITY() from tblpurchaseentrydetails      
  END      
    
 -- if @CompanyId = 1  
 --begin  
 -- exec CO_ACC_PURCHASE_VOUCHER_NAI @PurID  
 --end  
 -- else    
 --begin  
 -- exec CO_ACC_PURCHASE_VOUCHER @PurID    
 --end  
            
  begin --for user activity log                                         
   declare @nbranchid int=@branchid,                                          
   @nuserid int=@uuid,                                          
   @ntaskname varchar(200)='Account-Purchase Entry New',                                          
   @ntaskdescription varchar(200)='Purchase Amount:'+cast (isnull(@pAmount,'') as varchar) + ' vat amt:' + convert(varchar,@pVatAmt)  ,                                       
   @nactivity varchar(200)=@msg,  
   @nprimarykey int=@id_new                               
                                              
   exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nprimarykey                                        
  end                
 END TRY                  
   BEGIN CATCH                                
   SET @errcode=(SELECT ERROR_NUMBER())                                  
   GOTO PROBLEM                                
   END CATCH                    
   select @errcode = @@error                              
 if(@errcode <>0)goto problem                              
commit transaction                              
                              
problem:                              
if(@errcode<>0)                              
 begin                              
  declare @ErrID int, @ErrNo int, @ErrSeverity int, @ErrState int, @ErrProc nvarchar(1000), @ErrLine int, @ErrMsg nvarchar(2000)                                 
    set @ErrID = ( select  ERROR_NUMBER()  )                                
    set @ErrSeverity = ( select  ERROR_SEVERITY()  )                             
    set @ErrState = (select ERROR_STATE())                                
    set @ErrProc = (select ERROR_PROCEDURE())                                
    set @ErrLine = (select ERROR_LINE())                                
    set @ErrMsg = (select ERROR_MESSAGE())                                
                                    
    rollback transaction                                   
                                    
    insert into tbErrorLog(ErrorNumber,ErrorSeverity,ErrorState,ErrorProcedure,  ErrorLine,ErrorMessage)                                
    values (@ErrID,@ErrSeverity, @ErrState, @ErrProc, @ErrLine, @ErrMsg)                                 
                          
  set   @msg='error/'+cast((select SCOPE_IDENTITY()) as varchar)                                    
 end 
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankInfo_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[GetBankInfo_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[GetBankInfo_insertUpdate](                  
@BANKCODE varchar(10)=null,                
@AUID varchar(20) =null,      
@UUID varchar(20) =null,  
@ADT date=null,                  
@UDT datetime =null,          
@bankid varchar(200)=null,                  
@NatureOfPaymentID varchar(20)=null,                               
@Remarks varchar(500)=null,                                    
@AcNo varchar(50)=null,                  
@branch varchar(20)=null,      
@ACHolderName varchar(100)=null,                         
@msg varchar(20) output ,                           
@isbankdetail int=null ,
@claimid varchar(20) =null,
@Survyorfeeid  int =null,
@Commissionid int =null,
@AgentCommissionid int =null,
@CreditNoteid int =null,
@claimsetlementid int =null,
@surveyorfeesettlementid int =null,
@CreditNoteidMultiple int =null ,
@pymentmodeid int =null,
@purchaseid int = null,
@disbursementid int = null,
@Bankidnew int= null,
@CheqDate date = null,
@CheqAmt numeric(16,2)=null,
@branchid int=null,
@subbranchid int=null,
@moduleid int=null         
)                
as                                  
begin      
	
             
  Insert into tbl_PayeeBankInfo (bankid,branch,AcNo,AcHolderName,BankCode,NatureofPayment,Remarks,isbankdetail,AUID, UUI,ADT,UDT, claimPaymentid,  Survyorfeeid,Commissionid,
  AgentCommissionid,creditnotepaymentid,claimsetlementid,surveyorfeesettlementid, creditnotepaymentmultipleid,paymentid,Purchaseid,disbursementid,BankIdNew,CheqDate,CheqAmt,branchid,
  subbranchid,moduleid )  
                                                         
	values (@bankid,@branch,@AcNo,@ACHolderName,@BANKCODE,@NatureOfPaymentID,@Remarks,@isbankdetail,@AUID,@UUID,@ADT,@UDT,@claimid,@Survyorfeeid,@Commissionid,@AgentCommissionid,
	@CreditNoteid,	@claimsetlementid,@surveyorfeesettlementid,@CreditNoteidMultiple,@pymentmodeid,@purchaseid,@disbursementid,@Bankidnew,@CheqDate,@CheqAmt,@branchid,
	@subbranchid,@moduleid)

		set @msg='Insert'
              
   end 


GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[company_FiscalYr_get_new]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[company_FiscalYr_get_new]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[company_FiscalYr_get_new]          
        
as begin          
select a.* from FISCALYEAR   a                
   where (ISNULL(a.islock,0)=0) and (ISNULL(a.STATUS,0)=1) order by ENGSTARTDATE desc
end   


GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FxGetMaxDisbursementNo]') AND type IN (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION  [dbo].[FxGetMaxDisbursementNo]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE function [dbo].[FxGetMaxDisbursementNo] (        
@Branchid int,        
@SubBranchID int,        
@FiscalID int,      
@DisbType int       
)        
returns varchar(50) as        
begin        
declare @DISBNO varchar(50)        
declare @MaxDisbNo varchar(30),@ISINDIVIDUAL TINYINT,@COMPANYID INT        
SELECT @ISINDIVIDUAL=ISINDIVIDUAL FROM MSSUBBRANCH WHERE SUBBRANCHID=@SubBranchID        
SELECT @COMPANYID=ID FROM CompanyProfile        
        
--IF(@ISINDIVIDUAL=1)        
 BEGIN        
  select @MaxDisbNo = dbo.formatcode((select isnull(MAX(DISBURSEMENTNO),0)+1 as DISBURSEMENTNO from TBLDISBURSEMENTMASTER         
   where branchid = @Branchid        
   and subBranchID = @SubBranchID        
   and FISCALID = @FiscalID       
   and DTYPE=@DisbType),6)        
          
  IF(@COMPANYID=1)--NATIONAL        
   select @DISBNO =isnull((select ealias from MSSUBBRANCH where BRANCHID = @BranchID and SUBBRANCHID = @SubBranchID),'N/A')        
    + '/' + (select fiscalyear from fiscalyear where id = @fiscalid)       
    + '/' + (select EABBRV from tblDisbursementType where ID=@DisbType )      
    + '/' +  @MaxDisbNo + ':' + @MaxDisbNo        
          
  IF(@COMPANYID=2 or @COMPANYID=5 or @COMPANYID=6  or @COMPANYID=7)--GIC    
   select @DISBNO = @MaxDisbNo + ':' + @MaxDisbNo        
 END        
--ELSE        
-- BEGIN        
--  select @MaxDisbNo = dbo.formatcode((select isnull(MAX(DISBURSEMENTNO),0)+1 as DISBURSEMENTNO from TBLDISBURSEMENTMASTER         
--   where branchid = @Branchid        
--   and FISCALID = @FiscalID ),6)        
          
--  IF(@COMPANYID=1)--NATIONAL        
--   select @DISBNO =isnull((select alias from MSBRANCH where BRANCHID = @BranchID),'N/A')        
--    + '/' + (select fiscalyear from fiscalyear where id = @fiscalid)        
--    + '/' + (select EABBRV from tblDisbursementType where ID=@DisbType )      
--    + '/' +  @MaxDisbNo + ':' + @MaxDisbNo        
          
--  IF(@COMPANYID=2)--PICL        
--   select @MaxDisbNo = @MaxDisbNo + ':' + @MaxDisbNo        
-- END        
 return @DISBNO        
end        
        

GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[co_disbursementinsertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[co_disbursementinsertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_DISBURSEMENT]    Script Date: 04/03/2019 11:43:16 ******/
DROP TYPE [dbo].[TBLTYPE_DISBURSEMENT]
GO

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_DISBURSEMENT]    Script Date: 04/03/2019 11:43:16 ******/
CREATE TYPE [dbo].[TBLTYPE_DISBURSEMENT] AS TABLE(
	[ROWNUMBER] [int] NULL,
	[ACCOUNTCODE] [int] NULL,
	[ACCOUNTDESC] [varchar](200) NULL,
	[DRAMOUNT] [numeric](16, 2) NULL,
	[CRAMOUNT] [numeric](16, 2) NULL,
	[REMARKS] [varchar](255) NULL
)
GO



/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_FAC_DISBURSETYPE]    Script Date: 04/03/2019 11:43:43 ******/
DROP TYPE [dbo].[TBLTYPE_FAC_DISBURSETYPE]
GO

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_FAC_DISBURSETYPE]    Script Date: 04/03/2019 11:43:43 ******/
CREATE TYPE [dbo].[TBLTYPE_FAC_DISBURSETYPE] AS TABLE(
	[FACID] [int] NULL,
	[DOCID] [int] NULL
)
GO




             
                
CREATE proc [dbo].[co_disbursementinsertUpdate](                   
   @PAYID  int  = 0 ,                   
   @BRANCHID  int  = NULL ,                   
   @SUBBRANCHID  int  = NULL ,                   
   @FISCALID  int  = NULL ,                   
   @DTYPE  int  = NULL ,                   
   @DISBURSEMENTNO  int  = NULL ,                   
   @FDISBURSEMENTNO  varchar(40)  = NULL ,                   
   @PDATE  date  = NULL ,                   
   @NDATE  varchar(20)  = NULL ,                   
   @PAYTO  nvarchar(200) = NULL ,                   
   @BILLNO  varchar(30)  = NULL ,                   
   @BANKID  int  = NULL ,                   
   @CHEQUENO  varchar(30)  = NULL ,                   
   @CHEQUEDT  date  = NULL ,                   
   @CHEQAMT  numeric(16,2)  = NULL ,                   
   @DOCID  int  = NULL ,                   
   @FACID  int  = NULL ,                   
   @REMARKS  nvarchar(512) = NULL ,                   
   @AUID  int  = NULL ,                   
   @ADT  datetime = NULL ,                   
   @UUID  int  = NULL ,                   
   @UDT  datetime = NULL ,                   
   @CANCEL  smallint = NULL ,                   
   @CANCELDT  date  = NULL ,                   
   @CANCELTIME  datetime = NULL ,                   
   @CANCELREASON  nvarchar = NULL  ,                  
    @msg varchar(40) output,                
    @DISBURSEMENT [TBLTYPE_DISBURSEMENT] READONLY   ,              
    @FAC_DISBTYPE [TBLTYPE_FAC_DISBURSETYPE] READONLY                 
    --@DISBID int output                 
 ) AS                   
 declare @errcode int ,@id_new int                  
 --begin transaction                 
    if exists (select 1 from TBLDISBURSEMENTMASTER where PAYID = @PAYID )                
          Begin                
                    
             Update TBLDISBURSEMENTMASTER SET                   
             BRANCHID = @BRANCHID,                   
             SUBBRANCHID = @SUBBRANCHID,                   
             FISCALID = @FISCALID,                   
             DTYPE = @DTYPE,                   
             DISBURSEMENTNO = @DISBURSEMENTNO,                   
             FDISBURSEMENTNO = @FDISBURSEMENTNO,                   
             PDATE = @PDATE,                   
             NDATE = @NDATE,                   
             PAYTO = @PAYTO,                   
             BILLNO = @BILLNO,                   
             BANKID = @BANKID,                   
             CHEQUENO = @CHEQUENO,                   
             CHEQUEDT = @CHEQUEDT,                   
             CHEQAMT = @CHEQAMT,                   
             DOCID = isnull(@DOCID,''),                   
             FACID = @FACID,                   
             REMARKS = @REMARKS,           
             UUID = @UUID,                   
             UDT = GETDATE(),                   
             CANCEL = @CANCEL,                   
             CANCELDT = @CANCELDT,                   
             CANCELTIME = @CANCELTIME,                   
             CANCELREASON = @CANCELREASON                 
             where PAYID=@PAYID                 
               set @msg='update' 
			   set @id_new= @PAYID              
          End            
 else                          
          Begin                   
             declare @RawDisbNo varchar(30)                                                                    
   select @RawDisbNo = dbo.[FxGetMaxDisbursementNo](@BRANCHID,ISNULL(@SUBBRANCHID,0),@FISCALID,@DTYPE)                                                                    
   SET @DISBURSEMENTNO = RIGHT(@RawDisbNo,LEN(@RawDisbNo)-CHARINDEX(':',@RawDisbNo))                                                       
   SET @FDISBURSEMENTNO = SUBSTRING(@RawDisbNo,1,len(@RawDisbNo)-len(RIGHT(@RawDisbNo,LEN(@RawDisbNo)-CHARINDEX(':',@RawDisbNo)))-1)                  
                      
              Insert into TBLDISBURSEMENTMASTER (                   
                 BRANCHID,  SUBBRANCHID,  FISCALID,              
                DTYPE,  DISBURSEMENTNO,  FDISBURSEMENTNO,  PDATE,  NDATE,                   
                PAYTO,  BILLNO,  BANKID,  CHEQUENO, CHEQUEDT,                   
                CHEQAMT,  DOCID,  FACID,  REMARKS,  AUID,                   
                ADT,  UUID,  UDT,  CANCEL,  CANCELDT,             
                CANCELTIME,  CANCELREASON )                   
                select                   
                  @BRANCHID, @SUBBRANCHID, @FISCALID,           
                  @DTYPE, @DISBURSEMENTNO, @FDISBURSEMENTNO, @PDATE, @NDATE,                   
                  @PAYTO, @BILLNO, @BANKID, @CHEQUENO, @CHEQUEDT,                   
                 @CHEQAMT, (Case when isnull(@DOCID,0) < 1 then null else @DOCID end), 
                 (case when isnull(@FACID,0) < 1 then null else @FACID end), @REMARKS, @AUID,                   
                  GETDATE(), @UUID, GETDATE(), @CANCEL, @CANCELDT,                   
                  @CANCELTIME, @CANCELREASON                  
                            
                declare @id int=Scope_Identity()            
                set @msg='insert' +'#'+@FDISBURSEMENTNO+'#'+ cast(@id as varchar)

				 select @id_new = SCOPE_IDENTITY() from TBLDISBURSEMENTMASTER                
          End     
		  
		  
		  begin --for user activity log                                           
  declare @nbranchid int=@branchid,                                            
  @nuserid int=@uuid,                                            
  @ntaskname varchar(200)='Account-Disbursement Entry',                                            
  @ntaskdescription varchar(200)='Disbursement Entry where voucher no is :'+cast(isnull(@FDISBURSEMENTNO,'') as varchar),                                          
  @nactivity varchar(200)=@msg,
  @nprimarykey int =@id_new                                         
      
  exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nprimarykey
  end                                        
                              
         delete from  TBLDISBURSEMENTDETAILS where payid=@PAYID                
                  
        Insert into TBLDISBURSEMENTDETAILS (                                       
        PAYID, ACCOUNTDESC, ACCOUNTCODE,  DRAMOUNT,  CRAMOUNT,  REMARKS)                                       
  SELECT                                      
    @id, ACCOUNTDESC,ACCOUNTCODE,                                       
   DRAMOUNT,  CRAMOUNT,REMARKS  FROM  @DISBURSEMENT                
                   
  --UPDATE tblfacdetail SET payid = @id WHERE ID IN (SELECT FACID from @FAC_DISBTYPE)               
                   
  --       declare @CompID int          
  --       select @CompID = id from CompanyProfile          
  --       if (@CompID =1 ) -- only for national          
  --       begin          
  -- exec CO_ACC_DISBURSEMENT_VOUCHER_NAI @id              
  --       end        
  --      else if (@CompID =2 ) -- PICL         
  --       begin          
  -- exec CO_ACC_DISBURSEMENT_VOUCHER_PICL @id              
  --       end 

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetBankInfo_insertUpdate]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[GetBankInfo_insertUpdate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE proc [dbo].[GetBankInfo_insertUpdate](                  
@BANKCODE varchar(10)=null,                
@AUID varchar(20) =null,      
@UUID varchar(20) =null,  
@ADT date=null,                  
@UDT datetime =null,          
@bankid varchar(200)=null,                  
@NatureOfPaymentID varchar(20)=null,                               
@Remarks varchar(500)=null,                                    
@AcNo varchar(50)=null,                  
@branch varchar(20)=null,      
@ACHolderName varchar(100)=null,                         
@msg varchar(20) output ,                           
@isbankdetail int=null ,
@claimid varchar(20) =null,
@Survyorfeeid  int =null,
@Commissionid int =null,
@AgentCommissionid int =null,
@CreditNoteid int =null,
@claimsetlementid int =null,
@surveyorfeesettlementid int =null,
@CreditNoteidMultiple int =null ,
@pymentmodeid int =null,
@purchaseid int = null,
@disbursementid int = null,
@Bankidnew int= null,
@CheqDate date = null,
@CheqAmt numeric(16,2)=null,
@branchid int=null,
@subbranchid int=null,
@moduleid int=null         
)                
as                                  
begin      
	
             
  Insert into tbl_PayeeBankInfo (bankid,branch,AcNo,AcHolderName,BankCode,NatureofPayment,Remarks,isbankdetail,AUID, UUI,ADT,UDT, claimPaymentid,  Survyorfeeid,Commissionid,
  AgentCommissionid,creditnotepaymentid,claimsetlementid,surveyorfeesettlementid, creditnotepaymentmultipleid,paymentid,Purchaseid,disbursementid,BankIdNew,CheqDate,CheqAmt,branchid,
  subbranchid,moduleid )  
                                                         
	values (@bankid,@branch,@AcNo,@ACHolderName,@BANKCODE,@NatureOfPaymentID,@Remarks,@isbankdetail,@AUID,@UUID,@ADT,@UDT,@claimid,@Survyorfeeid,@Commissionid,@AgentCommissionid,
	@CreditNoteid,	@claimsetlementid,@surveyorfeesettlementid,@CreditNoteidMultiple,@pymentmodeid,@purchaseid,@disbursementid,@Bankidnew,@CheqDate,@CheqAmt,@branchid,
	@subbranchid,@moduleid)

		set @msg='Insert'
              
   end 


GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FxGetNepaliDate]') AND type IN (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION  [dbo].[FxGetNepaliDate]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create function dbo.FxGetNepaliDate(@prmEngDate date)
returns varchar(50)
as
begin
	declare @Firsttime int, @StartDate date, @datediff int, @Found int, @NepDate varchar(30), @Cnt int, @TotMonths int;
	declare @EngStDate date, @NDays int, @NYear int, @NMonth int;

	DECLARE Cur_GetNepDt CURSOR STATIC   
    FOR   
		SELECT tbYearInfo.NYear, tbMonthInfo.NMonth, tbMonthInfo.NDays, tbYearInfo.ESDate FROM tbYearInfo
		INNER JOIN tbMonthInfo ON tbYearInfo.NYear = tbMonthInfo.NYear
		Where replace(CONVERT(varchar, @prmEngDate,106),' ','-') Between ESDATE And  EEDate
		ORDER BY tbMonthInfo.NMonth;
	OPEN Cur_GetNepDt  
	set @Firsttime = 1;
	set @Found = 0;
	set @Cnt = 0;
	set @StartDate = @prmEngDate;
	set @TotMonths = 0;
	FETCH NEXT FROM Cur_GetNepDt into @NYear, @NMonth, @NDays, @EngStDate
	WHILE @@FETCH_STATUS = 0  
	BEGIN  
		if (@Firsttime=1)
			begin
				set @EngStDate = @EngStDate;
				set @datediff = datediff(d,@EngStDate,@StartDate);
				set @Firsttime = 0;		
			end
		if ((@Cnt + @NDays) > @datediff)
			begin
				set @Found = 1;
				set @NepDate = convert(varchar(30), @NYear) + '/' +  dbo.formatcode( convert(varchar(30),(@TotMonths + 1)),2) + '/' + dbo.formatcode( convert(varchar(30),(@datediff - @Cnt + 1)),2);
			end
		if (@Found=1)
			begin
				return @NepDate;
			end
		else
			begin
				set @TotMonths = @TotMonths + 1;
				set @Cnt = @Cnt + @NDays;
			end
		FETCH NEXT FROM Cur_GetNepDt into @NYear, @NMonth, @NDays, @EngStDate 
	END
	
	return @NepDate;
end
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FxGetMaxVoucherNo]') AND type IN (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION  [dbo].[FxGetMaxVoucherNo]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
  
CREATE function [dbo].[FxGetMaxVoucherNo] (  
@Branchid int,  
@FiscalID int,  
@SubBranchID int,  
@vouchertype int,  
@TRANSACTIONTYPEID varchar(3)  
)  
returns varchar(200) as  
begin  
declare @VOUCHERNO varchar(200),@FVOUCHERNO varchar(200),@ISINDIVIDUAL TINYINT,@COMPANYID INT  
SELECT @ISINDIVIDUAL=ISINDIVIDUAL FROM MSSUBBRANCH WHERE SUBBRANCHID=@SubBranchID  
SELECT @COMPANYID=ID FROM CompanyProfile  
  
IF(@ISINDIVIDUAL=1)  
 BEGIN  
  set @VOUCHERNO = ( dbo.FormatCode((select CONVERT(varchar(50), isnull(MAX(VOUCHERNO),0)+1) as VOUCHERNO from AC_TRANSACTION_MASTER   
   where BRANCHID=@Branchid and VOUCHERTYPEID=@vouchertype and FISCALID=@FiscalID AND SUBBRANCHID=@SubBranchID ),6) )  
    
  IF(@COMPANYID=1)--NATIONAL   
   select @FVOUCHERNO =  isnull((select ealias from MSSUBBRANCH where BRANCHID = @BranchID and SUBBRANCHID = @SubBranchID),0) +  
   + '/' + cast(@vouchertype as varchar) + '/' +  
   (select ALIAS from FISCALYEAR where ID = @FiscalID)  + '/' +  
   cast(@TRANSACTIONTYPEID as varchar)  + '/'  + @VOUCHERNO  + ':' + @VOUCHERNO  
 END  
ELSE  
 BEGIN  
  set @VOUCHERNO = ( dbo.FormatCode((select CONVERT(varchar(50), isnull(MAX(VOUCHERNO),0)+1) as VOUCHERNO from AC_TRANSACTION_MASTER   
   where BRANCHID=@Branchid and VOUCHERTYPEID=@vouchertype and FISCALID=@FiscalID),6) )  
     
  IF(@COMPANYID=1)--NATIONAL  
   begin  
    select @FVOUCHERNO =  isnull((select ALIAS from MSBRANCH where BRANCHID = @BranchID),0) +  
    + '/' + cast(@vouchertype as varchar) + '/' +  
    (select ALIAS from FISCALYEAR where ID = @FiscalID)  + '/' +  
    cast(@TRANSACTIONTYPEID as varchar)  + '/'  + @VOUCHERNO  + ':' + @VOUCHERNO  
   end  
  else  
   begin  
    set @FVOUCHERNO = CONVERT(int, @VOUCHERNO)  
   end  
 END  
return @FVOUCHERNO  
end  
  
  
  
  
  
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CO_ACC_PURCHASE_VOUCHER]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[CO_ACC_PURCHASE_VOUCHER]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[co_acc_voucherDetail_Insert]') AND type IN (N'P', N'PC'))
DROP PROCEDURE  [dbo].[co_acc_voucherDetail_Insert]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE proc co_acc_voucherDetail_Insert    
(    
 @TRANID INT,    
 @ACCOUNTCODE INT,    
 @DRAMOUNT NUMERIC(16,2),    
 @CRAMOUNT NUMERIC(16,2),    
 @ENTRYNO SMALLINT,    
 @CHQNO VARCHAR(100),    
 @DESCRIPTION VARCHAR(4000),    
 @ISSUEDTO VARCHAR(255),    
 @RELATEDTO NUMERIC(16,2),    
 @CHQDATE VARCHAR(20),    
 @BILLNO VARCHAR(40),    
 @PANNO VARCHAR(40) ,
 @ISHIDE INT=0   
)    
as    
begin    
 Insert into AC_TRANSACTION_DETAILS (  TRANID,ACCOUNTCODE, DRAMOUNT,  CRAMOUNT, ENTRYNO,  CHQNO,DESCRIPTION,                          
  ISSUEDTO, RELATEDTO, CHQDATE ,BILLNO,PANNO,VTYPE )       
 values  (@TRANID, @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@ENTRYNO, @CHQNO, @DESCRIPTION,                           
  @ISSUEDTO, @RELATEDTO, @CHQDATE,@BILLNO,@PANNO,ISNULL(@ISHIDE,0) )    
end

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FxGetAccountCodeNEW]') AND type IN (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION  [dbo].[FxGetAccountCodeNEW]

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

      
CREATE function [dbo].[FxGetAccountCodeNew] (                
@ACCOUNTTYPE INT,                
@DEPTID INT,                
@AGENTCODE VARCHAR(4), @Classid INT, @GLCODE varchar(20), @SLCODE varchar(20)            
)                  
returns INT as                  
begin                  
declare @ACCOUNTCODE INT         
if (ISNULL(@Classid,0)> 0)      
 begin      
  if exists(select 1 from AC_AccountHead                 
    WHERE isnull(ACCOUNTTYPE,0)=isnull(@ACCOUNTTYPE,0) AND                 
     (ISNULL(@DEPTID,0)=0 OR DEPTID=@DEPTID) AND                
     (ISNULL(@Classid,0)=0 OR CLASSID=@Classid) AND            
     (ISNULL(@AGENTCODE,'')='' OR AGENTCODE=@AGENTCODE) and                
     (ISNULL(@GLCODE,'')='' OR GLCODE=@GLCODE) and            
     (ISNULL(@SLCODE,'')='' OR SLCODE=@SLCODE))      
   select @ACCOUNTCODE=ACCOUNTCODE from AC_AccountHead                 
   WHERE isnull(ACCOUNTTYPE,0)=isnull(@ACCOUNTTYPE,0) AND                 
     (ISNULL(@DEPTID,0)=0 OR DEPTID=@DEPTID) AND                
     (ISNULL(@Classid,0)=0 OR CLASSID=@Classid) AND            
     (ISNULL(@AGENTCODE,'')='' OR AGENTCODE=@AGENTCODE) and                
     (ISNULL(@GLCODE,'')='' OR GLCODE=@GLCODE) and            
     (ISNULL(@SLCODE,'')='' OR SLCODE=@SLCODE)      
  else      
   select @ACCOUNTCODE=ACCOUNTCODE from AC_AccountHead                 
   WHERE isnull(ACCOUNTTYPE,0)=isnull(@ACCOUNTTYPE,0) AND                 
     (ISNULL(@DEPTID,0)=0 OR DEPTID=@DEPTID) AND isnull(Classid,0) = 0 and            
     (ISNULL(@AGENTCODE,'')='' OR AGENTCODE=@AGENTCODE) and                
     (ISNULL(@GLCODE,'')='' OR GLCODE=@GLCODE) and            
     (ISNULL(@SLCODE,'')='' OR SLCODE=@SLCODE)         
 end      
else      
 begin              
   select @ACCOUNTCODE=ACCOUNTCODE from AC_AccountHead                 
    WHERE isnull(ACCOUNTTYPE,0)=isnull(@ACCOUNTTYPE,0) AND                 
     (ISNULL(@DEPTID,0)=0 OR DEPTID=@DEPTID) AND        
     (ISNULL(Classid,0)=0 ) AND         
     (ISNULL(@AGENTCODE,'')='' OR AGENTCODE=@AGENTCODE) and                
     (ISNULL(@GLCODE,'')='' OR GLCODE=@GLCODE) and            
     (ISNULL(@SLCODE,'')='' OR SLCODE=@SLCODE)            
                     
 end      
 return @ACCOUNTCODE      
end 
GO

CREATE proc CO_ACC_PURCHASE_VOUCHER
(
	@PURCHASEID		INT
)
AS
BEGIN
	DECLARE @BANKID INT, @BANKNAME NVARCHAR(200), @TOTPAYABLE NUMERIC(16,2), @EDATE DATE, @CHEQNO NVARCHAR(50)
			,@TRANSMITI VARCHAR(20)=NULL, @TTYPE INT = 0, @DOCID INT, @BRANCHID INT, @SUBBRANCHID INT
			,@fiscalid INT, @TRANSACTIONTYPEID INT = NULL, @DESCRIPTION NVARCHAR(255), @CLAIMNO NVARCHAR(50)
			,@insuredname varchar(1024), @APPROVED INT, @IFPREVBALANCE INT, @AUID INT, @UUID INT, @TRANID INT
			,@accountType INT, @ACCOUNTCODE INT, @SURV_ACCID INT, @ENTRYNO INT = 0, @DRAMOUNT NUMERIC(16,2)
			, @CRAMOUNT NUMERIC(16,2), @CHQDATE DATE, @CHQNO VARCHAR(50), @ISSUEDTO NVARCHAR(255), @PANNO VARCHAR(20)
			, @VENDORID INT, @BILLNO VARCHAR(30), @VATAMT NUMERIC(16,2)
	
	SELECT @fiscalid = A.Fiscalid,@BRANCHID = A.branchid,@SUBBRANCHID = A.subbranchid,@VENDORID = A.vendorid,@BILLNO = A.billno
	, @VATAMT =  A.pVatAmt, @TOTPAYABLE = A.pNetAmt,@EDATE = A.pdate,@TRANSMITI = A.ndate,@DESCRIPTION = A.Remarks
	, @BANKID = A.Bankid, @CHEQNO = A.cheqno, @CHQDATE = A.cheqdt FROM tblpurchaseEntry A 
	WHERE A.PurchaseID = @PURCHASEID

	SELECT @PANNO = PANNO FROM TBLVENDORINFO WHERE VEN_ID = @VENDORID

	SELECT @fiscalid = ID FROM FISCALYEAR WHERE @EDATE BETWEEN ENGSTARTDATE AND ENGENDDATE
	set @TRANSMITI=dbo.FxGetNepaliDate(@EDATE)            
	set @TTYPE=6 
	SET @APPROVED = 0
	SET @IFPREVBALANCE = 0

    /******************************AC_TRANSACTION_MASTER*********************************************/         
	 begin              
	  delete from AC_TRANSACTION_DETAILS where TRANID in (select masterid from AC_TRANSACTION_MASTER     
			  where PURCHASEID = @PURCHASEID and VOUCHERTYPEID = @TTYPE )      
	  delete from AC_TRANSACTION_MASTER where PURCHASEID = @PURCHASEID and VOUCHERTYPEID = @TTYPE      
          
	  DECLARE @MaxVno INT  ,@RAWVNO VARCHAR(200),@FVOUCHERNO VARCHAR(200)            
	  SELECT @RAWVNO=dbo.[FxGetMaxVoucherNo](@branchid,@fiscalid,@SubBranchID,@TTYPE,@TRANSACTIONTYPEID)            
	  SET @FVOUCHERNO= @RAWVNO    
	  SET @MaxVno=right(@RAWVNO,6)      
	  set @DESCRIPTION = @DESCRIPTION + ', BILLNO. ' + @BILLNO
                
	  Insert  into AC_TRANSACTION_MASTER                                     
	   ( BRANCHID,FISCALID,VOUCHERTYPEID,NARRATION,VOUCHERNO, trans_date,approved, auid, adt,uuid, udt,              
		ifprevbalance,bsyear, Bsmonth, PURCHASEID, docid, receiptno,TRANSACTIONTYPEID,trans_miti,SUBBRANCHID,FVOUCHERNO)                                    
	   values(@branchid,@FiscalID,@TTYPE,@DESCRIPTION,@MaxVno,@EDATE,@APPROVED,@AUID, GETDATE(), @UUID, GETDATE(),              
		 @IFPREVBALANCE,0,0, @PURCHASEID, NULL, NULL,@TRANSACTIONTYPEID,@TRANSMITI,@SubBranchID,@FVOUCHERNO)               
    
	  set @TRANID=(select SCOPE_IDENTITY())                   
	 end	

	 DECLARE CUR_DISB CURSOR FAST_FORWARD FOR                   
	 SELECT  C.ACCOUNTCODE, B.amount FROM tblpurchaseentrydetails B 
	INNER JOIN TBL_PURCHASE_ITEM C ON B.itemid = C.PURCHASEID
	INNER JOIN tblpurchaseEntry A ON B.purchaseid = A.PurchaseID
	where B.purchaseid = @PURCHASEID        
         
	 set @DRAMOUNT = 0         
	 set @CRAMOUNT = 0        
	 OPEN CUR_DISB                  
	 FETCH NEXT FROM CUR_DISB INTO @ACCOUNTCODE, @DRAMOUNT
	 WHILE @@FETCH_STATUS=0                  
	  BEGIN              
		set @ENTRYNO=@ENTRYNO+1                  
		select @ACCOUNTCODE=@ACCOUNTCODE             
		set @ENTRYNO=@ENTRYNO+1              
		set @DRAMOUNT=@DRAMOUNT      
		set @CRAMOUNT=0              
		set @CHQDATE=null              
		set @CHQNO=null    
		if(@DRAMOUNT>0)             
		EXEC co_acc_voucherDetail_Insert @TRANID, @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@ENTRYNO, @CHQNO, @DESCRIPTION,                                     
		@ISSUEDTO, NULL, @CHQDATE,NULL,@PANNO 
	                      
	   FETCH NEXT FROM CUR_DISB INTO @ACCOUNTCODE, @DRAMOUNT                
	  END                  
	 CLOSE CUR_DISB                  
	 DEALLOCATE CUR_DISB
	 
	 
	   begin    
		SET @accountType = 53    
		select @ACCOUNTCODE=[dbo].[FxGetAccountCodeNEW](@accountType,0,null,null,null,null)           
		set @ENTRYNO=@ENTRYNO+1              
		set @DRAMOUNT=@VATAMT      
		set @CRAMOUNT=0              
		set @CHQDATE=null              
		set @CHQNO=null    
		if(@DRAMOUNT>0)             
		 EXEC co_acc_voucherDetail_Insert @TRANID, @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@ENTRYNO, @CHQNO, @DESCRIPTION,                                     
		  @ISSUEDTO, NULL, @CHQDATE,NULL,@PANNO    
	   end  
	  -- Bank a/c     
	  SET @accountType = 0    
	  set @ACCOUNTCODE=@BANKID    
	  set @ENTRYNO=@ENTRYNO+1              
	  set @DRAMOUNT=0    
	  set @CRAMOUNT=@TOTPAYABLE              
	  set @CHQDATE=null              
	  set @CHQNO=null    
	  if(@CRAMOUNT>0)             
	   EXEC co_acc_voucherDetail_Insert @TRANID, @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@ENTRYNO, @CHQNO, @DESCRIPTION,                                     
		@ISSUEDTO, NULL, @CHQDATE,NULL,@PANNO  
END

GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO
