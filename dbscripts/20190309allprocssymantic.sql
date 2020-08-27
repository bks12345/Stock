DROP proc get_paymenttype    
GO
CREATE proc get_paymenttype    
as    
begin    
select * from def_paymenttype where isnull(islocked,0)=0    
end  
  go

  --insert into def_paymenttype (PaymentType,islocked) values ('Cheque',0)
  alter proc acc_vw_acctransaction_get             
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
  
  go             
      DROP proc co_acc_voucherDetail_Insert    
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
  
               
  DROP PROC [GetBankInfo_insertUpdate]
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
 @CreditNoteid, @claimsetlementid,@surveyorfeesettlementid,@CreditNoteidMultiple,@pymentmodeid,@purchaseid,@disbursementid,@Bankidnew,@CheqDate,@CheqAmt,@branchid,  
 @subbranchid,@moduleid)  
  
  set @msg='Insert'  
                
   end   
  GO
    
DROP PROC [CO_ACC_DISBURSEMENT_VOUCHER_PICL]
GO
CREATE PROC [dbo].[CO_ACC_DISBURSEMENT_VOUCHER_PICL]      
(                                              
  @PAYID  int  = null            
)                      
AS               
BEGIN                      
 declare @TRANID  int  = null ,                     
   @TRANID_BLOCK2  int  = null ,                                                
   @deptid  int  = NULL ,                                            
   @RECEIPTNO  varchar(20)  = NULL ,                                  
   @FiscalID  int  = NULL ,                                              
   @branchid int = null,                                               
   @EDATE  datetime = NULL ,                                             
   @NDATE  varchar(20) = NULL ,                                               
   @IFPREVBALANCE  tinyint  = NULL ,                                   
   @TTYPE  tinyint  = NULL ,                                             
   @APPROVED  tinyint  = 1 ,                                       
   @DESCRIPTION  varchar(4000)  = NULL ,                               
   @TRANSACTIONTYPEID int =null,                       
   @TRANSMITI VARCHAR(20)=NULL,                                  
   @AUID  int  = NULL ,                                             
   @ADT  date  = NULL ,                                             
   @UUID  int  = NULL ,                                             
   @UDT  date  = NULL  ,                                       
   @billno  varchar(50)  = NULL ,                                             
   @ISSUEDTO  varchar(255)  = NULL ,                                              
   @RELATEDTO  tinyint  = NULL,                    
   @SubBranchID INT=NULL,            
   @DocumentNo varchar(50), @Remarks varchar(512),      
   @dtype int,  @BankID int,  @cheqNo varchar(50), @cheqAmt numeric(16,2),        
   @insuredname varchar(1024) , @CommAdj int, @DisbursementNo int, @FDisbursementNo varchar(50)           
       
           
 select @branchid = BRANCHID, @SubBranchID = SUBBRANCHID, @FiscalID = FISCALID,      
 @dtype = DTYPE, @DisbursementNo = DISBURSEMENTNO, @FDisbursementNo = FDISBURSEMENTNO,      
 @EDATE = PDATE, @NDATE = NDATE, @ISSUEDTO = PAYTO, @billno = BILLNO, @BankID = BANKID,      
 @cheqNo =CHEQUENO, @cheqAmt = CHEQAMT, @Remarks = REMARKS,      
 @AUID = AUID, @ADT = UDT, @UUID = UUID, @UDT = UDT  from TBLDISBURSEMENTMASTER where PAYID = @PAYID                   
        
 set @NDATE=dbo.FxGetNepaliDate(@EDATE)                    
       
 set @TTYPE=2        
 set @TRANSACTIONTYPEID = @dtype      
                 
    /******************************AC_TRANSACTIONDTL_MASTER*********************************************/                 
  DECLARE @MaxVno INT  ,@RAWVNO VARCHAR(200),@FVOUCHERNO VARCHAR(200)                    
  select @MaxVno = VOUCHERNO, @FVOUCHERNO = FVOUCHERNO from AC_TRANSACTION_MASTER where PayID = @PAYID      
        
  delete from AC_TRANSACTION_DETAILS where TRANID in (select masterid from AC_TRANSACTION_MASTER    
 where PayID = @PAYID and VOUCHERTYPEID = @TTYPE )    
  delete from AC_TRANSACTION_MASTER where PayID = @PAYID and VOUCHERTYPEID = @TTYPE    
                  
  if (ISNULL(@MaxVno,0)=0)      
  begin      
 SELECT @RAWVNO=dbo.[FxGetMaxVoucherNo](@branchid,@fiscalid,@SubBranchID,@TTYPE,null)    
 SET @FVOUCHERNO= @RAWVNO                  
    SET @MaxVno=right(@RAWVNO,6)              
  end      
  set @DESCRIPTION = @Remarks      
                        
  Insert  into AC_TRANSACTION_MASTER                                             
   ( BRANCHID,FISCALID,VOUCHERTYPEID,NARRATION,VOUCHERNO, trans_date,approved, auid, adt,uuid, udt,                      
    ifprevbalance,bsyear, Bsmonth, claimid, docid, receiptno,TRANSACTIONTYPEID,PayID,trans_miti,SUBBRANCHID,FVOUCHERNO)                                            
   values(@branchid,@FiscalID,@TTYPE,@DESCRIPTION,@MaxVno,@EDATE,@APPROVED,@AUID, GETDATE(), @UUID, GETDATE(),                      
     @IFPREVBALANCE,0,0, null, null, @RECEIPTNO,@TRANSACTIONTYPEID,@PAYID,@NDATE,@SubBranchID,@FVOUCHERNO)                       
            
  set @TRANID=(select SCOPE_IDENTITY())            
 --end                         
                       
 /******************************AC_TRANSACTIONDTL_DETAILS*********************************************/                      
 begin            
  declare @receivablePremiumIncome numeric(16,2),                      
    @vatOnSales  numeric(16,2),                      
    @stampDuty  numeric(16,2),                      
    @commExp  numeric(16,2),                      
    @agentAcc  numeric(16,2),                   
    @CommTds  numeric(16,2),                      
    @excessPremiumControlAcc  numeric(16,2),                      
    @excessid int,                      
    @bankAccAmt numeric(16,2),                      
    @creditAdviceAmt numeric(16,2),                      
    @creditAdviceBankCode varchar(100),                      
    @HisabMilanAmt numeric(16,2),                      
    @HisabMilanPartyCode int,                      
    @governmentSubsidy numeric(16,2),                      
    @mid int,                      
    @accountType int,                                        
    @ACCOUNTCODE  varchar(10),                      
    @classid int,                 
    @originalDeptid int,                          
    @AGENTCODE  varchar(10) ,                         
    @originalAGENTCODE varchar(10),                      
    @DRAMOUNT NUMERIC(16,2),                      
    @CRAMOUNT NUMERIC(16,2),                                            
    @OriginalCHQNO  varchar(50),                                       
    @OriginalCHQDATE  varchar(20) ,                                           
    @CHQNO  varchar(50),                                       
    @CHQDATE  varchar(20) ,                       
    @ENTRYNO  int=0 ,                      
    @TAXRATE NUMERIC(16,4),                      
    @PANNO VARCHAR(40),                    
    @PID INT            
        
  set @ENTRYNO = 0            
  DECLARE CUR_DISB CURSOR FAST_FORWARD FOR                 
 SELECT accountcode, dramount, cramount, remarks from TBLDISBURSEMENTDETAILS where payid = @PAYID      
       
 set @DRAMOUNT = 0       
 set @CRAMOUNT = 0      
 OPEN CUR_DISB                
 FETCH NEXT FROM CUR_DISB INTO @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@DESCRIPTION      
 WHILE @@FETCH_STATUS=0                
  BEGIN            
   set @ENTRYNO=@ENTRYNO+1                
   EXEC co_acc_voucherDetail_Insert @TRANID, @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@ENTRYNO, @cheqNo, @DESCRIPTION,                                       
     @ISSUEDTO, @RELATEDTO, @CHQDATE,@BILLNO,@PANNO                 
   FETCH NEXT FROM CUR_DISB INTO @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@DESCRIPTION               
  END                
 CLOSE CUR_DISB                
 DEALLOCATE CUR_DISB           
              
  set @ENTRYNO=@ENTRYNO+1            
  if(@CheqAmt>0)           
  begin      
  select @ACCOUNTCODE=@BankID      
  set @DRAMOUNT=0      
  set @CRAMOUNT=@cheqAmt      
  if(@CRAMOUNT>0)      
                     
   EXEC co_acc_voucherDetail_Insert @TRANID, @ACCOUNTCODE, @DRAMOUNT, @CRAMOUNT,@ENTRYNO, @cheqNo, @DESCRIPTION,                                             
    @ISSUEDTO, @RELATEDTO, @CHQDATE,@BILLNO,@PANNO ,1     
  end        
            
        
 end                                        
                         
