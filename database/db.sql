-- T?o b?ng
CREATE TABLE buyer (
    buyer_id NUMBER PRIMARY KEY,
    buyer_name VARCHAR2(50),
    buyer_paymentmethod VARCHAR2(200)
);

-- Thêm d? li?u
INSERT INTO buyer VALUES (1, 'John Doe', 'Cash');
INSERT INTO buyer VALUES (2, 'Jane Doe', 'ATM');

-- Hi?n th? d? li?u
SELECT * FROM buyer;

-- T?o th? t?c hi?n th? toàn b? buyer
create or replace PROCEDURE GetAllDataInTable (
    p_result OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_result FOR
    SELECT * FROM buyer; -- Replace with your actual table name
END GetAllDataInTable;
/

-- G?i th? t?c hi?n th? thông tin buyer
EXEC GetAllDataInTable;

-- T?o th? t?c thêm buyer
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

-- G?i th? t?c thêm nhân viên
EXEC add_buyer(3, 'Bob Smith', 'ATM');

-- Hi?n th? d? li?u sau khi thêm
SELECT * FROM buyer;

-- T?o th? t?c s?a thông tin nhân viên
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

-- G?i th? t?c s?a thông tin nhân viên
EXEC update_buyer(3, 'Hunggg', 'Cash');

-- Hi?n th? d? li?u sau khi s?a
SELECT * FROM buyer;

-- T?o th? t?c xóa nhân viên
CREATE OR REPLACE PROCEDURE delete_buyer(
    p_buyer_id NUMBER
) AS
BEGIN
    DELETE FROM buyer WHERE buyer_id = p_buyer_id;
    COMMIT;
END delete_buyer;
/

-- G?i th? t?c xóa nhân viên
EXEC delete_buyer(2);

-- Hi?n th? d? li?u sau khi xóa
SELECT * FROM buyer;