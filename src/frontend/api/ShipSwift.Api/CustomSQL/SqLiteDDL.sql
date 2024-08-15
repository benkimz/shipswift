-- Drop tables if they exist
DROP TABLE IF EXISTS SHIPMENT;
DROP TABLE IF EXISTS SHIPPER;
DROP TABLE IF EXISTS SHIPMENT_RATE;
DROP TABLE IF EXISTS CARRIER;

-- Create CARRIER table
CREATE TABLE CARRIER (
    carrier_id INTEGER NOT NULL PRIMARY KEY,
    carrier_name TEXT NOT NULL,
    carrier_mode TEXT NOT NULL
);

-- Create SHIPMENT table
CREATE TABLE SHIPMENT (
    shipment_id INTEGER NOT NULL PRIMARY KEY,
    shipper_id INTEGER NOT NULL,
    shipment_description TEXT NOT NULL,
    shipment_weight REAL NOT NULL,
    shipment_rate_id INTEGER NOT NULL,
    carrier_id INTEGER NOT NULL,
    FOREIGN KEY (carrier_id) REFERENCES CARRIER (carrier_id),
    FOREIGN KEY (shipment_rate_id) REFERENCES SHIPMENT_RATE (shipment_rate_id),
    FOREIGN KEY (shipper_id) REFERENCES SHIPPER (shipper_id)
);

-- Create SHIPMENT_RATE table
CREATE TABLE SHIPMENT_RATE (
    shipment_rate_id INTEGER NOT NULL PRIMARY KEY,
    shipment_rate_class TEXT NOT NULL,
    shipment_rate_description TEXT NOT NULL
);

-- Create SHIPPER table
CREATE TABLE SHIPPER (
    shipper_id INTEGER NOT NULL PRIMARY KEY,
    shipper_name TEXT NOT NULL
);