END    
    GO
	DROP function [dbo].[FxGetMaxVoucherNo] 
GO
CREATE function [dbo].[FxGetMaxVoucherNo] 
(       
@Branchid int,      
@FiscalID int,      
@SubBranchID int,       
@vouchertype int,       
@TRANSACTIONTYPEID varchar(3)       
)       
returns varchar(200) 
as       
begin      
	declare @VOUCHERNO varchar(200),@FVOUCHERNO varchar(200),@ISINDIVIDUAL TINYINT,@COMPANYID INT       
	set @VOUCHERNO = ( dbo.FormatCode((select CONVERT(varchar(50), isnull(MAX(VOUCHERNO),0)+1) as VOUCHERNO from AC_TRANSACTION_MASTER          
						where BRANCHID=@Branchid and VOUCHERTYPEID=@vouchertype and FISCALID=@FiscalID  ),6) ) 
				                   
	select @FVOUCHERNO =  cast(@vouchertype as varchar)   + '/' + 
							(select ALIAS from FISCALYEAR where ID = @FiscalID)    
							+ '/' +   @VOUCHERNO  + ':' + @VOUCHERNO  
					
	return @FVOUCHERNO 
END
GO
  
      DROP PROC [co_disbursementinsertUpdate]
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
			delete from  TBLDISBURSEMENTDETAILS where payid=@PAYID                  
                    
			Insert into TBLDISBURSEMENTDETAILS (                                         
			PAYID, ACCOUNTDESC, ACCOUNTCODE,  DRAMOUNT,  CRAMOUNT,  REMARKS)                                         
			SELECT                                        
			@id, ACCOUNTDESC,ACCOUNTCODE,                                         
			DRAMOUNT,  CRAMOUNT,REMARKS  FROM  @DISBURSEMENT                  
                     
         
			exec CO_ACC_DISBURSEMENT_VOUCHER_PICL @id  
      
    begin --for user activity log                                             
  declare @nbranchid int=@branchid,                                              
  @nuserid int=@uuid,                                              
  @ntaskname varchar(200)='Account-Disbursement Entry',                                              
  @ntaskdescription varchar(200)='Disbursement Entry where voucher no is :'+cast(isnull(@FDISBURSEMENTNO,'') as varchar),                                            
  @nactivity varchar(200)=@msg,  
  @nprimarykey int =@id_new                                           
        
  exec user_log_activity @nbranchid,@nuserid,@ntaskname,@ntaskdescription,@nactivity,@nprimarykey  
  end                                          
                                
              
         GO
 drop view     [vw_acc_transactions]
 go     
