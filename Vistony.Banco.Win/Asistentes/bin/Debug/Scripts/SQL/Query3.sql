CREATE PROCEDURE SP_VIS_SEARCH_DEPOSIT(
IN UN VARCHAR(10),
IN SUP VARCHAR(5),
IN VEN VARCHAR(5),
IN FecIni VARCHAR(8),
IN FecFin VARCHAR(8),
IN OP VARCHAR(20),
IN STATUS VARCHAR(20))
AS
BEGIN

	SELECT
	'',
	T0."U_VIS_Deposit" "Dep�sito"
	,T0."U_VIS_AmountDeposit" "Monto"
	,T0."U_VIS_BankID" "Banco"
	,T0."U_VIS_Date" "Fecha"
	,CASE T0."U_VIS_Status" WHEN 'P' THEN 'Pendiente' WHEN 'A' THEN 'Anulado' WHEN 'C' THEN 'Conciliado' WHEN 'M' THEN 'Manual' END "Estado"
	,T0."U_VIS_SlpCode" "Vendedor"
	FROM "@VIST_DEPOSITO1" T0
	INNER JOIN OHEM T1 ON T0."U_VIS_SlpCode" = T1."salesPrson"
	WHERE "U_VIS_Date" BETWEEN :FecIni AND :FecFin
	AND (CASE WHEN IFNULL(:UN,'') = '' THEN '' ELSE T1."U_VIS_UofBusiness" END) = (CASE WHEN IFNULL(:UN,'') = '' THEN '' ELSE :UN END)
	AND (CASE WHEN IFNULL(:SUP,'') = '' THEN '' ELSE T1."U_VIS_SalesRepSup" END) = (CASE WHEN IFNULL(:SUP,'') = '' THEN '' ELSE :SUP END)
	AND (CASE WHEN IFNULL(:VEN,'') = '' THEN '' ELSE T0."U_VIS_SlpCode" END) = (CASE WHEN IFNULL(:VEN,'') = '' THEN '' ELSE :VEN END)
	AND (CASE WHEN IFNULL(:OP,'') = '' THEN '' ELSE T0."U_VIS_Deposit" END) = (CASE WHEN IFNULL(:OP,'') = '' THEN '' ELSE :OP END)
	AND (CASE WHEN IFNULL(:STATUS,'') = '' THEN '' ELSE T0."U_VIS_Status" END) = (CASE WHEN IFNULL(:STATUS,'') = '' THEN '' ELSE :STATUS END);
END;