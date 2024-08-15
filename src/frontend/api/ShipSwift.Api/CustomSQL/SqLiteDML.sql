-- Insert data into SHIPPER
INSERT INTO SHIPPER (shipper_id, shipper_name) VALUES (1, 'Blossom Manufacturing');
INSERT INTO SHIPPER (shipper_id, shipper_name) VALUES (2, 'Sporting Partners');
INSERT INTO SHIPPER (shipper_id, shipper_name) VALUES (3, 'Associates and Company');

-- Insert data into CARRIER
INSERT INTO CARRIER (carrier_id, carrier_name, carrier_mode) VALUES (1, 'Short Line RailRoad', 'RAIL');
INSERT INTO CARRIER (carrier_id, carrier_name, carrier_mode) VALUES (2, 'Planet Express', 'TRUCK');
INSERT INTO CARRIER (carrier_id, carrier_name, carrier_mode) VALUES (3, 'Greene Transport', 'TRUCK');
INSERT INTO CARRIER (carrier_id, carrier_name, carrier_mode) VALUES (4, 'Big Boats R Us', 'OCEAN');
INSERT INTO CARRIER (carrier_id, carrier_name, carrier_mode) VALUES (5, 'Speedy Delivery', 'TRUCK');

-- Insert data into SHIPMENT_RATE
INSERT INTO SHIPMENT_RATE (shipment_rate_id, shipment_rate_class, shipment_rate_description) VALUES (1, 'FULL', 'Full Price');
INSERT INTO SHIPMENT_RATE (shipment_rate_id, shipment_rate_class, shipment_rate_description) VALUES (2, '50OFF', '50% Discount');
INSERT INTO SHIPMENT_RATE (shipment_rate_id, shipment_rate_class, shipment_rate_description) VALUES (3, '10OFF', '10% Discount');

-- Insert data into SHIPMENT
INSERT INTO SHIPMENT (shipment_id, shipper_id, shipment_description, shipment_weight, shipment_rate_id, carrier_id)
VALUES (1, 1, 'Machine Parts', 130.54, 1, 1);
INSERT INTO SHIPMENT (shipment_id, shipper_id, shipment_description, shipment_weight, shipment_rate_id, carrier_id)
VALUES (2, 3, 'Office Supplies', 10.05, 2, 3);
INSERT INTO SHIPMENT (shipment_id, shipper_id, shipment_description, shipment_weight, shipment_rate_id, carrier_id)
VALUES (3, 2, 'Basketball Hoops', 13.4, 2, 4);
INSERT INTO SHIPMENT (shipment_id, shipper_id, shipment_description, shipment_weight, shipment_rate_id, carrier_id)
VALUES (4, 2, 'Football Helmets', 25.98, 2, 2);
INSERT INTO SHIPMENT (shipment_id, shipper_id, shipment_description, shipment_weight, shipment_rate_id, carrier_id)
VALUES (5, 1, 'Conveyor System', 250.10, 1, 5);
INSERT INTO SHIPMENT (shipment_id, shipper_id, shipment_description, shipment_weight, shipment_rate_id, carrier_id)
VALUES (6, 3, 'Automobile Engines', 65.25, 3, 2);
