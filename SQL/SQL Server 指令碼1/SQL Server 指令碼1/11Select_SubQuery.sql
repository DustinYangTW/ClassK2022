select *
from �Z��
where �Ǹ�='S003'
select *
from �ǥ�
where �m�W='�i�L��'

--�쥻�n�W����
--�᭱�i�H�ΤU����
select *
from �Z��
where �Ǹ�=(
select �Ǹ�
from �ǥ�
where �m�W='�i�L��'
)

select *
from ���u
where �~�� > (
select AVG(�~��) 
from ���u
)

select a.�����Ҧr��,a.�m�W,a.�~��
from ���u as a
left join ���u as s on a.�����Ҧr�� != s.�����Ҧr��  --�Q�Τ�����Ӱ����
group by a.�����Ҧr��,a.�m�W,a.�~��
having a.�~�� > AVG(s.�~��)

select e.�����Ҧr��,e.�m�W,e.�~��
from ���u as e ,���u as s
group by e.�����Ҧr��,e.�m�W,e.�~��
having e.�~�� > AVG(s.�~��)

select *
from ���u 
where �����Ҧr�� in (
select �����Ҧr��
from �б�
where ¾�� = '�б�'
)

select *
from ���u 
where �����Ҧr�� = (
select �����Ҧr��
from �б�
where ¾�� = '�б�'
)

select *
from �б�
select *
from ���u

select * from ���u
where exists (
select * 
from �б� 
where ���u.�����Ҧr�� = �б�.�����Ҧr�� --�L�o��
)

--exists
select * from �ǥ�
where exists (select * from �Z��
where �ҵ{�s��='CS222' and �ǥ�.�Ǹ�=�Z��.�Ǹ�)

--in
select * from �ǥ�
where �Ǹ� in (select �Ǹ� from �Z��
where �ҵ{�s��='CS222')

select * 
from �ҵ{
select * 
from �Z��
--���ǽҵ{�b221-S�ЫǤW��
--in
select *
from �ҵ{
where �ҵ{�s�� in(
select �ҵ{�s��
from �Z��
where �Ы� = '221-S'
)

--exists
select *
from �ҵ{
where exists(
select *
from �Z��
where �Ы� = '221-S' and �ҵ{.�ҵ{�s�� = �Z��.�ҵ{�s��
)

select * 
from �ҵ{
select * 
from �ǥ�
select * 
from �Z��
select * 
from �ҵ{
--in
select * from �ҵ{
where �ҵ{�s�� in(
select �ҵ{�s�� from �Z�� where �Ǹ� = (
select �Ǹ� from �ǥ� where �m�W = '�P�N��')
)
--exists
select * from �ҵ{ as co
where exists
(select * from �Z�� as c
where exists(
select * from �ǥ� as s where �m�W='�P�N��' and c.�Ǹ�=s.�Ǹ� and co.�ҵ{�s��=c.�ҵ{�s��))

--�d�߾ǥͩP�N���S���諸�ҵ{���
--�l�d��

--in
select * from �ҵ{
where �ҵ{�s�� not in(
select �ҵ{�s�� from �Z�� where �Ǹ� = (
select �Ǹ� from �ǥ� where �m�W = '�P�N��')
)
--exists
select * from �ҵ{ as co
where not exists
(select * from �Z�� as c
where exists(
select * from �ǥ� as s where �m�W='�P�N��' and c.�Ǹ� =s.�Ǹ� and co.�ҵ{�s��=c.�ҵ{�s��))


select * from ���u
where �~�� >= all( --�Ҧ����󳣭n����
select �~�� from ���u
where ���� ='�x�_')

select * from ���u
where �~�� >= some( --�����󳣭n�����N�n
select �~�� from ���u
where ���� ='�x�_')

select * from ���u
where �~�� >= any( --�����󳣭n�����N�n
select �~�� from ���u
where ���� ='�x�_')