create VIEW [dbo].[vw_acc_transactions]          
AS          
SELECT     a.MASTERID, a.FISCALID, d.FISCALYEAR, d.ENGFISCALYEAR, a.BRANCHID, c.ENAME AS branchnameeng, a.NARRATION AS PrintingNarration, a.VOUCHERNO,a.fvoucherno ,           
                      a.VOUCHERTYPEID, b.ETITLE AS vouchertype, b.EABBRV AS vtypeAbbr, a.trans_date,a.trans_miti as NepaliDate, isnull(a.approved,0) approved, a.docid, a.claimid, a.receiptno, a.auid, g.USERNAME,           
                      a.adt, a.uuid, a.udt, cat.GLCODE, e.SLCODE, dtl.ACCOUNTCODE, e.ACCOUNTDESC, e.CATID, f.REFID, f.L1, f.L2, f.L3, f.L4, f.L5, f.LEVELNO, f.LEVEL1, f.LEVEL2, f.LEVEL3, f.LEVEL4, f.LEVEL5,           
                    dtl.DRAMOUNT, dtl.CRAMOUNT, dtl.CHQNO, dtl.ISSUEDTO, dtl.DESCRIPTION AS Narration, isnull(coalesce(tt.ifprevbalance, b.ifprevbalance),0) AS ifPrevBalance,           
                      dtl.IFPREVBALANCE AS PrevBlnce, h.LIMIT_AMOUNT, dtl.BILLNO, dtl.PANNO, a.TRANSACTIONTYPEID,a.trans_miti,i.ENAME as SubBranchNameEng,a.SUBBRANCHID, dtl.ENTRYNO       
                      , a.AMTINWORDS,i.ADDRESS as SubBranchAddEng,isnull(dtl.VTYPE,0) as VisibleType,a.PayID,a.depositid,a.PURCHASEID,  tt.TRANSACTIONNAME,   
       isnull(cat.showonVPrint,0) showonVPrint, isnull(a.declarationid,0) declarationid      
FROM         dbo.AC_TRANSACTION_MASTER AS a inner JOIN          
                      dbo.AC_TRANSACTION_DETAILS AS dtl ON a.MASTERID = dtl.TRANID left JOIN          
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
    go

	

drop proc [acc_rpt_ledger]
go

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_SECURITY_BRANCH]    Script Date: 09/03/2019 07:26:37 ******/
DROP TYPE [dbo].[TBLTYPE_SECURITY_BRANCH]
GO

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_SECURITY_BRANCH]    Script Date: 09/03/2019 07:26:37 ******/
CREATE TYPE [dbo].[TBLTYPE_SECURITY_BRANCH] AS TABLE(
	[BRANCHID] [int] NULL
)
GO



/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_SECURITY_SUBBRANCH]    Script Date: 09/03/2019 07:26:46 ******/
DROP TYPE [dbo].[TBLTYPE_SECURITY_SUBBRANCH]
GO

/****** Object:  UserDefinedTableType [dbo].[TBLTYPE_SECURITY_SUBBRANCH]    Script Date: 09/03/2019 07:26:46 ******/
CREATE TYPE [dbo].[TBLTYPE_SECURITY_SUBBRANCH] AS TABLE(
	[SUBBRANCHID] [int] NULL
)
GO




CREATE proc [dbo].[acc_rpt_ledger] (                                          
@FiscalID  int,                                          
@branchid  int = null,                                           
@vouchertypeid int = null,                                          
@datefrom  date,                                          
@dateto   date,                                          
@accountcode int,                                          
@IncludeBF  int = 0,                                        
 @SUBBRANCHID  int = null,                                      
 @APPROVED INT = 1,                          
 @Security_Branch TBLTYPE_SECURITY_BRANCH readonly,                                
 @Security_subBranch TBLTYPE_SECURITY_SUBBRANCH readonly,                            
 @Sec_userid int=null ,                  
  @pg int,                                
 @pgSize int,                
 @ISEXPORT int                                          
)                                         
as                  
--declare @FiscalID  int=22,                                          
--@branchid  int = 38,                                           
--@vouchertypeid int =0,                                          
--@datefrom  date = '17-jul-2018',                                          
--@dateto   date = '17-jul-2019',                                          
--@accountcode int = 1,                                          
--@IncludeBF  int = 0,                                        
-- @SUBBRANCHID  int = null,                                      
-- @APPROVED INT = 0,                          
-- @Security_Branch TBLTYPE_SECURITY_BRANCH ,                                
-- @Security_subBranch TBLTYPE_SECURITY_SUBBRANCH ,                            
-- @Sec_userid int=null ,                  
--  @pg int = 1,                                
-- @pgSize int = 100000                  
                     
begin                                 
 create table #tempbranchid(                            
branchid int                            
)                            
create table #tempsubbranchid(                            
SubBranchId int                            
)                  
create table #temp                  
(                  
id int identity(1,1),                  
masterid int ,                  
fiscalid int,                  
FISCALYEAR varchar(20),                  
branchid int,                  
branchnameeng varchar(50),                  
vouchertypeid int,                  
voucherno int,                  
vtypeabbr varchar(20),                  
accountcode int,                  
narration varchar(4000),                  
dramount numeric(16,2),                  
cramount numeric(16,2),                  
approved int,                  
trans_date date,                  
trans_miti varchar(20),                  
chqno varchar(50),                  
issuedto varchar(255),                  
PanNo varchar(40),                  
BillNo varchar(40),                
CummulativeTot numeric(16,2)                  
)                                          
declare @FYStartDt date , @SQL NVARCHAR(MAX)                            
declare @applynewsec int                            
select  @applynewsec=applyNewSecurity from tbluser where id= @Sec_userid                               
 insert into #tempbranchid( BranchId)                                
 select  Branchid from @Security_Branch                                  
                              
 insert into #tempsubbranchid( SubBranchId)                                
 select  SUBBRANCHID from @Security_subBranch                    
                  
 SET @SQL = N'insert into #temp (masterid,fiscalid,FISCALYEAR,branchid,branchnameeng,vouchertypeid,                  
   voucherno,vtypeabbr,accountcode,narration,dramount,cramount,approved,trans_date,                  
   trans_miti,chqno,issuedto,PanNo,BillNo)'                  
                           
                                        
