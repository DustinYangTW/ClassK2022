--�z���
select *
from �ǥ�
where �ʧO = '�k'

select *
from ���u
where �~�� >= 50000

select *
from �ǥ�
where �ͤ� Is Null

--like(�ҽk�d��)
-- % (�N��0~n���N�r��)
-- _(���1�ӥ��N�r��)

select *
from �б�
where ��t like 'cs'

select * 
from �б�
where ��t like '%[cklj]%'


select * 
from �б�
where ��t like '%[A-DW-Z0-5]%'

--between .. and ..�B��
select * 
from ���u
where �~�� between 25000 and 55000 --�]�i�H�g�~��>=2500 and �~�� <=55000
--in
select *
from �ҵ{
where �ҵ{�s�� = 'CS101' or �ҵ{�s�� = 'CS213' or �ҵ{�s�� = 'CS349' or �ҵ{�s�� = 'CS999'

select *
from �ҵ{
where �ҵ{�s�� in( 'CS101' , 'CS213' , 'CS349','CS999')

--�E�X���
--count()
select count(*) as �ǥ��`��
from �ǥ