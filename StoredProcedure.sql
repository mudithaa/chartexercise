/*    ==Scripting Parameters==

    Source Database Engine Edition : Microsoft Azure SQL Database Edition
    Source Database Engine Type : Microsoft Azure SQL Database

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [DevTest]
GO
/****** Object:  StoredProcedure [dbo].[ssp_GetSummaryByProduct]    Script Date: 27/11/2018 8:03:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:      Some Random Person
-- Create date: 7/7/2017
-- Description: Return Daily Sales By Product over a given date range
-- Parameters:
--   @productid - ProductID to filter output 
--   @startdate - Optional Start Date filter 
--   @enddate   - Optional End Date filter 
-- Returns:    Summary data Recordset 
-- =============================================
ALTER PROCEDURE [dbo].[ssp_GetSummaryByProduct](@productid int,@startdate date='2017-01-01',@enddate date='2019-01-01')
AS 
SET NOCOUNT ON 

--SELECT ProductID,
--       COUNT(DISTINCT TransactionID) TotalTransactions,
--       SUM(Quantity) TotalSalesValue,
--	   SUM(SalesValue) TotalQuantity,
--	   CONVERT(date,SalesDate) SalesDate
--FROM [dbo].[Transactions]
--WHERE CONVERT(date,SalesDate)>=@startdate AND CONVERT(date,SalesDate)<=@enddate 
--	AND StoreID IS NOT NULL AND ProductID=@productid
--GROUP BY ProductID,CONVERT(date,SalesDate)
--ORDER BY ProductID,5

SELECT ProductID,
       COUNT(DISTINCT TransactionID) TotalTransactions,
       SUM(SalesValue) TotalSalesValue,
	   SUM(Quantity) TotalQuantity,
	   CONVERT(date,SalesDate) SalesDate
FROM [dbo].[Transactions]
WHERE SalesDate >= @startdate AND SalesDate <=@enddate 
	AND StoreID IS NOT NULL -- why i'm not sure
	AND ProductID=@productid
GROUP BY ProductId, CONVERT(date,SalesDate)
ORDER BY 5






