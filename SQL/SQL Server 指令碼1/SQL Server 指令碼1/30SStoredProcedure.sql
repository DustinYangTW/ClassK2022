create procedure getOrderDetails
as
begin
	SELECT          �б�.�б½s��, �Z��.�ҵ{�s��, ���u.�~��
	FROM              �б� INNER JOIN
                            ���u ON �б�.�����Ҧr�� = ���u.�����Ҧr�� INNER JOIN
                            �Z�� ON �б�.�б½s�� = �Z��.�б½s�� INNER JOIN
                            �ǥ� ON �Z��.�Ǹ� = �ǥ�.�Ǹ� CROSS JOIN
                            �Ȥ�~�Z
end
----------------------------------------
--����
exec getOrderDetails