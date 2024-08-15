IF EXISTS(SELECT name FROM sysobjects WHERE name = 'Shipper_Shipment_Details' AND type = 'P')
   DROP PROCEDURE [dbo].[Shipper_Shipment_Details]
GO
-- =======================================================
-- Shipper_Shipment_Details Store Procedure
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      John Kishe
-- Create Date: 20/04/2024
-- Description: takes a parameter @shipper_id and returns a 
--              list of all Shipments in the system along with the details 
--              for both the Shipper and Carrier
-- =============================================
CREATE PROCEDURE [dbo].[Shipper_Shipment_Details]
(
    @shipperId int = 0
)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        [dbo].[SHIPPER].[shipper_id],
        [shipper_name],
        [shipment_id],
        [shipment_description],
        [shipment_weight],
        [shipment_rate_id],
        [carrier_id]
    FROM [dbo].[SHIPPER]
        INNER JOIN [dbo].[SHIPMENT]
        ON [dbo].[SHIPPER].[shipper_id] = [dbo].[SHIPMENT].[shipper_id]
    WHERE [dbo].[SHIPPER].[shipper_id] = @shipperId
END
GO