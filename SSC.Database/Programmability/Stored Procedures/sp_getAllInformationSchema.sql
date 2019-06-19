CREATE PROCEDURE sp_getAllInformationSchema
AS

SELECT 
    [Tabla] = i_s.TABLE_NAME, 
    [Columna] = i_s.COLUMN_NAME, 
	[Tipo de Dato] = i_s.DATA_TYPE,
	[Longitud] = CASE WHEN i_s.CHARACTER_MAXIMUM_LENGTH IS NULL THEN '' ELSE CONVERT(NVARCHAR, i_s.CHARACTER_MAXIMUM_LENGTH) END,
	[Permite Nulo] = CASE WHEN i_s.IS_NULLABLE = 'YES' THEN 'Sí' ELSE 'No' END,
    [Descripción] = s.value 
FROM 
    INFORMATION_SCHEMA.COLUMNS i_s 
LEFT OUTER JOIN 
    sys.extended_properties s 
ON 
    s.major_id = OBJECT_ID(i_s.TABLE_SCHEMA+'.'+i_s.TABLE_NAME) 
    AND s.minor_id = i_s.ORDINAL_POSITION 
    AND s.name = 'MS_Description' 
WHERE 
    OBJECTPROPERTY(OBJECT_ID(i_s.TABLE_SCHEMA+'.'+i_s.TABLE_NAME), 'IsMsShipped')=0 
    -- AND i_s.TABLE_NAME = 'table_name' 
ORDER BY 
    i_s.TABLE_NAME, i_s.ORDINAL_POSITION