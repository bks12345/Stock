
drop table [MSDEPARTMENT]
go

CREATE TABLE [dbo].[MSDEPARTMENT](
	[ID] [int] NOT NULL,
	[DEPTCODE] [varchar](2) NULL,
	[DEPTNAME] [varchar](50) NULL,
	[NDEPTNAME] [nvarchar](60) NULL,
	[CODE] [varchar](5) NULL,
	[NCODE] [nvarchar](25) NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[islock] [int] NULL,
	[NoLinkDeclarationNClaim] [int] NULL,
 CONSTRAINT [PK_MSDEPARTMENT] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_dept_code] UNIQUE NONCLUSTERED 
(
	[DEPTCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_dept_name] UNIQUE NONCLUSTERED 
(
	[DEPTNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
go

drop table [TBACCOUNTTYPE]
go

CREATE TABLE [dbo].[TBACCOUNTTYPE](
	[ACCTYPEID] [int] IDENTITY(1,1) NOT NULL,
	[ACCOUNTTYPE] [varchar](3) NOT NULL,
	[DESCRIPTION] [nvarchar](60) NULL,
	[islock] [int] NULL,
	[UUID] [int] NULL,
	[AUID] [int] NULL,
	[UDT] [datetime] NULL,
	[ADT] [datetime] NULL,
 CONSTRAINT [PK_TBACCOUNTTYPE] PRIMARY KEY CLUSTERED 
(
	[ACCTYPEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_TBACCTYPE_ACCTYPE] UNIQUE NONCLUSTERED 
(
	[ACCOUNTTYPE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_TBACCTYPE_DESC] UNIQUE NONCLUSTERED 
(
	[ACCTYPEID] ASC,
	[DESCRIPTION] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


drop table [TBACCTRANSACTIONTYPE]
go
CREATE TABLE [dbo].[TBACCTRANSACTIONTYPE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[VOUCHERTYPEID] [int] NULL,
	[TRANSACTIONNAME] [varchar](100) NULL,
	[ABBR] [varchar](50) NULL,
	[CODE] [varchar](50) NULL,
	[NTRANSACTIONNAME] [varchar](100) NULL,
	[isFacultative] [int] NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[ifPrevBalance] [int] NULL,
 CONSTRAINT [PK_TBACCTRANSACTIONTYPE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_TBACCTRANSACTIONTYPE_VOUCHERTYPEID_TRANSACTIONNAME] UNIQUE NONCLUSTERED 
(
	[VOUCHERTYPEID] ASC,
	[TRANSACTIONNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

drop table [DefPageSecurity]
go


CREATE TABLE [dbo].[DefPageSecurity](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ModuleGroupId] [int] NULL,
	[ModuleNameId] [int] NULL,
	[PageId] [int] NULL,
	[SECURITYID] [int] NULL,
	[islock] [int] NULL,
	[AUID] [int] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[ADT] [datetime] NULL,
 CONSTRAINT [PK_DefPageSecurity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_pgSec_GrpId_NmId_PgId_SecId] UNIQUE NONCLUSTERED 
(
	[ModuleGroupId] ASC,
	[ModuleNameId] ASC,
	[PageId] ASC,
	[SECURITYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

drop table [TBL_MODULE_GROUP]
go

CREATE TABLE [dbo].[TBL_MODULE_GROUP](
	[MODULE_GROUP_ID] [int] IDENTITY(1,1) NOT NULL,
	[MODULE_GROUP_NAME] [varchar](50) NULL,
	[AUID] [varchar](20) NULL,
	[ADT] [datetime] NULL,
	[UUID] [varchar](20) NULL,
	[UDT] [datetime] NULL,
	[islock] [int] NULL,
 CONSTRAINT [PK_TBL_MODULE_GROUP] PRIMARY KEY CLUSTERED 
(
	[MODULE_GROUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_module_grp_name] UNIQUE NONCLUSTERED 
(
	[MODULE_GROUP_NAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
drop table [TBL_MODULELIST]
go


CREATE TABLE [dbo].[TBL_MODULELIST](
	[MODULEID] [int] IDENTITY(1,1) NOT NULL,
	[MODULENAME] [varchar](50) NULL,
	[MODULE_GROUP_ID] [int] NULL,
	[ModuleNameSno] [int] NULL,
	[AUID] [varchar](20) NULL,
	[ADT] [datetime] NULL,
	[UUID] [varchar](20) NULL,
	[UDT] [datetime] NULL,
	[islock] [int] NULL,
 CONSTRAINT [PK_TBL_MODULELIST] PRIMARY KEY CLUSTERED 
(
	[MODULEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_module_name] UNIQUE NONCLUSTERED 
(
	[MODULENAME] ASC,
	[MODULE_GROUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

drop table [TBL_SECURITYNAME]
go


CREATE TABLE [dbo].[TBL_SECURITYNAME](
	[MODULEID] [int] NOT NULL,
	[SECURITYID] [int] IDENTITY(1,1) NOT NULL,
	[SECURITYNAME] [varchar](50) NULL,
	[ISVISIBLE] [tinyint] NULL,
	[AUID] [varchar](20) NULL,
	[ADT] [datetime] NULL,
	[UUID] [varchar](20) NULL,
	[UDT] [datetime] NULL,
	[SecuritySno] [int] NULL,
	[islock] [int] NULL,
 CONSTRAINT [PK_TBL_SECURITYNAME] PRIMARY KEY CLUSTERED 
(
	[SECURITYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[TBACCCATEGORY]    Script Date: 04/03/2019 06:47:33 ******/
DROP TABLE [dbo].[TBACCCATEGORY]
GO

/****** Object:  Table [dbo].[TBACCCATEGORY]    Script Date: 04/03/2019 06:47:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBACCCATEGORY](
	[CATID] [int] IDENTITY(1,1) NOT NULL,
	[SNO] [varchar](15) NULL,
	[ECATEGORY] [varchar](125) NOT NULL,
	[NCATEGORY] [varchar](125) NULL,
	[GLCODE] [varchar](50) NULL,
	[DEPARTMENT] [varchar](5) NULL,
	[DEPTID] [int] NULL,
	[FIXEDCAT] [smallint] NULL,
	[HASCHILD] [smallint] NULL,
	[LEVEL1] [int] NULL,
	[LEVEL2] [int] NULL,
	[LEVEL3] [int] NULL,
	[LEVEL4] [int] NULL,
	[LEVEL5] [int] NULL,
	[LEVELNO] [int] NULL,
	[OFTYPE] [tinyint] NULL,
	[REFID] [int] NULL,
	[AUID] [int] NULL,
	[ADT] [date] NULL,
	[UUID] [int] NULL,
	[UDT] [date] NULL,
	[DRCRTYPE] [int] NULL,
	[ShowOnVPrint] [int] NULL,
	[partyadjustment] [int] NULL,
	[plblitem] [int] NULL,
	[tbgroup] [int] NULL,
	[tbsubgroup] [int] NULL,
	[tbpart] [int] NULL,
	[type] [int] NULL
	)

	go

	
/****** Object:  Table [dbo].[TBACCCATEGORY_TRANSACTION]    Script Date: 04/03/2019 06:53:38 ******/
DROP TABLE [dbo].[TBACCCATEGORY_TRANSACTION]
GO

/****** Object:  Table [dbo].[TBACCCATEGORY_TRANSACTION]    Script Date: 04/03/2019 06:53:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBACCCATEGORY_TRANSACTION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CATID] [int] NULL,
	[TRANID] [int] NULL
) ON [PRIMARY]
GO



ALTER TABLE [dbo].[tbErrorLog] DROP CONSTRAINT [DF_tbErrorLog_ErrorDate]
GO

/****** Object:  Table [dbo].[tbErrorLog]    Script Date: 04/03/2019 06:54:24 ******/
DROP TABLE [dbo].[tbErrorLog]
GO

/****** Object:  Table [dbo].[tbErrorLog]    Script Date: 04/03/2019 06:54:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbErrorLog](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorNumber] [int] NULL,
	[ErrorSeverity] [int] NULL,
	[ErrorState] [int] NULL,
	[ErrorProcedure] [nvarchar](1000) NULL,
	[ErrorLine] [int] NULL,
	[ErrorMessage] [nvarchar](2000) NULL,
	[ErrorDate] [datetime] NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbErrorLog] ADD  CONSTRAINT [DF_tbErrorLog_ErrorDate]  DEFAULT (getdate()) FOR [ErrorDate]
GO



/****** Object:  Table [dbo].[AC_AccountHead]    Script Date: 04/03/2019 07:08:39 ******/
DROP TABLE [dbo].[AC_AccountHead]
GO

/****** Object:  Table [dbo].[AC_AccountHead]    Script Date: 04/03/2019 07:08:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AC_AccountHead](
	[ACCOUNTCODE] [int] IDENTITY(1,1) NOT NULL,
	[ACCOUNTDESC] [varchar](200) NULL,
	[ACCOUNTDESCN] [varchar](200) NULL,
	[ACCOUNTTYPE] [smallint] NULL,
	[AGENTCODE] [varchar](10) NULL,
	[ATYPE] [smallint] NULL,
	[BANKACCNO] [varchar](50) NULL,
	[BANKCODE] [int] NULL,
	[BANKID] [int] NULL,
	[BRANCHCODE] [int] NULL,
	[CATID] [int] NULL,
	[CLASSID] [int] NULL,
	[CLIENTCODE] [int] NULL,
	[CURRENCYACCOUNT] [tinyint] NULL,
	[DEPTID] [int] NULL,
	[FIXEDHEAD] [tinyint] NULL,
	[ISBANK] [tinyint] NULL,
	[ISSBRANCHCODE] [int] NULL,
	[MCBANKCODE] [int] NULL,
	[PLCATEGORY] [tinyint] NULL,
	[RELATEDTO] [tinyint] NULL,
	[RICOMPANYID] [int] NULL,
	[TYPE] [tinyint] NULL,
	[ACCTYPE] [tinyint] NULL,
	[BR_ACCOUNTCODE] [int] NULL,
	[BUDGETCATID] [int] NULL,
	[DEPTCODE] [varchar](3) NULL,
	[GLCODE] [varchar](10) NULL,
	[IS_CR_ADVICE] [tinyint] NULL,
	[IS_DEP_BANK] [tinyint] NULL,
	[SLCODE] [varchar](10) NULL,
	[SUBAGENTCODE] [varchar](50) NULL,
	[TBGROUP] [varchar](10) NULL,
	[TBPART] [varchar](10) NULL,
	[TBSUBGROUP] [varchar](10) NULL,
	[THECODE] [varchar](50) NULL,
	[AUID] [varchar](20) NULL,
	[ADT] [date] NULL,
	[UUID] [varchar](20) NULL,
	[UDT] [date] NULL,
	[BRANCHID] [int] NULL,
	[surveyorid] [int] NULL,
	[Bank_Acc_No] [varchar](50) NULL,
	[min_balance] [numeric](16, 2) NULL,
	[balancetypeid] [int] NULL,
	[ShortDescription] [varchar](500) NULL,
	[LedgerType] [varchar](500) NULL,
	[TB Code] [varchar](10) NULL,
	[SL_Type (7)] [varchar](10) NULL,
	[AC_Type (1)] [varchar](10) NULL,
	[GL_Cum (5)] [varchar](10) NULL,
	[Allowed (4)] [varchar](10) NULL,
	[Mod_Typ (6)] [varchar](500) NULL,
	[OS_Bal (3)] [varchar](500) NULL,
	[OS_Depn (2)] [varchar](500) NULL,
	[Restric tion for DO/BO] [varchar](10) NULL,
	[JV Allowed Flags] [varchar](10) NULL,
	[Misc Colln Allowed] [varchar](10) NULL,
	[Misc# Disb# Allowed] [varchar](10) NULL,
	[Petty Cash Allowed] [varchar](10) NULL,
	[Form 17 Grouping] [varchar](500) NULL,
	[Form 11 Grouping] [varchar](500) NULL,
	[Form 1A/1B Grouping] [varchar](500) NULL,
	[Version] [varchar](500) NULL,
	[Remarks] [varchar](3500) NULL,
	[locked] [int] NULL,
	[IsVatOnSales] [int] NULL,
	[subbranchid] [int] NULL,
 CONSTRAINT [PK_AC_AccountHead_1] PRIMARY KEY CLUSTERED 
(
	[ACCOUNTCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_account_accdesc] UNIQUE NONCLUSTERED 
(
	[ACCOUNTDESC] ASC,
	[ACCOUNTCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[MSSUBBRANCH]    Script Date: 04/03/2019 07:15:09 ******/
DROP TABLE [dbo].[MSSUBBRANCH]
GO

/****** Object:  Table [dbo].[MSSUBBRANCH]    Script Date: 04/03/2019 07:15:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MSSUBBRANCH](
	[SUBBRANCHID] [int] IDENTITY(1,1) NOT NULL,
	[SUBBRANCHCODE] [varchar](4) NULL,
	[BRANCHID] [int] NULL,
	[ENAME] [varchar](50) NULL,
	[NNAME] [nvarchar](60) NULL,
	[ADDRESS] [varchar](100) NULL,
	[NADDRESS] [nvarchar](150) NULL,
	[TELNO] [varchar](30) NULL,
	[FAXNO] [varchar](30) NULL,
	[EMAIL] [varchar](50) NULL,
	[EALIAS] [varchar](10) NULL,
	[NALIAS] [nvarchar](60) NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[ISINDIVIDUAL] [tinyint] NULL,
	[ISDEFAULT] [int] NULL,
	[islock] [int] NULL,
	[BANKID] [int] NULL,
 CONSTRAINT [PK_MSSUBBRANCH] PRIMARY KEY CLUSTERED 
(
	[SUBBRANCHID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_MSSubBranch_BranchId_EName] UNIQUE NONCLUSTERED 
(
	[BRANCHID] ASC,
	[ENAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[ic_vouchertype]    Script Date: 04/03/2019 07:15:53 ******/
DROP TABLE [dbo].[ic_vouchertype]
GO

/****** Object:  Table [dbo].[ic_vouchertype]    Script Date: 04/03/2019 07:15:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ic_vouchertype](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ETITLE] [varchar](255) NULL,
	[NTITLE] [nvarchar](260) NULL,
	[EABBRV] [varchar](20) NULL,
	[NABBRV] [nvarchar](25) NULL,
	[VOUCHERTYPE] [int] NULL,
	[SHOW] [int] NULL,
	[TOSHOW] [int] NULL,
	[STATUS] [int] NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[ifPrevBalance] [tinyint] NULL,
	[SNO] [numeric](22, 2) NULL,
	[ShowOnDisbursement] [int] NULL,
	[moduleid] [int] NULL,
	[islock] [int] NULL,
	[showpolicytype] [int] NULL,
 CONSTRAINT [PK_ic_vouchertype] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_ic_vouchertype_ETITLE] UNIQUE NONCLUSTERED 
(
	[ETITLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[TAXRATE]    Script Date: 04/03/2019 07:17:42 ******/
DROP TABLE [dbo].[TAXRATE]
GO

/****** Object:  Table [dbo].[TAXRATE]    Script Date: 04/03/2019 07:17:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TAXRATE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FISCALID] [int] NULL,
	[RATE] [numeric](16, 4) NULL,
	[TDSRATE] [numeric](16, 4) NULL,
	[AUID] [int] NULL,
	[ADT] [date] NULL,
	[UUID] [int] NULL,
	[UDT] [date] NULL,
 CONSTRAINT [PK_TAXRATE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[FISCALYEAR]    Script Date: 04/03/2019 07:26:37 ******/
DROP TABLE [dbo].[FISCALYEAR]
GO

/****** Object:  Table [dbo].[FISCALYEAR]    Script Date: 04/03/2019 07:26:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FISCALYEAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ENGSTARTDATE] [date] NULL,
	[STARTDATE] [varchar](50) NULL,
	[ENGENDDATE] [date] NULL,
	[ENDDATE] [varchar](50) NULL,
	[ENGFISCALYEAR] [varchar](20) NULL,
	[FISCALYEAR] [varchar](20) NOT NULL,
	[YEAR] [varchar](5) NULL,
	[STATUS] [tinyint] NULL,
	[FISCALYEARCODE] [int] NULL,
	[ISCURRENTFY] [tinyint] NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[ALIAS] [varchar](50) NULL,
	[islock] [int] NULL,
 CONSTRAINT [PK_FISCALYEAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_eFiscalYr] UNIQUE NONCLUSTERED 
(
	[ENGFISCALYEAR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_FiscalYr] UNIQUE NONCLUSTERED 
(
	[FISCALYEAR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_fyCode] UNIQUE NONCLUSTERED 
(
	[FISCALYEARCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_year] UNIQUE NONCLUSTERED 
(
	[YEAR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO








/****** Object:  Table [dbo].[tbYearInfo]    Script Date: 04/03/2019 07:43:02 ******/
DROP TABLE [dbo].[tbYearInfo]
GO

/****** Object:  Table [dbo].[tbYearInfo]    Script Date: 04/03/2019 07:43:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbYearInfo](
	[NYear] [int] NULL,
	[ESDate] [datetime] NULL,
	[EEDate] [datetime] NULL
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[tbMonthInfo]    Script Date: 04/03/2019 07:43:35 ******/
DROP TABLE [dbo].[tbMonthInfo]
GO

/****** Object:  Table [dbo].[tbMonthInfo]    Script Date: 04/03/2019 07:43:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbMonthInfo](
	[NYear] [int] NULL,
	[NMonth] [smallint] NULL,
	[NDays] [smallint] NULL
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[defmodule]    Script Date: 04/03/2019 08:59:36 ******/
DROP TABLE [dbo].[defmodule]
GO

/****** Object:  Table [dbo].[defmodule]    Script Date: 04/03/2019 08:59:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[defmodule](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Modulename] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[tblDisbursementType]    Script Date: 04/03/2019 09:06:49 ******/
DROP TABLE [dbo].[tblDisbursementType]
GO

/****** Object:  Table [dbo].[tblDisbursementType]    Script Date: 04/03/2019 09:06:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblDisbursementType](
	[ID] [int] identity(1,1)NOT NULL,
	[ETITLE] [varchar](255) NULL,
	[NTITLE] [varchar](255) NULL,
	[EABBRV] [varchar](20) NULL,
	[NABBRV] [varchar](20) NULL,
	[VOUCHERTYPE] [int] NULL,
	[SHOW] [int] NULL,
	[TOSHOW] [int] NULL,
	[STATUS] [int] NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[ifPrevBalance] [tinyint] NULL,
	[SNO] [numeric](22, 2) NULL,
 CONSTRAINT [uk_tblDisbursementType_ETITLE] UNIQUE NONCLUSTERED 
(
	[ETITLE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO





/****** Object:  Table [dbo].[TBLVENDORINFO]    Script Date: 04/03/2019 09:29:38 ******/
DROP TABLE [dbo].[TBLVENDORINFO]
GO

/****** Object:  Table [dbo].[TBLVENDORINFO]    Script Date: 04/03/2019 09:29:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBLVENDORINFO](
	[VEN_ID] [int] IDENTITY(1,1) NOT NULL,
	[ADDRESS] [nvarchar](90) NULL,
	[EMAILADDRESS] [varchar](100) NULL,
	[MOBILENO] [varchar](30) NULL,
	[PANNO] [varchar](20) NULL,
	[TELEPHONENO] [varchar](20) NULL,
	[VATNO] [varchar](20) NULL,
	[VENDORCODE] [varchar](25) NULL,
	[VENDORDESC] [varchar](60) NULL,
	[NVENDORDESC] [nvarchar](70) NULL,
	[AUID] [varchar](20) NULL,
	[ADT] [date] NULL,
	[UUID] [varchar](20) NULL,
	[UDT] [date] NULL,
	[ACCOUNTID] [int] NULL,
 CONSTRAINT [uk_TBLVENDORINFO_VENDORCODE] UNIQUE NONCLUSTERED 
(
	[VENDORCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_TBLVENDORINFO_VENDORDESC] UNIQUE NONCLUSTERED 
(
	[VENDORDESC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[MSACNAME]    Script Date: 04/03/2019 09:30:29 ******/
DROP TABLE [dbo].[MSACNAME]
GO

/****** Object:  Table [dbo].[MSACNAME]    Script Date: 04/03/2019 09:30:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MSACNAME](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KYCNO] [varchar](100) NULL,
	[branchid] [int] NULL,
	[BRANCHCODE] [varchar](2) NULL,
	[INSUREDTYPE] [int] NULL,
	[ACCOUNTNAMECODE] [bigint] NULL,
	[TITLE] [varchar](1000) NULL,
	[NEPTITLE] [nvarchar](1010) NULL,
	[ZONEID] [int] NULL,
	[DISTRICTID] [int] NULL,
	[MNUVDC] [int] NULL,
	[VDCCODE] [int] NULL,
	[MUNICIPALITYCODE] [int] NULL,
	[WARDNO] [varchar](10) NULL,
	[AREAID] [int] NULL,
	[TOLEID] [int] NULL,
	[HOUSENO] [varchar](50) NULL,
	[PLOTNO] [varchar](50) NULL,
	[ADDRESS] [varchar](500) NULL,
	[ADDRESSNEPALI] [nvarchar](510) NULL,
	[TEMPORARYADDRESS] [varchar](255) NULL,
	[NTEMPORARYADDRESS] [nvarchar](260) NULL,
	[HOMETELNO] [varchar](20) NULL,
	[MOBILENO] [varchar](50) NULL,
	[EMAIL] [varchar](50) NULL,
	[PANNO] [varchar](50) NULL,
	[CONTACTPERSON] [nvarchar](110) NULL,
	[INCOMESOURCE] [int] NULL,
	[OCCUPATION] [int] NULL,
	[FATHERNAME] [varchar](50) NULL,
	[NFATHERNAME] [nvarchar](60) NULL,
	[GRANDFATHERNAME] [varchar](50) NULL,
	[NGRANDFATHERNAME] [nvarchar](60) NULL,
	[MARITALSTATUS] [char](1) NULL,
	[DATEOFBIRTH] [date] NULL,
	[HUSBANDNAME] [varchar](50) NULL,
	[NHUSBANDNAME] [nvarchar](60) NULL,
	[WIFENAME] [varchar](50) NULL,
	[NWIFENAME] [nvarchar](60) NULL,
	[CITIZENSHIPNO] [varchar](50) NULL,
	[PASSPORTNO] [varchar](50) NULL,
	[LICENSENO] [varchar](50) NULL,
	[ISSUEDATE] [date] NULL,
	[ISSUE_DISTRICT_ID] [int] NULL,
	[PhotoPath] [varchar](100) NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[OCCUPATIONNEP] [varchar](100) NULL,
	[CITIZENSHIP] [varchar](50) NULL,
	[CLIENTCODE] [varchar](10) NULL,
	[FULLNAME] [varchar](255) NULL,
	[GROUPID] [int] NULL,
	[ISSBRANCHCODE] [varchar](2) NULL,
	[NFULLNAME] [varchar](255) NULL,
	[OFFICEEMAIL] [varchar](50) NULL,
	[OFFICEFAX] [varchar](15) NULL,
	[OFFICENAME] [varchar](500) NULL,
	[OFFICETELNO] [varchar](20) NULL,
	[SENT] [int] NULL,
	[TELEPHONENO] [varchar](50) NULL,
	[IsLock] [tinyint] NULL,
	[Remarks] [varchar](200) NULL,
	[bck_accCode] [varchar](15) NULL,
	[Image] [image] NULL,
	[Ref_Kyc_no] [varchar](100) NULL,
	[ISSUSPICIOUS] [int] NULL,
	[gender] [varchar](50) NULL,
	[registrationNo] [varchar](50) NULL,
	[KYCCategoryID] [int] NULL,
	[SpecialClientID] [int] NULL,
	[subbranchid] [int] NULL,
	[subbranchcode] [varchar](4) NULL,
	[RunningFileId] [varchar](10) NULL,
	[RunningFileNo] [varchar](10) NULL,
 CONSTRAINT [PK_MSACNAME] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_kycno] UNIQUE NONCLUSTERED 
(
	[KYCNO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


DROP TABLE [dbo].[TBL_PURCHASE_ITEM]
GO

/****** Object:  Table [dbo].[TBL_PURCHASE_ITEM]    Script Date: 04/03/2019 09:49:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBL_PURCHASE_ITEM](
	[PURCHASEID] [int] IDENTITY(1,1) NOT NULL,
	[EDESCRIPTION] [varchar](200) NULL,
	[NDESCRIPTION] [varchar](200) NULL,
	[ACCOUNTCODE] [varchar](50) NULL,
	[FIXEDACCESS] [int] NULL,
	[IsInventoryItem] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PURCHASEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[AC_TRANSACTION_MASTER]    Script Date: 04/03/2019 10:10:20 ******/
DROP TABLE [dbo].[AC_TRANSACTION_MASTER]
GO

/****** Object:  Table [dbo].[AC_TRANSACTION_MASTER]    Script Date: 04/03/2019 10:10:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AC_TRANSACTION_MASTER](
	[MASTERID] [int] IDENTITY(1,1) NOT NULL,
	[FISCALID] [int] NOT NULL,
	[BRANCHID] [smallint] NOT NULL,
	[NARRATION] [varchar](2000) NULL,
	[VOUCHERNO] [int] NOT NULL,
	[VOUCHERTYPEID] [tinyint] NOT NULL,
	[trans_date] [date] NOT NULL,
	[trans_miti] [varchar](20) NULL,
	[auid] [int] NULL,
	[uuid] [int] NULL,
	[adt] [datetime] NULL,
	[udt] [datetime] NULL,
	[remarks] [varchar](512) NULL,
	[claimid] [int] NULL,
	[docid] [int] NULL,
	[receiptno] [varchar](100) NULL,
	[riid] [int] NULL,
	[approved] [tinyint] NULL,
	[ifprevbalance] [tinyint] NULL,
	[BSYear] [int] NULL,
	[BsMonth] [tinyint] NULL,
	[Deleted] [tinyint] NULL,
	[TRANSACTIONTYPEID] [int] NULL,
	[PURCHASEID] [int] NULL,
	[subbranchid] [int] NULL,
	[fvoucherno] [varchar](200) NULL,
	[agentid] [int] NULL,
	[COMMGENID] [int] NULL,
	[BANKDEPOSITID] [int] NULL,
	[PayID] [int] NULL,
	[depositid] [int] NULL,
	[AMTINWORDS] [nvarchar](255) NULL,
	[pid] [int] NULL,
	[ClmSurvID] [int] NULL,
	[claimadvanceid] [int] NULL,
	[declarationid] [int] NULL,
	[IS_SFEE_PROV] [int] NULL,
	[IsRecovery] [int] NULL,
	[fytype] [int] NULL,
	[FISCALYRTYPEID] [int] NULL,
 CONSTRAINT [PK_AC_TRANSACTION_MASTER] PRIMARY KEY CLUSTERED 
(
	[MASTERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [masterId] UNIQUE NONCLUSTERED 
(
	[FISCALID] ASC,
	[BRANCHID] ASC,
	[subbranchid] ASC,
	[VOUCHERNO] ASC,
	[VOUCHERTYPEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[AC_TRANSACTION_DETAILS]    Script Date: 04/03/2019 10:11:01 ******/
DROP TABLE [dbo].[AC_TRANSACTION_DETAILS]
GO

/****** Object:  Table [dbo].[AC_TRANSACTION_DETAILS]    Script Date: 04/03/2019 10:11:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AC_TRANSACTION_DETAILS](
	[TRANID] [int] NULL,
	[DOCUMENTNO] [varchar](50) NULL,
	[POLICYNO] [varchar](50) NULL,
	[CLAIMNO] [varchar](50) NULL,
	[RECNO] [numeric](22, 0) NULL,
	[RECEIPTNO] [varchar](20) NULL,
	[BANKID] [int] NULL,
	[VOUCHERNO] [int] NULL,
	[EDATE] [datetime] NULL,
	[NDATE] [datetime] NULL,
	[ACCOUNTCODE] [int] NULL,
	[ACCOUNTDESC] [varchar](200) NULL,
	[DRAMOUNT] [numeric](16, 2) NULL,
	[CRAMOUNT] [numeric](16, 2) NULL,
	[IFPREVBALANCE] [tinyint] NULL,
	[OFDATE] [date] NULL,
	[TTYPE] [smallint] NULL,
	[FCCODE] [numeric](22, 22) NULL,
	[FCRATE] [numeric](22, 0) NULL,
	[ENTRYNO] [smallint] NULL,
	[AGENTCODE] [varchar](10) NULL,
	[APPROVED] [tinyint] NULL,
	[BSMONTH] [numeric](22, 22) NULL,
	[BSYEAR] [numeric](22, 22) NULL,
	[CHQNO] [varchar](50) NULL,
	[CLAIMPAYID] [numeric](22, 22) NULL,
	[CLAIMTYPE] [numeric](22, 22) NULL,
	[CLIENTCODE] [varchar](10) NULL,
	[DECLARATIONNO] [varchar](10) NULL,
	[DEPOSITID] [numeric](22, 10) NULL,
	[DESCRIPTION] [varchar](4000) NULL,
	[EDITTIME] [varchar](30) NULL,
	[EDITUSER] [varchar](20) NULL,
	[FACID] [numeric](22, 22) NULL,
	[FACIID] [numeric](22, 22) NULL,
	[FCAMOUNT] [numeric](22, 0) NULL,
	[ISSUEDTO] [varchar](255) NULL,
	[LSBUID] [varchar](11) NULL,
	[MANUALVN] [varchar](50) NULL,
	[PNARRATION] [varchar](500) NULL,
	[POLICYNUMBER] [varchar](50) NULL,
	[RELATEDTO] [numeric](22, 22) NULL,
	[REMARKS] [varchar](200) NULL,
	[RIID] [numeric](22, 10) NULL,
	[RIPOOLID] [numeric](22, 22) NULL,
	[TRNTIME] [varchar](30) NULL,
	[TRNUSER] [varchar](20) NULL,
	[VTYPE] [varchar](10) NULL,
	[CHQDATE] [varchar](20) NULL,
	[ISMANUAL] [numeric](22, 0) NULL,
	[PD_ID] [numeric](22, 0) NULL,
	[USERID] [varchar](50) NULL,
	[AUID] [varchar](20) NULL,
	[ADT] [date] NULL,
	[UUID] [varchar](20) NULL,
	[UDT] [date] NULL,
	[BILLNO] [varchar](40) NULL,
	[PANNO] [varchar](40) NULL,
	[SIGNATURECODE1] [varchar](50) NULL,
	[SIGNATURECODE2] [varchar](50) NULL,
	[glcode] [varchar](20) NULL,
	[deptid] [int] NULL,
	[classid] [int] NULL,
	[trcode] [varchar](10) NULL
) ON [PRIMARY]
GO



/****** Object:  Table [dbo].[tbl_MaxNumber_Vno]    Script Date: 04/03/2019 10:12:26 ******/
DROP TABLE [dbo].[tbl_MaxNumber_Vno]
GO

/****** Object:  Table [dbo].[tbl_MaxNumber_Vno]    Script Date: 04/03/2019 10:12:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_MaxNumber_Vno](
	[fiscalid] [int] NULL,
	[branchid] [int] NULL,
	[vouchertype] [int] NULL,
	[Voucherno] [int] NULL
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[TBLUSER_VOUCHER_APPLIMIT]    Script Date: 04/03/2019 10:25:56 ******/
DROP TABLE [dbo].[TBLUSER_VOUCHER_APPLIMIT]
GO

/****** Object:  Table [dbo].[TBLUSER_VOUCHER_APPLIMIT]    Script Date: 04/03/2019 10:25:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBLUSER_VOUCHER_APPLIMIT](
	[LIMITID] [int] IDENTITY(1,1) NOT NULL,
	[DESIGNATIONID] [int] NULL,
	[LIMIT_AMOUNT] [numeric](18, 2) NULL,
	[USERID] [int] NULL,
 CONSTRAINT [PK_TBLUSER_VOUCHER_APPLIMIT] PRIMARY KEY CLUSTERED 
(
	[LIMITID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [cons_V_defsuminsuredApprovalLimit] UNIQUE NONCLUSTERED 
(
	[DESIGNATIONID] ASC,
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uk_TBLUSER_VOUCHER_APPLIMIT_DESIGNATIONID_USERID] UNIQUE NONCLUSTERED 
(
	[DESIGNATIONID] ASC,
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO




/****** Object:  Table [dbo].[def_paymenttype]    Script Date: 04/03/2019 11:14:37 ******/
DROP TABLE [dbo].[def_paymenttype]
GO

/****** Object:  Table [dbo].[def_paymenttype]    Script Date: 04/03/2019 11:14:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[def_paymenttype](
	[id] [int] NULL,
	[PaymentType] [varchar](200) NULL,
	[islocked] [int] NULL
) ON [PRIMARY]
GO



ALTER TABLE [dbo].[tblpurchaseEntry] DROP CONSTRAINT [DF__tblpurcha__IsDel__4D4B3A2F]
GO

/****** Object:  Table [dbo].[tblpurchaseEntry]    Script Date: 04/03/2019 11:18:15 ******/
DROP TABLE [dbo].[tblpurchaseEntry]
GO

/****** Object:  Table [dbo].[tblpurchaseEntry]    Script Date: 04/03/2019 11:18:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblpurchaseEntry](
	[PurchaseID] [int] IDENTITY(1,1) NOT NULL,
	[Fiscalid] [int] NULL,
	[branchid] [int] NULL,
	[pdate] [date] NULL,
	[vendorid] [int] NULL,
	[billno] [varchar](50) NULL,
	[pAmount] [numeric](15, 2) NULL,
	[pdiscAmt] [numeric](15, 2) NULL,
	[pVatAmt] [numeric](15, 2) NULL,
	[pNetAmt] [numeric](15, 2) NULL,
	[IsDeleted] [tinyint] NULL,
	[vatoptionid] [int] NULL,
	[pTypeid] [int] NULL,
	[Transactionno] [int] NULL,
	[subbranchid] [int] NULL,
	[ndate] [date] NULL,
	[Remarks] [varchar](200) NULL,
	[Bankid] [int] NULL,
	[cheqno] [varchar](30) NULL,
	[cheqdt] [date] NULL,
	[cheqAmt] [numeric](16, 2) NULL,
	[BillType] [int] NULL,
	[BillDate] [date] NULL,
	[BillDateNep] [nvarchar](20) NULL,
	[lsuid] [int] NULL,
	[lmuid] [int] NULL,
	[lsdt] [datetime] NULL,
	[lmdt] [datetime] NULL,
	[pvatrate] [numeric](6, 3) NULL,
	[pDiscRate] [numeric](6, 3) NULL,
	[ptdsamt] [numeric](16, 2) NULL,
	[ptdsRate] [numeric](16, 2) NULL,
	[ptdsGLcode] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblpurchaseEntry] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO




ALTER TABLE [dbo].[tblpurchaseentrydetails] DROP CONSTRAINT [FK__tblpurcha__purch__24B9C572]
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails] DROP CONSTRAINT [FK__tblpurcha__purch__23AD337A]
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails] DROP CONSTRAINT [FK__tblpurcha__purch__21DD58C7]
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails] DROP CONSTRAINT [FK__tblpurcha__purch__1F00EC1C]
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails] DROP CONSTRAINT [FK__tblpurcha__purch__1C247F71]
GO

/****** Object:  Table [dbo].[tblpurchaseentrydetails]    Script Date: 04/03/2019 11:18:54 ******/
DROP TABLE [dbo].[tblpurchaseentrydetails]
GO

/****** Object:  Table [dbo].[tblpurchaseentrydetails]    Script Date: 04/03/2019 11:18:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tblpurchaseentrydetails](
	[detailid] [int] IDENTITY(1,1) NOT NULL,
	[itemid] [int] NULL,
	[rate] [varchar](100) NULL,
	[quantity] [varchar](100) NULL,
	[amount] [varchar](100) NULL,
	[purchaseid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[detailid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails]  WITH CHECK ADD FOREIGN KEY([purchaseid])
REFERENCES [dbo].[tblpurchaseEntry] ([PurchaseID])
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails]  WITH CHECK ADD FOREIGN KEY([purchaseid])
REFERENCES [dbo].[tblpurchaseEntry] ([PurchaseID])
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails]  WITH CHECK ADD FOREIGN KEY([purchaseid])
REFERENCES [dbo].[tblpurchaseEntry] ([PurchaseID])
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails]  WITH CHECK ADD FOREIGN KEY([purchaseid])
REFERENCES [dbo].[tblpurchaseEntry] ([PurchaseID])
GO

ALTER TABLE [dbo].[tblpurchaseentrydetails]  WITH CHECK ADD FOREIGN KEY([purchaseid])
REFERENCES [dbo].[tblpurchaseEntry] ([PurchaseID])
GO


/****** Object:  Table [dbo].[tbl_PayeeBankInfo]    Script Date: 04/03/2019 11:24:35 ******/
DROP TABLE [dbo].[tbl_PayeeBankInfo]
GO

/****** Object:  Table [dbo].[tbl_PayeeBankInfo]    Script Date: 04/03/2019 11:24:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_PayeeBankInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bankid] [varchar](200) NULL,
	[branch] [varchar](50) NULL,
	[AcNo] [varchar](30) NULL,
	[AcHolderName] [varchar](100) NULL,
	[BankCode] [varchar](20) NULL,
	[NatureofPayment] [varchar](200) NULL,
	[Remarks] [varchar](500) NULL,
	[isbankdetail] [int] NULL,
	[AUID] [varchar](20) NULL,
	[UUI] [varchar](20) NULL,
	[ADT] [datetime] NULL,
	[UDT] [datetime] NULL,
	[claimPaymentid] [varchar](20) NULL,
	[Survyorfeeid] [varchar](20) NULL,
	[Commissionid] [varchar](20) NULL,
	[AgentCommissionid] [varchar](20) NULL,
	[creditnotepaymentid] [varchar](20) NULL,
	[claimsetlementid] [varchar](20) NULL,
	[surveyorfeesettlementid] [varchar](20) NULL,
	[creditnotepaymentmultipleid] [varchar](20) NULL,
	[paymentid] [int] NULL,
	[Purchaseid] [int] NULL,
	[disbursementid] [int] NULL,
	[BankIdNew] [int] NULL,
	[CheqDate] [date] NULL,
	[CheqAmt] [numeric](16, 2) NULL,
	[branchid] [int] NULL,
	[subbranchid] [int] NULL,
	[moduleid] [int] NULL
) ON [PRIMARY]
GO






/****** Object:  Table [dbo].[TBLDISBURSEMENTMASTER]    Script Date: 04/03/2019 11:44:21 ******/
DROP TABLE [dbo].[TBLDISBURSEMENTMASTER]
GO

/****** Object:  Table [dbo].[TBLDISBURSEMENTMASTER]    Script Date: 04/03/2019 11:44:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBLDISBURSEMENTMASTER](
	[PAYID] [int] IDENTITY(1,1) NOT NULL,
	[BRANCHID] [int] NULL,
	[SUBBRANCHID] [int] NULL,
	[FISCALID] [int] NULL,
	[DTYPE] [int] NULL,
	[DISBURSEMENTNO] [int] NULL,
	[FDISBURSEMENTNO] [varchar](40) NULL,
	[PDATE] [date] NULL,
	[NDATE] [varchar](20) NULL,
	[PAYTO] [nvarchar](200) NULL,
	[BILLNO] [varchar](30) NULL,
	[BANKID] [int] NULL,
	[CHEQUENO] [varchar](30) NULL,
	[CHEQUEDT] [date] NULL,
	[CHEQAMT] [numeric](16, 2) NULL,
	[DOCID] [int] NULL,
	[FACID] [int] NULL,
	[REMARKS] [nvarchar](512) NULL,
	[AUID] [int] NULL,
	[ADT] [datetime] NULL,
	[UUID] [int] NULL,
	[UDT] [datetime] NULL,
	[CANCEL] [smallint] NULL,
	[CANCELDT] [date] NULL,
	[CANCELTIME] [datetime] NULL,
	[CANCELREASON] [nvarchar](512) NULL
	)



/****** Object:  Table [dbo].[TBLDISBURSEMENTDETAILS]    Script Date: 04/03/2019 11:45:18 ******/
DROP TABLE [dbo].[TBLDISBURSEMENTDETAILS]
GO

/****** Object:  Table [dbo].[TBLDISBURSEMENTDETAILS]    Script Date: 04/03/2019 11:45:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBLDISBURSEMENTDETAILS](
	[DID] [int] IDENTITY(1,1) NOT NULL,
	[PAYID] [int] NULL,
	[ACCOUNTDESC] [varchar](200) NULL,
	[ACCOUNTCODE] [int] NULL,
	[DRAMOUNT] [numeric](16, 2) NULL,
	[CRAMOUNT] [numeric](16, 2) NULL,
	[REMARKS] [nvarchar](255) NULL
	)


