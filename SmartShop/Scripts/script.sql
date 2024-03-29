USE [shop]
GO
/****** Object:  Table [dbo].[CustomerArrear]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerArrear](
	[ArrId] [int] IDENTITY(1,1) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[SellsInvoice] [nvarchar](20) NULL,
	[CustId] [nvarchar](20) NULL,
	[CustomerName] [nvarchar](50) NULL,
	[TotalAmount] [int] NULL,
	[DueAmount] [int] NULL,
 CONSTRAINT [pk_SellesChild_ArrId] PRIMARY KEY CLUSTERED 
(
	[ArrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CustomerInformation]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInformation](
	[CustId] [nvarchar](20) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[CustomerPresentAddress] [nvarchar](200) NULL,
	[CustomerPermanentAddress] [nvarchar](200) NULL,
	[ContactNo] [nvarchar](24) NULL,
	[Email] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[Photo] [varbinary](max) NULL,
	[IsActive] [bit] NULL,
	[CreateBy] [nvarchar](30) NULL,
	[CreateDateTime] [datetime] NULL,
 CONSTRAINT [pk_CustomerInformation_CustId] PRIMARY KEY CLUSTERED 
(
	[CustId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ArrearAmount_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ArrearAmount_vw] as 
select sum(ISNULL(ar.DueAmount,0))DueAmount,ar.CustId ,ci.CustomerName from CustomerArrear ar 
left join CustomerInformation as ci on ar.CustId=ci.CustId  group by ar.CustId,ci.CustomerName
GO
/****** Object:  Table [dbo].[ProductName]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductName](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[ProductCode] [nvarchar](30) NOT NULL,
	[CategoryId] [int] NULL,
	[CompanyId] [int] NULL,
	[ReorderLebel] [int] NULL,
	[CreateDate] [datetime] NULL,
	[CreateById] [nvarchar](20) NULL,
	[logo] [varbinary](max) NULL,
	[Status] [nvarchar](1) NULL,
	[PurchasePrice] [decimal](10, 2) NULL,
	[SellingPrice] [decimal](10, 2) NULL,
	[VatPercent] [decimal](10, 2) NULL,
	[Description] [nvarchar](100) NULL,
	[ColurId] [nvarchar](20) NULL,
	[SizeId] [nvarchar](3) NULL,
	[BrandId] [nvarchar](50) NULL,
	[DisCountPercent] [decimal](10, 2) NULL,
 CONSTRAINT [ProductName_Id_Code_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseChildTable]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseChildTable](
	[PChidId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseInvoice] [nvarchar](20) NOT NULL,
	[PurchaseId] [int] NULL,
	[ProductCode] [nvarchar](20) NOT NULL,
	[Qty] [int] NOT NULL,
	[ColourId] [nvarchar](50) NULL,
	[SizeId] [nvarchar](50) NULL,
	[BrandId] [nvarchar](50) NULL,
	[PurchasePrice] [int] NULL,
	[SellingPrice] [int] NULL,
	[DiscountPrice] [int] NULL,
	[DiscountAmount] [int] NULL,
	[TotalAmount] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [pk_PurchaseChildTable_PChidId] PRIMARY KEY CLUSTERED 
(
	[PChidId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseParentTable]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseParentTable](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDate] [datetime] NULL,
	[PurchaseInvoice] [nvarchar](20) NULL,
	[CompanyInvoice] [nvarchar](20) NULL,
	[SupplyerId] [nvarchar](20) NULL,
	[DelivaryBy] [nvarchar](20) NULL,
	[ContactNo] [nvarchar](11) NULL,
	[Status] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[PcName] [nvarchar](20) NULL,
	[IsApproved] [bit] NOT NULL,
 CONSTRAINT [PurchaseId_PK] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[PurchaseRegister_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[PurchaseRegister_vw] as
SELECT        sc.ProductCode, sc.TotalAmount, sc.SellingPrice,pn.PurchasePrice,sc.DiscountPrice, sc.DiscountAmount, sc.Qty, pn.ProductName,
                         CAST(sp.PurchaseDate AS date) AS SellsDate
FROM            dbo.PurchaseChildTable AS sc INNER JOIN
                         dbo.ProductName AS pn ON sc.ProductCode = pn.ProductCode INNER JOIN
                         dbo.PurchaseParentTable AS sp ON sc.PurchaseInvoice = sp.PurchaseInvoice
GO
/****** Object:  Table [dbo].[ArrearCollection]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ArrearCollection](
	[CollArrear] [int] IDENTITY(1,1) NOT NULL,
	[CustId] [nvarchar](20) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[DueAmount] [int] NOT NULL,
	[PayAmount] [int] NOT NULL,
	[LastDueAmount] [int] NOT NULL,
	[CreateBy] [nvarchar](20) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [pk_ArrearCollection_CollArrear] PRIMARY KEY CLUSTERED 
(
	[CollArrear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ArrearCollection_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[ArrearCollection_vw] as
SELECT        ROW_NUMBER() OVER (ORDER BY CollArrear DESC) AS sl, TransactionDate, CustId, sum(ISNULL(PayAmount, 0)) PayAmount, LastDueAmount,CreateBy
FROM            (SELECT        CollArrear, CustId, CAST(TransactionDate AS date) TransactionDate, PayAmount, LastDueAmount,CreateBy
                          FROM            ArrearCollection) DueCollection
GROUP BY CollArrear, TransactionDate, CustId, LastDueAmount,CreateBy
GO
/****** Object:  Table [dbo].[SellesChild]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellesChild](
	[SellsId] [bigint] IDENTITY(1,1) NOT NULL,
	[SellsParId] [bigint] NOT NULL,
	[SellsInvoice] [nvarchar](20) NULL,
	[SalesMonth] [nvarchar](6) NULL,
	[ProductCode] [nvarchar](20) NULL,
	[ColurId] [nvarchar](20) NULL,
	[SizeId] [nvarchar](20) NULL,
	[BrandId] [nvarchar](20) NULL,
	[Qty] [int] NOT NULL,
	[SellingPrice] [decimal](10, 3) NOT NULL,
	[VatPercent] [decimal](10, 3) NULL,
	[VatAmount] [int] NULL,
	[DiscountPercent] [decimal](10, 3) NULL,
	[DiscountAmount] [decimal](10, 3) NULL,
	[TotalAmount] [int] NOT NULL,
 CONSTRAINT [pk_SellesParent_SellsId] PRIMARY KEY CLUSTERED 
(
	[SellsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SellsParent]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SellsParent](
	[SellsParId] [bigint] IDENTITY(1,1) NOT NULL,
	[SellsInvoice] [nvarchar](20) NOT NULL,
	[SalesMonth] [nvarchar](6) NOT NULL,
	[SellsDate] [datetime] NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](24) NULL,
	[TotalAmount] [decimal](10, 3) NULL,
	[PayAmount] [decimal](10, 3) NULL,
	[ReturnAmount] [decimal](10, 3) NULL,
	[DueAmount] [int] NULL,
	[SellsBy] [nvarchar](30) NOT NULL,
	[PcName] [nvarchar](30) NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [pk_SellsPrent_SellsPrId] PRIMARY KEY CLUSTERED 
(
	[SellsParId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_LastSells]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vw_LastSells] as
SELECT    CAST(SellsDate as date)SellsDate,    sellsParent.SellsInvoice, c.ProductCode, Qty, SellingPrice,VatAmount,DiscountAmount, c.TotalAmount
FROM            (SELECT        *
                          FROM            (SELECT        ROW_NUMBER() OVER (ORDER BY SellsParId DESC) AS sl, a.*
                          FROM            (SELECT        *
                                                    FROM            SellsParent) a) b
WHERE        sl <= 100) sellsParent,
    (SELECT      SellsInvoice, ProductCode, Qty, SellingPrice,VatAmount,DiscountAmount, TotalAmount
      FROM            SellesChild) c
WHERE        sellsParent.SellsInvoice = c.SellsInvoice
GO
/****** Object:  View [dbo].[StockSales_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[StockSales_vw] as
select ProductCode,sum(isnull(Qty,0))Qty,sum(isnull(TotalAmount ,0))TotalAmount
from SellesChild
group by ProductCode
GO
/****** Object:  View [dbo].[StockPurchase_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[StockPurchase_vw] as
select ProductCode,sum(isnull(Qty,0))Qty,sum(isnull(TotalAmount,0))TotalAmount
 from PurchaseChildTable
 group by ProductCode
GO
/****** Object:  View [dbo].[CustomerAllDue_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[CustomerAllDue_vw] as 
select * 
from 
(
select 
                        ar.CustId,
                        ar.CustomerName, 
                        ar.DueAmount,
                        sum(isnull(ac.PayAmount,0))PayAmount,
                        isnull(ar.DueAmount,0)-sum(isnull(ac.PayAmount,0))LastDueAmount ,
                        c.ContactNo,
                        c.CustomerPresentAddress 
                        from ArrearAmount_vw as ar 
                        left join ArrearCollection_vw as ac on ar.CustId = ac.CustId 
                        left join CustomerInformation as c on ar.CustId = c.CustId 
                        group by ar.CustId, ar.CustomerName, ar.DueAmount, c.ContactNo, c.CustomerPresentAddress)a
						where a.LastDueAmount>0
GO
/****** Object:  View [dbo].[SalesReturn_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[SalesReturn_vw] as 
select cast(sp.SellsDate as date) SellsDate,
                           sp.SellsInvoice,
	                       sp.SellsBy, 
	                       sc.ProductCode,
						    pn.ProductName,
							sc.VatPercent,
							sc.DiscountPercent,
							 sc.Qty,
						   pn.SellingPrice,
						   sc.VatAmount,
						   sc.DiscountAmount,
                            sc.TotalAmount
                    from SellesChild as sc
                    inner join SellsParent as sp on sc.SellsInvoice=sp.SellsInvoice
                    inner join ProductName as pn on sc.ProductCode=pn.ProductCode
GO
/****** Object:  View [dbo].[Stock_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[Stock_vw] as
select p.ProductCode,pn.ProductName,pn.CompanyId,pn.CategoryId,pn.BrandId,pn.ColurId,pn.SizeId,  p.Qty as PurchaseQty,s.Qty as SalesQty,(isnull(p.Qty,0)-isnull(s.Qty,0))QtyBalance,p.TotalAmount as PurchasesAmount,s.TotalAmount as SalesAmount
from StockPurchase_vw as p
left join StockSales_vw as s on s.ProductCode=p.ProductCode
inner join ProductName as pn on p.ProductCode=pn.ProductCode
GO
/****** Object:  Table [dbo].[ColourTable]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ColourTable](
	[ColurId] [int] IDENTITY(1,1) NOT NULL,
	[ColourName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ColurId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplyerTable]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplyerTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[SupplyerName] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](100) NULL,
	[ContactPerson] [nvarchar](30) NULL,
	[ContactPersonMobileNo] [nvarchar](11) NULL,
	[Mobile] [nvarchar](11) NULL,
	[Email] [nvarchar](50) NULL,
	[logo] [varbinary](max) NULL,
	[Status] [varchar](1) NULL,
	[CreateBy] [varchar](10) NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SizeTable]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SizeTable](
	[SizeId] [int] IDENTITY(1,1) NOT NULL,
	[SizeName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BrandTable]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BrandTable](
	[BrandId] [int] IDENTITY(1,1) NOT NULL,
	[BrandName] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[ContactNo] [nvarchar](11) NULL,
 CONSTRAINT [PK_BrandId] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoriesTable]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoriesTable](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NULL,
	[Logo] [varbinary](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[Status] [nvarchar](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[stockList_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[stockList_vw] as
select 
                        st.ProductCode,
                        st.ProductName,
                        st.PurchaseQty,
                        st.SalesQty,
                        st.QtyBalance,
                        st.PurchasesAmount,
                        st.SalesAmount,
                        s.SupplyerName,
                        ct.CategoryName,
                        b.BrandName,
                        sz.SizeName,
                        col.ColourName
                        from Stock_vw as st
                        inner join SupplyerTable as s on st.CompanyId=s.id
                        inner join CategoriesTable  as ct on st.CategoryId=ct.Id
                        inner join BrandTable as b on st.BrandId=b.BrandId
                        inner join  SizeTable as sz on st.SizeId=sz.SizeId
                        inner join ColourTable as col on st.ColurId=col.ColurId
			
GO
/****** Object:  View [dbo].[vw_LastPurchase]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vw_LastPurchase] as
select purchaseParent.PurchaseInvoice,c.ProductCode,Qty,PurchasePrice as ProductPrice,TotalAmount
from 
(
select *
from 
(
select ROW_NUMBER() over(order by PurchaseId desc ) as sl,a.*
from
(
select *
from PurchaseParentTable)a)b
where sl<=100 )purchaseParent,
(
 select PurchaseInvoice,ProductCode,Qty,PurchasePrice,TotalAmount
from PurchaseChildTable)c
where purchaseParent.PurchaseInvoice=c.PurchaseInvoice
GO
/****** Object:  View [dbo].[SalesRegister_vw]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[SalesRegister_vw] as
select sc.ProductCode,sc.TotalAmount,sc.SellingPrice,sc.VatAmount,sc.DiscountAmount,sc.Qty,(pn.PurchasePrice* sc.Qty)PurchaseAmount,(sc.TotalAmount-(pn.PurchasePrice* sc.Qty))BenfitAmount,pn.ProductName ,CAST(SellsDate as date)SellsDate
from SellesChild sc
inner join ProductName as pn on sc.ProductCode=pn.ProductCode
inner join SellsParent as sp on sc.SellsInvoice=sp.SellsInvoice
GO
/****** Object:  Table [dbo].[BusinessObjects]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessObjects](
	[BusinessObjectCode] [nvarchar](50) NOT NULL,
	[ApplicationCode] [nvarchar](50) NOT NULL,
	[BusinessObjectName] [nvarchar](50) NULL,
	[ObjectFormName] [nvarchar](50) NULL,
	[ObjectFormType] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[LastCommand] [nvarchar](50) NULL,
	[LastChangedBy] [nvarchar](50) NULL,
	[LastChangeDateTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[BusinessObjectCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CompanyTables]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyTables](
	[OfficeCode] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](150) NULL,
	[FactoryAddress] [nvarchar](150) NULL,
	[ContactNo] [nvarchar](11) NULL,
	[Email] [nvarchar](30) NULL,
	[Fax] [nvarchar](30) NULL,
	[Logo] [varbinary](max) NULL,
	[CEO] [nvarchar](30) NULL,
	[AppInstallDate] [date] NULL,
	[AppVersion] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[OfficeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [nvarchar](20) NULL,
	[DepartmentName] [nvarchar](50) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK__Departme__3214EC07165D0F90] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Designations]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Designations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DesiCode] [nvarchar](20) NOT NULL,
	[DesiName] [nvarchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [DesignationTable_id_DesiCode_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[DesiCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeInformation]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeInformation](
	[id] [int] IDENTITY(1000,1) NOT NULL,
	[AccountCode] [nvarchar](20) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[ConfirmPassword] [nvarchar](20) NOT NULL,
	[UserEmail] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[FullName] [nvarchar](50) NULL,
	[PresentAddress] [nvarchar](250) NULL,
	[PermanentAddress] [nvarchar](250) NULL,
	[ReportingPerson] [nvarchar](50) NULL,
	[MobileNo] [nvarchar](11) NULL,
	[DeviceName] [nvarchar](50) NULL,
	[DeviceQty] [int] NULL,
	[IMEINo] [nvarchar](50) NULL,
	[Photo] [varbinary](max) NULL,
	[DepartmentCode] [nvarchar](20) NULL,
	[DesiCode] [nvarchar](20) NULL,
	[BasicSalary] [int] NULL,
	[HouseRent] [int] NULL,
	[MedicalAllonce] [int] NULL,
	[DainingAllonce] [int] NULL,
	[CreateBy] [nvarchar](30) NULL,
	[UserStatus] [bit] NULL,
 CONSTRAINT [PK__Employee__3213E83FFD9FCEA4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpensesEntry]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpensesEntry](
	[ExpensEntryId] [int] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[SalesMonth] [nvarchar](6) NOT NULL,
	[ExpnsId] [int] NOT NULL,
	[ExpenseAmount] [int] NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[CreateBy] [nvarchar](50) NOT NULL,
	[CreateDateTime] [datetime] NULL,
 CONSTRAINT [pk_ExpensesEntryTable_ExpensId] PRIMARY KEY CLUSTERED 
(
	[ExpensEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExpensesList]    Script Date: 1/14/2020 3:18:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExpensesList](
	[ExpnsId] [int] IDENTITY(1,1) NOT NULL,
	[ExpnsName] [nvarchar](150) NULL,
	[Remarks] [nvarchar](500) NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ObjectCommand]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ObjectCommand](
	[OCommandId] [int] IDENTITY(1000,1) NOT NULL,
	[BusinessObjectCode] [nvarchar](50) NULL,
	[BusinessObjectName] [nvarchar](50) NULL,
	[ObjectFormName] [nvarchar](50) NULL,
	[ObjectFormDescription] [nvarchar](50) NULL,
	[UserId] [int] NULL,
	[LoginName] [nvarchar](50) NULL,
	[Permisson] [bit] NULL,
	[CreateBy] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reports]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[RptCode] [int] IDENTITY(1,1) NOT NULL,
	[ReportIdentity] [nvarchar](20) NOT NULL,
	[ReportModule] [nvarchar](20) NOT NULL,
	[ReportType] [nvarchar](20) NOT NULL,
	[SettingValue] [nvarchar](150) NOT NULL,
	[ReportDisplayName] [nvarchar](150) NOT NULL,
	[ReportName] [nvarchar](150) NOT NULL,
	[HasHeader] [bit] NOT NULL,
	[HasFooter] [bit] NOT NULL,
	[IsActivated] [bit] NOT NULL,
 CONSTRAINT [pk_Reports_RptCode] PRIMARY KEY CLUSTERED 
(
	[RptCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesReturn]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesReturn](
	[SalesRetId] [int] IDENTITY(1,1) NOT NULL,
	[SellsDate] [datetime] NOT NULL,
	[SalesMonth] [nvarchar](6) NOT NULL,
	[SellsInvoice] [nvarchar](20) NOT NULL,
	[ProductCode] [nvarchar](20) NOT NULL,
	[Qty] [int] NOT NULL,
	[SellingPrice] [int] NULL,
	[SalesAmount] [int] NULL,
	[TotalAmount] [int] NOT NULL,
	[SellsBy] [nvarchar](30) NOT NULL,
	[PcName] [nvarchar](30) NOT NULL,
	[CreateDateTime] [datetime] NULL,
 CONSTRAINT [SalesReturn_pk] PRIMARY KEY CLUSTERED 
(
	[SalesRetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SequencePopulate]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SequencePopulate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ObjName] [nvarchar](50) NULL,
	[FrmName] [nvarchar](50) NULL,
	[Code] [nvarchar](10) NULL,
	[StartWith] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_PurchaseRequgitionTable]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_PurchaseRequgitionTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrderInvoice] [nvarchar](20) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[CompanyId] [int] NOT NULL,
	[Code] [nvarchar](30) NOT NULL,
	[Qty] [int] NOT NULL,
	[PurchasePrice] [int] NOT NULL,
	[Amount]  AS ([Qty]*[PurchasePrice]),
	[DelivaryDate] [datetime] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateBy] [nvarchar](20) NULL,
	[Status] [nvarchar](1) NULL,
	[Comments] [nvarchar](100) NULL,
	[Vat] [nchar](10) NULL,
	[VatAmount]  AS ((([Qty]*[PurchasePrice])*[Vat])/(100)),
 CONSTRAINT [tbl_PRItemOrderTable_id_pk] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogin]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogin](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[NickName] [nvarchar](10) NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[ConfirmPassword] [nvarchar](20) NULL,
	[MobileNo] [nvarchar](11) NULL,
	[UserStatus] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](20) NULL,
	[DesiCode] [nvarchar](50) NULL,
 CONSTRAINT [PK__UserLogi__CB9A1CFF0B136A5A] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EmployeeInformation] ADD  CONSTRAINT [DF_EmployeeInformation_Password]  DEFAULT ((1)) FOR [Password]
GO
ALTER TABLE [dbo].[EmployeeInformation] ADD  CONSTRAINT [DF_EmployeeInformation_ConfirmPassword]  DEFAULT ((1)) FOR [ConfirmPassword]
GO
ALTER TABLE [dbo].[PurchaseChildTable] ADD  CONSTRAINT [DF_PurchaseChildTable_IsApproved]  DEFAULT ((0)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[PurchaseParentTable] ADD  CONSTRAINT [DF_PurchaseParentTable_IsApproved]  DEFAULT ((0)) FOR [IsApproved]
GO
ALTER TABLE [dbo].[Reports] ADD  CONSTRAINT [dft_Reports_HasHeader]  DEFAULT ((0)) FOR [HasHeader]
GO
ALTER TABLE [dbo].[Reports] ADD  CONSTRAINT [dft_Reports_HasFooter]  DEFAULT ((0)) FOR [HasFooter]
GO
ALTER TABLE [dbo].[Reports] ADD  CONSTRAINT [dft_Reports_IsActivated]  DEFAULT ((0)) FOR [IsActivated]
GO
ALTER TABLE [dbo].[SellsParent] ADD  CONSTRAINT [DF_SellsParent_DueAmount]  DEFAULT ((0)) FOR [DueAmount]
GO
ALTER TABLE [dbo].[SellsParent] ADD  CONSTRAINT [dft_SellsPrent_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[tbl_PurchaseRequgitionTable]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CategoriesTable] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseRequgitionTable]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CategoriesTable] ([Id])
GO
ALTER TABLE [dbo].[tbl_PurchaseRequgitionTable]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[SupplyerTable] ([id])
GO
ALTER TABLE [dbo].[tbl_PurchaseRequgitionTable]  WITH CHECK ADD FOREIGN KEY([CompanyId])
REFERENCES [dbo].[SupplyerTable] ([id])
GO
/****** Object:  StoredProcedure [dbo].[ArrearCollection_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ArrearCollection_sp](
@CustId nvarchar(20),
@TransactionDate datetime,
@DueAmount int,
@PayAmount int,
@LastDueAmount int,
@CreateBy nvarchar(20),
@StatementType  nvarchar(20)='' )as
begin
set nocount on;
	set xact_abort on;
	begin
	if(@StatementType='Create')
	insert into ArrearCollection(CustId,TransactionDate,DueAmount,PayAmount,LastDueAmount,CreateBy,CreateDateTime)
	values (@CustId,@TransactionDate,@DueAmount,@PayAmount,@LastDueAmount,@CreateBy,CURRENT_TIMESTAMP)
	end
end
GO
/****** Object:  StoredProcedure [dbo].[CategoriesTable_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[CategoriesTable_sp](
@Name nvarchar(100),
@Logo varbinary,
@CreateBy nvarchar(50),
@Active nvarchar(1),
@StatementType nvarchar(20) = '')as
begin
if @StatementType='Create'
begin
INSERT INTO CategoriesTable
           (CategoryName,Logo,CreateDate,CreateBy,Status)
     VALUES
           (@Name,@Logo,SYSDATETIME(),@CreateBy,@Active)

end
if  @StatementType='Update'
begin
update CategoriesTable set CategoryName=@Name,Logo=@Logo,CreateDate=SYSDATETIME() 
where CategoryName =@Name
end
end
GO
/****** Object:  StoredProcedure [dbo].[companyProfile]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[companyProfile](@Name  nvarchar(100),
@Address nvarchar(150),
@FactoryAddress nvarchar(150),
@ContactNo nvarchar(11),
@Email nvarchar(30),
@Fax nvarchar(20),
@Logo varbinary(max),
@CEO nvarchar(30),
@AppInstallDate datetime, 
@AppVersion nvarchar(20),
@StatementType nvarchar(20) = '')as
begin
IF @StatementType = 'Create'
begin
insert into CompanyTables (Name ,Address ,FactoryAddress ,ContactNo ,Email ,Fax ,Logo ,CEO ,AppInstallDate, AppVersion )
values(@Name ,@Address ,@FactoryAddress ,@ContactNo ,@Email ,@Fax ,@Logo ,@CEO ,@AppInstallDate, @AppVersion )
end
IF @StatementType = 'Update'
begin
update CompanyTables set Name=@Name ,
Address=@Address ,
FactoryAddress=@FactoryAddress ,
ContactNo=@ContactNo ,
Email=@Email ,
Fax=@Fax ,
Logo=@Logo ,
CEO=@CEO ,
AppInstallDate=@AppInstallDate,
AppVersion=@AppVersion
 where Name=@Name
end
end
GO
/****** Object:  StoredProcedure [dbo].[CustomerInfo_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CustomerInfo_sp] (
@CustId nvarchar(20),
@CustomerName nvarchar(50),
@CustomerPresentAddress nvarchar(200),
@CustomerPermanentAddress nvarchar(200),
@ContactNo nvarchar(24),
@Email nvarchar(50),
@Gender nvarchar(50),
@Photo varbinary(max),
@IsActive bit,
@CreateBy nvarchar(30),
@StatementType  nvarchar(20)=''
)as
begin

set nocount on;
	set xact_abort on;
	begin
	 
	 declare @CustIde nvarchar(20);
 select @CustIde=max(ISNULL(CustId,0)+1) from CustomerInformation

	if (@StatementType='Create')
	insert into CustomerInformation(CustId,CustomerName,CustomerPresentAddress,CustomerPermanentAddress,ContactNo,
	                                Email,Gender,Photo,IsActive,CreateBy,CreateDateTime)
									values(@CustIde,@CustomerName,@CustomerPresentAddress,@CustomerPermanentAddress,@ContactNo,
	                                @Email,@Gender,@Photo,@IsActive,@CreateBy,CURRENT_TIMESTAMP)
	else if(@StatementType='Update')
	update CustomerInformation set CustomerName=@CustomerName,CustomerPresentAddress=@CustomerPresentAddress,CustomerPermanentAddress=@CustomerPermanentAddress,
	Email=@Email,ContactNo=@ContactNo,Photo=@Photo,IsActive=@IsActive,CreateBy=@CreateBy,CreateDateTime=CURRENT_TIMESTAMP
	where CustId=@CustId

	end 
	end
GO
/****** Object:  StoredProcedure [dbo].[DesiganationInformation]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[DesiganationInformation](
@DesiCode nvarchar(50),
@Name nvarchar(50),
@Status nvarchar(1),
@StatementType nvarchar(20) = '')as
begin
declare @DesiCodeCount nvarchar(20)
select @DesiCodeCount= COUNT(DesiCode) from Designations where DesiCode=@DesiCode
begin
if @StatementType='Create'
insert into Designations (DesiCode ,DesiName ,Status )
Values(@DesiCode ,@Name ,@Status)
update SequencePopulate set StartWith=@DesiCode where Code='DesiCode'
end
begin
if @StatementType='Update'
update Designations set DesiName=@Name ,
Status =@Status
where DesiCode=@DesiCode
end
end

GO
/****** Object:  StoredProcedure [dbo].[EmployeeInformation_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[EmployeeInformation_sp] (
           @AccountCode varchar(30),
           @UserName varchar(50),
           @UserEmail  varchar(30),
           @Password varchar(30),
           @ConfirmPassword varchar(30),
           @FirstName varchar(30),
           @LastName varchar(30),
           @FullName varchar(30),
		   @PresentAddress varchar(30),
		   @PermanentAddress varchar(30),
           @ReportingPerson varchar(30),
           @MobileNo varchar(30),
           @DeviceName varchar(30),
           @DeviceQty int,
           @IMEINo varchar(30),
           @Photo varbinary(max),
           @DepartmentCode nvarchar(30),
           @DesiCode nvarchar(30),
           @BasicSalary int,
           @HouseRent int,
           @MedicalAllonce int,
           @DainingAllonce int,
		   @CreateBy nvarchar(30),
		   @UserStatus bit,
		   @StatementType nvarchar(20)='') AS
begin

select @AccountCode= max(AccountCode)+1  from EmployeeInformation
IF  @StatementType='Create'
begin
INSERT INTO [dbo].[EmployeeInformation]
           (AccountCode,UserName,Password,ConfirmPassword,UserEmail ,FirstName,LastName
           ,FullName,ReportingPerson,MobileNo,DeviceName
           ,DeviceQty,IMEINo,Photo,DepartmentCode,DesiCode,BasicSalary,HouseRent
           ,MedicalAllonce,DainingAllonce,CreateBy,UserStatus)
     VALUES
           (@AccountCode,@UserName,@Password,@ConfirmPassword,@UserEmail ,@FirstName,@LastName
           ,@FullName,@ReportingPerson,@MobileNo,@DeviceName
           ,@DeviceQty,@IMEINo,@Photo,@DepartmentCode,@DesiCode,@BasicSalary,@HouseRent
           ,@MedicalAllonce,@DainingAllonce,@CreateBy,@UserStatus)

Insert into UserLogin(Name,NickName,LoginName,Password,ConfirmPassword,MobileNo,UserStatus,CreateDate,CreateBy,DesiCode)
values (@FullName,@FirstName,@UserName,@Password,@ConfirmPassword,@MobileNo,0,CURRENT_TIMESTAMP,@CreateBy,@DesiCode)
end
end
GO
/****** Object:  StoredProcedure [dbo].[ExpensesEntry_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[ExpensesEntry_sp] (
@EntryDate datetime,
@SalesMonth nvarchar(6),
@ExpnsId int,
@ExpenseAmount int,
@Remarks nvarchar(250),
@CreateBy nvarchar(30),
@StatementType  nvarchar(20)=''
)as
begin

set nocount on;
	set xact_abort on;
	begin

	if (@StatementType='Create')
	insert into ExpensesEntry(EntryDate,SalesMonth,ExpnsId,ExpenseAmount,Remarks,CreateBy,CreateDateTime)
									values(@EntryDate,@SalesMonth,@ExpnsId,@ExpenseAmount,@Remarks,@CreateBy,CURRENT_TIMESTAMP)
	end 
	end


	
GO
/****** Object:  StoredProcedure [dbo].[ExpensesList_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ExpensesList_sp] (
@ExpnsName nvarchar(150),
@Remarks nvarchar(500),
@IsActive bit,
@StatementType  nvarchar(20)=''
)as
begin

set nocount on;
	set xact_abort on;
	begin
	 
	if (@StatementType='Create')
	insert into ExpensesList(ExpnsName,Remarks,IsActive)
									values(@ExpnsName,@Remarks,@IsActive)
	end 
	end
GO
/****** Object:  StoredProcedure [dbo].[ObjectCommand_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[ObjectCommand_sp] (
@BusinessObjectCode nvarchar(50),
@BusinessObjectName nvarchar(50),
@ObjectFormName nvarchar(50),
@UserId int,
@Permisson bit,
@CreateBy nvarchar(50),
@StatementType  nvarchar(20)='')as
begin

set nocount on;
	set xact_abort on;
	if(@StatementType = 'Create')
	declare @LoginName nvarchar(50);
	declare @ObjectCode nvarchar(50);

select @LoginName= LoginName from UserLogin where UserId=@UserId
select ObjectCode=BusinessObjectCode from ObjectCommand where BusinessObjectCode=@BusinessObjectCode and UserId=@UserId
if exists(select * from  ObjectCommand where BusinessObjectCode=@BusinessObjectCode and UserId=@UserId )
delete from ObjectCommand where BusinessObjectCode=@BusinessObjectCode and UserId=@UserId

	insert into ObjectCommand(BusinessObjectCode,BusinessObjectName,ObjectFormName,ObjectFormDescription,UserId,LoginName,Permisson,CreateBy,CreateDate)
	    values(@BusinessObjectCode,@BusinessObjectName,@ObjectFormName,@BusinessObjectName,@UserId,@LoginName,@Permisson,@CreateBy,CURRENT_TIMESTAMP)
end

GO
/****** Object:  StoredProcedure [dbo].[ProductName_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[ProductName_sp](
@Name nvarchar(50),
@ProductCode nvarchar(20),
@CategoryId int,
@CompanyId int, 
@ReorderLebel int,
@logo varbinary(max),
@Status nvarchar(1),
@PurchasePrice decimal(10,3),
@SellingPrice decimal(10,3),
@VatPercent decimal(10,3),
@Description nvarchar(100),
@ColourId int, 
@SizeId int, 
@BrandId int,
@DisCountPercent decimal(10,3),
@CreateById nvarchar(20),
@StatementType nvarchar(20)='')as
begin

declare @Codee nvarchar(20);
select @Codee=ISNULL( sum(StartWith),0)+1  from SequencePopulate where Code='ProCode'
begin
if @StatementType='Create'
INSERT INTO ProductName(ProductName,ProductCode,CategoryId,CompanyId,ReorderLebel,CreateDate,CreateById,logo,Status,PurchasePrice,SellingPrice,VatPercent,Description,ColurId,SizeId,BrandId,DisCountPercent)
     VALUES(@Name, 'PC'+@Codee,@CategoryId,@CompanyId,@ReorderLebel,SYSDATETIME(),@CreateById,@logo,@Status,@PurchasePrice,@SellingPrice,@VatPercent,@Description,@ColourId,@SizeId,@BrandId,@DisCountPercent)
	 update SequencePopulate set StartWith=@Codee where Code='ProCode'
end
begin
if @StatementType='Update'
update ProductName
set ProductName=@Name,
CategoryId=@CategoryId,
CompanyId=@CompanyId,
ReorderLebel=@ReorderLebel,
CreateDate=SYSDATETIME(),
CreateById=@CreateById,
logo=@logo,
PurchasePrice=@PurchasePrice,
SellingPrice=@SellingPrice,
VatPercent=@VatPercent,
Status=@Status,
Description=@Description,
ColurId=@ColourId,
SizeId=@SizeId,
BrandId=@BrandId,
DisCountPercent=@DisCountPercent
where ProductCode=@ProductCode
end
end
GO
/****** Object:  StoredProcedure [dbo].[PurchaseApproved_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[PurchaseApproved_sp](
@PurchaseInvoice nvarchar(50),
@StatementType nvarchar(20) = '') as
begin
set nocount on;
	set xact_abort on;

	if (@StatementType='Update')
	update PurchaseChildTable set IsApproved=1 where PurchaseInvoice=@PurchaseInvoice
	update PurchaseParentTable set IsApproved=1 where PurchaseInvoice=@PurchaseInvoice
end 
GO
/****** Object:  StoredProcedure [dbo].[PurchaseChild_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[PurchaseChild_sp](
@PurchaseInvoice nvarchar(50),
@PurchaseId int,
@ProductCode nvarchar(20),
@Qty int,
@PurchasePrice int,
@SellingPrice int,
@DiscountPrice int,
@DiscountAmount int,
@TotalAmount int,
@BrandId nvarchar(20),
@ColourId nvarchar(20),
@SizeId nvarchar(20),
@StatementType nvarchar(20) = '')as
begin
	set nocount on;
	set xact_abort on;

declare @Price int;
select @Price=SellingPrice  from ProductName where ProductCode=@ProductCode
if @StatementType='Create'
begin
INSERT INTO PurchaseChildTable
           (PurchaseInvoice,PurchaseId,ProductCode,Qty,PurchasePrice,SellingPrice,DiscountPrice,DiscountAmount,TotalAmount,ColourId,SizeId,BrandId)
     VALUES
           (@PurchaseInvoice,@PurchaseId,@ProductCode,@Qty,@PurchasePrice,@SellingPrice,@DiscountPrice,@DiscountAmount,@TotalAmount,@ColourId,@SizeId,@BrandId)

end

update PurchaseChildTable set SellingPrice=@Price where ProductCode=@ProductCode and PurchaseInvoice=@PurchaseInvoice

end


GO
/****** Object:  StoredProcedure [dbo].[PurchaseParent_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[PurchaseParent_sp](
@PurchaseDate datetime,
@PurchaseInvoice nvarchar(50),
@CompanyInvoice nvarchar(20),
@SupplyerId nvarchar(20),
@DelivaryBy nvarchar(30),
@ContactNo nvarchar(11),
@CreateDate datetime,
@CreateBy nvarchar(20),
@PcName nvarchar(20),
@StatementType nvarchar(20) = '')as
begin
	set nocount on;
	set xact_abort on;
if @StatementType='Create'
begin
INSERT INTO PurchaseParentTable
           (PurchaseDate,PurchaseInvoice,CompanyInvoice,SupplyerId,DelivaryBy,ContactNo,Status,CreateDate,CreateBy,PcName)
     VALUES
           (@PurchaseDate,@PurchaseInvoice,@CompanyInvoice,@SupplyerId,@DelivaryBy,@ContactNo,1,@CreateDate,@CreateBy,@PcName)

		   update SequencePopulate set StartWith=ISNULL(StartWith,0)+1 where Code='Invoice'

end

end
GO
/****** Object:  StoredProcedure [dbo].[PurchaseRequisitionTable_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[PurchaseRequisitionTable_sp](
@OrderInvoice nvarchar(20),
 @OrderDate datetime ,
 @CategoryId int ,
 @CompanyId int ,
 @Code nvarchar(30)  ,
 @Qty int ,
 @PurchasePrice int ,
 @DelivaryDate datetime ,
 @VatPercent nvarchar(20),
 @Comments nvarchar(100),
 @StatementType nvarchar(20)=null
)as
begin
if @StatementType='Create'
declare @Codee nvarchar(20);
select @Codee=ISNULL( sum(StartWith),0)+1  from SequencePopulateTable where Code='ItemInv'
INSERT INTO tbl_PurchaseRequgitionTable(OrderInvoice,OrderDate,CategoryId,CompanyId,Code,Qty,PurchasePrice,DelivaryDate,CreateDate,CreateBy,Status,Comments,Vat)
     VALUES(@OrderInvoice, @OrderDate,@CategoryId, @CompanyId, @Code, @Qty, @PurchasePrice, @DelivaryDate, SYSDATETIME(), 'Create','R', @Comments,@VatPercent )
	  update SequencePopulateTable set StartWith=@Codee where Code='ItemInv'

end
GO
/****** Object:  StoredProcedure [dbo].[SellsChild_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SellsChild_sp](
@SellsParId bigint,
@SellsInvoice nvarchar(50),
@SalesMonth nvarchar(6),
@ProductCode nvarchar(20),
@ColurId nvarchar(20),
@SizeId nvarchar(20),
@BrandId nvarchar(20),
@Qty int,
@SellingPrice int,
@VatPercent decimal(10,3),
@VatAmount int,
@DiscountPercent decimal(10,3),
@DiscountAmount int,
@TotalAmount int,
@StatementType nvarchar(20) = '')as
begin
	set nocount on;
	set xact_abort on;

declare @Price int;
select @Price=SellingPrice  from ProductName where ProductCode=@ProductCode
if @StatementType='Create'
begin
INSERT INTO SellesChild
           (SellsParId,SellsInvoice,SalesMonth,ProductCode,ColurId,SizeId,BrandId,Qty,SellingPrice,VatPercent,VatAmount,DiscountPercent,DiscountAmount, TotalAmount)
     VALUES
           (@SellsParId,@SellsInvoice,@SalesMonth,@ProductCode,@ColurId,@SizeId,@BrandId,@Qty,@SellingPrice,@VatPercent,@VatAmount,@DiscountPercent,@DiscountAmount, @TotalAmount)

end
end


GO
/****** Object:  StoredProcedure [dbo].[SellsParent_sp]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SellsParent_sp](
@SellsInvoice nvarchar(50),
@SellsDate datetime,
@SalesMonth nvarchar(6),
@CustomerName nvarchar(100),
@ContactNo nvarchar(24),
@TotalAmount int,
@PayAmount int,
@ReturnAmount int,
@DueAmount int,
@SellsBy nvarchar(30),
@PcName nvarchar(50),
@StatementType nvarchar(20) = '')as
begin
	set nocount on;
	set xact_abort on;
if @StatementType='Create'
begin
INSERT INTO SellsParent
           (SellsInvoice,SellsDate,SalesMonth,CustomerName,ContactNo,TotalAmount,PayAmount,ReturnAmount,DueAmount,SellsBy,PcName,CreateDateTime)
     VALUES
           (@SellsInvoice,@SellsDate,@SalesMonth,@CustomerName,@ContactNo,@TotalAmount,@PayAmount,@ReturnAmount,@DueAmount,@SellsBy,@PcName,CURRENT_TIMESTAMP)

		   update SequencePopulate set StartWith=ISNULL(StartWith,0)+1 where Code='SInvoice'
if(@DueAmount>0)
insert into CustomerArrear(DueDate,SellsInvoice,CustId,CustomerName,TotalAmount,DueAmount)
values(@SellsDate,@SellsInvoice,@CustomerName,@CustomerName,@TotalAmount,@DueAmount)
end

end
GO
/****** Object:  StoredProcedure [dbo].[SupplyerInformation]    Script Date: 1/14/2020 3:18:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SupplyerInformation](
@Name nvarchar(50),
@Address nvarchar(50),
@ContactPerson nvarchar(50),
@ContactPersonMobileNo nvarchar(11),
@Mobile nvarchar(11),
@Email nvarchar(30),
@logo varbinary(max),
@StatementType nvarchar(20) = '')as
begin
if @StatementType='Create'
begin
insert into SupplyerTable (SupplyerName ,Address ,ContactPerson ,ContactPersonMobileNo ,Mobile,Email,logo ,Status,CreateBy,CreateDate)
Values(@Name ,@Address ,@ContactPerson ,@ContactPersonMobileNo ,@Mobile,@Email,@logo ,'A','Create', SYSDATETIME())
end
if @StatementType='Update'
begin
update SupplyerTable set SupplyerName=@Name ,
Address =@Address,
ContactPerson=@ContactPerson ,
ContactPersonMobileNo=@ContactPersonMobileNo ,
Mobile=@Mobile,
Email=@Email,
logo=@logo ,
CreateBy='Create',
CreateDate=SYSDATETIME()
where SupplyerName=@Name
end
end
GO