if (@IncludeBF = 1)                                        
 begin                                          
  -- get fiscal start date                                          
  select @FYStartDt = (select engstartdate from FISCALYEAR where ID = @FiscalID)                                          
  if (@FYStartDt=@datefrom)-- it means starting date                                          
  begin                                          
   SET @SQL = @SQL+'select aa.masterid, aa.fiscalid, aa.FISCALYEAR, aa.branchid, aa.branchnameeng, convert(int,aa.vouchertypeid) vouchertypeid,                                       
     aa.voucherno, aa.vtypeabbr, aa.accountcode, left(aa.narration,4000), aa.dramount, aa.cramount, convert(int,aa.approved) approved, aa.trans_date,                                       
     aa.trans_miti, aa.chqno, aa.issuedto, aa.PanNo, aa.BillNo from vw_acc_transactions aa                                          
     where aa.accountcode = ' + CONVERT(VARCHAR, @accountcode)                            
    if(@applynewsec=0)                           
    begin                 
    IF (ISNULL(@branchid,0)> 0) SET @SQL = @SQL + ' and aa.branchid = ' + CONVERT(VARCHAR,@branchid)                                      
   IF (ISNULL(@SUBBRANCHID,0)> 0) SET @SQL = @SQL + ' and aa.SUBBRANCHID = ' + CONVERT(VARCHAR,@SUBBRANCHID)                           
    end                          
                              
    else                          
    begin                          
    set @SQL = @SQL + ' and aa.branchid in (select branchid from #tempbranchid)'                                 
  --set @SQL = @SQL + ' and aa.SUBBRANCHID in (select SubBranchId from  #tempsubbranchid)'                             
    end                                     
                              
                                       
   IF (ISNULL(@vouchertypeid,0)> 0) SET @SQL = @SQL + ' and aa.vouchertypeid = ' + CONVERT(VARCHAR,@vouchertypeid)                                      
   SET @SQL = @SQL + ' and aa.trans_date between ''' + REPLACE(CONVERT(VARCHAR,@datefrom,106),' ','-') + ''''                                      
   SET @SQL = @SQL + ' and ''' + REPLACE(CONVERT(VARCHAR,@dateto,106),' ','-') + ''''                                      
   IF (ISNULL(@APPROVED,0)< 2) SET @SQL = @SQL + ' and aa.approved = ' + CONVERT(VARCHAR,@APPROVED)                                      
   SET @SQL = @SQL + ' order by aa.trans_date, aa.masterid '                  
   --delete from aaaa                                   
   --insert into aaaa values( @sql  )                                          
   EXECUTE sp_executesql @Sql                                      
   --PRINT @Sql                                      
  end                                          
  else                                          
  begin                                          
   SET @SQL =  @SQL+'select 0 as masterid,' + CONVERT(VARCHAR,@FiscalID) + ', '' '' as fiscalyear, ' + CONVERT(VARCHAR,@branchid) + ','                                      
   SET @SQL = @SQL + ''' '' as branchnameeng, -1 as vouchertypeid, 0 as voucherno, '' '' as vtypeabbr,'                                      
   SET @SQL = @SQL + ' -1 as accountcode, ''Previous Balance b/d'' as narration, sum(isnull(aa.dramount,0)) DrAmount,'                                           
   SET @SQL = @SQL + ' sum(isnull(aa.cramount,0)) as Cramount, 1 as approved, '                                      
   SET @SQL = @SQL + '''' + REPLACE(CONVERT(VARCHAR,DATEADD(DAY,-1,@datefrom),106),' ','-') + ''' as trans_date, ''-1'' as trans_miti,                                          
   '' '' as chqno, '' '' as issuedto, 0 PanNo, '''' BillNo from vw_acc_transactions aa                                          
   where aa.accountcode = ' + CONVERT(VARCHAR,@accountcode)                            
   if(@applynewsec=0)                           
   begin                          
   IF (ISNULL(@branchid,0)> 0) SET @SQL = @SQL + ' and aa.branchid = ' + CONVERT(VARCHAR,@branchid)                                      
   IF (ISNULL(@SUBBRANCHID,0)> 0) SET @SQL = @SQL + ' and aa.SUBBRANCHID = ' + CONVERT(VARCHAR,@SUBBRANCHID)                            
   end                          
   else                
   begin                          
    set @SQL = @SQL + ' and aa.branchid in (select branchid from #tempbranchid)'                                 
  --set @SQL = @SQL + ' and aa.SUBBRANCHID in (select SubBranchId from  #tempsubbranchid)'           
   end                                    
                                 
                                   
   IF (ISNULL(@vouchertypeid,0)> 0) SET @SQL = @SQL + ' and aa.vouchertypeid = ' + CONVERT(VARCHAR,@vouchertypeid)                                      
   SET @SQL = @SQL + ' and aa.trans_date between ''' + REPLACE(CONVERT(VARCHAR,@FYStartDt,106),' ','-') + ''''                                      
   SET @SQL = @SQL + ' and ''' + REPLACE(CONVERT(VARCHAR,DATEADD(DAY,-1,@datefrom),106),' ','-') + ''''                                 IF (ISNULL(@APPROVED,0)< 2) SET @SQL = @SQL + ' and aa.approved = ' + CONVERT(VARCHAR,@APPROVED)                      
  
    
      
       
        
                    
   SET @SQL = @SQL + ' union all   '                                           
   SET @SQL = @SQL + ' select aa.masterid, aa.fiscalid, aa.FISCALYEAR, aa.branchid, aa.branchnameeng, convert(int, aa.vouchertypeid) vouchertypeid, aa.voucherno, aa.vtypeabbr,                                           
   aa.accountcode, aa.narration, aa.dramount, aa.cramount, convert(int,aa.approved) approved, aa.trans_date, aa.trans_miti,                           
   aa.chqno, aa.issuedto, aa.PanNo, aa.BillNo from vw_acc_transactions aa                                          
   where aa.accountcode = ' + CONVERT(VARCHAR,@accountcode)                                      
   if(@applynewsec=0)                           
   begin                          
   IF (ISNULL(@branchid,0)> 0) SET @SQL = @SQL + ' and aa.branchid = ' + CONVERT(VARCHAR,@branchid)                                      
   IF (ISNULL(@SUBBRANCHID,0)> 0) SET @SQL = @SQL + ' and aa.SUBBRANCHID = ' + CONVERT(VARCHAR,@SUBBRANCHID)                            
   end                          
   else                          
   begin                          
    set @SQL = @SQL + ' and aa.branchid in (select branchid from #tempbranchid)'                                 
  --set @SQL = @SQL + ' and aa.SUBBRANCHID in (select SubBranchId from  #tempsubbranchid)'                             
   end                                              
   IF (ISNULL(@vouchertypeid,0)> 0) SET @SQL = @SQL + ' and aa.vouchertypeid = ' + CONVERT(VARCHAR,@vouchertypeid)                                      
   SET @SQL = @SQL + ' and aa.trans_date between ''' + REPLACE(CONVERT(VARCHAR,@datefrom,106),' ','-') + ''''                                      
   SET @SQL = @SQL + ' and ''' + REPLACE(CONVERT(VARCHAR,@dateto,106),' ','-') + ''''                                      
   IF (ISNULL(@APPROVED,0)< 2) SET @SQL = @SQL + ' and aa.approved = ' + CONVERT(VARCHAR,@APPROVED)                                           
   SET @SQL = @SQL + ' order by trans_date, masterid '                   
   --delete from aaaa                                   
   --insert into aaaa values( @sql  )                                  
   EXECUTE sp_executesql @Sql                                      
   --PRINT @Sql                                      
  end                                            
 end                                          
else                                          
 begin                                          
  SET @SQL =  @SQL+'select aa.masterid, aa.fiscalid, aa.FISCALYEAR, aa.branchid, aa.branchnameeng, convert(int, aa.vouchertypeid) vouchertypeid, aa.voucherno, aa.vtypeabbr,                                           
  aa.accountcode, aa.narration, aa.dramount, aa.cramount, convert(int,aa.approved) approved, aa.trans_date, aa.trans_miti,                                          
  aa.chqno, aa.issuedto, aa.PanNo, aa.BillNo from vw_acc_transactions aa                    
  where aa.accountcode = ' + CONVERT(VARCHAR,@accountcode)                                      
  --IF (ISNULL(@branchid,0)> 0) SET @SQL = @SQL + ' and aa.branchid = ' + CONVERT(VARCHAR,@branchid)                                      
  --IF (ISNULL(@SUBBRANCHID,0)> 0 and ISNULL(@branchid,0)> 0) SET @SQL = @SQL + ' and aa.SUBBRANCHID = ' + CONVERT(VARCHAR,@SUBBRANCHID)                  
                             
   if(@applynewsec=0)                           
   begin                          
   IF (ISNULL(@branchid,0)> 0) SET @SQL = @SQL + ' and aa.branchid = ' + CONVERT(VARCHAR,@branchid)                                      
   IF (ISNULL(@SUBBRANCHID,0)> 0 and ISNULL(@branchid,0)> 0) SET @SQL = @SQL + ' and aa.SUBBRANCHID = ' + CONVERT(VARCHAR,@SUBBRANCHID)                          
   end                          
   else                          
   begin                          
    set @SQL = @SQL + ' and aa.branchid in (select branchid from #tempbranchid)'                                 
  --set @SQL = @SQL + ' and aa.SUBBRANCHID in (select SubBranchId from  #tempsubbranchid)'                             
  end                              
  IF (ISNULL(@vouchertypeid,0)> 0) SET @SQL = @SQL + ' and aa.vouchertypeid = ' + CONVERT(VARCHAR,@vouchertypeid)                               
  SET @SQL = @SQL + ' and aa.trans_date between ''' + REPLACE(CONVERT(VARCHAR,@datefrom,106),' ','-') + ''''                                      
  SET @SQL = @SQL + ' and ''' + REPLACE(CONVERT(VARCHAR,@dateto,106),' ','-') + ''''                                      
  IF (ISNULL(@APPROVED,0)< 2) SET @SQL = @SQL + ' and aa.approved = ' + CONVERT(VARCHAR,@APPROVED)                                          
  SET @SQL = @SQL + ' and aa.ifprevbalance = 0  '                                        
  SET @SQL = @SQL + ' order by aa.trans_date, aa.masterid '                  
  --delete from aaaa                                   
  -- insert into aaaa values( @sql  )                                         
  EXECUTE sp_executesql @Sql                        
  --drop table #tempbranchid                  
  --drop table #tempsubbranchid                      
  --select * from #temp                  
  --drop table #temp                              
  --PRINT @Sql                                        
 end                  
  declare @frompg int                                
declare @topg int                                
set @topg=@pg * @pgSize                                
Set @frompg= @pg * @pgSize-@pgsize                    
                  
  drop table #tempbranchid                    
  drop table #tempsubbranchid                   
                 
if isnull(@ISEXPORT,0)=0  --display data in grid                
  select *, case when CummTotal < 0 then 'CR' else 'DR' end DRCR from (                   
   select aa.masterid, aa.fiscalid, aa.FISCALYEAR, aa.branchid, aa.branchnameeng, convert(int, aa.vouchertypeid) vouchertypeid, aa.voucherno, aa.vtypeabbr,                                           
   aa.accountcode, aa.narration, aa.dramount, aa.cramount, convert(int,aa.approved) approved, aa.trans_date, aa.trans_miti,                                          
   aa.chqno, aa.issuedto, aa.PanNo, aa.BillNo,                
   (select sum(dramount - cramount ) from #temp bb where bb.id <= aa.id ) as CummTotal, aa.id from #temp aa where id>@frompg and id<=@topg                 
  ) as tt order by tt.id                
else if  isnull(@ISEXPORT,0)=1   -- export                   
 select replace(convert(NVARCHAR, tt.Trans_date, 106), ' ', '-')Trans_date, tt.trans_miti, tt.vtypeabbr VoucherType,          
  tt.vtypeabbr + ' ' + CONVERT(varchar,tt.voucherno) voucherno ,          
 tt.narration, tt.dramount , tt.cramount, tt.CummTotal [Balance (Rs.)], case when tt.CummTotal < 0 then 'CR' else 'DR' end [DR/CR], tt.BranchNameEng           
 , tt.PanNo [PAN No.], tt.BillNo [Bill No.], tt.ChqNo [Cheque No.],tt.issuedto PayTo--, tt.branchnameeng             
 from (                   
   select aa.masterid, aa.fiscalid, aa.FISCALYEAR, aa.branchid, aa.branchnameeng, convert(int, aa.vouchertypeid) vouchertypeid, aa.voucherno, aa.vtypeabbr,                                           
   aa.accountcode, aa.narration, aa.dramount, aa.cramount, convert(int,aa.approved) approved, aa.trans_date, aa.trans_miti,                                          
   aa.chqno, aa.issuedto, aa.PanNo, aa.BillNo,                
   (select sum(dramount - cramount ) from #temp bb where bb.id <= aa.id ) as CummTotal, aa.id from #temp aa --where id>@frompg and id<=@topg                 
  ) as tt order by tt.id           
 else -- print          
  select replace(convert(NVARCHAR, tt.Trans_date, 106), ' ', '-')Trans_date, tt.trans_miti, tt.vtypeabbr ,          
  tt.voucherno,             
 tt.narration, tt.dramount , tt.cramount, tt.CummTotal [Balance (Rs.)], case when tt.CummTotal < 0 then 'CR' else 'DR' end [DR/CR], tt.BranchNameEng           
 --, tt.PanNo [PAN No.], tt.BillNo [Bill No.], tt.ChqNo [Cheque No.], tt.branchnameeng             
 from (                   
   select aa.masterid, aa.fiscalid, aa.FISCALYEAR, aa.branchid, aa.branchnameeng, convert(int, aa.vouchertypeid) vouchertypeid, aa.voucherno, aa.vtypeabbr,                                           
   aa.accountcode, aa.narration, aa.dramount, aa.cramount, convert(int,aa.approved) approved, aa.trans_date, aa.trans_miti,                                          
   aa.chqno, aa.issuedto, aa.PanNo, aa.BillNo,                
   (select sum(dramount - cramount ) from #temp bb where bb.id <= aa.id ) as CummTotal, aa.id from #temp aa --where id>@frompg and id<=@topg                 
  ) as tt order by tt.id                  
            Select count(*) Cnt, sum(dramount) DrAmt, sum(CrAmount) CrAmt,                 
  case when sum(dramount - cramount) >=0 then sum(dramount-cramount) else sum(cramount-dramount) end as CummTotal,                
  case when sum(dramount - cramount) >=0 then 'DR' else 'CR' end as DRCR                
  , case when @topg < count(*) then 0 else 1 end LastPage from #temp                
                      
  drop table #temp                        
 end 
 go

 drop proc [company_FiscalYr_get]
 go
     
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
go

drop proc acc_catagory_list_Trialblc
go

CREATE PROCEDURE acc_catagory_list_Trialblc  
(  
 @CATID int=null  
)  
as  
begin  
select * from TBACCCATEGORY where CATID=@CATID  
end
go

drop proc [acc_rpt_trialBalance]
go
CREATE proc [dbo].[acc_rpt_trialBalance] (                      
@FiscalID  int,                      
@branchid  int = null,                       
@vouchertypeid int = null,                      
@datefrom  date,                      
@dateto   date,                      
@IncludeBF  int = 0,                      
@IsOpeningOnly int = 0,                      
@level1   int = null,                      
@level2   int = null,                      
@level3   int = null,                      
@level4   int = null,                      
@level5   int = null,                  
 @SUBBRANCHID  int = null,              
 @APPROVED INT = NULL,      
 @Security_Branch TBLTYPE_SECURITY_BRANCH readonly,              
 @Security_subBranch TBLTYPE_SECURITY_SUBBRANCH readonly,          
 @Sec_userid int=null,      
 @TransactionTypeID int = null                         
 ) as              
            
create table #trialbalance            
(            
accountcode int,      
glcode varchar(100),          
DrAmount numeric(16,2),            
Cramount numeric(16,2),            
DrBalance numeric(16,2),            
CrBalance numeric(16,2),            
BalanceAmt numeric(16,2),            
accountDesc nvarchar(500),            
l1   nvarchar(500),            
l2   nvarchar(500),            
l3   nvarchar(500),            
l4   nvarchar(500),            
l5   nvarchar(500),            
level1   int,            
level2   int,            
level3   int,            
level4   int,            
level5   int            
)            
            
   create table #tempbranchid(          
branchid int          
)          
create table #tempsubbranchid(          
SubBranchId int          
)        
                    
declare @FYStartDt date                 
declare @SQL nvarchar(max)         
declare @applynewsec int        , @CompanyId int  
select  @applynewsec=applyNewSecurity from tbluser where id= @Sec_userid             
select @CompanyId = id from CompanyProfile  
  
 insert into #tempbranchid( BranchId)              
 select  Branchid from @Security_Branch                
            
 insert into #tempsubbranchid( SubBranchId)              
 select  SUBBRANCHID from @Security_subBranch          
      
                  
if (@IncludeBF = 1)                       
  begin                      
    select @FYStartDt = (select engstartdate from FISCALYEAR where ID = @FiscalID)                     
                          
    set @SQL = N'Insert into #trialbalance(accountcode,glcode,DrAmount,Cramount,DrBalance,CrBalance,BalanceAmt,accountDesc            
    ,l1,l2,l3,l4,l5,level1,level2,level3,level4,level5)                
    select aa.accountcode,aa.glcode, sum(isnull(aa.dramount,0)) as DrAmount, sum(isnull(aa.cramount,0)) as Cramount,                       
    case when (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) >= 0 then (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) else 0 end as DrBalance,                      
    case when (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) < 0 then (sum(isnull(aa.CRAMOUNT,0))- sum(isnull(aa.DRAMOUNT,0))) else 0 end as CrBalance,                      
    (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) as BalanceAmt,                      
    aa.accountdesc, isnull(L1,'' '') L1, isnull(L2,'' '') L2, isnull(L3,'' '') L3,isnull(L4,'' '') L4, isnull(L5,'' '') L5,                      
    isnull(level1,0) level1, isnull(level2,0) level2, isnull(level3,0) level3, isnull(level4,0) level4, isnull(level5,0) level5 from vw_acc_transactions aa                      
    where 1 = 1 '              
    IF ISNULL(@APPROVED,1) < 2 set @SQL = @SQL + ' and aa.approved = ' + convert(varchar,@APPROVED)        
     if(@applynewsec=0)         
     begin      
      if ISNULL(@branchid,0)>0 set @SQL = @SQL + ' and aa.branchid = ' + convert(varchar,@branchid)                
    if ISNULL(@SUBBRANCHID,0)>0 set @SQL = @SQL + ' and aa.SUBBRANCHID = ' + convert(varchar,@SUBBRANCHID)       
     end      
     else      
     begin      
      set @SQL = @SQL + ' and aa.branchid in (select branchid from #tempbranchid)'               
  set @SQL = @SQL + ' and aa.SUBBRANCHID in (select SubBranchId from  #tempsubbranchid)'           
     end               
           
                 
    if ISNULL(@vouchertypeid,0)>0 set @SQL = @SQL + ' and aa.vouchertypeid = ' + convert(varchar,@vouchertypeid)                
 if ISNULL(@TransactionTypeID,0)>0 set @SQL = @SQL + ' and aa.transactiontypeid = ' + convert(varchar,@TransactionTypeID)                
    set @SQL = @SQL + ' and aa.trans_date between ''' + replace(convert(varchar,@FYStartDt,106),' ','-') + '''' + ' and ''' + replace(convert(varchar,@dateto,106),' ','-') + ''''                
    set @SQL = @SQL + ' and (case when ' + convert(varchar,@IsOpeningOnly) + ' = 1 then aa.ifprevbalance else 1 end) = 1 '                
    if ISNULL(@level1,0)>0 set @SQL = @SQL + ' and aa.level1 = ' + convert(varchar,@level1)                
    if ISNULL(@level2,0)>0 set @SQL = @SQL + ' and aa.level2 = ' + convert(varchar,@level2)                
    if ISNULL(@level3,0)>0 set @SQL = @SQL + ' and aa.level3 = ' + convert(varchar,@level3)                
    if ISNULL(@level4,0)>0 set @SQL = @SQL + ' and aa.level4 = ' + convert(varchar,@level4)                
 if ISNULL(@level5,0)>0 set @SQL = @SQL + ' and aa.level5 = ' + convert(varchar,@level5)                
    set @SQL = @SQL + ' group by aa.accountcode,aa.glcode, aa.accountdesc, L1, L2, L3,L4, L5, level1, level2, level3, level4, level5'  
   
 if @CompanyId = 1  
  set @SQL = @SQL + ' order by aa.glcode ,isnull(level1,0), isnull(level2,0), isnull(level3,0), isnull(level4,0), isnull(level5,0), accountdesc '                   
 else  
  set @SQL = @SQL + ' order by isnull(level1,0), isnull(level2,0), isnull(level3,0), isnull(level4,0), isnull(level5,0), accountdesc '  
    EXECUTE sp_executesql @SQL                    
  end                      
else                      
 begin                      
   if (@IsOpeningOnly=1)                      
     begin                      
  set @SQL = N'Insert into #trialbalance(accountcode,glcode,DrAmount,Cramount,DrBalance,CrBalance,BalanceAmt,accountDesc            
    ,l1,l2,l3,l4,l5,level1,level2,level3,level4,level5)                
    select aa.accountcode,aa.glcode, sum(isnull(aa.dramount,0)) as DrAmount, sum(isnull(aa.cramount,0)) as Cramount,                       
  case when (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) >= 0 then (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) else 0 end as DrBalance,             
  case when (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) < 0 then (sum(isnull(aa.CRAMOUNT,0))- sum(isnull(aa.DRAMOUNT,0))) else 0 end as CrBalance,                      
  (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) as BalanceAmt,                      
  aa.accountdesc, isnull(L1,'' '') L1, isnull(L2,'' '') L2, isnull(L3,'' '') L3,isnull(L4,'' '') L4, isnull(L5,'' '') L5,                      
  isnull(level1,0) level1, isnull(level2,0) level2, isnull(level3,0) level3, isnull(level4,0) level4, isnull(level5,0) level5 from vw_acc_transactions aa                      
  where 1 = 1 '                
  IF ISNULL(@APPROVED,1) < 2 set @SQL = @SQL + ' and aa.approved = ' + convert(varchar,@APPROVED)        
   if(@applynewsec=0)        
   begin      
   if ISNULL(@branchid,0)>0 set @SQL = @SQL + ' and aa.branchid = ' + convert(varchar,@branchid)                
  if ISNULL(@SUBBRANCHID,0)>0 set @SQL = @SQL + ' and aa.SUBBRANCHID = ' + convert(varchar,@SUBBRANCHID)      
   end      
   else      
   begin      
   set @SQL = @SQL + ' and aa.branchid in (select branchid from #tempbranchid)'               
  set @SQL = @SQL + ' and aa.SUBBRANCHID in (select SubBranchId from  #tempsubbranchid)'          
   end            
                
          
  if ISNULL(@vouchertypeid,0)>0 set @SQL = @SQL + ' and aa.vouchertypeid = ' + convert(varchar,@vouchertypeid)         
  if ISNULL(@TransactionTypeID,0)>0 set @SQL = @SQL + ' and aa.transactiontypeid = ' + convert(varchar,@TransactionTypeID)                  
  if ISNULL(@level1,0)>0 set @SQL = @SQL + ' and aa.level1 = ' + convert(varchar,@level1)                
  if ISNULL(@level2,0)>0 set @SQL = @SQL + ' and aa.level2 = ' + convert(varchar,@level2)                
  if ISNULL(@level3,0)>0 set @SQL = @SQL + ' and aa.level3 = ' + convert(varchar,@level3)                
  if ISNULL(@level4,0)>0 set @SQL = @SQL + ' and aa.level4 = ' + convert(varchar,@level4)                
  if ISNULL(@level5,0)>0 set @SQL = @SQL + ' and aa.level5 = ' + convert(varchar,@level5)                
  set @SQL = @SQL + ' and aa.fiscalid = ' + convert(varchar,@FiscalID)                
  set @SQL = @SQL + ' and aa.ifprevbalance = 1 '           
  set @SQL = @SQL + ' group by aa.accountcode,aa.glcode, aa.accountdesc, L1, L2, L3,L4, L5, level1, level2, level3, level4, level5'  
   
 if @CompanyId = 1  
  set @SQL = @SQL + ' order by aa.glcode ,isnull(level1,0), isnull(level2,0), isnull(level3,0), isnull(level4,0), isnull(level5,0), accountdesc '                   
 else  
  set @SQL = @SQL + ' order by isnull(level1,0), isnull(level2,0), isnull(level3,0), isnull(level4,0), isnull(level5,0), accountdesc '                   
  EXECUTE sp_executesql @SQL                  
     end                      
   else                      
     begin                      
  set @SQL = N'Insert into #trialbalance(accountcode,glcode,DrAmount,Cramount,DrBalance,CrBalance,BalanceAmt,accountDesc            
    ,l1,l2,l3,l4,l5,level1,level2,level3,level4,level5)                
    select aa.accountcode,aa.glcode,                       
  sum(isnull(aa.dramount,0)) as DrAmount, sum(isnull(aa.cramount,0)) as Cramount,                       
  case when (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) >= 0 then (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) else 0 end as DrBalance,                      
  case when (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) < 0 then (sum(isnull(aa.CRAMOUNT,0))- sum(isnull(aa.DRAMOUNT,0))) else 0 end as CrBalance,                      
  (sum(isnull(aa.dramount,0))- sum(isnull(aa.cramount,0))) as BalanceAmt,                      
  aa.accountdesc , isnull(L1,'' '') L1, isnull(L2,'' '') L2, isnull(L3,'' '') L3,isnull(L4,'' '') L4, isnull(L5,'' '') L5,                       
  isnull(level1,0) level1, isnull(level2,0) level2, isnull(level3,0) level3, isnull(level4,0) level4, isnull(level5,0) level5 from vw_acc_transactions aa                      
  where 1 = 1 '                
  IF ISNULL(@APPROVED,1) < 2 set @SQL = @SQL + ' and aa.approved = ' + convert(varchar,@APPROVED)           
    if(@applynewsec=0)        
    begin      
    if ISNULL(@branchid,0)>0 set @SQL = @SQL + ' and aa.branchid = ' + convert(varchar,@branchid)        
  if ISNULL(@SUBBRANCHID,0)>0 set @SQL = @SQL + ' and aa.SUBBRANCHID = ' + convert(varchar,@SUBBRANCHID)        
    end      
    else      
    begin      
     set @SQL = @SQL + ' and aa.branchid in (select branchid from #tempbranchid)'               
  set @SQL = @SQL + ' and aa.SUBBRANCHID in (select SubBranchId from  #tempsubbranchid)'          
    end        
           
        
             
  if ISNULL(@vouchertypeid,0)>0 set @SQL = @SQL + ' and aa.vouchertypeid = ' + convert(varchar,@vouchertypeid)         
  if ISNULL(@TransactionTypeID,0)>0 set @SQL = @SQL + ' and aa.transactiontypeid = ' + convert(varchar,@TransactionTypeID)                  
  set @SQL = @SQL + ' and aa.trans_date between ''' + replace(convert(varchar,@datefrom,106),' ','-') + '''' + ' and ''' + replace(convert(varchar,@dateto,106),' ','-') + ''''                
  if ISNULL(@level1,0)>0 set @SQL = @SQL + ' and aa.level1 = ' + convert(varchar,@level1)                
  if ISNULL(@level2,0)>0 set @SQL = @SQL + ' and aa.level2 = ' + convert(varchar,@level2)                
  if ISNULL(@level3,0)>0 set @SQL = @SQL + ' and aa.level3 = ' + convert(varchar,@level3)                
  if ISNULL(@level4,0)>0 set @SQL = @SQL + ' and aa.level4 = ' + convert(varchar,@level4)                
  if ISNULL(@level5,0)>0 set @SQL = @SQL + ' and aa.level5 = ' + convert(varchar,@level5)                
  set @SQL = @SQL + ' and aa.ifprevbalance = 0 '                     
  set @SQL = @SQL + ' group by aa.accountcode,aa.glcode, aa.accountdesc, L1, L2, L3,L4, L5, level1, level2, level3, level4, level5'  
   
 if @CompanyId = 1  
  set @SQL = @SQL + ' order by aa.glcode ,isnull(level1,0), isnull(level2,0), isnull(level3,0), isnull(level4,0), isnull(level5,0), accountdesc '                   
 else  
  set @SQL = @SQL + ' order by isnull(level1,0), isnull(level2,0), isnull(level3,0), isnull(level4,0), isnull(level5,0), accountdesc '                   
              
  EXECUTE sp_executesql @Sql                  
     end                      
 end             
 select * from #trialbalance            
             
 drop table #trialbalance       

 go
    
