-- T?o b?ng
CREATE TABLE buyer (
    buyer_id NUMBER PRIMARY KEY,
    buyer_name VARCHAR2(50),
    buyer_paymentmethod VARCHAR2(200)
);

-- Th�m d? li?u
INSERT INTO buyer VALUES (1, 'John Doe', 'Cash');
INSERT INTO buyer VALUES (2, 'Jane Doe', 'ATM');

-- Hi?n th? d? li?u
SELECT * FROM buyer;

-- T?o th? t?c hi?n th? to�n b? buyer
create or replace PROCEDURE GetAllDataInTable (
    p_result OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_result FOR
    SELECT * FROM buyer; -- Replace with your actual table name
END GetAllDataInTable;
/

-- G?i th? t?c hi?n th? th�ng tin buyer
EXEC GetAllDataInTable;

-- T?o th? t?c th�m buyer
CREATE OR REPLACE PROCEDURE add_buyer(
    p_buyer_id NUMBER,
    p_buyer_name VARCHAR2,
    p_buyer_paymentmethod VARCHAR2
) AS
BEGIN
    INSERT INTO buyer VALUES (p_buyer_id, p_buyer_name, p_buyer_paymentmethod);
    COMMIT;
END add_buyer;
/

-- G?i th? t?c th�m nh�n vi�n
EXEC add_buyer(3, 'Bob Smith', 'ATM');

-- Hi?n th? d? li?u sau khi th�m
SELECT * FROM buyer;

-- T?o th? t?c s?a th�ng tin nh�n vi�n
CREATE OR REPLACE PROCEDURE update_buyer(
    p_buyer_id NUMBER,
    p_new_buyer_name VARCHAR2,
    p_new_paymentmethod VARCHAR2
) AS
BEGIN
    UPDATE buyer SET buyer_name = p_new_buyer_name WHERE buyer_id = p_buyer_id;
    UPDATE buyer SET buyer_paymentmethod = p_new_paymentmethod WHERE buyer_id = p_buyer_id;
    COMMIT;
END update_buyer;
/

-- G?i th? t?c s?a th�ng tin nh�n vi�n
EXEC update_buyer(3, 'Hunggg', 'Cash');

-- Hi?n th? d? li?u sau khi s?a
SELECT * FROM buyer;

-- T?o th? t?c x�a nh�n vi�n
CREATE OR REPLACE PROCEDURE delete_buyer(
    p_buyer_id NUMBER
) AS
BEGIN
    DELETE FROM buyer WHERE buyer_id = p_buyer_id;
    COMMIT;
END delete_buyer;
/

-- G?i th? t?c x�a nh�n vi�n
EXEC delete_buyer(2);

-- Hi?n th? d? li?u sau khi x�a
SELECT * FROM buyer;