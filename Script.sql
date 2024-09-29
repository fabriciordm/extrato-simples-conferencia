INSERT INTO Transacoes(Data, TipoTransacao, Valor)
VALUES
    (DATEADD(DAY, -5, GETDATE()), 'Depósito', 1000.00), -- 5 dias atrás
    (DATEADD(DAY, -5, GETDATE()), 'Saque', -200.00),    -- 5 dias atrás
    (DATEADD(DAY, -10, GETDATE()), 'Transferência', -150.00), -- 10 dias atrás
    (DATEADD(DAY, -10, GETDATE()), 'Depósito', 500.00),  -- 10 dias atrás
    (DATEADD(DAY, -15, GETDATE()), 'Pagamento', -350.00), -- 15 dias atrás
    (DATEADD(DAY, -15, GETDATE()), 'Depósito', 700.00),   -- 15 dias atrás
    (DATEADD(DAY, -20, GETDATE()), 'Saque', -100.00),     -- 20 dias atrás
    (DATEADD(DAY, -20, GETDATE()), 'Depósito', 300.00);   -- 20 dias atrás